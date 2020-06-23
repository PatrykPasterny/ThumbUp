﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThumbUp.Models;

namespace ThumbUp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200617144344_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThumbUp.Models.Localization", b =>
                {
                    b.Property<long>("LocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocID");

                    b.ToTable("Localizations");
                });

            modelBuilder.Entity("ThumbUp.Models.LocalizationRating", b =>
                {
                    b.Property<long>("LRaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LRaLocID")
                        .HasColumnType("bigint");

                    b.Property<string>("LRaOpinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("LRaRating")
                        .HasColumnType("smallint");

                    b.HasKey("LRaID");

                    b.HasIndex("LRaLocID");

                    b.ToTable("LocalizationRatings");
                });

            modelBuilder.Entity("ThumbUp.Models.LocalizationRating", b =>
                {
                    b.HasOne("ThumbUp.Models.Localization", "Localization")
                        .WithMany("LocRatings")
                        .HasForeignKey("LRaLocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
