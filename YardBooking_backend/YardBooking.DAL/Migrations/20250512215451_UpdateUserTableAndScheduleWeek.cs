using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YardBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTableAndScheduleWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Yards_YardId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "IDNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IDPhoto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonPhoto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "YardId",
                table: "Schedules",
                newName: "YardID_FK");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Schedules",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_YardId",
                table: "Schedules",
                newName: "IX_Schedules_YardID_FK");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ScheduleId1",
                table: "Bookings",
                column: "ScheduleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId1",
                table: "Bookings",
                column: "ScheduleId1",
                principalTable: "Schedules",
                principalColumn: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Yards_YardID_FK",
                table: "Schedules",
                column: "YardID_FK",
                principalTable: "Yards",
                principalColumn: "YardId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Yards_YardID_FK",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ScheduleId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ScheduleId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "address",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "YardID_FK",
                table: "Schedules",
                newName: "YardId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Schedules",
                newName: "IsAvailable");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_YardID_FK",
                table: "Schedules",
                newName: "IX_Schedules_YardId");

            migrationBuilder.AddColumn<string>(
                name: "IDNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IDPhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonPhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Yards_YardId",
                table: "Schedules",
                column: "YardId",
                principalTable: "Yards",
                principalColumn: "YardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
