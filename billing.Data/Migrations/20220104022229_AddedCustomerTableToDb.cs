using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace billing.Data.Migrations
{
    public partial class AddedCustomerTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_number = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_customer", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 4, 7, 52, 29, 276, DateTimeKind.Local).AddTicks(6584), new DateTime(2022, 1, 4, 7, 52, 29, 277, DateTimeKind.Local).AddTicks(5345), "2963b4b7-d526-4de2-9405-d9144fbf6fd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mst_customer");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2021, 12, 31, 18, 26, 37, 639, DateTimeKind.Local).AddTicks(3964), new DateTime(2021, 12, 31, 18, 26, 37, 640, DateTimeKind.Local).AddTicks(1340), "e1c69f61-1b37-4914-81ba-08637f85c5df" });
        }
    }
}
