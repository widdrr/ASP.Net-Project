using Backend.Models;
using Backend.Models.Associations;
using Microsoft.EntityFrameworkCore;
namespace Backend.Data
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
            modelBuilder.Entity<Addition>()
                .HasKey(gl => new { gl.LibraryId, gl.GameId });

            modelBuilder.Entity<Game>()
                .HasMany(g => g.GameLibraries)
                .WithOne(gl => gl.Game)
                .HasForeignKey(gl => gl.GameId);
            
            modelBuilder.Entity<Library>()
                .HasMany(l => l.GameLibraries)
                .WithOne(gl => gl.Library)
                .HasForeignKey(gl => gl.LibraryId);

            //Many to Many between Game<->Purchase
            //Done through the GameTransaction associative entity
            modelBuilder.Entity<GamePurchase>()
                .HasKey(gt => new { gt.TransactionId, gt.GameId });

            //Purchase and Deposit are subentities in 1 to 1 with Transaction
            modelBuilder.Entity<Purchase>()
                .HasKey(p => p.TransactionId);
            modelBuilder.Entity<Deposit>()
                .HasKey(d => d.TransactionId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Purchase)
                .WithOne(p => p.Transaction)
                .HasForeignKey<Purchase>(p => p.TransactionId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Deposit)
                .WithOne(d => d.Transaction)
                .HasForeignKey<Deposit>(d => d.TransactionId);


            modelBuilder.Entity<Game>()
                .HasMany(g => g.GamePurchases)
                .WithOne(gp => gp.Game)
                .HasForeignKey(gt => gt.GameId);

            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.GamePurchases)
                .WithOne(gp => gp.Purchase)
                .HasForeignKey(gp => gp.TransactionId);


            base.OnModelCreating(modelBuilder);
        }

    }
}
