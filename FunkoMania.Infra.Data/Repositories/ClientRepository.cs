﻿using FunkoMania.Domain.Entities;
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
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(FunkoManiaDbContext context) : base(context)
        {

        }

        public Client Add(Client entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<Client> AddAsync(Client entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Client GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var client = context.FirstOrDefault(c => c.Id == id);
            return client;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var client = await context.FirstOrDefaultAsync(c => c.Id == id);
            return client;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Client, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public async Task<IEnumerable<Client>> SearchAsync(Expression<Func<Client, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return await context.Where(predicate).ToListAsync();
        }

        public Client Update(Client entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
