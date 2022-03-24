using BookESale.Models;
using Microsoft.EntityFrameworkCore;

namespace BookESale.DataAccess.Data

{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //This will create table named Categories
        //and let me edit the database ....
        public DbSet<Category> Categories{ get; set; }
        public DbSet<CoverType> CoverTypes{ get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
