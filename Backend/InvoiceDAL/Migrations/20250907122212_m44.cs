using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceDAL.Migrations
{
    /// <inheritdoc />
    public partial class m44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Method",
                table: "AuditLogs",
                newName: "Entity");

            migrationBuilder.RenameColumn(
                name: "Endpoint",
                table: "AuditLogs",
                newName: "Action");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Entity",
                table: "AuditLogs",
                newName: "Method");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "AuditLogs",
                newName: "Endpoint");
        }
    }
}
