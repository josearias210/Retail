﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Retail.Infrastructure.Data.EF;

namespace Retail.Infrastructure.Data.EF.Migrations
{
    [DbContext(typeof(RetailDataContext))]
    [Migration("20210322050955_initial_database")]
    partial class initial_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Retail.Core.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateIn")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Retail.Core.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Retail.Core.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c022e3f-9467-4c28-8aff-a299a0a92001"),
                            Description = "Mouse",
                            Price = 40m
                        },
                        new
                        {
                            Id = new Guid("3c022e3f-9467-4c28-8aff-a299a0a92002"),
                            Description = "Monitor",
                            Price = 150m
                        });
                });

            modelBuilder.Entity("Retail.Core.Domain.Entities.Order", b =>
                {
                    b.OwnsOne("Retail.Core.Domain.Entities.ValueObjects.Delivery", "Delivery", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("City")
                                .HasColumnType("nvarchar(150)")
                                .HasMaxLength(150);

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnName("State")
                                .HasColumnType("nvarchar(60)")
                                .HasMaxLength(60);

                            b1.Property<string>("StreetAddress")
                                .IsRequired()
                                .HasColumnName("StreetAddress")
                                .HasColumnType("nvarchar(600)")
                                .HasMaxLength(600);

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnName("ZipCode")
                                .HasColumnType("nvarchar(12)")
                                .HasMaxLength(12);

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
                });

            modelBuilder.Entity("Retail.Core.Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("Retail.Core.Domain.Entities.Order", null)
                        .WithMany("Details")
                        .HasForeignKey("OrderId");

                    b.HasOne("Retail.Core.Domain.Entities.Product", null)
                        .WithMany("Details")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}