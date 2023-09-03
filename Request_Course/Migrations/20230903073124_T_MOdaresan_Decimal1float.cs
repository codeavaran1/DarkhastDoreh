using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request_Course.Migrations
{
    public partial class T_MOdaresan_Decimal1float : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Avg_Nomreh_Tadris_float",
                table: "T_Modaresan",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Nomreh_Keyfi_float",
                table: "T_Modaresan",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avg_Nomreh_Tadris_float",
                table: "T_Modaresan");

            migrationBuilder.DropColumn(
                name: "Nomreh_Keyfi_float",
                table: "T_Modaresan");
        }
    }
}
