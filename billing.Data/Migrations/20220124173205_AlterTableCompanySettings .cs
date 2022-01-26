using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class AlterTableCompanySettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "company_settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "company_settings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now() at time zone 'utc'");

            migrationBuilder.AddColumn<string>(
                name: "face_book_id",
                table: "company_settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "instagram_id",
                table: "company_settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "company_settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_on",
                table: "company_settings",
                type: "timestamp without time zone",
                nullable: true,
                defaultValueSql: "now() at time zone 'utc'");

            migrationBuilder.AddColumn<string>(
                name: "u_id",
                table: "company_settings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "whats_app_number",
                table: "company_settings",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 24, 23, 2, 4, 880, DateTimeKind.Local).AddTicks(2478), new DateTime(2022, 1, 24, 23, 2, 4, 881, DateTimeKind.Local).AddTicks(1450), "bf1ee3c9-e460-4ba7-bde6-925ed62eb3d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "company_settings");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "company_settings");

            migrationBuilder.DropColumn(
                name: "face_book_id",
                table: "company_settings");

            migrationBuilder.DropColumn(
                name: "instagram_id",
                table: "company_settings");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "company_settings");

            migrationBuilder.DropColumn(
                name: "modified_on",
                table: "company_settings");

            migrationBuilder.DropColumn(
                name: "u_id",
                table: "company_settings");

            migrationBuilder.DropColumn(
                name: "whats_app_number",
                table: "company_settings");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 19, 13, 59, 50, 219, DateTimeKind.Local).AddTicks(5504), new DateTime(2022, 1, 19, 13, 59, 50, 220, DateTimeKind.Local).AddTicks(4400), "4f5eef3d-c348-401b-b865-9c5b09e4adba" });
        }
    }
}
