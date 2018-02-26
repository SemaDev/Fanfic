using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fanfic.Data.Migrations
{
    public partial class UpdateManytoMany1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Fanfics_FanficId",
                table: "FanficTag");

            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Tags_TagId",
                table: "FanficTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Fanfics_FanficId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tags_TagId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_FanficId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TagId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_FanficTag_FanficId",
                table: "FanficTag");

            migrationBuilder.DropIndex(
                name: "IX_FanficTag_TagId",
                table: "FanficTag");

            migrationBuilder.DropColumn(
                name: "FanficId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "FanficId",
                table: "FanficTag");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "FanficTag");

            migrationBuilder.CreateIndex(
                name: "IX_FanficTag_Id_Tag",
                table: "FanficTag",
                column: "Id_Tag");

            migrationBuilder.AddForeignKey(
                name: "FK_FanficTag_Fanfics_Id_Fanfic",
                table: "FanficTag",
                column: "Id_Fanfic",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FanficTag_Tags_Id_Tag",
                table: "FanficTag",
                column: "Id_Tag",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Fanfics_Id_Fanfic",
                table: "FanficTag");

            migrationBuilder.DropForeignKey(
                name: "FK_FanficTag_Tags_Id_Tag",
                table: "FanficTag");

            migrationBuilder.DropIndex(
                name: "IX_FanficTag_Id_Tag",
                table: "FanficTag");

            migrationBuilder.AddColumn<int>(
                name: "FanficId",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FanficId",
                table: "FanficTag",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "FanficTag",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_FanficId",
                table: "Tags",
                column: "FanficId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagId",
                table: "Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_FanficTag_FanficId",
                table: "FanficTag",
                column: "FanficId");

            migrationBuilder.CreateIndex(
                name: "IX_FanficTag_TagId",
                table: "FanficTag",
                column: "TagId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Fanfics_FanficId",
                table: "Tags",
                column: "FanficId",
                principalTable: "Fanfics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tags_TagId",
                table: "Tags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
