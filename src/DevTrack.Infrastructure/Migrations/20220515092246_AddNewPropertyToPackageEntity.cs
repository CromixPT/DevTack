using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTrack.Infrastructure.Migrations
{
    public partial class AddNewPropertyToPackageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStatus",
                table: "Packages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "Packages");
        }
    }
}
