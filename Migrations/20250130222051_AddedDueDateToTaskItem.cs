using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTaskManager.Migrations
{
    /// <inheritdoc />
    public partial class AddedDueDateToTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dueDate",
                table: "TaskItem",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dueDate",
                table: "TaskItem");
        }
    }
}
