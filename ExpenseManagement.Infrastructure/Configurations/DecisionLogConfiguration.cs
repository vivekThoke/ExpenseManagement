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
    public class DecisionLogConfiguration : IEntityTypeConfiguration<DecisionLog>
    {
        public void Configure(EntityTypeBuilder<DecisionLog> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.PolicyScore).IsRequired();
            builder.Property(b => b.PatternScore).IsRequired();
            builder.Property(b => b.AiScore).IsRequired();
            builder.Property(b => b.FinalRiskScore).IsRequired();

            builder.Property(b => b.DecidedAt).IsRequired();
        }
    }
}
