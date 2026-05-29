using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClanArchMvc.Infra.Data.EntitysConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> 
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Metais"),
                new Category(2, "Madeiras"),
                new Category(3, "Eletrônicos"),
                new Category(4, "Acessorios")
            );
        }
    }
}
