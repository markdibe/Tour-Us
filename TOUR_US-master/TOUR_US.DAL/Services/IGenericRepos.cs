using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.DAL.Services
{
    public interface IGenericRepos<T>
    {
        IQueryable<T> GetAll();

        Task<T> GetById(int Id);

        Task<T> GetById(string id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(int id);
    }
}
