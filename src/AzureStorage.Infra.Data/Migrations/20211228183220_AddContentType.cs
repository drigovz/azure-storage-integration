using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureStorage.Infra.Data.Migrations
{
    public partial class AddContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "CustomerDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "CustomerDocuments",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "CustomerDocuments");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "CustomerDocuments");
        }
    }
}
