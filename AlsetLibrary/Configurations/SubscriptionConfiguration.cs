using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlsetLibrary.Configurations
{
    internal class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdSubscription");

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(128);


            builder.HasOne(e => e.Researcher)
               .WithMany(r => r.Subscriptions)
               .HasForeignKey(r => r.IdResearcher)
               .IsRequired();

        }
    }
}
