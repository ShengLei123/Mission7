using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; set; }
        void SaveOrders(Order order);
    }
}
