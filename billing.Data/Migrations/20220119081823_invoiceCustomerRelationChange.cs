using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class invoiceCustomerRelationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_invoice_customer_id",
                table: "invoice");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 19, 13, 48, 23, 441, DateTimeKind.Local).AddTicks(7147), new DateTime(2022, 1, 19, 13, 48, 23, 442, DateTimeKind.Local).AddTicks(6850), "47589358-7431-41ec-98ba-280def9329bf" });

            migrationBuilder.CreateIndex(
                name: "ix_invoice_customer_id",
                table: "invoice",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_invoice_customer_id",
                table: "invoice");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 19, 13, 42, 39, 904, DateTimeKind.Local).AddTicks(6622), new DateTime(2022, 1, 19, 13, 42, 39, 905, DateTimeKind.Local).AddTicks(7651), "b0384423-c669-42ee-a0cf-82412fee6133" });

            migrationBuilder.CreateIndex(
                name: "ix_invoice_customer_id",
                table: "invoice",
                column: "customer_id",
                unique: true);
        }
    }
}
