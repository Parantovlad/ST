using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STDAL.Configuration
{
    public class EmployeeGroupConfiguration : IEntityTypeConfiguration<EmployeeGroup>
    {
        public void Configure(EntityTypeBuilder<EmployeeGroup> builder)
        {
            builder.HasIndex(e => e.Id).IsUnique();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
