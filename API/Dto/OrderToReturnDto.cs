

using Core.Models.OrderAggregate;

namespace API.Dto
{
    public class OrderToReturnDto
    {
        public int OrderId { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } 
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
        public string  Total { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; } 
        


    }
}
