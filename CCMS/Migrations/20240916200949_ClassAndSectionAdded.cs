using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.Migrations
{
    /// <inheritdoc />
    public partial class ClassAndSectionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionShift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "StudentSections");
        }
    }
}
