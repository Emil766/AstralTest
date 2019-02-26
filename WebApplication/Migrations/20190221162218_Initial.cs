using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Identificator = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Headline = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    EmployementType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Identificator);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
