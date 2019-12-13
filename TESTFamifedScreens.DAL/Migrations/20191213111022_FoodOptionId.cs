using Microsoft.EntityFrameworkCore.Migrations;

namespace TESTFamifedScreens.DAL.Migrations
{
    public partial class FoodOptionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodOptionId",
                table: "FoodRequests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodOptionId",
                table: "FoodRequests");
        }
    }
}
