using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LamdaForum.Core.Migrations
{
    public partial class AddedPostIdtoPostReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "PostReplies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "PostReplies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
