using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTodoDemo.Domain.Entities
{
    public enum TodoStatus : byte
    {
        Opened = 0,
        Closed = 1
    }
}
