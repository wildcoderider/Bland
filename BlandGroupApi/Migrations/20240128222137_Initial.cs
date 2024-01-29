using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlandGroupApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryOfVehicle = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RegNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ConfidenceLevel = table.Column<int>(type: "int", nullable: false),
                    CameraName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CaptureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageFilename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimestampProcessed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plates");

            migrationBuilder.DropTable(
                name: "UserFiles");
        }
    }
}
