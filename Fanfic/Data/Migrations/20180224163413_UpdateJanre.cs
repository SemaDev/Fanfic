using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fanfic.Data.Migrations
{
    public partial class UpdateJanre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Fanfics_JanreId",
                table: "Fanfics");

            migrationBuilder.DropColumn(
                name: "Id_Fanfic",
                table: "Janres");

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "Janres",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Fanfics_JanreId",
                table: "Fanfics",
                column: "JanreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Fanfics_JanreId",
                table: "Fanfics");

            migrationBuilder.AlterColumn<int>(
                name: "Caption",
                table: "Janres",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Fanfic",
                table: "Janres",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fanfics_JanreId",
                table: "Fanfics",
                column: "JanreId",
                unique: true,
                filter: "[JanreId] IS NOT NULL");
        }
    }
}
