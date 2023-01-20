﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    [Migration("20230117164407_maybe")]
    partial class maybe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Associations.Addition", b =>
                {
                    b.Property<Guid>("LibraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("LibraryId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("Addition");
                });

            modelBuilder.Entity("Backend.Models.Associations.GamePurchase", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("TransactionId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GamePurchase");
                });

            modelBuilder.Entity("Backend.Models.Deposit", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("TransactionId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Backend.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Backend.Models.Library", b =>
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

            modelBuilder.Entity("Backend.Models.Purchase", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Backend.Models.Transaction", b =>
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

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.Associations.Addition", b =>
                {
                    b.HasOne("Backend.Models.Game", "Game")
                        .WithMany("GameLibraries")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Library", "Library")
                        .WithMany("GameLibraries")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("Backend.Models.Associations.GamePurchase", b =>
                {
                    b.HasOne("Backend.Models.Game", "Game")
                        .WithMany("GamePurchases")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Purchase", "Purchase")
                        .WithMany("GamePurchases")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Backend.Models.Deposit", b =>
                {
                    b.HasOne("Backend.Models.Transaction", "Transaction")
                        .WithOne("Deposit")
                        .HasForeignKey("Backend.Models.Deposit", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Backend.Models.Library", b =>
                {
                    b.HasOne("Backend.Models.User", "User")
                        .WithOne("Library")
                        .HasForeignKey("Backend.Models.Library", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.Purchase", b =>
                {
                    b.HasOne("Backend.Models.Transaction", "Transaction")
                        .WithOne("Purchase")
                        .HasForeignKey("Backend.Models.Purchase", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Backend.Models.Transaction", b =>
                {
                    b.HasOne("Backend.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.Game", b =>
                {
                    b.Navigation("GameLibraries");

                    b.Navigation("GamePurchases");
                });

            modelBuilder.Entity("Backend.Models.Library", b =>
                {
                    b.Navigation("GameLibraries");
                });

            modelBuilder.Entity("Backend.Models.Purchase", b =>
                {
                    b.Navigation("GamePurchases");
                });

            modelBuilder.Entity("Backend.Models.Transaction", b =>
                {
                    b.Navigation("Deposit");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Navigation("Library");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
