using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegisterSystem.DAL.Migrations
{
    public partial class SubjectGroupMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubjectGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubjectGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
