using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsCrudWithPagination.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorNo);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorNo = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarNo);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorNo",
                        column: x => x.ColorNo,
                        principalTable: "Colors",
                        principalColumn: "ColorNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorNo", "ColorName" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Black" },
                    { 3, "Green" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarNo", "ArName", "BeginDate", "CardNo", "ColorNo", "Company", "EnName", "EndDate", "Model", "UserNo" },
                values: new object[,]
                {
                    { 1, "اول اسم", new DateTime(2024, 10, 21, 12, 6, 37, 935, DateTimeKind.Local).AddTicks(3378), "33", 1, "Appy", "First Name", new DateTime(2024, 10, 26, 12, 6, 37, 935, DateTimeKind.Local).AddTicks(3425), "bmw", "1" },
                    { 2, "ثاني اسم", new DateTime(2024, 10, 21, 12, 6, 37, 935, DateTimeKind.Local).AddTicks(3433), "33", 2, "mg", "Second Name", new DateTime(2024, 10, 31, 12, 6, 37, 935, DateTimeKind.Local).AddTicks(3435), "bmw", "2" },
                    { 3, "ثالث اسم", new DateTime(2024, 10, 21, 12, 6, 37, 935, DateTimeKind.Local).AddTicks(3438), "33", 3, "mg-control.com", "Third Name", new DateTime(2024, 11, 5, 12, 6, 37, 935, DateTimeKind.Local).AddTicks(3440), "mg", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorNo",
                table: "Cars",
                column: "ColorNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
