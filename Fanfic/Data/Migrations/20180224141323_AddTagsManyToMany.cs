using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fanfic.Data.Migrations
{
    public partial class AddTagsManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Fanfics_FanficId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Janre_Fanfics_FanficId",
                table: "Janre");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Chapter_ChapterId",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Fanfics_FanficId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Janre",
                table: "Janre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Janre",
                newName: "Janres");

            migrationBuilder.RenameTable(
                name: "Chapter",
                newName: "Chapters");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_FanficId",
                table: "Tags",
                newName: "IX_Tags_FanficId");

            migrationBuilder.RenameIndex(
                name: "IX_Janre_FanficId",
                table: "Janres",
                newName: "IX_Janres_FanficId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapter_FanficId",
                table: "Chapters",
                newName: "IX_Chapters_FanficId");

            migrationBuilder.AddColumn<int>(
                name: "Id_Tag",
                table: "Fanfics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Janres",
                table: "Janres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Fanfics_FanficId",
                table: "Chapters",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Janres_Fanfics_FanficId",
                table: "Janres",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Chapters_ChapterId",
                table: "Rate",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Fanfics_FanficId",
                table: "Tags",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Fanfics_FanficId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Janres_Fanfics_FanficId",
                table: "Janres");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Chapters_ChapterId",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Fanfics_FanficId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Janres",
                table: "Janres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "Id_Tag",
                table: "Fanfics");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Janres",
                newName: "Janre");

            migrationBuilder.RenameTable(
                name: "Chapters",
                newName: "Chapter");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_FanficId",
                table: "Tag",
                newName: "IX_Tag_FanficId");

            migrationBuilder.RenameIndex(
                name: "IX_Janres_FanficId",
                table: "Janre",
                newName: "IX_Janre_FanficId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapters_FanficId",
                table: "Chapter",
                newName: "IX_Chapter_FanficId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Janre",
                table: "Janre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Fanfics_FanficId",
                table: "Chapter",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Janre_Fanfics_FanficId",
                table: "Janre",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Chapter_ChapterId",
                table: "Rate",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Fanfics_FanficId",
                table: "Tag",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
