﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S_Squared_Enterprises_Personal_System.Data;

#nullable disable

namespace SSquaredEnterprisesPersonalSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("S_Squared_Enterprises_Personal_System.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("S_Squared_Enterprises_Personal_System.Models.Employee", b =>
                {
                    b.HasOne("S_Squared_Enterprises_Personal_System.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Manager");
                });
#pragma warning restore 612, 618
        }
    }
}