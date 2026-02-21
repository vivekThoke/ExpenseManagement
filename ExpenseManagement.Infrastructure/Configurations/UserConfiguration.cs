using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManagement.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);

            builder.Property(p => p.Email).IsRequired().HasMaxLength(200);

            builder.HasIndex(i => i.Email).IsUnique();

            builder.Property(p => p.Role).IsRequired();

            builder.Property(p => p.ManagerId).IsRequired(false);
        }
    }
}
