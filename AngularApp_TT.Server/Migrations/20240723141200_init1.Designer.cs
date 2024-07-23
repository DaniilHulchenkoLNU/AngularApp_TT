﻿// <auto-generated />
using AngularApp_TT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularApp_TT.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240723141200_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AngularApp_TT.Server.Models.Auth.Accounts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Email = "admin@example.com",
                            Password = "admin"
                        });
                });

            modelBuilder.Entity("AngularApp_TT.Server.Models.Entity.СryptoRate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("AccountsId")
                        .HasColumnType("int");

                    b.Property<string>("changePercent24Hr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("explorer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marketCapUsd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("maxSupply")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priceUsd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("supply")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("volumeUsd24Hr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vwap24Hr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AccountsId");

                    b.ToTable("СryptoRate");
                });

            modelBuilder.Entity("AngularApp_TT.Server.Models.Entity.СryptoRate", b =>
                {
                    b.HasOne("AngularApp_TT.Server.Models.Auth.Accounts", "Accounts")
                        .WithMany("UserHistoryList")
                        .HasForeignKey("AccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("AngularApp_TT.Server.Models.Auth.Accounts", b =>
                {
                    b.Navigation("UserHistoryList");
                });
#pragma warning restore 612, 618
        }
    }
}
