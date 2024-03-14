using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoCodes.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    AvailableViewCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentViewCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodeChangeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Column = table.Column<string>(type: "TEXT", nullable: false),
                    PreviousValue = table.Column<string>(type: "TEXT", nullable: false),
                    NewValue = table.Column<string>(type: "TEXT", nullable: false),
                    PromoCodeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeChangeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCodeChangeHistory_PromoCodes_PromoCodeId",
                        column: x => x.PromoCodeId,
                        principalTable: "PromoCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodeChangeHistory_PromoCodeId",
                table: "PromoCodeChangeHistory",
                column: "PromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_Name",
                table: "PromoCodes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromoCodeChangeHistory");

            migrationBuilder.DropTable(
                name: "PromoCodes");
        }
    }
}
