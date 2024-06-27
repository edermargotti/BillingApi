﻿// <auto-generated />
using System;
using BillingApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BillingApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240626114535_CriacaoInicialBancoETabelas")]
    partial class CriacaoInicialBancoETabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BillingApi.Domain.Models.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Currency");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DueDate")
                        .HasAnnotation("Relational:JsonPropertyName", "due_date");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("InvoiceNumber")
                        .HasAnnotation("Relational:JsonPropertyName", "invoice_number");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int")
                        .HasColumnName("TotalAmount")
                        .HasAnnotation("Relational:JsonPropertyName", "total_amount");

                    b.HasKey("Id")
                        .HasName("PK_IdBilling");

                    b.HasIndex("CustomerId");

                    b.ToTable("Billing", (string)null);
                });

            modelBuilder.Entity("BillingApi.Domain.Models.BillingLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillingId")
                        .HasColumnType("int")
                        .HasColumnName("BillingId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<int>("SubTotal")
                        .HasColumnType("int")
                        .HasColumnName("SubTotal");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("UnitPrice")
                        .HasAnnotation("Relational:JsonPropertyName", "unit_price");

                    b.HasKey("Id")
                        .HasName("PK_IdBillingLine");

                    b.HasIndex("BillingId");

                    b.HasIndex("ProductId");

                    b.ToTable("BillingLine", (string)null);

                    b.HasAnnotation("Relational:JsonPropertyName", "lines");
                });

            modelBuilder.Entity("BillingApi.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_IdCustomer");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("BillingApi.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_IdProduct");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("BillingApi.Domain.Models.Billing", b =>
                {
                    b.HasOne("BillingApi.Domain.Models.Customer", "Customer")
                        .WithMany("Billing")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BillingApi.Domain.Models.BillingLine", b =>
                {
                    b.HasOne("BillingApi.Domain.Models.Billing", "Billing")
                        .WithMany("BillingLines")
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BillingApi.Domain.Models.Product", "Product")
                        .WithMany("BillingLine")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Billing");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BillingApi.Domain.Models.Billing", b =>
                {
                    b.Navigation("BillingLines");
                });

            modelBuilder.Entity("BillingApi.Domain.Models.Customer", b =>
                {
                    b.Navigation("Billing");
                });

            modelBuilder.Entity("BillingApi.Domain.Models.Product", b =>
                {
                    b.Navigation("BillingLine");
                });
#pragma warning restore 612, 618
        }
    }
}
