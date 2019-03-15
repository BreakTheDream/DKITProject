using Microsoft.EntityFrameworkCore.Migrations;

namespace DKITProject.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPreviev",
                table: "Specialties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPreviev",
                table: "Specialties",
                nullable: true);
        }
    }
}
