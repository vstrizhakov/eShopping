﻿using eShop.Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.DbContexts
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Announce> Announces { get; set; }
        public DbSet<AnnounceImage> AnnounceImages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(e => e.ParentCategory)
                .WithMany(e => e.SubCategories)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shop>()
                .HasData(
                    new Shop
                    {
                        Id = Guid.Parse("{68BAF3EC-9BFD-4192-8EC1-D7CFE4C15805}"),
                        Name = "GUESS Factory",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{EA7A3FB8-B981-45F1-A38D-021BE1C5084E}"),
                        Name = "GUESS",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{A3AE0D87-6ACC-4FDA-8BC2-08F6F14F803F}"),
                        Name = "NEXT",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{5B3FCDFB-7148-4DDF-B861-04B40C20BBA3}"),
                        Name = "DKNY",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{E2C9AF14-FDFC-4141-9DD7-E208E68372BA}"),
                        Name = "Women Secret",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{52719937-2C2B-465D-B753-D5E7481E47A5}"),
                        Name = "STRADIVARIUS",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{8105A063-B864-4818-A0A2-ACB6D67B40C4}"),
                        Name = "KARL LAGERFIELD",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{697EC4AC-EACE-4F86-B0C4-7804E45453A3}"),
                        Name = "COACH",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{20C520B7-64FB-4B74-9574-7253DF507AF0}"),
                        Name = "Timberland",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{CD13F11B-3E4B-49D3-BA73-646CEE331DB4}"),
                        Name = "Amazon UK, USA",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{FFCAEBF2-4807-4871-B547-6571C86C8597}"),
                        Name = "Mango Outlet",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{3060DC9E-8CAA-4CFD-B70A-AA299D22BFA6}"),
                        Name = "Adidas",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{AF6CC85D-6610-49FB-9F65-18AA81303B4B}"),
                        Name = "Calvin Klein",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{510F26B9-A48C-407B-BE73-EA604EA63379}"),
                        Name = "Clinique",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{E924C4AA-C9C8-4984-B009-81D064B2CCB6}"),
                        Name = "Zara",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{CFA27462-DF03-4A85-B7EA-872F12783D98}"),
                        Name = "Carters",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{605FE585-29E4-4487-9E1F-F56B5F02A30D}"),
                        Name = "SMYK",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{1F809D98-50CD-40D4-BE1A-9835F4A81214}"),
                        Name = "Lefties",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{08A8AC0C-3D28-4AFF-8742-245DD9D644A3}"),
                        Name = "Mango",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{F5066B5C-794A-4AE0-B853-362F9BC1486A}"),
                        Name = "PUMA ",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{8E972F07-888E-4C70-9DA9-367A4B6EDED8}"),
                        Name = "Bershka",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{B8F2F19F-4492-4090-BD4E-06BE22ABC51C}"),
                        Name = "Oysho ES",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{E92A6F82-F569-40E8-B50C-B2BB868DE508}"),
                        Name = "HM UK",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{C6C6E5FD-7D6C-4630-AEE2-994A1BFFFC4A}"),
                        Name = "Zara PL",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{BE49C236-0BA1-4A8F-8F41-4ADC996F25B5}"),
                        Name = "Nike US",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{AF80FD3C-409E-4C53-B40E-5C07D9045275}"),
                        Name = "Tommy Hilfiger",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{40837F56-0E75-4662-9038-2AD7577F23A8}"),
                        Name = "Under Armour",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{A32D0B43-CFEE-42CF-9EA9-B515E46D2EC3}"),
                        Name = "Columbia US",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{C8C878B0-8366-43F4-9CAE-3C41E22B970D}"),
                        Name = "Rituals США",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{487ADC27-6A38-41D6-A889-944E99071C1B}"),
                        Name = "Marc-o-Polo",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{A9AD6042-33F8-46BC-84A0-FDA1B92FD7CB}"),
                        Name = "Lacoste",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{9C57533C-1324-4179-ABC4-9B10E527A8E8}"),
                        Name = "Armani Exchange",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{9CD9E8A6-B2FA-4B90-A1F4-4FE9368FD31F}"),
                        Name = "MountainWarehouse",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{71F33E42-F7F9-463F-B7BB-9F4612547644}"),
                        Name = "Columbia",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{2C466174-9364-4CFF-88EC-4788209A5867}"),
                        Name = "Lidl",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{0F5C8EA0-9328-4DD6-88AD-893075A7FAF2}"),
                        Name = "Macys",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{CFD5B6A3-2582-4D2E-BA67-A2D0FC52AE2D}"),
                        Name = "Gemini",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{DBCEC2E7-C79E-4F3D-A9BE-6547F060488A}"),
                        Name = "Underarmour",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{B64D2E73-3F6B-4D51-82E4-F57E8A0AFA63}"),
                        Name = "Desigual",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{A1FE4C49-3DB0-4E5B-A231-369530F6805D}"),
                        Name = "IHerb",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{2DE3D6CD-6E3E-42BE-B0EC-032C0EDEFC21}"),
                        Name = "Zalando",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{966B6F67-B7D2-4F89-AB77-D3BC361CFEAB}"),
                        Name = "Reebok UK",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{74C459DF-4855-41E5-A064-5668F0546725}"),
                        Name = "Lesacoutlet",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{BB836752-5E31-481F-A6C0-1E340D513224}"),
                        Name = "Puritan",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Shop
                    {
                        Id = Guid.Parse("{253D286D-E3BB-402F-B6FF-43B5A938BA17}"),
                        Name = "JOMASHOP",
                        CreatedAt = DateTimeOffset.MinValue,
                    }
                );

            modelBuilder.Entity<Currency>()
                .HasData(
                    new Currency
                    {
                        Id = Guid.Parse("9724739E-E4B8-45EB-AC11-EFE2B0558A34"),
                        Name = "UAH",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Currency
                    {
                        Id = Guid.Parse("BF879FB6-7B4B-41C7-9CC5-DF8724D511E5"),
                        Name = "USD",
                        CreatedAt = DateTimeOffset.MinValue,
                    },
                    new Currency
                    {
                        Id = Guid.Parse("41ED0945-7196-4EAD-8F5E-DB262E62E536"),
                        Name = "EUR",
                        CreatedAt = DateTimeOffset.MinValue,
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
