using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations.AppDb
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("514229af-b1a1-44cf-a8bd-0057ba74a82d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("de2029f5-5a8a-44fc-8dc8-11867af30aff"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("8c7431ed-aa8d-4fc7-a5ef-8ddabfcef029"), new Guid("9bd797a0-812d-4ead-b3a4-e549336f6e6f"), "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "56c089e4-d413-42c4-aff3-3a5e84336dfc", new DateTime(2023, 8, 29, 11, 30, 29, 947, DateTimeKind.Local).AddTicks(8524), null, null, new Guid("9324be78-0522-499f-97a2-bc8b5af88abc"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 },
                    { new Guid("cbc688d3-e3ac-4fb1-9494-4721374b81d6"), new Guid("aeb70f85-9272-4c29-b71e-7dd2a4fdf3f9"), "Asp.Net Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "56c089e4-d413-42c4-aff3-3a5e84336dfc", new DateTime(2023, 8, 29, 11, 30, 29, 947, DateTimeKind.Local).AddTicks(8515), null, null, new Guid("659e7a9f-96e8-4b89-9a9a-6c27de62a083"), false, null, null, "Asp.Net Core Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9bd797a0-812d-4ead-b3a4-e549336f6e6f"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "8c2de2a2-9825-4626-ba41-43d0661f5e62", new DateTime(2023, 8, 29, 11, 30, 29, 947, DateTimeKind.Local).AddTicks(8637) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aeb70f85-9272-4c29-b71e-7dd2a4fdf3f9"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "8c2de2a2-9825-4626-ba41-43d0661f5e62", new DateTime(2023, 8, 29, 11, 30, 29, 947, DateTimeKind.Local).AddTicks(8634) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("659e7a9f-96e8-4b89-9a9a-6c27de62a083"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "8c2de2a2-9825-4626-ba41-43d0661f5e62", new DateTime(2023, 8, 29, 11, 30, 29, 947, DateTimeKind.Local).AddTicks(8684) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9324be78-0522-499f-97a2-bc8b5af88abc"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "8c2de2a2-9825-4626-ba41-43d0661f5e62", new DateTime(2023, 8, 29, 11, 30, 29, 947, DateTimeKind.Local).AddTicks(8687) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8c7431ed-aa8d-4fc7-a5ef-8ddabfcef029"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cbc688d3-e3ac-4fb1-9494-4721374b81d6"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("514229af-b1a1-44cf-a8bd-0057ba74a82d"), new Guid("aeb70f85-9272-4c29-b71e-7dd2a4fdf3f9"), "Asp.Net Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "56c089e4-d413-42c4-aff3-3a5e84336dfc", new DateTime(2023, 8, 29, 7, 47, 13, 742, DateTimeKind.Local).AddTicks(766), null, null, new Guid("659e7a9f-96e8-4b89-9a9a-6c27de62a083"), false, null, null, "Asp.Net Core Deneme Makalesi 1", 15 },
                    { new Guid("de2029f5-5a8a-44fc-8dc8-11867af30aff"), new Guid("9bd797a0-812d-4ead-b3a4-e549336f6e6f"), "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "56c089e4-d413-42c4-aff3-3a5e84336dfc", new DateTime(2023, 8, 29, 7, 47, 13, 742, DateTimeKind.Local).AddTicks(813), null, null, new Guid("9324be78-0522-499f-97a2-bc8b5af88abc"), false, null, null, "Visual Studio Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9bd797a0-812d-4ead-b3a4-e549336f6e6f"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin Test", new DateTime(2023, 8, 29, 7, 47, 13, 742, DateTimeKind.Local).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aeb70f85-9272-4c29-b71e-7dd2a4fdf3f9"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin Test", new DateTime(2023, 8, 29, 7, 47, 13, 742, DateTimeKind.Local).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("659e7a9f-96e8-4b89-9a9a-6c27de62a083"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin test", new DateTime(2023, 8, 29, 7, 47, 13, 742, DateTimeKind.Local).AddTicks(1004) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9324be78-0522-499f-97a2-bc8b5af88abc"),
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin test", new DateTime(2023, 8, 29, 7, 47, 13, 742, DateTimeKind.Local).AddTicks(1007) });
        }
    }
}
