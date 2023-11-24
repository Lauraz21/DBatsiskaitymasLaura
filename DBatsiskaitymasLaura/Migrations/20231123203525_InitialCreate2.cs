using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBatsiskaitymasLaura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentID",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LectureID",
                table: "DepartmentLecture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentLecture",
                table: "DepartmentLecture");

            migrationBuilder.RenameTable(
                name: "DepartmentLecture",
                newName: "DepartmentLectures");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_LectureID",
                table: "DepartmentLectures",
                newName: "IX_DepartmentLectures_LectureID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentLectures",
                table: "DepartmentLectures",
                columns: new[] { "DepartmentID", "LectureID" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLectures_Departments_DepartmentID",
                table: "DepartmentLectures",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLectures_Lectures_LectureID",
                table: "DepartmentLectures",
                column: "LectureID",
                principalTable: "Lectures",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLectures_Departments_DepartmentID",
                table: "DepartmentLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLectures_Lectures_LectureID",
                table: "DepartmentLectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentLectures",
                table: "DepartmentLectures");

            migrationBuilder.RenameTable(
                name: "DepartmentLectures",
                newName: "DepartmentLecture");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLectures_LectureID",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_LectureID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentLecture",
                table: "DepartmentLecture",
                columns: new[] { "DepartmentID", "LectureID" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentID",
                table: "DepartmentLecture",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LectureID",
                table: "DepartmentLecture",
                column: "LectureID",
                principalTable: "Lectures",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
