﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sales_API.data;

#nullable disable

namespace sales_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sales_API.data.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("sales_API.data.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("InvoiceTotal")
                        .HasColumnType("float");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("sales_API.data.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("sales_API.data.SalesTransaction", b =>
                {
                    b.Property<int>("SalesTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesTransactionId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("SalesTransactionId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("SalesTransactions");
                });

            modelBuilder.Entity("sales_API.data.Invoice", b =>
                {
                    b.HasOne("sales_API.data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("sales_API.data.SalesTransaction", b =>
                {
                    b.HasOne("sales_API.data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sales_API.data.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("sales_API.data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
