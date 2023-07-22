using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            //AddInclude(o => o.ShortName);
            //AddInclude(o => o.DeliveryTime);
            //AddInclude(o => o.Description);
            //AddInclude(o => o.Price);
            AddOrderByDescending(o => o.OrderDate);

        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email) : base(o => o.OrderId == id && o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            //AddInclude(o => o.ShortName);
            //AddInclude(o => o.DeliveryTime);
            //AddInclude(o => o.Description);
            //AddInclude(o => o.Price);
        }
    }
}
