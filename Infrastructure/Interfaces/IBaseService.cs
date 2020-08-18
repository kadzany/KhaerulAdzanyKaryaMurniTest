using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        int Insert(T entity);

        T Update(int id, T entity);

        T Delete(int id);

        T GetById(int id);

        IQueryable<T> GetAll();
    }
}
