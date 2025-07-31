using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceDAL.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84", null, "Admin", "ADMIN" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe85", null, "Shop", "SHOP" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28b21eb8-d6dc-4dcf-9ab8-91bf746efe85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86");
        }
    }
}
