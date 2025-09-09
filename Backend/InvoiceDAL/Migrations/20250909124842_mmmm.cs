using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceDAL.Migrations
{
    /// <inheritdoc />
    public partial class mmmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewData",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewData",
                table: "AuditLogs");
        }
    }
}
