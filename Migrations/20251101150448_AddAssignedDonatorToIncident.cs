using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftOfTheGiversHub.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignedDonatorToIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedDonatorEmail",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Donators",
                columns: table => new
                {
                    DonatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonatorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donators", x => x.DonatorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donators");

            migrationBuilder.DropColumn(
                name: "AssignedDonatorEmail",
                table: "Incidents");
        }
    }
}
