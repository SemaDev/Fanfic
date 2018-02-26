using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fanfic.Data.Migrations
{
    public partial class AddTagsManyToMany3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Janres_Fanfics_FanficId",
                table: "Janres");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Fanfics_FanficId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_FanficId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Janres_FanficId",
                table: "Janres");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "FanficId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Id_Fanfic",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "FanficId",
                table: "Janres");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Fanfics");

            migrationBuilder.RenameColumn(
                name: "Id_Tag",
                table: "Fanfics",
                newName: "Id_Janre");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JanreId",
                table: "Fanfics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fanfics_JanreId",
                table: "Fanfics",
                column: "JanreId",
                unique: true,
                filter: "[JanreId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Fanfics_Janres_JanreId",
                table: "Fanfics",
                column: "JanreId",
                principalTable: "Janres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fanfics_Janres_JanreId",
                table: "Fanfics");

            migrationBuilder.DropIndex(
                name: "IX_Fanfics_JanreId",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "JanreId",
                table: "Fanfics");

            migrationBuilder.RenameColumn(
                name: "Id_Janre",
                table: "Fanfics",
                newName: "Id_Tag");

            migrationBuilder.AddColumn<int>(
                name: "Caption",
                table: "Tags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FanficId",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Fanfic",
                table: "Tags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FanficId",
                table: "Janres",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Fanfics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tags_FanficId",
                table: "Tags",
                column: "FanficId");

            migrationBuilder.CreateIndex(
                name: "IX_Janres_FanficId",
                table: "Janres",
                column: "FanficId");

            migrationBuilder.AddForeignKey(
                name: "FK_Janres_Fanfics_FanficId",
                table: "Janres",
                column: "FanficId",
                principalTable: "Fanfics",
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
    }
}
