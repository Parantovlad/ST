using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STDAL.Configuration
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.Name).IsRequired();
            builder.HasOne(d => d.EmployeeGroup)
                .WithMany(p => p.Staff)
                .HasForeignKey(d => d.EmployeeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
