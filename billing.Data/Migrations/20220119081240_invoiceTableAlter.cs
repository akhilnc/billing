using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class invoiceTableAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_invoice_item_service_id",
                table: "invoice_item");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 19, 13, 42, 39, 904, DateTimeKind.Local).AddTicks(6622), new DateTime(2022, 1, 19, 13, 42, 39, 905, DateTimeKind.Local).AddTicks(7651), "b0384423-c669-42ee-a0cf-82412fee6133" });

            migrationBuilder.CreateIndex(
                name: "ix_invoice_item_service_id",
                table: "invoice_item",
                column: "service_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_invoice_item_service_id",
                table: "invoice_item");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 14, 19, 13, 29, 499, DateTimeKind.Local).AddTicks(2778), new DateTime(2022, 1, 14, 19, 13, 29, 500, DateTimeKind.Local).AddTicks(3607), "d49648f6-6ccd-495b-88cb-b9dfa3c1a066" });

            migrationBuilder.CreateIndex(
                name: "ix_invoice_item_service_id",
                table: "invoice_item",
                column: "service_id",
                unique: true);
        }
    }
}
