using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        List<T> List(Expression<Func<T, bool>> filter); // şartlı listeleme

        void Update(T item);

        void Delete(T item);

        void Insert(T item);

        T Get(Expression<Func<T, bool>> filter);
    }
}
