using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureStorage.Infra.Data.Migrations
{
    public partial class RemoveFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "CustomerDocuments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "CustomerDocuments",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
