using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enongzi.MeetingReport.Migrations
{
    public partial class updateadddatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "meeting",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "subject",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "subject",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "meeting",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "subject");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "subject");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "meeting");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "meeting",
                newName: "Time");
        }
    }
}
