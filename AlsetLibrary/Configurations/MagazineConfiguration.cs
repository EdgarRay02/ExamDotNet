using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlsetLibrary.Configurations
{
    internal class MagazineConfiguration : IEntityTypeConfiguration<Magazine>
    {
        public void Configure(EntityTypeBuilder<Magazine> builder)
        {
            builder.ToTable("Magazine");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdMagazine");

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.FileUrl)
                .IsRequired();

            builder.HasOne(e => e.Researcher)
                .WithMany(r => r.Magazines)
                .HasForeignKey(r => r.ResearcherId)
                .IsRequired();
        }
    }
}
