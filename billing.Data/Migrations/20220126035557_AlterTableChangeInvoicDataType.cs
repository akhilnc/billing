using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class AlterTableChangeInvoicDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "invoice_date",
                table: "invoice",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 26, 9, 25, 57, 0, DateTimeKind.Local).AddTicks(3514), new DateTime(2022, 1, 26, 9, 25, 57, 1, DateTimeKind.Local).AddTicks(864), "776c51c2-afbf-4fe3-8c39-805069415b2c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "invoice_date",
                table: "invoice",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 24, 23, 40, 35, 184, DateTimeKind.Local).AddTicks(2214), new DateTime(2022, 1, 24, 23, 40, 35, 185, DateTimeKind.Local).AddTicks(852), "76b4a824-3ae4-4258-a168-50f2c0972b6b" });
        }
    }
}
