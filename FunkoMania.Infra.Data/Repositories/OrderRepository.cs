using FunkoMania.Domain.Entities;
using FunkoMania.Domain.Interfaces;
using FunkoMania.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(FunkoManiaDbContext context) : base(context)
        {

        }

        public Order Add(Order entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<Order> AddAsync(Order entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Order GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var Order = context.FirstOrDefault(c => c.Id == id);
            return Order;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var Order = await context.FirstOrDefaultAsync(c => c.Id == id);
            return Order;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Order, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Order> Search(Expression<Func<Order, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public async Task<IEnumerable<Order>> SearchAsync(Expression<Func<Order, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return await context.Where(predicate).ToListAsync();
        }

        public Order Update(Order entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
