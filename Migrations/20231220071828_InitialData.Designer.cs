﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using efejemplo;

#nullable disable

namespace efejemplo.Migrations
{
    [DbContext(typeof(TasksContext))]
    [Migration("20231220071828_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("efejemplo.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Effort")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("96c1a1ea-12f0-4c7b-b7f5-e0bfc5b372a7"),
                            Description = "Categoria de hogar",
                            Effort = 20,
                            Name = "Tareas del hogar"
                        },
                        new
                        {
                            CategoryId = new Guid("4693fbd8-95f9-46cf-bc12-053d3be7fda2"),
                            Description = "Categoria de oficina",
                            Effort = 50,
                            Name = "Tareas oficina"
                        });
                });

            modelBuilder.Entity("efejemplo.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskProperty")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("2e5f01ad-a366-4c50-963e-35631715ea7b"),
                            CategoryId = new Guid("96c1a1ea-12f0-4c7b-b7f5-e0bfc5b372a7"),
                            DateCreation = new DateTime(2023, 12, 20, 1, 18, 28, 103, DateTimeKind.Local).AddTicks(5478),
                            Description = "Tender la cama hace que nos sitamos felices el resto del dia.",
                            TaskProperty = 0,
                            Title = "Tender la cama"
                        },
                        new
                        {
                            TaskId = new Guid("c03ccaca-ea76-4c7c-94c9-c2e676fa3188"),
                            CategoryId = new Guid("4693fbd8-95f9-46cf-bc12-053d3be7fda2"),
                            DateCreation = new DateTime(2023, 12, 20, 1, 18, 28, 103, DateTimeKind.Local).AddTicks(5491),
                            Description = "Hacer la tarea que se tiene en jira",
                            TaskProperty = 2,
                            Title = "Terminar el algoritmo del trabajo"
                        });
                });

            modelBuilder.Entity("efejemplo.Models.Task", b =>
                {
                    b.HasOne("efejemplo.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("efejemplo.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
