using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("48d304ba-af40-4ee8-b4c7-031fd9a5a6c6"), new DateTime(2025, 2, 12, 2, 56, 35, 896, DateTimeKind.Local).AddTicks(9712), "Description2", "Image2", "Product2", new DateTime(2025, 2, 12, 2, 56, 35, 896, DateTimeKind.Local).AddTicks(9713) },
                    { new Guid("734eb585-e9f1-44c9-ab05-7e9af8273bb6"), new DateTime(2025, 2, 12, 2, 56, 35, 896, DateTimeKind.Local).AddTicks(9706), "Description1", "Image1", "Product1", new DateTime(2025, 2, 12, 2, 56, 35, 896, DateTimeKind.Local).AddTicks(9707) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 12, 2, 56, 35, 610, DateTimeKind.Local).AddTicks(2303), "User1@gmail.com", "User1", "$2a$11$PGNe75/FVzsbmmoCuyuV7.4tSiz7mKndNChj.w7VVJqeiu3ukBR4a", new DateTime(2025, 2, 12, 2, 56, 35, 610, DateTimeKind.Local).AddTicks(2315) },
                    { 2, new DateTime(2025, 2, 12, 2, 56, 35, 744, DateTimeKind.Local).AddTicks(3460), "User2@gmail.com", "User2", "$2a$11$0QOMXvY.JrUlDKbYwOGjDOGoJTnBe4BDXDB/HysJiToO6JiP7qwY2", new DateTime(2025, 2, 12, 2, 56, 35, 744, DateTimeKind.Local).AddTicks(3479) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
