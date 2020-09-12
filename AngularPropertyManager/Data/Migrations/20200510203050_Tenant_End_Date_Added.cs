using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularPropertyManager.Data.Migrations
{
    public partial class Tenant_End_Date_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TenancyEndDate",
                table: "Tenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenancyEndDate",
                table: "Tenants");
        }
    }
}
