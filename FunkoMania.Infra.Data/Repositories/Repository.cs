using FunkoMania.Core.DomainObjects;
using FunkoMania.Domain.Interfaces;
using FunkoMania.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FunkoMania.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly FunkoManiaDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(FunkoManiaDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        protected IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }

        public long Count()
        {
            return DbSet.LongCount();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            var result = DbSet.LongCount(predicate);
            return result;
        }


    }
}
