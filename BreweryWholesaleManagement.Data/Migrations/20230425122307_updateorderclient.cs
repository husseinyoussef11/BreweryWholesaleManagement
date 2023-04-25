using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreweryWholesaleManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateorderclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdBrewery",
                table: "ClientOrders",
                newName: "IdWholesaler");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "ClientOrders",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "ClientOrders");

            migrationBuilder.RenameColumn(
                name: "IdWholesaler",
                table: "ClientOrders",
                newName: "IdBrewery");
        }
    }
}
