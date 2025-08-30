using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class removedvehkm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "vehicle_km",
                table: "mst_customer",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2025, 8, 30, 13, 24, 43, 19, DateTimeKind.Local).AddTicks(5254), new DateTime(2025, 8, 30, 13, 24, 43, 21, DateTimeKind.Local).AddTicks(3199), "fbaeb68b-082b-4ba2-847b-456a971dc0e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "vehicle_km",
                table: "mst_customer",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2025, 8, 30, 13, 22, 9, 829, DateTimeKind.Local).AddTicks(1642), new DateTime(2025, 8, 30, 13, 22, 9, 830, DateTimeKind.Local).AddTicks(4918), "0db084dc-9b3c-4c8f-b33f-08004ade988a" });
        }
    }
}
