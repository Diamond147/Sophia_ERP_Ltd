using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sophia_Ltd.Migrations
{
    /// <inheritdoc />
    public partial class AddedApplicationObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "UpdateAt",
                table: "employees",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicantName = table.Column<string>(type: "text", nullable: false),
                    ApplicantEmail = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    SubmittedAt = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdateAt = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_applications_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applications_EmployeeId",
                table: "applications",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "UpdateAt",
                table: "employees",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
