using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionLogEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppVersion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    OsVersion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    IsAndroid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MethodName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    ResponseLog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseEntity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogEntity");

            migrationBuilder.DropTable(
                name: "ResponseEntity");
        }
    }
}
