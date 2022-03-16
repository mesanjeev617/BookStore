using BookESale.Models;
using Microsoft.EntityFrameworkCore;

namespace BookESale.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //This will create table named Categories
        //and let me edit the database ....
        public DbSet<Category> Categories{ get; set; }
    }
}
