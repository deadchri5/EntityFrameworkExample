using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace efejemplo.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[,]
                {
                    { new Guid("4693fbd8-95f9-46cf-bc12-053d3be7fda2"), "Categoria de oficina", 50, "Tareas oficina" },
                    { new Guid("96c1a1ea-12f0-4c7b-b7f5-e0bfc5b372a7"), "Categoria de hogar", 20, "Tareas del hogar" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreation", "Description", "TaskProperty", "Title" },
                values: new object[,]
                {
                    { new Guid("2e5f01ad-a366-4c50-963e-35631715ea7b"), new Guid("96c1a1ea-12f0-4c7b-b7f5-e0bfc5b372a7"), new DateTime(2023, 12, 20, 1, 18, 28, 103, DateTimeKind.Local).AddTicks(5478), "Tender la cama hace que nos sitamos felices el resto del dia.", 0, "Tender la cama" },
                    { new Guid("c03ccaca-ea76-4c7c-94c9-c2e676fa3188"), new Guid("4693fbd8-95f9-46cf-bc12-053d3be7fda2"), new DateTime(2023, 12, 20, 1, 18, 28, 103, DateTimeKind.Local).AddTicks(5491), "Hacer la tarea que se tiene en jira", 2, "Terminar el algoritmo del trabajo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("2e5f01ad-a366-4c50-963e-35631715ea7b"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("c03ccaca-ea76-4c7c-94c9-c2e676fa3188"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("4693fbd8-95f9-46cf-bc12-053d3be7fda2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("96c1a1ea-12f0-4c7b-b7f5-e0bfc5b372a7"));
        }
    }
}
