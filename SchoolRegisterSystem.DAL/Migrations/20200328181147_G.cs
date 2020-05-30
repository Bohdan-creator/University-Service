using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegisterSystem.DAL.Migrations
{
    public partial class G : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Grade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Grade",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
