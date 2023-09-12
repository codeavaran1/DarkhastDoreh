using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request_Course.Migrations
{
    public partial class Add_FK_onvandoreh_TO_OnvanAsli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_FildAsli",
                table: "T_L_OnvanDoreh",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_L_OnvanDoreh_ID_FildAsli",
                table: "T_L_OnvanDoreh",
                column: "ID_FildAsli");

            migrationBuilder.AddForeignKey(
                name: "FK_T_L_OnvanDoreh_T_L_FildAsli_ID_FildAsli",
                table: "T_L_OnvanDoreh",
                column: "ID_FildAsli",
                principalTable: "T_L_FildAsli",
                principalColumn: "ID_FildAsli");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_L_OnvanDoreh_T_L_FildAsli_ID_FildAsli",
                table: "T_L_OnvanDoreh");

            migrationBuilder.DropIndex(
                name: "IX_T_L_OnvanDoreh_ID_FildAsli",
                table: "T_L_OnvanDoreh");

            migrationBuilder.DropColumn(
                name: "ID_FildAsli",
                table: "T_L_OnvanDoreh");
        }
    }
}
