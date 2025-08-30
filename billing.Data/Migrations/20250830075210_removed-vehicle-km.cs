using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class removedvehiclekm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2025, 8, 30, 13, 22, 9, 829, DateTimeKind.Local).AddTicks(1642), new DateTime(2025, 8, 30, 13, 22, 9, 830, DateTimeKind.Local).AddTicks(4918), "0db084dc-9b3c-4c8f-b33f-08004ade988a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2025, 8, 30, 13, 17, 25, 377, DateTimeKind.Local).AddTicks(7025), new DateTime(2025, 8, 30, 13, 17, 25, 379, DateTimeKind.Local).AddTicks(5174), "a8b8a00d-3802-4dfb-b65b-7f330cf20701" });
        }
    }
}
