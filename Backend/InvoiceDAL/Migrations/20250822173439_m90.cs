using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceDAL.Migrations
{
    /// <inheritdoc />
    public partial class m90 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ConcurrencyStamp", "Name" },
                values: new object[,]
                {
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "Food" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "Electronics" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "Clothes" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "Furniture" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "Education" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "Transportation" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "Health" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "Services" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "Entertainment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe81");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe82");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe83");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe84");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe85");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe86");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe87");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe88");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe89");
        }
    }
}
