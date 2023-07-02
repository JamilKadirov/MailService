using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailService.Migrations
{
    public partial class MailServiceDBConvertResultToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Mails",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Result" },
                values: new object[] { new DateTime(2023, 7, 1, 20, 9, 30, 935, DateTimeKind.Local).AddTicks(1654), "OK" });

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Result" },
                values: new object[] { new DateTime(2023, 7, 1, 20, 9, 30, 935, DateTimeKind.Local).AddTicks(1674), "Failed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Result",
                table: "Mails",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Result" },
                values: new object[] { new DateTime(2023, 7, 1, 19, 43, 35, 516, DateTimeKind.Local).AddTicks(4172), 0 });

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Result" },
                values: new object[] { new DateTime(2023, 7, 1, 19, 43, 35, 516, DateTimeKind.Local).AddTicks(4185), 1 });
        }
    }
}
