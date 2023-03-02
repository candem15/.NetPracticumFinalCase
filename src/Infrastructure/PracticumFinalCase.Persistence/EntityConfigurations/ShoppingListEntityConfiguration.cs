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

            builder.Property(i => i.Title).HasColumnType("title").HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.IsCompleted).HasDefaultValue(false);

            builder.Property(i => i.CategoryName).HasColumnType("CategoryName").HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.HasOne<User>(x=>x.User)
                .WithMany(x=>x.ShoppingLists)
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
