using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context;
        public EFOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        IQueryable<Order> IOrderRepository.Orders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SaveOrders(Order order)
        {
            context.AttachRange(order.Lines.Select(x=>x.Book));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
                
            }
            context.SaveChanges();
        }
    }
}
