using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assistant.Infraestructure.Configurations
{
    public class GroceryItemConfiguration : IEntityTypeConfiguration<GroceryItem>
    {
        public void Configure(EntityTypeBuilder<GroceryItem> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.Property(x => x.GroceryListID).IsRequired();

            builder.Property(x => x.Name).IsRequired();
        }
    }
}
