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

        public Task<Address> AddAsync(Address entity)
        {
            
        }

        public Address GetbyId(Guid id)
        {
            var context = DbSet.AsQueryable();
            var address = context.FirstOrDefault(x => x.Id == id);
            return address;
        }

        public Task<Address> GetbyIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Expression<Func<Address, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> SearchAsync(Expression<Func<Address, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Address Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
