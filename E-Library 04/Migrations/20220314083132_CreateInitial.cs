using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Library_04.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminID);
                });

            migrationBuilder.CreateTable(
                name: "ExamAndTestManagement",
                columns: table => new
                {
                    exam_and_test_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exam_and_test_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exam_and_test_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAndTestManagement", x => x.exam_and_test_ID);
                });

            migrationBuilder.CreateTable(
                name: "ExamBank",
                columns: table => new
                {
                    exambankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exambank_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamBank", x => x.exambankID);
                });

            migrationBuilder.CreateTable(
                name: "FileManagement",
                columns: table => new
                {
                    fileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileManagement", x => x.fileID);
                });

            migrationBuilder.CreateTable(
                name: "HelpManagement",
                columns: table => new
                {
                    helpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    help_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    help_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpManagement", x => x.helpID);
                });

            migrationBuilder.CreateTable(
                name: "LessionManagement",
                columns: table => new
                {
                    lessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lession_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lession_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessionManagement", x => x.lessionID);
                });

            migrationBuilder.CreateTable(
                name: "NotificationManagement",
                columns: table => new
                {
                    notificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notification_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notification_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationManagement", x => x.notificationID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectManagement",
                columns: table => new
                {
                    subjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subject_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectManagement", x => x.subjectID);
                });

            migrationBuilder.CreateTable(
                name: "SystemManagement",
                columns: table => new
                {
                    systemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    system_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemManagement", x => x.systemID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacher_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacher_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacherID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ExamAndTestManagement");

            migrationBuilder.DropTable(
                name: "ExamBank");

            migrationBuilder.DropTable(
                name: "FileManagement");

            migrationBuilder.DropTable(
                name: "HelpManagement");

            migrationBuilder.DropTable(
                name: "LessionManagement");

            migrationBuilder.DropTable(
                name: "NotificationManagement");

            migrationBuilder.DropTable(
                name: "SubjectManagement");

            migrationBuilder.DropTable(
                name: "SystemManagement");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
