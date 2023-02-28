using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticumFinalCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Persistence.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(b => b.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.Name).HasColumnType("name").HasColumnType("varchar").HasMaxLength(100);

            builder.Property(i => i.Description).HasColumnType("description").HasColumnType("varchar").HasMaxLength(1000);

        }
    }
}
