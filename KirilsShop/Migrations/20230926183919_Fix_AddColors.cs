using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KirilsShop.Migrations
{
    /// <inheritdoc />
    public partial class Fix_AddColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Colour_ColorId",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colour",
                table: "Colour");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Colour",
                newName: "CarColors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarColors",
                table: "CarColors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CarColors_ColorId",
                table: "Car",
                column: "ColorId",
                principalTable: "CarColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarColors_ColorId",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarColors",
                table: "CarColors");

            migrationBuilder.RenameTable(
                name: "CarColors",
                newName: "Colour");

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colour",
                table: "Colour",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Colour_ColorId",
                table: "Car",
                column: "ColorId",
                principalTable: "Colour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
