using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Order( string buyerEmail, Address address , DeliveryMethod deliveryMethod, IReadOnlyList<OrderItem> orderItems, decimal subTotal,  string paymentIntentId)
        {
            
            BuyerEmail = buyerEmail;
           

            FirstName = address.FirstName;
            LastName = address.LastName;
            Street = address.Street;
            City = address.City;
            State = address.State;
            PostalCode = address.PostalCode;

            ShortName = deliveryMethod.ShortName;
            DeliveryTime = deliveryMethod.DeliveryTime;
            Description = deliveryMethod.Description;
            Price = deliveryMethod.Price;


            OrderItems = orderItems;
            SubTotal = subTotal;
            PaymentIntentId = paymentIntentId;
        }
        [Key]
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
