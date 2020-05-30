using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegisterSystem.DAL.Migrations
{
    public partial class GradeI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Grade");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Grade",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Grade");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Grade",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
