using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Migrations
{
    /// <inheritdoc />
    public partial class addrelationbetweenEntities5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksLists_Users_UserId",
                table: "TasksLists");

            migrationBuilder.DropIndex(
                name: "IX_TasksLists_UserId",
                table: "TasksLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TasksLists");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TasksLists",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TasksLists_UserId",
                table: "TasksLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksLists_Users_UserId",
                table: "TasksLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
