using ASP.Net_Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP.Net_Backend.Data
{
    public class GameStoreContext : DbContext
    {
        public DbSet<TestModel1> TestModel1s { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
