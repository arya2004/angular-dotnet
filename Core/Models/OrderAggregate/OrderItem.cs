using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.OrderAggregate
{
    public class OrderItem 
    {
        public OrderItem()
        {
        }

        public OrderItem(int orderItemId, int productItemId, string productName, string pictureUrl, decimal price, int quantity)
        {
            OrderItemId = orderItemId;
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
            Quantity = quantity;
        }

        public int OrderItemId { get; set; }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
