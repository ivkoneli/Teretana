using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanarine_Teretana_TeretanaID",
                table: "Clanarine");

            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Teretana_TeretanaID",
                table: "Termini");

            migrationBuilder.DropForeignKey(
                name: "FK_Treneri_Teretana_TeretanaID",
                table: "Treneri");

            migrationBuilder.DropColumn(
                name: "IDTeretane",
                table: "Treneri");

            migrationBuilder.DropColumn(
                name: "IDteretane",
                table: "Termini");

            migrationBuilder.DropColumn(
                name: "IDTeretane",
                table: "Clan");

            migrationBuilder.RenameColumn(
                name: "TeretanaID",
                table: "Treneri",
                newName: "teretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Treneri_TeretanaID",
                table: "Treneri",
                newName: "IX_Treneri_teretanaID");

            migrationBuilder.RenameColumn(
                name: "TeretanaID",
                table: "Termini",
                newName: "teretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Termini_TeretanaID",
                table: "Termini",
                newName: "IX_Termini_teretanaID");

            migrationBuilder.RenameColumn(
                name: "TeretanaID",
                table: "Clanarine",
                newName: "teretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Clanarine_TeretanaID",
                table: "Clanarine",
                newName: "IX_Clanarine_teretanaID");

            migrationBuilder.AddColumn<int>(
                name: "brlicence",
                table: "Treneri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teretanaID",
                table: "Clan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clan_teretanaID",
                table: "Clan",
                column: "teretanaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Teretana_teretanaID",
                table: "Clan",
                column: "teretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clanarine_Teretana_teretanaID",
                table: "Clanarine",
                column: "teretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_Teretana_teretanaID",
                table: "Termini",
                column: "teretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treneri_Teretana_teretanaID",
                table: "Treneri",
                column: "teretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Teretana_teretanaID",
                table: "Clan");

            migrationBuilder.DropForeignKey(
                name: "FK_Clanarine_Teretana_teretanaID",
                table: "Clanarine");

            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Teretana_teretanaID",
                table: "Termini");

            migrationBuilder.DropForeignKey(
                name: "FK_Treneri_Teretana_teretanaID",
                table: "Treneri");

            migrationBuilder.DropIndex(
                name: "IX_Clan_teretanaID",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "brlicence",
                table: "Treneri");

            migrationBuilder.DropColumn(
                name: "teretanaID",
                table: "Clan");

            migrationBuilder.RenameColumn(
                name: "teretanaID",
                table: "Treneri",
                newName: "TeretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Treneri_teretanaID",
                table: "Treneri",
                newName: "IX_Treneri_TeretanaID");

            migrationBuilder.RenameColumn(
                name: "teretanaID",
                table: "Termini",
                newName: "TeretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Termini_teretanaID",
                table: "Termini",
                newName: "IX_Termini_TeretanaID");

            migrationBuilder.RenameColumn(
                name: "teretanaID",
                table: "Clanarine",
                newName: "TeretanaID");

            migrationBuilder.RenameIndex(
                name: "IX_Clanarine_teretanaID",
                table: "Clanarine",
                newName: "IX_Clanarine_TeretanaID");

            migrationBuilder.AddColumn<int>(
                name: "IDTeretane",
                table: "Treneri",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDteretane",
                table: "Termini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDTeretane",
                table: "Clan",
                type: "int",
                maxLength: 12,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Clanarine_Teretana_TeretanaID",
                table: "Clanarine",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_Teretana_TeretanaID",
                table: "Termini",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treneri_Teretana_TeretanaID",
                table: "Treneri",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
