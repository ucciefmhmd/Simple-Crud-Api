using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DO1.Migrations
{
    /// <inheritdoc />
    public partial class createRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "Dept_Id");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentID",
                table: "Student",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DepartmentID",
                table: "Student",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "Dept_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DepartmentID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepartmentID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "Dept_Id",
                table: "Department",
                newName: "Id");
        }
    }
}
