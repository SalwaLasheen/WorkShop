using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentation.Application.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSqlSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ResponseEntity");

            migrationBuilder.DropColumn(
                name: "ResponseLog",
                table: "ResponseEntity");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ActionLogEntity");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ActionLogEntity");

            migrationBuilder.AlterColumn<string>(
                name: "MethodName",
                table: "ResponseEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorCode",
                table: "ResponseEntity",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "ResponseEntity",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChannelName",
                table: "ActionLogEntity",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dial",
                table: "ActionLogEntity",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                table: "ActionLogEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorCode",
                table: "ResponseEntity");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "ResponseEntity");

            migrationBuilder.DropColumn(
                name: "ChannelName",
                table: "ActionLogEntity");

            migrationBuilder.DropColumn(
                name: "Dial",
                table: "ActionLogEntity");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "ActionLogEntity");

            migrationBuilder.AlterColumn<string>(
                name: "MethodName",
                table: "ResponseEntity",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ResponseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseLog",
                table: "ResponseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ActionLogEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogEntity",
                type: "datetime2",
                nullable: true);
        }
    }
}
