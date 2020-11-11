using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Assistant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assistant.Infraestructure.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.Property(x => x.UserID).IsRequired();

            builder.Property(x => x.Title).IsRequired();

            builder.Property(x => x.TriggerDate).IsRequired();            
        }
    }
}