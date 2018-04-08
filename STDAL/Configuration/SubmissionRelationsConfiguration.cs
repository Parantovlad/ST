using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STDAL.Configuration
{
    public class SubmissionRelationsConfiguration : IEntityTypeConfiguration<SubmissionRelations>
    {
        public void Configure(EntityTypeBuilder<SubmissionRelations> builder)
        {
            builder.HasKey(e => new { e.ChiefId, e.SubordinateId });
            builder.HasOne(d => d.Chief)
                .WithMany(p => p.SubmissionRelationsChief)
                .HasForeignKey(d => d.ChiefId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.Subordinate)
                .WithMany(p => p.SubmissionRelationsSubordinate)
                .HasForeignKey(d => d.SubordinateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
