using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        long Count();
        long Count(Expression<Func<T, bool>> predicate);
    }
}
