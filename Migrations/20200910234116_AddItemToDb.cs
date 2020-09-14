using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGarageSale.Migrations
{
    public partial class AddItemToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemForSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategory = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    ItemModel = table.Column<string>(nullable: true),
                    ItemManufacturer = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<double>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemForSale", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemForSale");
        }
    }
}
