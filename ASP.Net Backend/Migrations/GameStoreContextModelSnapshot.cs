﻿// <auto-generated />
using System;
using ASP.Net_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NetBackend.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    partial class GameStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP.Net_Backend.Models.Associations.GameLibrary", b =>
                {
                    b.Property<Guid>("LibraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("LibraryId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameLibrary");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Associations.GameTransaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.HasKey("TransactionId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameTransaction");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Developer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Associations.GameLibrary", b =>
                {
                    b.HasOne("ASP.Net_Backend.Models.Game", "Game")
                        .WithMany("GameLibraries")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.Net_Backend.Models.Library", "Library")
                        .WithMany("GameLibraries")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Associations.GameTransaction", b =>
                {
                    b.HasOne("ASP.Net_Backend.Models.Game", "Game")
                        .WithMany("GameTransactions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.Net_Backend.Models.Transaction", "Transaction")
                        .WithMany("GameTransactions")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Library", b =>
                {
                    b.HasOne("ASP.Net_Backend.Models.User", "User")
                        .WithOne("Library")
                        .HasForeignKey("ASP.Net_Backend.Models.Library", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Transaction", b =>
                {
                    b.HasOne("ASP.Net_Backend.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Game", b =>
                {
                    b.Navigation("GameLibraries");

                    b.Navigation("GameTransactions");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Library", b =>
                {
                    b.Navigation("GameLibraries");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.Transaction", b =>
                {
                    b.Navigation("GameTransactions");
                });

            modelBuilder.Entity("ASP.Net_Backend.Models.User", b =>
                {
                    b.Navigation("Library");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
