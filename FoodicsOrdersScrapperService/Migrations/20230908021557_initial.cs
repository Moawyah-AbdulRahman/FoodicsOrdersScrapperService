using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodicsOrdersScrapperService.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    app_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    promotion_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discount_type = table.Column<int>(type: "int", nullable: true),
                    reference_x = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    source = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    delivery_status = table.Column<int>(type: "int", nullable: true),
                    guests = table.Column<int>(type: "int", nullable: false),
                    kitchen_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subtotal_price = table.Column<double>(type: "float", nullable: false),
                    discount_amount = table.Column<double>(type: "float", nullable: false),
                    rounding_amount = table.Column<double>(type: "float", nullable: false),
                    total_price = table.Column<double>(type: "float", nullable: false),
                    tax_exclusive_discount_amount = table.Column<double>(type: "float", nullable: false),
                    delay_in_seconds = table.Column<int>(type: "int", nullable: true),
                    reference = table.Column<int>(type: "int", nullable: false),
                    check_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
