using DapperTodoDemo.Application.Models;
using System.Collections.Generic;

namespace DapperTodoDemo.Web.Models
{
    public class TodoViewModel
    {
        public List<TodoItemDto> TodoItems { get; set; }
    }
}
