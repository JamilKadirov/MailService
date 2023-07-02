using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailService.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Mails_MailId",
                table: "Recipient");

            migrationBuilder.AlterColumn<int>(
                name: "MailId",
                table: "Recipient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "Id", "Body", "CreatedAt", "FailedMessage", "Result", "Subject" },
                values: new object[] { 1, "Here's to be a CTA text or some random text", new DateTime(2023, 7, 1, 19, 43, 35, 516, DateTimeKind.Local).AddTicks(4172), "", 0, "The best subject ever" });

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "Id", "Body", "CreatedAt", "FailedMessage", "Result", "Subject" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed quis nisl vitae nisi tincidunt pretium. Phasellus auctor, magna id consequat malesuada, leo augue mattis massa, quis aliquet sapien nisi quis nunc", new DateTime(2023, 7, 1, 19, 43, 35, 516, DateTimeKind.Local).AddTicks(4185), "", 1, "Самый продающий текст" });

            migrationBuilder.InsertData(
                table: "Recipient",
                columns: new[] { "Id", "EmailAddress", "MailId", "Name" },
                values: new object[] { 1, "username@example.ru", 2, "Иванов И.И." });

            migrationBuilder.InsertData(
                table: "Recipient",
                columns: new[] { "Id", "EmailAddress", "MailId", "Name" },
                values: new object[] { 2, "username1@example.com", 1, "Lee Sam" });

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Mails_MailId",
                table: "Recipient",
                column: "MailId",
                principalTable: "Mails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Mails_MailId",
                table: "Recipient");

            migrationBuilder.DeleteData(
                table: "Recipient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "MailId",
                table: "Recipient",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Mails_MailId",
                table: "Recipient",
                column: "MailId",
                principalTable: "Mails",
                principalColumn: "Id");
        }
    }
}
