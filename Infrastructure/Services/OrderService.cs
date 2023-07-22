using Core.Interfaces;
using Core.Models;
using Core.Models.OrderAggregate;
using Core.Specifications;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;

        public OrderService( IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
           
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> CreateOrderAsync(string buyer, int deliveryMethodId, string basketId, Address shippingAddress)
        {   //get basket from repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
            //get items from  product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrders = new ProductItemOrdered(productItem.ProductId, productItem.Name,productItem.PictureUrl );
                var orderItem = new OrderItem(itemOrders.ProductItemId, itemOrders.ProductName, itemOrders.PictureUrl, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            //get deliery method
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            //calculate subtotal
            var subTotal = items.Sum(item => item.Price * item.Quantity);
            //create order
            var order = new Order(buyer, shippingAddress, deliveryMethod,items, subTotal,"temp");

            _unitOfWork.Repository<Order>().Add(order);
            //save to db
            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                return null;
            }

            //delete basket

            await _basketRepository.DeleteBasketAsync(basketId);
            //return order

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethod()
        {   //can break
            return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(orderId, buyerEmail);
            return await _unitOfWork.Repository<Order>().GetENtityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUserAsync(string BuyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(BuyerEmail);
            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}
