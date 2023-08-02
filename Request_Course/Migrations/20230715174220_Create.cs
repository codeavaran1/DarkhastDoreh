using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request_Course.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_L_DaragehElmi",
                columns: table => new
                {
                    ID_DaragehElmi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_DaragehElmi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_DaragehElmi", x => x.ID_DaragehElmi);
                });

            migrationBuilder.CreateTable(
                name: "T_L_FildAsli",
                columns: table => new
                {
                    ID_FildAsli = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_FildAsli = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_FildAsli", x => x.ID_FildAsli);
                });

            migrationBuilder.CreateTable(
                name: "T_L_MaghtaeTahsili",
                columns: table => new
                {
                    ID_MaghtaeTahsili = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_MaghtaeTahsili = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_MaghtaeTahsili", x => x.ID_MaghtaeTahsili);
                });

            migrationBuilder.CreateTable(
                name: "T_L_MediaAmozeshi",
                columns: table => new
                {
                    ID_MediaAmozeshi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_MediaAmozeshi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_MediaAmozeshi", x => x.ID_MediaAmozeshi);
                });

            migrationBuilder.CreateTable(
                name: "T_L_ModateDoreh",
                columns: table => new
                {
                    ID_ModateDoreh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_ModateDoreh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_ModateDoreh", x => x.ID_ModateDoreh);
                });

            migrationBuilder.CreateTable(
                name: "T_L_MokhatabanDoreh",
                columns: table => new
                {
                    ID_MokhatabanDoreh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_MokhatabanDoreh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_MokhatabanDoreh", x => x.ID_MokhatabanDoreh);
                });

            migrationBuilder.CreateTable(
                name: "T_L_OnvanAsli",
                columns: table => new
                {
                    ID_L_OnvanAsli = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_OnvanAsli = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_OnvanAsli", x => x.ID_L_OnvanAsli);
                });

            migrationBuilder.CreateTable(
                name: "T_L_OnvanDoreh",
                columns: table => new
                {
                    ID_OnvanDoreh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_OnvanDoreh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_OnvanDoreh", x => x.ID_OnvanDoreh);
                });

            migrationBuilder.CreateTable(
                name: "T_L_Ostan",
                columns: table => new
                {
                    ID_Ostan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_Ostan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_Ostan", x => x.ID_Ostan);
                });

            migrationBuilder.CreateTable(
                name: "T_L_RaveshAmozeshi",
                columns: table => new
                {
                    ID_L_RaveshAmozeshi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_RaveshAmozeshi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_RaveshAmozeshi", x => x.ID_L_RaveshAmozeshi);
                });

            migrationBuilder.CreateTable(
                name: "T_L_ReshtehTahsili",
                columns: table => new
                {
                    ID_ReshtehTahsili = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_ReshtehTahsili = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_ReshtehTahsili", x => x.ID_ReshtehTahsili);
                });

            migrationBuilder.CreateTable(
                name: "T_L_Sathe_Sherkat",
                columns: table => new
                {
                    ID_Sathe_Sherkat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_Sathe_Sherkat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_Sathe_Sherkat", x => x.ID_Sathe_Sherkat);
                });

            migrationBuilder.CreateTable(
                name: "T_L_SatheKeyfi_Modares",
                columns: table => new
                {
                    ID_L_SatheKeyfi_Modares = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_SatheKeyfi_Modares = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_SatheKeyfi_Modares", x => x.ID_L_SatheKeyfi_Modares);
                });

            migrationBuilder.CreateTable(
                name: "T_L_Semat",
                columns: table => new
                {
                    ID_Semat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_Semat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_Semat", x => x.ID_Semat);
                });

            migrationBuilder.CreateTable(
                name: "T_L_Vaziyat_Doreh",
                columns: table => new
                {
                    ID_L_Vaziyat_Doreh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles_Vaziyat_Doreh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_L_Vaziyat_Doreh", x => x.ID_L_Vaziyat_Doreh);
                });

            migrationBuilder.CreateTable(
                name: "T_Fasl_Doreh",
                columns: table => new
                {
                    ID_Fasl_Doreh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mohtav = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Modate_Ejra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Shekle_Ejra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    T_L_OnvanAsli_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_OnvanDoreh_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Fasl_Doreh", x => x.ID_Fasl_Doreh);
                    table.ForeignKey(
                        name: "FK_T_Fasl_Doreh_T_L_OnvanAsli_T_L_OnvanAsli_ID",
                        column: x => x.T_L_OnvanAsli_ID,
                        principalTable: "T_L_OnvanAsli",
                        principalColumn: "ID_L_OnvanAsli");
                    table.ForeignKey(
                        name: "FK_T_Fasl_Doreh_T_L_OnvanDoreh_T_L_OnvanDoreh_ID",
                        column: x => x.T_L_OnvanDoreh_ID,
                        principalTable: "T_L_OnvanDoreh",
                        principalColumn: "ID_OnvanDoreh");
                });

            migrationBuilder.CreateTable(
                name: "T_Modaresan",
                columns: table => new
                {
                    ID_Modaresan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_L_ReshtehTahsili_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_MaghtaeTahsili_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_DaragehElmi_ID = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Daneshgah_Sherkat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nomreh_Keyfi = table.Column<decimal>(type: "decimal(2,2)", precision: 2, scale: 2, nullable: true),
                    Onvan_Shoghli = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MadrakTahsili = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sathe_Keyfi = table.Column<int>(type: "int", nullable: true),
                    C_Doreh_Ejra = table.Column<int>(type: "int", nullable: true),
                    Rotbe_Modares = table.Column<int>(type: "int", nullable: true),
                    Avg_Nomreh_Tadris = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Modaresan", x => x.ID_Modaresan);
                    table.ForeignKey(
                        name: "FK_T_Modaresan_T_L_DaragehElmi_T_L_DaragehElmi_ID",
                        column: x => x.T_L_DaragehElmi_ID,
                        principalTable: "T_L_DaragehElmi",
                        principalColumn: "ID_DaragehElmi");
                    table.ForeignKey(
                        name: "FK_T_Modaresan_T_L_MaghtaeTahsili_T_L_MaghtaeTahsili_ID",
                        column: x => x.T_L_MaghtaeTahsili_ID,
                        principalTable: "T_L_MaghtaeTahsili",
                        principalColumn: "ID_MaghtaeTahsili");
                    table.ForeignKey(
                        name: "FK_T_Modaresan_T_L_ReshtehTahsili_T_L_ReshtehTahsili_ID",
                        column: x => x.T_L_ReshtehTahsili_ID,
                        principalTable: "T_L_ReshtehTahsili",
                        principalColumn: "ID_ReshtehTahsili");
                });

            migrationBuilder.CreateTable(
                name: "T_Mokhatebin",
                columns: table => new
                {
                    ID_Mokhatebin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Sherkat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NamFamily_Rabet = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mobile_Rabet = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    T_L_Semat_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_Ostan_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_Sathe_Sherkat_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Mokhatebin", x => x.ID_Mokhatebin);
                    table.ForeignKey(
                        name: "FK_T_Mokhatebin_T_L_Ostan_T_L_Ostan_ID",
                        column: x => x.T_L_Ostan_ID,
                        principalTable: "T_L_Ostan",
                        principalColumn: "ID_Ostan");
                    table.ForeignKey(
                        name: "FK_T_Mokhatebin_T_L_Sathe_Sherkat_T_L_Sathe_Sherkat_ID",
                        column: x => x.T_L_Sathe_Sherkat_ID,
                        principalTable: "T_L_Sathe_Sherkat",
                        principalColumn: "ID_Sathe_Sherkat");
                    table.ForeignKey(
                        name: "FK_T_Mokhatebin_T_L_Semat_T_L_Semat_ID",
                        column: x => x.T_L_Semat_ID,
                        principalTable: "T_L_Semat",
                        principalColumn: "ID_Semat");
                });

            migrationBuilder.CreateTable(
                name: "T_Modaresan_Fild_Amozeshi",
                columns: table => new
                {
                    ID_Modaresan_Fild_Amozeshi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_L_FildAsli_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_OnvanDoreh_ID = table.Column<int>(type: "int", nullable: true),
                    T_Modaresan_ID = table.Column<int>(type: "int", nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Modaresan_Fild_Amozeshi", x => x.ID_Modaresan_Fild_Amozeshi);
                    table.ForeignKey(
                        name: "FK_T_Modaresan_Fild_Amozeshi_T_L_FildAsli_T_L_FildAsli_ID",
                        column: x => x.T_L_FildAsli_ID,
                        principalTable: "T_L_FildAsli",
                        principalColumn: "ID_FildAsli");
                    table.ForeignKey(
                        name: "FK_T_Modaresan_Fild_Amozeshi_T_L_OnvanDoreh_T_L_OnvanDoreh_ID",
                        column: x => x.T_L_OnvanDoreh_ID,
                        principalTable: "T_L_OnvanDoreh",
                        principalColumn: "ID_OnvanDoreh");
                    table.ForeignKey(
                        name: "FK_T_Modaresan_Fild_Amozeshi_T_Modaresan_T_Modaresan_ID",
                        column: x => x.T_Modaresan_ID,
                        principalTable: "T_Modaresan",
                        principalColumn: "ID_Modaresan");
                });

            migrationBuilder.CreateTable(
                name: "T_Activation",
                columns: table => new
                {
                    ID_Activation = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    code = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Teacher = table.Column<bool>(type: "bit", nullable: false),
                    Student = table.Column<bool>(type: "bit", nullable: false),
                    DateGenerateCode = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_Modaresan_ID = table.Column<int>(type: "int", nullable: true),
                    T_Mokhatebin_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Activation", x => x.ID_Activation);
                    table.ForeignKey(
                        name: "FK_T_Activation_T_Modaresan_T_Modaresan_ID",
                        column: x => x.T_Modaresan_ID,
                        principalTable: "T_Modaresan",
                        principalColumn: "ID_Modaresan");
                    table.ForeignKey(
                        name: "FK_T_Activation_T_Mokhatebin_T_Mokhatebin_ID",
                        column: x => x.T_Mokhatebin_ID,
                        principalTable: "T_Mokhatebin",
                        principalColumn: "ID_Mokhatebin");
                });

            migrationBuilder.CreateTable(
                name: "T_Doreh_Darkhasti",
                columns: table => new
                {
                    ID_Doreh_Darkhasti = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_Mokhatebin_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_OnvanAsli_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_OnvanDoreh_ID = table.Column<int>(type: "int", nullable: true),
                    OnvanDoreh_Jadid = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    T_L_MediaAmozeshi_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_RaveshAmozeshi_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_ModateDoreh_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_MokhatabanDoreh_ID = table.Column<int>(type: "int", nullable: true),
                    Date_Az_Pishnahad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Ta_Pishnahad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_L_SatheKeyfi_Modares_ID = table.Column<int>(type: "int", nullable: true),
                    T_Modaresan_ID = table.Column<int>(type: "int", nullable: true),
                    Date_Az_Ejra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Ta_Ejra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nomreh_Modares = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_L_Vaziyat_Doreh_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Doreh_Darkhasti", x => x.ID_Doreh_Darkhasti);
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_L_MediaAmozeshi_T_L_MediaAmozeshi_ID",
                        column: x => x.T_L_MediaAmozeshi_ID,
                        principalTable: "T_L_MediaAmozeshi",
                        principalColumn: "ID_MediaAmozeshi");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_L_ModateDoreh_T_L_ModateDoreh_ID",
                        column: x => x.T_L_ModateDoreh_ID,
                        principalTable: "T_L_ModateDoreh",
                        principalColumn: "ID_ModateDoreh");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_L_MokhatabanDoreh_T_L_MokhatabanDoreh_ID",
                        column: x => x.T_L_MokhatabanDoreh_ID,
                        principalTable: "T_L_MokhatabanDoreh",
                        principalColumn: "ID_MokhatabanDoreh");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_L_OnvanDoreh_T_L_OnvanDoreh_ID",
                        column: x => x.T_L_OnvanDoreh_ID,
                        principalTable: "T_L_OnvanDoreh",
                        principalColumn: "ID_OnvanDoreh");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_L_RaveshAmozeshi_T_L_RaveshAmozeshi_ID",
                        column: x => x.T_L_RaveshAmozeshi_ID,
                        principalTable: "T_L_RaveshAmozeshi",
                        principalColumn: "ID_L_RaveshAmozeshi");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_L_SatheKeyfi_Modares_T_L_SatheKeyfi_Modares_ID",
                        column: x => x.T_L_SatheKeyfi_Modares_ID,
                        principalTable: "T_L_SatheKeyfi_Modares",
                        principalColumn: "ID_L_SatheKeyfi_Modares");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_L_Vaziyat_Doreh_T_L_Vaziyat_Doreh_ID",
                        column: x => x.T_L_Vaziyat_Doreh_ID,
                        principalTable: "T_L_Vaziyat_Doreh",
                        principalColumn: "ID_L_Vaziyat_Doreh");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_Modaresan_T_Modaresan_ID",
                        column: x => x.T_Modaresan_ID,
                        principalTable: "T_Modaresan",
                        principalColumn: "ID_Modaresan");
                    table.ForeignKey(
                        name: "FK_T_Doreh_Darkhasti_T_Mokhatebin_T_Mokhatebin_ID",
                        column: x => x.T_Mokhatebin_ID,
                        principalTable: "T_Mokhatebin",
                        principalColumn: "ID_Mokhatebin");
                });

            migrationBuilder.CreateTable(
                name: "T_Fasl_Doreh_Pishnahadi",
                columns: table => new
                {
                    ID_Fasl_Doreh_Pishnahadi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mohtava = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Modate_Ejra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Shekle_Ejra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    T_Doreh_Darkhasti_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Fasl_Doreh_Pishnahadi", x => x.ID_Fasl_Doreh_Pishnahadi);
                    table.ForeignKey(
                        name: "FK_T_Fasl_Doreh_Pishnahadi_T_Doreh_Darkhasti_T_Doreh_Darkhasti_ID",
                        column: x => x.T_Doreh_Darkhasti_ID,
                        principalTable: "T_Doreh_Darkhasti",
                        principalColumn: "ID_Doreh_Darkhasti");
                });

            migrationBuilder.CreateTable(
                name: "T_MarahelDoreh",
                columns: table => new
                {
                    ID_Marahel_Doreh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_Doreh_Darkhasti_ID = table.Column<int>(type: "int", nullable: true),
                    T_L_Vaziyat_Doreh_ID = table.Column<int>(type: "int", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MarahelDoreh", x => x.ID_Marahel_Doreh);
                    table.ForeignKey(
                        name: "FK_T_MarahelDoreh_T_Doreh_Darkhasti_T_Doreh_Darkhasti_ID",
                        column: x => x.T_Doreh_Darkhasti_ID,
                        principalTable: "T_Doreh_Darkhasti",
                        principalColumn: "ID_Doreh_Darkhasti");
                    table.ForeignKey(
                        name: "FK_T_MarahelDoreh_T_L_Vaziyat_Doreh_T_L_Vaziyat_Doreh_ID",
                        column: x => x.T_L_Vaziyat_Doreh_ID,
                        principalTable: "T_L_Vaziyat_Doreh",
                        principalColumn: "ID_L_Vaziyat_Doreh");
                });

            migrationBuilder.CreateTable(
                name: "T_Nazarsanji",
                columns: table => new
                {
                    ID_Nazarsanji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_Doreh_Darkhasti_ID = table.Column<int>(type: "int", nullable: true),
                    Num_Tasalot = table.Column<int>(type: "int", nullable: true),
                    Num_Roayat_Sarfasl = table.Column<int>(type: "int", nullable: true),
                    Num_Roayat_Nazm = table.Column<int>(type: "int", nullable: true),
                    Num_TamoolBaFaragir = table.Column<int>(type: "int", nullable: true),
                    Avg_Num = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Nazarsanji", x => x.ID_Nazarsanji);
                    table.ForeignKey(
                        name: "FK_T_Nazarsanji_T_Doreh_Darkhasti_T_Doreh_Darkhasti_ID",
                        column: x => x.T_Doreh_Darkhasti_ID,
                        principalTable: "T_Doreh_Darkhasti",
                        principalColumn: "ID_Doreh_Darkhasti");
                });

            migrationBuilder.CreateTable(
                name: "T_Pishnahad_Modares_Doreh",
                columns: table => new
                {
                    ID_Pishnahad_Modares_Doreh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_Doreh_Darkhasti_ID = table.Column<int>(type: "int", nullable: true),
                    T_Modaresan_ID1 = table.Column<int>(type: "int", nullable: true),
                    T_Modaresan_ID2 = table.Column<int>(type: "int", nullable: true),
                    T_Modaresan_ID3 = table.Column<int>(type: "int", nullable: true),
                    Pishnahad_Modares_Name1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pishnahad_Modares_phone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pishnahad_Modares_Name2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pishnahad_Modares_phone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pishnahad_Modares_Name3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pishnahad_Modares_phone3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Pishnahad_Modares_Doreh", x => x.ID_Pishnahad_Modares_Doreh);
                    table.ForeignKey(
                        name: "FK_T_Pishnahad_Modares_Doreh_T_Doreh_Darkhasti_T_Doreh_Darkhasti_ID",
                        column: x => x.T_Doreh_Darkhasti_ID,
                        principalTable: "T_Doreh_Darkhasti",
                        principalColumn: "ID_Doreh_Darkhasti");
                    table.ForeignKey(
                        name: "FK_T_Pishnahad_Modares_Doreh_T_Modaresan_T_Modaresan_ID1",
                        column: x => x.T_Modaresan_ID1,
                        principalTable: "T_Modaresan",
                        principalColumn: "ID_Modaresan");
                    table.ForeignKey(
                        name: "FK_T_Pishnahad_Modares_Doreh_T_Mokhatebin_T_Modaresan_ID2",
                        column: x => x.T_Modaresan_ID2,
                        principalTable: "T_Mokhatebin",
                        principalColumn: "ID_Mokhatebin");
                    table.ForeignKey(
                        name: "FK_T_Pishnahad_Modares_Doreh_T_Mokhatebin_T_Modaresan_ID3",
                        column: x => x.T_Modaresan_ID3,
                        principalTable: "T_Mokhatebin",
                        principalColumn: "ID_Mokhatebin");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Activation_T_Modaresan_ID",
                table: "T_Activation",
                column: "T_Modaresan_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Activation_T_Mokhatebin_ID",
                table: "T_Activation",
                column: "T_Mokhatebin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_L_MediaAmozeshi_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_L_MediaAmozeshi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_L_ModateDoreh_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_L_ModateDoreh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_L_MokhatabanDoreh_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_L_MokhatabanDoreh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_L_OnvanDoreh_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_L_OnvanDoreh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_L_RaveshAmozeshi_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_L_RaveshAmozeshi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_L_SatheKeyfi_Modares_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_L_SatheKeyfi_Modares_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_L_Vaziyat_Doreh_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_L_Vaziyat_Doreh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_Modaresan_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_Modaresan_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Doreh_Darkhasti_T_Mokhatebin_ID",
                table: "T_Doreh_Darkhasti",
                column: "T_Mokhatebin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Fasl_Doreh_T_L_OnvanAsli_ID",
                table: "T_Fasl_Doreh",
                column: "T_L_OnvanAsli_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Fasl_Doreh_T_L_OnvanDoreh_ID",
                table: "T_Fasl_Doreh",
                column: "T_L_OnvanDoreh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Fasl_Doreh_Pishnahadi_T_Doreh_Darkhasti_ID",
                table: "T_Fasl_Doreh_Pishnahadi",
                column: "T_Doreh_Darkhasti_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_MarahelDoreh_T_Doreh_Darkhasti_ID",
                table: "T_MarahelDoreh",
                column: "T_Doreh_Darkhasti_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_MarahelDoreh_T_L_Vaziyat_Doreh_ID",
                table: "T_MarahelDoreh",
                column: "T_L_Vaziyat_Doreh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Modaresan_T_L_DaragehElmi_ID",
                table: "T_Modaresan",
                column: "T_L_DaragehElmi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Modaresan_T_L_MaghtaeTahsili_ID",
                table: "T_Modaresan",
                column: "T_L_MaghtaeTahsili_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Modaresan_T_L_ReshtehTahsili_ID",
                table: "T_Modaresan",
                column: "T_L_ReshtehTahsili_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Modaresan_Fild_Amozeshi_T_L_FildAsli_ID",
                table: "T_Modaresan_Fild_Amozeshi",
                column: "T_L_FildAsli_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Modaresan_Fild_Amozeshi_T_L_OnvanDoreh_ID",
                table: "T_Modaresan_Fild_Amozeshi",
                column: "T_L_OnvanDoreh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Modaresan_Fild_Amozeshi_T_Modaresan_ID",
                table: "T_Modaresan_Fild_Amozeshi",
                column: "T_Modaresan_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Mokhatebin_T_L_Ostan_ID",
                table: "T_Mokhatebin",
                column: "T_L_Ostan_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Mokhatebin_T_L_Sathe_Sherkat_ID",
                table: "T_Mokhatebin",
                column: "T_L_Sathe_Sherkat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Mokhatebin_T_L_Semat_ID",
                table: "T_Mokhatebin",
                column: "T_L_Semat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Nazarsanji_T_Doreh_Darkhasti_ID",
                table: "T_Nazarsanji",
                column: "T_Doreh_Darkhasti_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Pishnahad_Modares_Doreh_T_Doreh_Darkhasti_ID",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Doreh_Darkhasti_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Pishnahad_Modares_Doreh_T_Modaresan_ID1",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Modaresan_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_T_Pishnahad_Modares_Doreh_T_Modaresan_ID2",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Modaresan_ID2");

            migrationBuilder.CreateIndex(
                name: "IX_T_Pishnahad_Modares_Doreh_T_Modaresan_ID3",
                table: "T_Pishnahad_Modares_Doreh",
                column: "T_Modaresan_ID3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Activation");

            migrationBuilder.DropTable(
                name: "T_Fasl_Doreh");

            migrationBuilder.DropTable(
                name: "T_Fasl_Doreh_Pishnahadi");

            migrationBuilder.DropTable(
                name: "T_MarahelDoreh");

            migrationBuilder.DropTable(
                name: "T_Modaresan_Fild_Amozeshi");

            migrationBuilder.DropTable(
                name: "T_Nazarsanji");

            migrationBuilder.DropTable(
                name: "T_Pishnahad_Modares_Doreh");

            migrationBuilder.DropTable(
                name: "T_L_OnvanAsli");

            migrationBuilder.DropTable(
                name: "T_L_FildAsli");

            migrationBuilder.DropTable(
                name: "T_Doreh_Darkhasti");

            migrationBuilder.DropTable(
                name: "T_L_MediaAmozeshi");

            migrationBuilder.DropTable(
                name: "T_L_ModateDoreh");

            migrationBuilder.DropTable(
                name: "T_L_MokhatabanDoreh");

            migrationBuilder.DropTable(
                name: "T_L_OnvanDoreh");

            migrationBuilder.DropTable(
                name: "T_L_RaveshAmozeshi");

            migrationBuilder.DropTable(
                name: "T_L_SatheKeyfi_Modares");

            migrationBuilder.DropTable(
                name: "T_L_Vaziyat_Doreh");

            migrationBuilder.DropTable(
                name: "T_Modaresan");

            migrationBuilder.DropTable(
                name: "T_Mokhatebin");

            migrationBuilder.DropTable(
                name: "T_L_DaragehElmi");

            migrationBuilder.DropTable(
                name: "T_L_MaghtaeTahsili");

            migrationBuilder.DropTable(
                name: "T_L_ReshtehTahsili");

            migrationBuilder.DropTable(
                name: "T_L_Ostan");

            migrationBuilder.DropTable(
                name: "T_L_Sathe_Sherkat");

            migrationBuilder.DropTable(
                name: "T_L_Semat");
        }
    }
}
