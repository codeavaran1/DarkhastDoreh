using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request_Course.Migrations
{
    public partial class Modaresan_img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "T_Modaresan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "T_Modaresan");
        }
    }
}
