using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZayShopMVC.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "products",
                newName: "image_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image_name",
                table: "products",
                newName: "image_url");
        }
    }
}
