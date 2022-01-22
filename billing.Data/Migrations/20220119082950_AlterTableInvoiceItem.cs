using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class AlterTableInvoiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "invoice_item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 19, 13, 59, 50, 219, DateTimeKind.Local).AddTicks(5504), new DateTime(2022, 1, 19, 13, 59, 50, 220, DateTimeKind.Local).AddTicks(4400), "4f5eef3d-c348-401b-b865-9c5b09e4adba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "invoice_item");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 19, 13, 48, 23, 441, DateTimeKind.Local).AddTicks(7147), new DateTime(2022, 1, 19, 13, 48, 23, 442, DateTimeKind.Local).AddTicks(6850), "47589358-7431-41ec-98ba-280def9329bf" });
        }
    }
}
