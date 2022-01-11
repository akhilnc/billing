using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace billing.Data.Migrations
{
    public partial class AddedInvoiceTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoice_no = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    discount = table.Column<int>(type: "integer", nullable: false),
                    sub_total = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    total_amount = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now() at time zone 'utc'"),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now() at time zone 'utc'"),
                    modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invoice", x => x.id);
                    table.ForeignKey(
                        name: "fk_invoice_mst_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "mst_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    service_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    invoice_id = table.Column<int>(type: "integer", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invoice_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_invoice_item_invoice_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_invoice_item_mst_service_service_id",
                        column: x => x.service_id,
                        principalTable: "mst_service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 10, 17, 28, 25, 576, DateTimeKind.Local).AddTicks(9772), new DateTime(2022, 1, 10, 17, 28, 25, 579, DateTimeKind.Local).AddTicks(5896), "7a46bf9b-ad59-4977-ad77-94071cfd8a85" });

            migrationBuilder.CreateIndex(
                name: "ix_invoice_customer_id",
                table: "invoice",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_invoice_item_invoice_id",
                table: "invoice_item",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "ix_invoice_item_service_id",
                table: "invoice_item",
                column: "service_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_item");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.UpdateData(
                table: "mst_user_role",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_on", "modified_on", "u_id" },
                values: new object[] { new DateTime(2022, 1, 4, 7, 52, 29, 276, DateTimeKind.Local).AddTicks(6584), new DateTime(2022, 1, 4, 7, 52, 29, 277, DateTimeKind.Local).AddTicks(5345), "2963b4b7-d526-4de2-9405-d9144fbf6fd5" });
        }
    }
}
