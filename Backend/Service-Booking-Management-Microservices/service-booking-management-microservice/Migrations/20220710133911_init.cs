using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_Booking_Management_Microservice.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReqDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppServiceReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTaken = table.Column<bool>(type: "bit", nullable: false),
                    DiagnosisDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    VisitFees = table.Column<int>(type: "int", nullable: false),
                    RepairDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerReqId = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppServiceReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppServiceReports_AppServices_AppServiceId",
                        column: x => x.AppServiceId,
                        principalTable: "AppServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppServiceReports_AppServiceId",
                table: "AppServiceReports",
                column: "AppServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppServiceReports");

            migrationBuilder.DropTable(
                name: "AppServices");
        }
    }
}
