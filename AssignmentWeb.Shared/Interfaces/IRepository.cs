using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentWeb.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task Get(string slug);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Remove(string slug);
    }
}
