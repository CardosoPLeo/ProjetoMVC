﻿// <auto-generated />
using System;
using CRUDMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDMVC.Migrations
{
    [DbContext(typeof(CRUDMVCContext))]
    [Migration("20200630013847_ForeignKeyDeDepartamentos")]
    partial class ForeignKeyDeDepartamentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CRUDMVC.Models.Departamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("CRUDMVC.Models.RegistroDeVendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<double>("Quantia");

                    b.Property<int>("Status");

                    b.Property<int?>("VendedorId");

                    b.HasKey("Id");

                    b.HasIndex("VendedorId");

                    b.ToTable("RegistroDeVendas");
                });

            modelBuilder.Entity("CRUDMVC.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAniversario");

                    b.Property<int>("DepartamentosId");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentosId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("CRUDMVC.Models.RegistroDeVendas", b =>
                {
                    b.HasOne("CRUDMVC.Models.Vendedor", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedorId");
                });

            modelBuilder.Entity("CRUDMVC.Models.Vendedor", b =>
                {
                    b.HasOne("CRUDMVC.Models.Departamentos", "Departamentos")
                        .WithMany("Vendedores")
                        .HasForeignKey("DepartamentosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
