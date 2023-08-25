using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Secure.Application.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class RegisterMockWSDLSqlSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseWsdls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BucketId = table.Column<int>(type: "int", nullable: true),
                    BucketName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsRnR = table.Column<bool>(type: "bit", nullable: true),
                    RnRText = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseWsdls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionsLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ResponseWsdlsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsLists_ResponseWsdls_ResponseWsdlsId",
                        column: x => x.ResponseWsdlsId,
                        principalTable: "ResponseWsdls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionsLists_ResponseWsdlsId",
                table: "OptionsLists",
                column: "ResponseWsdlsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionsLists");

            migrationBuilder.DropTable(
                name: "ResponseWsdls");
        }
    }
}
