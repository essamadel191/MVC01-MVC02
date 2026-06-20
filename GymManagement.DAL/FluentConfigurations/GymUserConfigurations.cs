using GymManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.DAL.FluentConfigurations
{
    public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.Phone).IsUnique();

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("EmailCheck", "Email Like '_%@_%._%'");
                tb.HasCheckConstraint("PhoneCheck", "Phone Like '010' or Phone Like '012' Phone Like '015'");
            });

            // Address Own Entity
            builder.OwnsOne(x => x.Address , address =>
            {
                address.Property(p => p.Street)
                    .HasColumnName("Street")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                //address.Property(p => p.City)
                //    .HasColumnName("City")
                //    .HasColumnType("varchar")
                //    .HasMaxLength(100);

            });
        }
    }
}
