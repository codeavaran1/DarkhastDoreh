using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request_Course.Migrations
{
    public partial class LastTimeArrive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeArrive",
                table: "T_Mokhatebin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeArrive",
                table: "T_Modaresan",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTimeArrive",
                table: "T_Mokhatebin");

            migrationBuilder.DropColumn(
                name: "LastTimeArrive",
                table: "T_Modaresan");
        }
    }
}
