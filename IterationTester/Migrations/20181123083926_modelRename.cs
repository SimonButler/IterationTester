using Microsoft.EntityFrameworkCore.Migrations;

namespace IterationTester.Migrations
{
    public partial class modelRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateType",
                table: "Results",
                newName: "DataType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataType",
                table: "Results",
                newName: "DateType");
        }
    }
}
