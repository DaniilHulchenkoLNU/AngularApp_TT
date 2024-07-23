using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp_TT.Server.Migrations
{
    /// <inheritdoc />
    public partial class idtoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Account",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "СryptoRate",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Account",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "СryptoRate",
                newName: "id");
        }
    }
}
