using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Context
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menus { get; set;}
        public DbSet<Plate> Plates { get; set;}
        public DbSet<Ingredient> Ingredients { get; set;}


    }
}
