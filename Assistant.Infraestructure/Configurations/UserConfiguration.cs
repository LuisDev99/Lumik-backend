using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assistant.Infraestructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.HasMany(x => x.GroceryLists).WithOne(x => x.User).HasForeignKey(x => x.UserID);

            builder.HasMany(x => x.ScheduledEvents).WithOne(x => x.User).HasForeignKey(x => x.UserID);

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.UserName).IsRequired();
        }
    }
}
