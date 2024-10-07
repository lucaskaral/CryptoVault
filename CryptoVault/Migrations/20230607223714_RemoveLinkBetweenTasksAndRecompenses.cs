using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoVault.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLinkBetweenTasksAndRecompenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recompenses_Tasks_TaskId",
                table: "Recompenses");

            migrationBuilder.DropIndex(
                name: "IX_Recompenses_TaskId",
                table: "Recompenses");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Recompenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "Recompenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recompenses_TaskId",
                table: "Recompenses",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recompenses_Tasks_TaskId",
                table: "Recompenses",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
