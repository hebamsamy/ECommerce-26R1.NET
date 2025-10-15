﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Models
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages", "Production");
            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);
            builder.HasOne(pi => pi.Product)
                   .WithMany(p => p.ProductImages)
                   .HasForeignKey(pi => pi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}