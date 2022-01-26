﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using billing.Data.DbContexts;

namespace billing.Data.Migrations
{
    [DbContext(typeof(BillingAppContext))]
    partial class BillingAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("billing.Data.Models.AdminAppLogs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Exception")
                        .HasColumnType("text")
                        .HasColumnName("exception");

                    b.Property<DateTime>("IssueAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("issue_at");

                    b.Property<string>("LogLevel")
                        .HasColumnType("text")
                        .HasColumnName("log_level");

                    b.Property<string>("Message")
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<string>("UId")
                        .HasColumnType("text")
                        .HasColumnName("u_id");

                    b.Property<string>("UserUId")
                        .HasColumnType("text")
                        .HasColumnName("user_u_id");

                    b.HasKey("Id")
                        .HasName("pk_admin_app_logs");

                    b.ToTable("admin_app_logs");
                });

            modelBuilder.Entity("billing.Data.Models.AdminUserRefreshToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime>("RefreshTokenExpiry")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("refresh_token_expiry");

                    b.Property<string>("UId")
                        .HasColumnType("text")
                        .HasColumnName("u_id");

                    b.Property<string>("UserUId")
                        .HasColumnType("text")
                        .HasColumnName("user_u_id");

                    b.HasKey("Id")
                        .HasName("pk_admin_user_refresh_token");

                    b.ToTable("admin_user_refresh_token");
                });

            modelBuilder.Entity("billing.Data.Models.CompanySettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("address1");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("address2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("district");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("FaceBookId")
                        .HasColumnType("text")
                        .HasColumnName("face_book_id");

                    b.Property<string>("InstagramId")
                        .HasColumnType("text")
                        .HasColumnName("instagram_id");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("logo");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("phone_no");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("state");

                    b.Property<string>("UId")
                        .HasColumnType("text")
                        .HasColumnName("u_id");

                    b.Property<string>("WhatsAppNumber")
                        .HasColumnType("text")
                        .HasColumnName("whats_app_number");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_company_settings");

                    b.ToTable("company_settings");
                });

            modelBuilder.Entity("billing.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<int>("Discount")
                        .HasColumnType("integer")
                        .HasColumnName("discount");

                    b.Property<string>("InvoiceDate")
                        .HasColumnType("text")
                        .HasColumnName("invoice_date");

                    b.Property<string>("InvoiceNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("invoice_no");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<int>("ServiceCharge")
                        .HasColumnType("integer")
                        .HasColumnName("service_charge");

                    b.Property<int>("SubTotal")
                        .HasMaxLength(10)
                        .HasColumnType("integer")
                        .HasColumnName("sub_total");

                    b.Property<int>("TotalAmount")
                        .HasMaxLength(10)
                        .HasColumnType("integer")
                        .HasColumnName("total_amount");

                    b.HasKey("Id")
                        .HasName("pk_invoice");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_invoice_customer_id");

                    b.ToTable("invoice");
                });

            modelBuilder.Entity("billing.Data.Models.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasMaxLength(10)
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<int>("InvoiceId")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("invoice_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("service_id");

                    b.HasKey("Id")
                        .HasName("pk_invoice_item");

                    b.HasIndex("InvoiceId")
                        .HasDatabaseName("ix_invoice_item_invoice_id");

                    b.HasIndex("ServiceId")
                        .HasDatabaseName("ix_invoice_item_service_id");

                    b.ToTable("invoice_item");
                });

            modelBuilder.Entity("billing.Data.Models.MstCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("phone_number");

                    b.Property<string>("UId")
                        .HasColumnType("text")
                        .HasColumnName("u_id");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("text")
                        .HasColumnName("vehicle_number");

                    b.HasKey("Id")
                        .HasName("pk_mst_customer");

                    b.ToTable("mst_customer");
                });

            modelBuilder.Entity("billing.Data.Models.MstService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("name");

                    b.Property<string>("UId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("u_id");

                    b.HasKey("Id")
                        .HasName("pk_mst_service");

                    b.ToTable("mst_service");
                });

            modelBuilder.Entity("billing.Data.Models.MstUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email_id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("full_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("mobile_no");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_on")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_salt");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text")
                        .HasColumnName("profile_image");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<string>("UId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("u_id");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_mst_user");

                    b.HasIndex("RoleId")
                        .IsUnique()
                        .HasDatabaseName("ix_mst_user_role_id");

                    b.ToTable("mst_user");
                });

            modelBuilder.Entity("billing.Data.Models.MstUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("ShortName")
                        .HasColumnType("text")
                        .HasColumnName("short_name");

                    b.Property<string>("UId")
                        .HasColumnType("text")
                        .HasColumnName("u_id");

                    b.HasKey("Id")
                        .HasName("pk_mst_user_role");

                    b.ToTable("mst_user_role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "test",
                            CreatedOn = new DateTime(2022, 1, 26, 9, 25, 57, 0, DateTimeKind.Local).AddTicks(3514),
                            IsActive = true,
                            ModifiedBy = "asda",
                            ModifiedOn = new DateTime(2022, 1, 26, 9, 25, 57, 1, DateTimeKind.Local).AddTicks(864),
                            Name = "admin",
                            ShortName = "Ad",
                            UId = "776c51c2-afbf-4fe3-8c39-805069415b2c"
                        });
                });

            modelBuilder.Entity("billing.Data.Models.Invoice", b =>
                {
                    b.HasOne("billing.Data.Models.MstCustomer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("fk_invoice_mst_customer_customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("billing.Data.Models.InvoiceItem", b =>
                {
                    b.HasOne("billing.Data.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("fk_invoice_item_invoice_invoice_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billing.Data.Models.MstService", "Service")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("fk_invoice_item_mst_service_service_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("billing.Data.Models.MstUser", b =>
                {
                    b.HasOne("billing.Data.Models.MstUserRole", "Role")
                        .WithOne("User")
                        .HasForeignKey("billing.Data.Models.MstUser", "RoleId")
                        .HasConstraintName("fk_mst_user_mst_user_role_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("billing.Data.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("billing.Data.Models.MstCustomer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("billing.Data.Models.MstService", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("billing.Data.Models.MstUserRole", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
