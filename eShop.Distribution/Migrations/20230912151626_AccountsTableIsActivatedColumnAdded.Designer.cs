﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShop.Distribution.DbContexts;

#nullable disable

namespace eShop.Distribution.Migrations
{
    [DbContext(typeof(DistributionDbContext))]
    [Migration("20230912151626_AccountsTableIsActivatedColumnAdded")]
    partial class AccountsTableIsActivatedColumnAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eShop.Distribution.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("DistributionGroups");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionGroupItem", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TelegramChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ViberChatId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "Id");

                    b.HasIndex("TelegramChatId");

                    b.HasIndex("ViberChatId");

                    b.ToTable("DistributionGroupItems");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.TelegramChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("TelegramChats");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.ViberChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("ViberChats");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionGroupItem", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.DistributionGroup", "Group")
                        .WithMany("Items")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Distribution.Entities.TelegramChat", "TelegramChat")
                        .WithMany()
                        .HasForeignKey("TelegramChatId");

                    b.HasOne("eShop.Distribution.Entities.ViberChat", "ViberChat")
                        .WithMany()
                        .HasForeignKey("ViberChatId");

                    b.Navigation("Group");

                    b.Navigation("TelegramChat");

                    b.Navigation("ViberChat");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.TelegramChat", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.Account", "Account")
                        .WithMany("TelegramChats")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.ViberChat", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.Account", "Account")
                        .WithOne("ViberChat")
                        .HasForeignKey("eShop.Distribution.Entities.ViberChat", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.Account", b =>
                {
                    b.Navigation("TelegramChats");

                    b.Navigation("ViberChat");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionGroup", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
