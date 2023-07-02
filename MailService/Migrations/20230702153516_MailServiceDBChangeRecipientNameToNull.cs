using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailService.Migrations
{
    public partial class MailServiceDBChangeRecipientNameToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipient",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 2, 18, 35, 15, 924, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 2, 18, 35, 15, 924, DateTimeKind.Local).AddTicks(3343));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipient",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 1, 20, 9, 30, 935, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 1, 20, 9, 30, 935, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.InsertData(
                table: "Recipient",
                columns: new[] { "Id", "EmailAddress", "MailId", "Name" },
                values: new object[] { 1, "username@example.ru", 2, "Иванов И.И." });

            migrationBuilder.InsertData(
                table: "Recipient",
                columns: new[] { "Id", "EmailAddress", "MailId", "Name" },
                values: new object[] { 2, "username1@example.com", 1, "Lee Sam" });
        }
    }
}
