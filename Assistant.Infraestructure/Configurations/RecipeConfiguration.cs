using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assistant.Infraestructure.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Ingredients).WithOne(x => x.Recipe).HasForeignKey(x => x.RecipeID);

            builder.Property(x => x.Name).IsRequired();            
        }
    }
}
