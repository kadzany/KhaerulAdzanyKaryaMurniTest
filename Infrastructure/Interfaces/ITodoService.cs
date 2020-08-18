using Data.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Contains all basic operations for todo entity
    /// All the basic operations covered by the IBaseService definition
    /// </summary>
    public interface ITodoService : IBaseService<Todo>
    {
        Todo MarkDone(int id);
        Todo SetTodoPercentComplete(SetTodoPercentCompleteDto setTodoPercentCompleteDto);
        IQueryable<Todo> GetIncomingTodo(IncomingType incomingType);
    }
}
