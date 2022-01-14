using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Clanarine_clanarinaID",
                table: "Clan");

            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Treneri_trenerID",
                table: "Clan");

            migrationBuilder.RenameColumn(
                name: "brLicence",
                table: "Treneri",
                newName: "IDTeretane");

            migrationBuilder.RenameColumn(
                name: "BrKartice",
                table: "Clan",
                newName: "IDTeretane");

            migrationBuilder.AddColumn<int>(
                name: "TeretanaID",
                table: "Treneri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDteretane",
                table: "Termini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeretanaID",
                table: "Termini",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDTeretane",
                table: "Clanarine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeretanaID",
                table: "Clanarine",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "trenerID",
                table: "Clan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clanarinaID",
                table: "Clan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Teretana",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teretana", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treneri_TeretanaID",
                table: "Treneri",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_TeretanaID",
                table: "Termini",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Clanarine_TeretanaID",
                table: "Clanarine",
                column: "TeretanaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Clanarine_clanarinaID",
                table: "Clan",
                column: "clanarinaID",
                principalTable: "Clanarine",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Treneri_trenerID",
                table: "Clan",
                column: "trenerID",
                principalTable: "Treneri",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Clanarine_clanarinaID",
                table: "Clan");

            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Treneri_trenerID",
                table: "Clan");

            migrationBuilder.DropForeignKey(
                name: "FK_Clanarine_Teretana_TeretanaID",
                table: "Clanarine");

            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Teretana_TeretanaID",
                table: "Termini");

            migrationBuilder.DropForeignKey(
                name: "FK_Treneri_Teretana_TeretanaID",
                table: "Treneri");

            migrationBuilder.DropTable(
                name: "Teretana");

            migrationBuilder.DropIndex(
                name: "IX_Treneri_TeretanaID",
                table: "Treneri");

            migrationBuilder.DropIndex(
                name: "IX_Termini_TeretanaID",
                table: "Termini");

            migrationBuilder.DropIndex(
                name: "IX_Clanarine_TeretanaID",
                table: "Clanarine");

            migrationBuilder.DropColumn(
                name: "TeretanaID",
                table: "Treneri");

            migrationBuilder.DropColumn(
                name: "IDteretane",
                table: "Termini");

            migrationBuilder.DropColumn(
                name: "TeretanaID",
                table: "Termini");

            migrationBuilder.DropColumn(
                name: "IDTeretane",
                table: "Clanarine");

            migrationBuilder.DropColumn(
                name: "TeretanaID",
                table: "Clanarine");

            migrationBuilder.RenameColumn(
                name: "IDTeretane",
                table: "Treneri",
                newName: "brLicence");

            migrationBuilder.RenameColumn(
                name: "IDTeretane",
                table: "Clan",
                newName: "BrKartice");

            migrationBuilder.AlterColumn<int>(
                name: "trenerID",
                table: "Clan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clanarinaID",
                table: "Clan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Clanarine_clanarinaID",
                table: "Clan",
                column: "clanarinaID",
                principalTable: "Clanarine",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Treneri_trenerID",
                table: "Clan",
                column: "trenerID",
                principalTable: "Treneri",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
