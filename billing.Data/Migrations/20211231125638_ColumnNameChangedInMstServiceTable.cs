using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class ColumnNameChangedInMstServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "s_id",
                table: "mst_service",
                newName: "u_id");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2021, 12, 31, 18, 26, 37, 639, DateTimeKind.Local).AddTicks(3964), new DateTime(2021, 12, 31, 18, 26, 37, 640, DateTimeKind.Local).AddTicks(1340), "e1c69f61-1b37-4914-81ba-08637f85c5df" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "u_id",
                table: "mst_service",
                newName: "s_id");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2021, 12, 31, 16, 17, 9, 160, DateTimeKind.Local).AddTicks(941), new DateTime(2021, 12, 31, 16, 17, 9, 160, DateTimeKind.Local).AddTicks(9248), "1e59fe31-6f8d-42bf-8a0a-56b70dac4f50" });
        }
    }
}
