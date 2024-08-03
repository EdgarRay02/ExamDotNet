using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlsetLibrary.Configurations
{
    internal class ResearcherConfiguration : IEntityTypeConfiguration<Researcher>
    {
        public void Configure(EntityTypeBuilder<Researcher> builder)
        {
            builder.ToTable("Researcher");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdResearcher");

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.LastName)
               .IsRequired()
               .HasMaxLength(100);

            builder.HasMany(i => i.Magazines)
                .WithOne(s => s.Researcher)
                .HasForeignKey(s => s.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.Subscriptions)
                .WithOne(s => s.Researcher)
                .HasForeignKey(s => s.IdResearcher)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
