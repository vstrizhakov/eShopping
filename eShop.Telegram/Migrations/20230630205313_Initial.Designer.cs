﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShop.Telegram.DbContexts;

#nullable disable

namespace eShop.Telegram.Migrations
{
    [DbContext(typeof(TelegramDbContext))]
    [Migration("20230630205313_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("SupergroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("SupergroupId");

                    b.ToTable("TelegramChats");
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramChatMember", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ChatId");

                    b.HasIndex("ChatId");

                    b.ToTable("TelegramChatMembers");
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramChatSettings", b =>
                {
                    b.Property<Guid>("TelegramChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("TelegramChatId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TelegramChatId")
                        .IsUnique();

                    b.ToTable("TelegramChatSettings");
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("TelegramUsers");
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramChat", b =>
                {
                    b.HasOne("eShop.Telegram.Entities.TelegramChat", "Supergroup")
                        .WithMany()
                        .HasForeignKey("SupergroupId");

                    b.Navigation("Supergroup");
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramChatMember", b =>
                {
                    b.HasOne("eShop.Telegram.Entities.TelegramChat", "Chat")
                        .WithMany("Members")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Telegram.Entities.TelegramUser", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramChatSettings", b =>
                {
                    b.HasOne("eShop.Telegram.Entities.TelegramUser", "Owner")
                        .WithMany("ChatSettings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Telegram.Entities.TelegramChat", "TelegramChat")
                        .WithOne("Settings")
                        .HasForeignKey("eShop.Telegram.Entities.TelegramChatSettings", "TelegramChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("TelegramChat");
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramChat", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Settings")
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.Telegram.Entities.TelegramUser", b =>
                {
                    b.Navigation("ChatSettings");

                    b.Navigation("Chats");
                });
#pragma warning restore 612, 618
        }
    }
}
