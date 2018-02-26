using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fanfic.Data.Migrations
{
    public partial class AddTagsManyToMany5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FanficTag",
                columns: table => new
                {
                    Id_Fanfic = table.Column<int>(nullable: false),
                    Id_Tag = table.Column<int>(nullable: false),
                    FanficId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanficTag", x => new { x.Id_Fanfic, x.Id_Tag });
                    table.ForeignKey(
                        name: "FK_FanficTag_Fanfics_FanficId",
                        column: x => x.FanficId,
                        principalTable: "Fanfics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FanficTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FanficTag_FanficId",
                table: "FanficTag",
                column: "FanficId");

            migrationBuilder.CreateIndex(
                name: "IX_FanficTag_TagId",
                table: "FanficTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FanficTag");
        }
    }
}
