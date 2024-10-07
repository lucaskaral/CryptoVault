using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoVault.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkBetweenUserDependentWithRecompenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Recompenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recompenses_UserId",
                table: "Recompenses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recompenses_Users_UserId",
                table: "Recompenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recompenses_Users_UserId",
                table: "Recompenses");

            migrationBuilder.DropIndex(
                name: "IX_Recompenses_UserId",
                table: "Recompenses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recompenses");
        }
    }
}
