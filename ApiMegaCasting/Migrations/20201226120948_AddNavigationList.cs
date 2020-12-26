using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMegaCasting.Migrations
{
    public partial class AddNavigationList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Profession_ProfessionId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Studio_StudioId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Profession_ProfessionSector_ProfessionSectorId",
                table: "Profession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studio",
                table: "Studio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionSector",
                table: "ProfessionSector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profession",
                table: "Profession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiffsionPartner",
                table: "DiffsionPartner");

            migrationBuilder.RenameTable(
                name: "Studio",
                newName: "Studios");

            migrationBuilder.RenameTable(
                name: "ProfessionSector",
                newName: "ProfessionSectors");

            migrationBuilder.RenameTable(
                name: "Profession",
                newName: "Professions");

            migrationBuilder.RenameTable(
                name: "DiffsionPartner",
                newName: "DiffsionPartners");

            migrationBuilder.RenameIndex(
                name: "IX_Profession_ProfessionSectorId",
                table: "Professions",
                newName: "IX_Professions_ProfessionSectorId");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studios",
                table: "Studios",
                column: "StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionSectors",
                table: "ProfessionSectors",
                column: "ProfessionSectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professions",
                table: "Professions",
                column: "ProfessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiffsionPartners",
                table: "DiffsionPartners",
                column: "DiffsionPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_OfferId",
                table: "Contracts",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Offers_OfferId",
                table: "Contracts",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "OfferId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Professions_ProfessionId",
                table: "Offers",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Studios_StudioId",
                table: "Offers",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_ProfessionSectors_ProfessionSectorId",
                table: "Professions",
                column: "ProfessionSectorId",
                principalTable: "ProfessionSectors",
                principalColumn: "ProfessionSectorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Offers_OfferId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Professions_ProfessionId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Studios_StudioId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_ProfessionSectors_ProfessionSectorId",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_OfferId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studios",
                table: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionSectors",
                table: "ProfessionSectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professions",
                table: "Professions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiffsionPartners",
                table: "DiffsionPartners");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Studios",
                newName: "Studio");

            migrationBuilder.RenameTable(
                name: "ProfessionSectors",
                newName: "ProfessionSector");

            migrationBuilder.RenameTable(
                name: "Professions",
                newName: "Profession");

            migrationBuilder.RenameTable(
                name: "DiffsionPartners",
                newName: "DiffsionPartner");

            migrationBuilder.RenameIndex(
                name: "IX_Professions_ProfessionSectorId",
                table: "Profession",
                newName: "IX_Profession_ProfessionSectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studio",
                table: "Studio",
                column: "StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionSector",
                table: "ProfessionSector",
                column: "ProfessionSectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profession",
                table: "Profession",
                column: "ProfessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiffsionPartner",
                table: "DiffsionPartner",
                column: "DiffsionPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Profession_ProfessionId",
                table: "Offers",
                column: "ProfessionId",
                principalTable: "Profession",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Studio_StudioId",
                table: "Offers",
                column: "StudioId",
                principalTable: "Studio",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profession_ProfessionSector_ProfessionSectorId",
                table: "Profession",
                column: "ProfessionSectorId",
                principalTable: "ProfessionSector",
                principalColumn: "ProfessionSectorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
