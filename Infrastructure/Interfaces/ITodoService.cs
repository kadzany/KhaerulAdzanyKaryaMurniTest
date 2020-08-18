using Data.Entities;
using Infrastructure.Dto;
using System.Linq;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Contains all basic operations for todo entity
    /// All the basic operations covered by the IBaseService definition
    /// </summary>
    public interface ITodoService : IBaseService<Todo>
    {
        /// <summary>
        /// marking a todo to be done
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Todo MarkDone(int id);
        /// <summary>
        /// set a percentage value to a todo
        /// </summary>
        /// <param name="setTodoPercentCompleteDto"></param>
        /// <returns></returns>
        Todo SetTodoPercentComplete(SetTodoPercentCompleteDto setTodoPercentCompleteDto);
        /// <summary>
        /// gets incoming todos based on the type
        /// </summary>
        /// <param name="incomingType"></param>
        /// <returns></returns>
        IQueryable<Todo> GetIncomingTodo(IncomingType incomingType);
    }
}
