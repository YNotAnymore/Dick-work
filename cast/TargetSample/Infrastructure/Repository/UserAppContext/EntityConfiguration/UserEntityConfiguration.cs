using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserDomain.Model;

namespace UserAppContext.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(p => p.Id).HasName(nameof(User.Id));

            builder.Property(p => p.Name).HasColumnName(nameof(User.Name));
            builder.Property(p => p.Password).HasColumnName(nameof(User.Password));

        }
    }
}
