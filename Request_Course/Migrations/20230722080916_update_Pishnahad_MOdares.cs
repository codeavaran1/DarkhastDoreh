using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request_Course.Migrations
{
    public partial class update_Pishnahad_MOdares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Mokhatebin_T_Modaresan_ID2",
                table: "T_Pishnahad_Modares_Doreh");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Mokhatebin_T_Modaresan_ID3",
                table: "T_Pishnahad_Modares_Doreh");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Modaresan_T_Modaresan_ID2",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Modaresan_ID2",
                principalTable: "T_Modaresan",
                principalColumn: "ID_Modaresan");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Modaresan_T_Modaresan_ID3",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Modaresan_ID3",
                principalTable: "T_Modaresan",
                principalColumn: "ID_Modaresan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Modaresan_T_Modaresan_ID2",
                table: "T_Pishnahad_Modares_Doreh");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Modaresan_T_Modaresan_ID3",
                table: "T_Pishnahad_Modares_Doreh");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Mokhatebin_T_Modaresan_ID2",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Modaresan_ID2",
                principalTable: "T_Mokhatebin",
                principalColumn: "ID_Mokhatebin");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Pishnahad_Modares_Doreh_T_Mokhatebin_T_Modaresan_ID3",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Modaresan_ID3",
                principalTable: "T_Mokhatebin",
                principalColumn: "ID_Mokhatebin");
        }
    }
}
