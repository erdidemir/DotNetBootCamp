using DapperTodoDemo.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTodoDemo.Application.Services
{
    public interface ITodoItemAppService
    {
        Task<List<TodoItemDto>> GetTodosAsync();

        Task<TodoItemDto> GetAsync(Guid id);

        Task CreateAsync(CreateUpdateTodoItemDto todoItem);

        Task UpdateAsync(Guid id, CreateUpdateTodoItemDto todoItem);

        Task DeleteAsync(Guid id);
    }
}
