using AutoMapper;
using DapperTodoDemo.Application.Models;
using DapperTodoDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTodoDemo.Application.Mapper
{
    public class TodoItemAutoMapperProfile : Profile
    {
        public TodoItemAutoMapperProfile()
        {
            CreateMap<TodoItem, TodoItemDto>();

            CreateMap<CreateUpdateTodoItemDto, TodoItem>();
        }
    }
}
