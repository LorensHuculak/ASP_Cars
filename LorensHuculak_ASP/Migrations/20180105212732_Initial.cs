using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LorensHuculak_ASP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    CarTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.CarTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarTypeID = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    LicensePlate = table.Column<string>(nullable: true),
                    OwnerID = table.Column<int>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Car_CarType_CarTypeID",
                        column: x => x.CarTypeID,
                        principalTable: "CarType",
                        principalColumn: "CarTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Owner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "OwnerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeID",
                table: "Car",
                column: "CarTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_OwnerID",
                table: "Car",
                column: "OwnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
