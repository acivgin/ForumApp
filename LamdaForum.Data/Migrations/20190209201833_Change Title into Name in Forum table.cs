using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LamdaForum.Core.Migrations
{
    public partial class ChangeTitleintoNameinForumtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Forums");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Forums",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Forums");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Forums",
                nullable: true);
        }
    }
}
