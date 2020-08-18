using Data;
using Data.Entities;
using Infrastructure.Dto;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class TodoService : BaseService<Todo>, ITodoService
    {
        public TodoService(TodoContext context) : base(context)
        {
        }

        public IQueryable<Todo> GetIncomingTodo(IncomingType incomingType)
        {
            try
            {
                switch (incomingType)
                {
                    case IncomingType.Today:
                        return from i in GetAll()
                                 where i.ExpiredAt <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                 select i;
                    case IncomingType.NextDay:
                        return from i in GetAll()
                               where i.ExpiredAt <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1)
                                 select i;
                    case IncomingType.CurrentWeek:
                        return from i in GetAll()
                               where i.ExpiredAt <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 7)
                                 select i;
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Todo MarkDone(int id)
        {
            try
            {
                var existing = GetById(id);

                existing.IsDone = true;

                Update(id, existing);

                return existing;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Todo SetTodoPercentComplete(SetTodoPercentCompleteDto setTodoPercentCompleteDto)
        {
            try
            {
                var existing = GetById(setTodoPercentCompleteDto.Id);

                existing.PercentComplete = setTodoPercentCompleteDto.PercentComplete;

                Update(setTodoPercentCompleteDto.Id, existing);

                return existing;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
