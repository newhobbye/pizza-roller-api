using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RollerPizza.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CPFId = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NickName = table.Column<string>(type: "varchar(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CPFId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<sbyte>(type: "tinyint(100)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(38,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<sbyte>(type: "tinyint(100)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(38,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    AdressId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "varchar(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "varchar(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<short>(type: "smallint(10)", nullable: false),
                    Description = table.Column<string>(type: "varchar(120)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<string>(type: "varchar(11)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.AdressId);
                    table.ForeignKey(
                        name: "FK_Adress_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "CPFId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payament",
                columns: table => new
                {
                    PayamentId = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPFId = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTransaction = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusOrder = table.Column<string>(type: "varchar(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payament", x => x.PayamentId);
                    table.ForeignKey(
                        name: "FK_Payament_Client_CPFId",
                        column: x => x.CPFId,
                        principalTable: "Client",
                        principalColumn: "CPFId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrinkPayament",
                columns: table => new
                {
                    DrinksId = table.Column<int>(type: "int", nullable: false),
                    PayamentId = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkPayament", x => new { x.DrinksId, x.PayamentId });
                    table.ForeignKey(
                        name: "FK_DrinkPayament_Drink_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkPayament_Payament_PayamentId",
                        column: x => x.PayamentId,
                        principalTable: "Payament",
                        principalColumn: "PayamentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayamentPizza",
                columns: table => new
                {
                    PayamentId = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PizzasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayamentPizza", x => new { x.PayamentId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_PayamentPizza_Payament_PayamentId",
                        column: x => x.PayamentId,
                        principalTable: "Payament",
                        principalColumn: "PayamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayamentPizza_Pizza_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_ClientId",
                table: "Adress",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrinkPayament_PayamentId",
                table: "DrinkPayament",
                column: "PayamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payament_CPFId",
                table: "Payament",
                column: "CPFId");

            migrationBuilder.CreateIndex(
                name: "IX_PayamentPizza_PizzasId",
                table: "PayamentPizza",
                column: "PizzasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "DrinkPayament");

            migrationBuilder.DropTable(
                name: "PayamentPizza");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "Payament");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
