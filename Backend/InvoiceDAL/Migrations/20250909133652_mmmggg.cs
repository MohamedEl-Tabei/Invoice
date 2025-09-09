using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceDAL.Migrations
{
    /// <inheritdoc />
    public partial class mmmggg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewData",
                table: "AuditLogs",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "AuditLogs",
                newName: "NewData");
        }
    }
}
