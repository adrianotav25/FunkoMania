﻿using FunkoMania.Domain.Entities;
using FunkoMania.Domain.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableNames.TbProduct);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(240);
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.Price).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(200);
            builder.Property(p => p.DateRegister).HasDefaultValue(DateTime.Now);

            builder.Ignore(p => p.Deleted);
        }
    }
}
