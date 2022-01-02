using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class AlterTableMstService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "mst_service",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2021, 12, 31, 16, 17, 9, 160, DateTimeKind.Local).AddTicks(941), new DateTime(2021, 12, 31, 16, 17, 9, 160, DateTimeKind.Local).AddTicks(9248), "1e59fe31-6f8d-42bf-8a0a-56b70dac4f50" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "name",
                table: "mst_service",
                type: "boolean",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2021, 12, 31, 15, 37, 39, 41, DateTimeKind.Local).AddTicks(9607), new DateTime(2021, 12, 31, 15, 37, 39, 42, DateTimeKind.Local).AddTicks(8097), "4222100d-ea9d-42b0-9b58-f02e5fcbe030" });
        }
    }
}
