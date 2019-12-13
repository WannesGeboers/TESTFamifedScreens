using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TESTFamifedScreens.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowStatusMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowStatusMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestById = table.Column<int>(nullable: true),
                    IsThirsty = table.Column<bool>(nullable: false),
                    FlowStatusId = table.Column<int>(nullable: false),
                    TimeOfReview = table.Column<DateTime>(nullable: false),
                    ReviewedById = table.Column<int>(nullable: true),
                    TimeOfOrder = table.Column<DateTime>(nullable: false),
                    OrderedById = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodRequests_Persons_OrderedById",
                        column: x => x.OrderedById,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodRequests_Persons_RequestById",
                        column: x => x.RequestById,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodRequests_Persons_ReviewedById",
                        column: x => x.ReviewedById,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodRequests_OrderedById",
                table: "FoodRequests",
                column: "OrderedById");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRequests_RequestById",
                table: "FoodRequests",
                column: "RequestById");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRequests_ReviewedById",
                table: "FoodRequests",
                column: "ReviewedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowStatusMessages");

            migrationBuilder.DropTable(
                name: "FoodOptions");

            migrationBuilder.DropTable(
                name: "FoodRequests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
