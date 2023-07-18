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

        public OrderItem(int orderItemId, ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            OrderItemId = orderItemId;
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }

        public int OrderItemId { get; set; }
        public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
