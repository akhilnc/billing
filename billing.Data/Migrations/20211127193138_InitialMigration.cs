using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace billing.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_app_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    exception = table.Column<string>(type: "text", nullable: true),
                    user_u_id = table.Column<string>(type: "text", nullable: true),
                    log_level = table.Column<string>(type: "text", nullable: true),
                    issue_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admin_app_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "admin_user_refresh_token",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: true),
                    user_u_id = table.Column<string>(type: "text", nullable: true),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    refresh_token_expiry = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admin_user_refresh_token", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mst_user_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_by = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_user_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mst_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    u_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    email_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    password_salt = table.Column<string>(type: "text", nullable: false),
                    profile_image = table.Column<string>(type: "text", nullable: true),
                    mobile_no = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now() at time zone 'utc'"),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now() at time zone 'utc'"),
                    modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_mst_user_mst_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "mst_user_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "mst_user_role",
                columns: new[] { "id", "created_by", "created_on", "is_active", "modified_by", "modified_on", "name", "short_name", "u_id" },
                values: new object[] { 1, "test", new DateTime(2021, 11, 28, 1, 1, 37, 867, DateTimeKind.Local).AddTicks(5039), true, "asda", new DateTime(2021, 11, 28, 1, 1, 37, 868, DateTimeKind.Local).AddTicks(2117), "admin", "Ad", "72b0799c-a635-4080-acce-de2b3cec8551" });

            migrationBuilder.CreateIndex(
                name: "ix_mst_user_role_id",
                table: "mst_user",
                column: "role_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_app_logs");

            migrationBuilder.DropTable(
                name: "admin_user_refresh_token");

            migrationBuilder.DropTable(
                name: "mst_user");

            migrationBuilder.DropTable(
                name: "mst_user_role");
        }
    }
}
