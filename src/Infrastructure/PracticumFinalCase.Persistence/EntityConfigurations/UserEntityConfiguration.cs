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
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(b => b.Id);

            builder.HasIndex(b => new { b.UserName }).IsUnique();

            builder.HasIndex(b => new { b.Email }).IsUnique();

            builder.Property(i => i.UserName).HasColumnType("UserName").HasColumnType("varchar").HasMaxLength(100);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.Name).HasColumnType("name").HasColumnType("varchar").HasMaxLength(100);

            builder.Property(i => i.Email).HasColumnType("email").HasColumnType("varchar").HasMaxLength(100);

            builder.Property(i => i.PhoneNumber).HasMaxLength(10).IsFixedLength(fixedLength: true);
        }
    }
}
