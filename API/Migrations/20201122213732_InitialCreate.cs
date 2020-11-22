using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    TypeContract = table.Column<string>(type: "TEXT", nullable: true),
                    SalaryAmount = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    SalaryCurrency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    AnnualSalaryAmount = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    AnnualSalaryCurrency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    IdRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
