﻿using FunkoMania.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem GetById(Guid id);
        Task<OrderItem> GetByIdAsync(Guid id);
        IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate);
        Task<IEnumerable<OrderItem>> SearchAsync(Expression<Func<OrderItem, bool>> predicate);
        IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate,
            int pageNumber,
            int pageSize);
        OrderItem Add(OrderItem entity);
        Task<OrderItem> AddAsync(OrderItem entity);
        OrderItem Update(OrderItem entity);
        void Remove(Guid id);
        void Remove(Expression<Func<OrderItem, bool>> expression);
    }
}
