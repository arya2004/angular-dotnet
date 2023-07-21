using Core.Interfaces;
using Core.Models;
using Core.Models.OrderAggregate;
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
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IGenericRepository<Product> _pridRepo;
        private readonly IBasketRepository _basketRepository;

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<DeliveryMethod> dmRepo, IGenericRepository<Product> pridRepo, IBasketRepository basketRepository)
        {
            _orderRepo = orderRepo;
            _dmRepo = dmRepo;
            _pridRepo = pridRepo;
            _basketRepository = basketRepository;
        }
        public async Task<Order> CreateOrderAsync(string buyer, int deliveryMethodId, string basketId, Address shippingAddress)
        {   //get basket from repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
            //get items from  product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _pridRepo.GetByIdAsync(item.Id);
                var itemOrders = new ProductItemOrdered(productItem.ProductId, productItem.Name,productItem.PictureUrl );
                var orderItem = new OrderItem(itemOrders.ProductItemId, itemOrders.ProductName, itemOrders.PictureUrl, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            //get deliery method
            var deliveryMethod = await _dmRepo.GetByIdAsync(deliveryMethodId);
            //calculate subtotal
            var subTotal = items.Sum(item => item.Price * item.Quantity);
            //create order
            var order = new Order(buyer, shippingAddress, deliveryMethod,items, subTotal,"temp");

            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethod()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int orderId, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string BuyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
