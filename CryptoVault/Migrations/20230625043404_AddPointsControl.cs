using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoVault.Migrations
{
    /// <inheritdoc />
    public partial class AddPointsControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Points",
                table: "Recompenses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "UsersTotalizers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    totalPoints = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTotalizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersTotalizers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersTotalizers_UserId",
                table: "UsersTotalizers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersTotalizers");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Recompenses");
        }
    }
}
