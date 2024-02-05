using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KirilsShop.Migrations
{
    /// <inheritdoc />
    public partial class Models_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarYOPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarOrigins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarFuels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarColors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarBrands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarBodys",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarYOPs");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarOrigins");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarFuels");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarColors");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarBrands");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarBodys");
        }
    }
}
