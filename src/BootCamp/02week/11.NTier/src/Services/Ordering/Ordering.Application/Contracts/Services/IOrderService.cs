using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Services
{
    public interface IOrderService
    {
        Task<List<OrdersVm>> GetOrdersByUserName(string userName);
    }
}
