using Microsoft.EntityFrameworkCore;
using Assistant.Core.Entities;
using Assistant.Infraestructure.Configurations;

namespace Assistant.Infraestructure
{
    public class AssistantDbContext : DbContext
    {
        public AssistantDbContext(DbContextOptions options) :
            base(options)
        {

        }               

        public DbSet<Event> Events { get; set; }

        public DbSet<GroceryItem> GroceryItems { get; set; }

        public DbSet<GroceryList> GroceryLists { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new GroceryItemConfiguration());
            modelBuilder.ApplyConfiguration(new GroceryListConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
