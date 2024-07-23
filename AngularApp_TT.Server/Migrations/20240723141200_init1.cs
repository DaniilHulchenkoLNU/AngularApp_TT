using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp_TT.Server.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_СryptoRate_Account_Accountsid",
                table: "СryptoRate");

            migrationBuilder.RenameColumn(
                name: "Accountsid",
                table: "СryptoRate",
                newName: "AccountsId");

            migrationBuilder.RenameIndex(
                name: "IX_СryptoRate_Accountsid",
                table: "СryptoRate",
                newName: "IX_СryptoRate_AccountsId");

            migrationBuilder.AlterColumn<int>(
                name: "AccountsId",
                table: "СryptoRate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_СryptoRate_Account_AccountsId",
                table: "СryptoRate",
                column: "AccountsId",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_СryptoRate_Account_AccountsId",
                table: "СryptoRate");

            migrationBuilder.RenameColumn(
                name: "AccountsId",
                table: "СryptoRate",
                newName: "Accountsid");

            migrationBuilder.RenameIndex(
                name: "IX_СryptoRate_AccountsId",
                table: "СryptoRate",
                newName: "IX_СryptoRate_Accountsid");

            migrationBuilder.AlterColumn<int>(
                name: "Accountsid",
                table: "СryptoRate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_СryptoRate_Account_Accountsid",
                table: "СryptoRate",
                column: "Accountsid",
                principalTable: "Account",
                principalColumn: "id");
        }
    }
}
