using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class removedkm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2025, 8, 30, 13, 17, 25, 377, DateTimeKind.Local).AddTicks(7025), new DateTime(2025, 8, 30, 13, 17, 25, 379, DateTimeKind.Local).AddTicks(5174), "a8b8a00d-3802-4dfb-b65b-7f330cf20701" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 3, 19, 13, 39, 36, 60, DateTimeKind.Local).AddTicks(3535), new DateTime(2022, 3, 19, 13, 39, 36, 61, DateTimeKind.Local).AddTicks(3581), "c6902963-bcac-41e5-b77d-a4463b59e683" });
        }
    }
}
