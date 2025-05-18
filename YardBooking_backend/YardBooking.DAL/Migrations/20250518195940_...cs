using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YardBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamBookings_Bookings_BookingId",
                table: "TeamBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamBookings_Teams_TeamId",
                table: "TeamBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_CaptainId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Yards_AspNetUsers_OwnerId",
                table: "Yards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamBookings",
                table: "TeamBookings");

            migrationBuilder.DropColumn(
                name: "address",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "YardId",
                table: "Yards",
                newName: "YardID");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "TeamBookings",
                newName: "BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_TeamBookings_BookingId",
                table: "TeamBookings",
                newName: "IX_TeamBookings_BookingID");

            migrationBuilder.AlterColumn<string>(
                name: "YardName",
                table: "Yards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "YardLocation",
                table: "Yards",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "YardArea",
                table: "Yards",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "ServicesOffered",
                table: "Yards",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Teams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TeamId",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CaptainId1",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TeamId",
                table: "TeamMembers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TeamId1",
                table: "TeamMembers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TeamMembers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TeamId",
                table: "TeamBookings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "TeamBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeamId1",
                table: "TeamBookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Schedules",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercentage",
                table: "Offers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Offers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId1",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YardID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamBookings",
                table: "TeamBookings",
                columns: new[] { "BookingId", "TeamId" });

            migrationBuilder.CreateTable(
                name: "Proximities",
                columns: table => new
                {
                    YardID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    YardID1 = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proximities", x => new { x.YardID, x.UserID });
                    table.ForeignKey(
                        name: "FK_Proximities_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proximities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proximities_Yards_YardID",
                        column: x => x.YardID,
                        principalTable: "Yards",
                        principalColumn: "YardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proximities_Yards_YardID1",
                        column: x => x.YardID1,
                        principalTable: "Yards",
                        principalColumn: "YardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YardOwners",
                columns: table => new
                {
                    YardID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YardLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    YardArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicesOffered = table.Column<bool>(type: "bit", nullable: true),
                    YardPhotos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YardOwners", x => x.YardID);
                    table.ForeignKey(
                        name: "FK_YardOwners_AspNetUsers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YardOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CaptainId1",
                table: "Teams",
                column: "CaptainId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId1",
                table: "TeamMembers",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId1",
                table: "TeamMembers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeamBookings_TeamId",
                table: "TeamBookings",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamBookings_TeamId1",
                table: "TeamBookings",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingID",
                table: "Payments",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_YardID",
                table: "Bookings",
                column: "YardID");

            migrationBuilder.CreateIndex(
                name: "IX_Proximities_UserId",
                table: "Proximities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proximities_UserID",
                table: "Proximities",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Proximities_YardID1",
                table: "Proximities",
                column: "YardID1");

            migrationBuilder.CreateIndex(
                name: "IX_YardOwners_OwnerID",
                table: "YardOwners",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_YardOwners_UserId",
                table: "YardOwners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId1",
                table: "Bookings",
                column: "ScheduleId1",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Yards_YardID",
                table: "Bookings",
                column: "YardID",
                principalTable: "Yards",
                principalColumn: "YardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Yards_OfferId",
                table: "Offers",
                column: "OfferId",
                principalTable: "Yards",
                principalColumn: "YardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingID",
                table: "Payments",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamBookings_Bookings_BookingID",
                table: "TeamBookings",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamBookings_Bookings_BookingId",
                table: "TeamBookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamBookings_Teams_TeamId",
                table: "TeamBookings",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamBookings_Teams_TeamId1",
                table: "TeamBookings",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_AspNetUsers_UserId1",
                table: "TeamMembers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId1",
                table: "TeamMembers",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_CaptainId",
                table: "Teams",
                column: "CaptainId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_CaptainId1",
                table: "Teams",
                column: "CaptainId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yards_YardOwners_OwnerId",
                table: "Yards",
                column: "OwnerId",
                principalTable: "YardOwners",
                principalColumn: "YardID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Yards_YardID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Yards_OfferId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamBookings_Bookings_BookingID",
                table: "TeamBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamBookings_Bookings_BookingId",
                table: "TeamBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamBookings_Teams_TeamId",
                table: "TeamBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamBookings_Teams_TeamId1",
                table: "TeamBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_AspNetUsers_UserId1",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId1",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_CaptainId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_CaptainId1",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Yards_YardOwners_OwnerId",
                table: "Yards");

            migrationBuilder.DropTable(
                name: "Proximities");

            migrationBuilder.DropTable(
                name: "YardOwners");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CaptainId1",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_TeamId1",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_UserId1",
                table: "TeamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamBookings",
                table: "TeamBookings");

            migrationBuilder.DropIndex(
                name: "IX_TeamBookings_TeamId",
                table: "TeamBookings");

            migrationBuilder.DropIndex(
                name: "IX_TeamBookings_TeamId1",
                table: "TeamBookings");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BookingID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_YardID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CaptainId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "TeamBookings");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "TeamBookings");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "YardID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "YardID",
                table: "Yards",
                newName: "YardId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "TeamBookings",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamBookings_BookingID",
                table: "TeamBookings",
                newName: "IX_TeamBookings_BookingId");

            migrationBuilder.AlterColumn<string>(
                name: "YardName",
                table: "Yards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "YardLocation",
                table: "Yards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<double>(
                name: "YardArea",
                table: "Yards",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServicesOffered",
                table: "Yards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamMembers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamBookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Schedules",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercentage",
                table: "Offers",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Offers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId1",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamBookings",
                table: "TeamBookings",
                columns: new[] { "TeamId", "BookingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId1",
                table: "Bookings",
                column: "ScheduleId1",
                principalTable: "Schedules",
                principalColumn: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamBookings_Bookings_BookingId",
                table: "TeamBookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamBookings_Teams_TeamId",
                table: "TeamBookings",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_CaptainId",
                table: "Teams",
                column: "CaptainId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yards_AspNetUsers_OwnerId",
                table: "Yards",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
