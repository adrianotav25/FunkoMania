using FunkoMania.Domain.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.FunkoManiaDbContext _context;

        public UnitOfWork(Context.FunkoManiaDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
