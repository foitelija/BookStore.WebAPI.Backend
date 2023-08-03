using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class booksSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "DateCreated", "Description", "Genre", "ImageUrl", "Price", "Rating", "Stock", "Title", "TotalPages", "Year" },
                values: new object[,]
                {
                    { 1, "Author book name", new DateTime(2023, 8, 3, 10, 53, 22, 691, DateTimeKind.Local).AddTicks(4704), "Full Description book", "Genre test", "ImageUrl put here", 15.99, 4, 20, "Test book name", 200, 2000 },
                    { 2, "Author 2 book 2 name 2", new DateTime(2023, 8, 3, 10, 53, 22, 691, DateTimeKind.Local).AddTicks(4718), "Full 2 Description 2 book 2", "Genre 2 test 2", "ImageUrl 2 put 2 here", 2.0, 2, 22, "Test 2 book 2 name 2", 20, 2022 },
                    { 3, "Author 3 book 3 name", new DateTime(2023, 8, 3, 10, 53, 22, 691, DateTimeKind.Local).AddTicks(4721), "Full 3 Description 3 book", "Genre 3 test 3", "ImageUrl 3 put 3 here 3", 33.329999999999998, 5, 33, "Test 3 book 3 name", 33, 2013 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
