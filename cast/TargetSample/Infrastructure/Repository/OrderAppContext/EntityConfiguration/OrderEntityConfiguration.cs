using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using OrderDomain.Model;
using UserDomain.Model;

namespace OrderAppContext.EntityConfiguration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            var datetime2Converter = new ValueConverter<DateTime, DateTimeOffset>(x => x, x => x.LocalDateTime);

            builder.ToTable(nameof(Order));

            builder.HasKey(p => p.Id).HasName(nameof(Order.Id));

            builder.Property(p => p.ActualAmount).HasColumnName(nameof(Order.ActualAmount));
            builder.Property(p => p.Amount).HasColumnName(nameof(Order.Amount));
            builder.Property(p => p.CreateTime).HasColumnName(nameof(Order.CreateTime)).HasConversion(datetime2Converter);
            builder.Property(p => p.Intro).HasColumnName(nameof(Order.Intro));
            builder.Property(p => p.UserId).HasColumnName(nameof(Order.UserId));

        }
    }
}
