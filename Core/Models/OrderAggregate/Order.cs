using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.OrderAggregate
{
    public class Order
    {
        public Order()
        {
            
        }

        public Order(int orderId, string buyerEmail, DateTime orderDate, string firstName, string lastName, string street, string city, string state, string postalCode, string shortName, string deliveryTime, string description, string price, IReadOnlyList<OrderItem> orderItems, decimal subTotal, string status, string paymentIntentId)
        {
            OrderId = orderId;
            BuyerEmail = buyerEmail;
            OrderDate = orderDate;
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            ShortName = shortName;
            DeliveryTime = deliveryTime;
            Description = description;
            Price = price;
            OrderItems = orderItems;
            SubTotal = subTotal;
            Status = status;
            PaymentIntentId = paymentIntentId;
        }

        public int OrderId { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; } = "Pending";
        public string PaymentIntentId { get; set; }

        public string GetTotal()
        {
            return SubTotal + Price;
        }

    }
}
