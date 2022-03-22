using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookESale.DataAccess.Repository.IRepository
{
    //this is generic repository where T is the class
    public interface IRepository<T> where T : class
    {
        //T - Category
        //here func is the function filter is the name of func
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);


    }
}
