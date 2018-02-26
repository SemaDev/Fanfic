using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fanfic.Data.Migrations
{
    public partial class removeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Fanfics_FanficId",
                table: "FanficTag");

            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Tags_TagId",
                table: "FanficTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FanficTag",
                table: "FanficTag");

            migrationBuilder.DropIndex(
                name: "IX_FanficTag_FanficId",
                table: "FanficTag");

            migrationBuilder.DropColumn(
                name: "Id_ApplicationUser",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "Id_Chapter",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "Id_Fanfic",
                table: "FanficTag");

            migrationBuilder.DropColumn(
                name: "Id_Tag",
                table: "FanficTag");

            migrationBuilder.DropColumn(
                name: "Id_ApplicationUser",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "Id_Janre",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "Id_ApplicationUser",
                table: "CommentLike");

            migrationBuilder.DropColumn(
                name: "Id_Comment",
                table: "CommentLike");

            migrationBuilder.DropColumn(
                name: "Id_ApplicationUser",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Id_Fanfic",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Id_Fanfic",
                table: "Chapters");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "FanficTag",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FanficId",
                table: "FanficTag",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FanficTag",
                table: "FanficTag",
                columns: new[] { "FanficId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FanficTag_Fanfics_FanficId",
                table: "FanficTag",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FanficTag_Tags_TagId",
                table: "FanficTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Fanfics_FanficId",
                table: "FanficTag");

            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Tags_TagId",
                table: "FanficTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FanficTag",
                table: "FanficTag");

            migrationBuilder.AddColumn<int>(
                name: "Id_ApplicationUser",
                table: "Rate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Chapter",
                table: "Rate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "FanficTag",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FanficId",
                table: "FanficTag",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id_Fanfic",
                table: "FanficTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Tag",
                table: "FanficTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_ApplicationUser",
                table: "Fanfics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Janre",
                table: "Fanfics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_ApplicationUser",
                table: "CommentLike",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Comment",
                table: "CommentLike",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_ApplicationUser",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Fanfic",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Fanfic",
                table: "Chapters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FanficTag",
                table: "FanficTag",
                columns: new[] { "Id_Fanfic", "Id_Tag" });

            migrationBuilder.CreateIndex(
                name: "IX_FanficTag_FanficId",
                table: "FanficTag",
                column: "FanficId");

            migrationBuilder.AddForeignKey(
                name: "FK_FanficTag_Fanfics_FanficId",
                table: "FanficTag",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FanficTag_Tags_TagId",
                table: "FanficTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
