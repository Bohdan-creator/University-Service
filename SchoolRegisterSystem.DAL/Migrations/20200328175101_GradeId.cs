using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegisterSystem.DAL.Migrations
{
    public partial class GradeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Grade",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Grade");
        }
    }
}
