using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class AlterTableInvoiceAddedNewColumnInvoiceDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "invoice_date",
                table: "invoice",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 24, 23, 40, 35, 184, DateTimeKind.Local).AddTicks(2214), new DateTime(2022, 1, 24, 23, 40, 35, 185, DateTimeKind.Local).AddTicks(852), "76b4a824-3ae4-4258-a168-50f2c0972b6b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "invoice_date",
                table: "invoice");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 24, 23, 2, 4, 880, DateTimeKind.Local).AddTicks(2478), new DateTime(2022, 1, 24, 23, 2, 4, 881, DateTimeKind.Local).AddTicks(1450), "bf1ee3c9-e460-4ba7-bde6-925ed62eb3d5" });
        }
    }
}
