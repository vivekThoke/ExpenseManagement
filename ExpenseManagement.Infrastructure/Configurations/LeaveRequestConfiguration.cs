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
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Reason).HasMaxLength(1000);

            builder.Property(l => l.Status).IsRequired();

            builder.Property(l => l.CreatedAt).IsRequired();

            builder.Property(l => l.AiSummary).HasMaxLength(2000).IsRequired();

            builder.Property(l => l.RiskScore).IsRequired(false);

            builder.HasOne<User>().WithMany().HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
