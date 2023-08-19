using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_5.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    cityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.empId);
                    table.ForeignKey(
                        name: "FK_Employee_City_cityId",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpTransSalary",
                columns: table => new
                {
                    emp_trans_salId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    salaryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTransSalary", x => x.emp_trans_salId);
                    table.ForeignKey(
                        name: "FK_EmpTransSalary_Employee_empId",
                        column: x => x.empId,
                        principalTable: "Employee",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_cityId",
                table: "Employee",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTransSalary_empId",
                table: "EmpTransSalary",
                column: "empId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpTransSalary");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
