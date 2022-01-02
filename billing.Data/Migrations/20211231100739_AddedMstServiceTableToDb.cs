using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace billing.Data.Migrations
{
    public partial class AddedMstServiceTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_service",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    s_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<bool>(type: "boolean", maxLength: 300, nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now() at time zone 'utc'"),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now() at time zone 'utc'"),
                    modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_service", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2021, 12, 31, 15, 37, 39, 41, DateTimeKind.Local).AddTicks(9607), new DateTime(2021, 12, 31, 15, 37, 39, 42, DateTimeKind.Local).AddTicks(8097), "4222100d-ea9d-42b0-9b58-f02e5fcbe030" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mst_service");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2021, 12, 25, 23, 7, 49, 75, DateTimeKind.Local).AddTicks(5003), new DateTime(2021, 12, 25, 23, 7, 49, 76, DateTimeKind.Local).AddTicks(3376), "5e2d0aab-ba56-47b9-a2ad-90854a33c873" });
        }
    }
}
