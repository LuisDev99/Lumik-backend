using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assistant.Infraestructure.Configurations
{
    public class GroceryListConfiguration : IEntityTypeConfiguration<GroceryList>
    {
        public void Configure(EntityTypeBuilder<GroceryList> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.HasMany(x => x.GroceryItems).WithOne(x => x.GroceryList).HasForeignKey(x => x.GroceryListID);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.UserID).IsRequired();
        }
    }
}
