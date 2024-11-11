using carShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carShop.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Model)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(c => c.Color)
				.IsRequired()
				.HasMaxLength(20);
			builder.Property(c => c.BodyType)
			    .IsRequired()
			    .HasMaxLength(50);
			builder.Property(c => c.Year)
				.IsRequired();
            builder.Property(c => c.ImagePath)
                .IsRequired();
			builder.Property(c => c.Price)
				 .HasPrecision(20, 2)
			   .IsRequired();

			builder.HasMany(c => c.Carts)
				.WithMany(cart => cart.Cars)
                .UsingEntity<Dictionary<string, object>>(
            "CarCart", 
            j => j.HasOne<Cart>().WithMany().HasForeignKey("CartId"),
            j => j.HasOne<Car>().WithMany().HasForeignKey("CarId")
        );
		}
	}
}
