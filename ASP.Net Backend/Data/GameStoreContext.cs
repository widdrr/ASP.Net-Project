using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.Associations;
using Microsoft.EntityFrameworkCore;
namespace ASP.Net_Backend.Data
{
    public class GameStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Transaction> Transactions {get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to One between User<->Library
            modelBuilder.Entity<User>()
                .HasOne(u => u.Library)
                .WithOne(l => l.User)
                .HasForeignKey<Library>(l => l.UserId);

            //One to Many between User<->Transaction
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
            
            //Many to Many between Game<->Library
            //Done through the GameLibrary associative entity
            modelBuilder.Entity<GameLibrary>()
                .HasKey(gl => new { gl.LibraryId, gl.GameId });

            modelBuilder.Entity<Game>()
                .HasMany(g => g.GameLibraries)
                .WithOne(gl => gl.Game)
                .HasForeignKey(gl => gl.GameId);
            
            modelBuilder.Entity<Library>()
                .HasMany(l => l.GameLibraries)
                .WithOne(gl => gl.Library)
                .HasForeignKey(gl => gl.LibraryId);

            //Many to Many between Game<->Transaction
            //Done through the GameTransaction associative entity
            modelBuilder.Entity<GameTransaction>()
                .HasKey(gt => new { gt.TransactionId, gt.GameId });

            modelBuilder.Entity<Game>()
                .HasMany(g => g.GameTransactions)
                .WithOne(gt => gt.Game)
                .HasForeignKey(gt => gt.GameId);

            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.GameTransactions)
                .WithOne(gt => gt.Transaction)
                .HasForeignKey(gt => gt.TransactionId);


            base.OnModelCreating(modelBuilder);
        }

    }
}
