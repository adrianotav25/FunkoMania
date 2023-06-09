﻿

using FunkoMania.Domain.Entities;
using FunkoMania.Domain.Interfaces;
using FunkoMania.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FunkoMania.Infra.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(FunkoManiaDbContext context) : base(context)
        {

        }

        public Address Add(Address entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<Address> AddAsync(Address entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Address GetbyId(Guid id)
        {
            var context = DbSet.AsQueryable();
            var address = context.FirstOrDefault(x => x.Id == id);
            return address;
        }

        public async Task<Address> GetbyIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var address = await context.FirstOrDefaultAsync(x => x.Id == id);
            return address;
        }

        public void Remove(Guid id)
        {
            var obj = GetbyId(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Address, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public async Task<IEnumerable<Address>> SearchAsync(Expression<Func<Address, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return await context.Where(predicate).ToListAsync();
        }

        public Address Update(Address entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
