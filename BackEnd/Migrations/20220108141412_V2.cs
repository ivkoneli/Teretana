using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "brLicence",
                table: "Treneri",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrKartice",
                table: "Clan",
                type: "int",
                maxLength: 12,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pocetakTermina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    krajTermina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trenerID = table.Column<int>(type: "int", nullable: true),
                    clanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termini", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Termini_Clan_clanID",
                        column: x => x.clanID,
                        principalTable: "Clan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termini_Treneri_trenerID",
                        column: x => x.trenerID,
                        principalTable: "Treneri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Termini_clanID",
                table: "Termini",
                column: "clanID");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_trenerID",
                table: "Termini",
                column: "trenerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Termini");

            migrationBuilder.DropColumn(
                name: "brLicence",
                table: "Treneri");

            migrationBuilder.DropColumn(
                name: "BrKartice",
                table: "Clan");
        }
    }
}
