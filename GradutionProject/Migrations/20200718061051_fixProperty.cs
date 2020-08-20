using Microsoft.EntityFrameworkCore.Migrations;

namespace GradutionProject.Migrations
{
    public partial class fixProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Area",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Area",
                table: "Posts",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
