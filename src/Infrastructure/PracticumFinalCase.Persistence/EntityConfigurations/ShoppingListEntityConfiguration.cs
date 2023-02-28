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
    public class ShoppingListEntityConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.ToTable("ShoppingList");

            builder.HasKey(b => b.Id);

            builder.Property(i => i.Title).HasColumnType("title").HasColumnType("varchar").HasMaxLength(100);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.CategoryName).HasColumnType("CategoryName").HasColumnType("varchar").HasMaxLength(100);

            builder.HasOne<User>(x=>x.Owner)
                .WithMany(x=>x.ShoppingLists)
                .HasForeignKey(x=>x.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
