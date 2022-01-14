using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billing.Data.Migrations
{
    public partial class addedColumnServiceChargeInInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "service_charge",
                table: "invoice",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 14, 19, 13, 29, 499, DateTimeKind.Local).AddTicks(2778), new DateTime(2022, 1, 14, 19, 13, 29, 500, DateTimeKind.Local).AddTicks(3607), "d49648f6-6ccd-495b-88cb-b9dfa3c1a066" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "service_charge",
                table: "invoice");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 10, 17, 28, 25, 576, DateTimeKind.Local).AddTicks(9772), new DateTime(2022, 1, 10, 17, 28, 25, 579, DateTimeKind.Local).AddTicks(5896), "7a46bf9b-ad59-4977-ad77-94071cfd8a85" });
        }
    }
}
