using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimesProtech.DAL.Migrations
{
    public partial class addsoftdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Directors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Animes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Animes");
        }
    }
}
