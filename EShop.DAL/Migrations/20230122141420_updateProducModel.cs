using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DAL.Migrations
{
    public partial class updateProducModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitOfPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitOfPrice",
                table: "Products");
        }
    }
}
