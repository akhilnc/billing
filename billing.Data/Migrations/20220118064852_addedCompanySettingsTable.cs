using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace billing.Data.Migrations
{
    public partial class addedCompanySettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone_no = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    logo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    district = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    zip_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_settings", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 18, 12, 18, 52, 235, DateTimeKind.Local).AddTicks(67), new DateTime(2022, 1, 18, 12, 18, 52, 236, DateTimeKind.Local).AddTicks(1220), "2763f39c-4b77-47f0-8b3d-9c260eff98fd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company_settings");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 14, 19, 13, 29, 499, DateTimeKind.Local).AddTicks(2778), new DateTime(2022, 1, 14, 19, 13, 29, 500, DateTimeKind.Local).AddTicks(3607), "d49648f6-6ccd-495b-88cb-b9dfa3c1a066" });
        }
    }
}
