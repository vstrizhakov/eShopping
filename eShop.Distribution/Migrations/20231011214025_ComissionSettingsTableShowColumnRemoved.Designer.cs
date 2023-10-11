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
    [Migration("20231011214025_ComissionSettingsTableShowColumnRemoved")]
    partial class ComissionSettingsTableShowColumnRemoved
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopShopSettings", b =>
                {
                    b.Property<Guid>("PreferredShopsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PreferredShopsId", "ShopSettingsId");

                    b.HasIndex("ShopSettingsId");

                    b.ToTable("ShopShopSettings");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DistributionSettingsAccountId")
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

                    b.HasIndex("DistributionSettingsAccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.ComissionSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("DistributionSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DistributionSettingsId")
                        .IsUnique();

                    b.ToTable("ComissionSettings");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9724739e-e4b8-45eb-ac11-efe2b0558a34"),
                            Name = "UAH"
                        },
                        new
                        {
                            Id = new Guid("bf879fb6-7b4b-41c7-9cc5-df8724d511e5"),
                            Name = "USD"
                        },
                        new
                        {
                            Id = new Guid("41ed0945-7196-4ead-8f5e-db262e62e536"),
                            Name = "EUR"
                        });
                });

            modelBuilder.Entity("eShop.Distribution.Entities.CurrencyRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DistributionSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<Guid>("SourceCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TargetCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SourceCurrencyId");

                    b.HasIndex("TargetCurrencyId");

                    b.HasIndex("DistributionSettingsId", "TargetCurrencyId", "SourceCurrencyId")
                        .IsUnique();

                    b.ToTable("CurrencyRates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3b279ea-2a65-4996-b0b5-ec242c90ebb2"),
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 37.090000000000003,
                            SourceCurrencyId = new Guid("bf879fb6-7b4b-41c7-9cc5-df8724d511e5"),
                            TargetCurrencyId = new Guid("9724739e-e4b8-45eb-ac11-efe2b0558a34")
                        },
                        new
                        {
                            Id = new Guid("a05f6d6b-ccb2-43fd-8694-eceafdf0ab31"),
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 39.109999999999999,
                            SourceCurrencyId = new Guid("41ed0945-7196-4ead-8f5e-db262e62e536"),
                            TargetCurrencyId = new Guid("9724739e-e4b8-45eb-ac11-efe2b0558a34")
                        },
                        new
                        {
                            Id = new Guid("d5d120a1-dba7-4e87-a4e1-9670a365dd2d"),
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 0.027,
                            SourceCurrencyId = new Guid("9724739e-e4b8-45eb-ac11-efe2b0558a34"),
                            TargetCurrencyId = new Guid("bf879fb6-7b4b-41c7-9cc5-df8724d511e5")
                        },
                        new
                        {
                            Id = new Guid("6fc5e363-a92e-4412-9dbb-c84841e06f91"),
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 1.05,
                            SourceCurrencyId = new Guid("41ed0945-7196-4ead-8f5e-db262e62e536"),
                            TargetCurrencyId = new Guid("bf879fb6-7b4b-41c7-9cc5-df8724d511e5")
                        },
                        new
                        {
                            Id = new Guid("e4021ee6-1568-448c-a95b-ac76191f235b"),
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 0.025999999999999999,
                            SourceCurrencyId = new Guid("9724739e-e4b8-45eb-ac11-efe2b0558a34"),
                            TargetCurrencyId = new Guid("41ed0945-7196-4ead-8f5e-db262e62e536")
                        },
                        new
                        {
                            Id = new Guid("69d06081-f197-4823-8248-eb6c60cb73a4"),
                            CreatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 0.94999999999999996,
                            SourceCurrencyId = new Guid("bf879fb6-7b4b-41c7-9cc5-df8724d511e5"),
                            TargetCurrencyId = new Guid("41ed0945-7196-4ead-8f5e-db262e62e536")
                        });
                });

            modelBuilder.Entity("eShop.Distribution.Entities.CurrencyRateHistoryRecord", b =>
                {
                    b.Property<Guid>("DistributionSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DistributionSettingsHistoryRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("DistributionSettingsId", "CurrencyId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DistributionSettingsHistoryRecordId");

                    b.ToTable("CurrencyRateHistoryRecord");
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

                    b.Property<Guid>("DistributionSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TelegramChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ViberChatId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "Id");

                    b.HasIndex("DistributionSettingsId");

                    b.HasIndex("TelegramChatId");

                    b.HasIndex("ViberChatId");

                    b.ToTable("DistributionGroupItems");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionSettings", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("PreferredCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ShowSales")
                        .HasColumnType("bit");

                    b.HasKey("AccountId");

                    b.HasIndex("PreferredCurrencyId");

                    b.ToTable("DistributionSettings");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionSettingsHistoryRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PreferredCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PreferredCurrencyId");

                    b.ToTable("DistributionSettingsHistoryRecord");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.ShopSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DistributionSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Filter")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DistributionSettingsId")
                        .IsUnique();

                    b.ToTable("ShopSettings");
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

            modelBuilder.Entity("ShopShopSettings", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.Shop", null)
                        .WithMany()
                        .HasForeignKey("PreferredShopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Distribution.Entities.ShopSettings", null)
                        .WithMany()
                        .HasForeignKey("ShopSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.Distribution.Entities.Account", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.DistributionSettings", "DistributionSettings")
                        .WithMany()
                        .HasForeignKey("DistributionSettingsAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DistributionSettings");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.ComissionSettings", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.DistributionSettings", "DistributionSettings")
                        .WithOne("ComissionSettings")
                        .HasForeignKey("eShop.Distribution.Entities.ComissionSettings", "DistributionSettingsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("DistributionSettings");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.CurrencyRate", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.DistributionSettings", "DistributionSettings")
                        .WithMany("CurrencyRates")
                        .HasForeignKey("DistributionSettingsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eShop.Distribution.Entities.Currency", "SourceCurrency")
                        .WithMany()
                        .HasForeignKey("SourceCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("eShop.Distribution.Entities.Currency", "TargetCurrency")
                        .WithMany()
                        .HasForeignKey("TargetCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DistributionSettings");

                    b.Navigation("SourceCurrency");

                    b.Navigation("TargetCurrency");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.CurrencyRateHistoryRecord", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("eShop.Distribution.Entities.DistributionSettingsHistoryRecord", null)
                        .WithMany("CurrencyRates")
                        .HasForeignKey("DistributionSettingsHistoryRecordId");

                    b.HasOne("eShop.Distribution.Entities.DistributionSettingsHistoryRecord", "DistributionSettings")
                        .WithMany()
                        .HasForeignKey("DistributionSettingsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("DistributionSettings");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionGroupItem", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.DistributionSettingsHistoryRecord", "DistributionSettings")
                        .WithMany()
                        .HasForeignKey("DistributionSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("DistributionSettings");

                    b.Navigation("Group");

                    b.Navigation("TelegramChat");

                    b.Navigation("ViberChat");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionSettings", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.Currency", "PreferredCurrency")
                        .WithMany()
                        .HasForeignKey("PreferredCurrencyId");

                    b.Navigation("PreferredCurrency");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionSettingsHistoryRecord", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.Currency", "PreferredCurrency")
                        .WithMany()
                        .HasForeignKey("PreferredCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PreferredCurrency");
                });

            modelBuilder.Entity("eShop.Distribution.Entities.ShopSettings", b =>
                {
                    b.HasOne("eShop.Distribution.Entities.DistributionSettings", "DistributionSettings")
                        .WithOne("ShopSettings")
                        .HasForeignKey("eShop.Distribution.Entities.ShopSettings", "DistributionSettingsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("DistributionSettings");
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

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionSettings", b =>
                {
                    b.Navigation("ComissionSettings")
                        .IsRequired();

                    b.Navigation("CurrencyRates");

                    b.Navigation("ShopSettings")
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.Distribution.Entities.DistributionSettingsHistoryRecord", b =>
                {
                    b.Navigation("CurrencyRates");
                });
#pragma warning restore 612, 618
        }
    }
}
