using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp_TT.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "СryptoRate",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxSupply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marketCapUsd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    volumeUsd24Hr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priceUsd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    changePercent24Hr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vwap24Hr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    explorer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_СryptoRate", x => x.id);
                    table.ForeignKey(
                        name: "FK_СryptoRate_Account_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Account",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "id", "Email", "Password" },
                values: new object[] { 1, "admin@example.com", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_СryptoRate_AccountsId",
                table: "СryptoRate",
                column: "AccountsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "СryptoRate");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
