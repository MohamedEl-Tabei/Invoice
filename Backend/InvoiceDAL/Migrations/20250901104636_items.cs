using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceDAL.Migrations
{
    /// <inheritdoc />
    public partial class items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Items",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "CurrentPrice", "Description", "Quantity", "Unit" },
                values: new object[,]
                {
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", 500m, "Transportation by bus", 1m, "trip" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", 500m, "Transportation by taxi", 1m, "trip" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe87");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "78b21eb8-d6dc-4acf-9ab8-91bf746efe88");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");
        }
    }
}
