using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBodyType",
                columns: table => new
                {
                    BodyTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodyType", x => x.BodyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CarMake",
                columns: table => new
                {
                    MakeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMake", x => x.MakeID);
                });

            migrationBuilder.CreateTable(
                name: "CarService",
                columns: table => new
                {
                    RegistrationNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    KMTravelled = table.Column<int>(type: "int", nullable: true),
                    ServicedKM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarService", x => x.RegistrationNumber);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.DetailID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BodyTypeID = table.Column<int>(type: "int", nullable: true),
                    MakeID = table.Column<int>(type: "int", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Car_CarBodyType_BodyTypeID",
                        column: x => x.BodyTypeID,
                        principalTable: "CarBodyType",
                        principalColumn: "BodyTypeID");
                    table.ForeignKey(
                        name: "FK_Car_CarMake_MakeID",
                        column: x => x.MakeID,
                        principalTable: "CarMake",
                        principalColumn: "MakeID");
                    table.ForeignKey(
                        name: "FK_Car_CarService_RegistrationNumber",
                        column: x => x.RegistrationNumber,
                        principalTable: "CarService",
                        principalColumn: "RegistrationNumber");
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailID = table.Column<int>(type: "int", nullable: true),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverID);
                    table.ForeignKey(
                        name: "FK_Driver_Detail_DetailID",
                        column: x => x.DetailID,
                        principalTable: "Detail",
                        principalColumn: "DetailID");
                });

            migrationBuilder.CreateTable(
                name: "Inspector",
                columns: table => new
                {
                    InspectorID = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspector", x => x.InspectorID);
                    table.ForeignKey(
                        name: "FK_Inspector_Detail_DetailID",
                        column: x => x.DetailID,
                        principalTable: "Detail",
                        principalColumn: "DetailID");
                });

            migrationBuilder.CreateTable(
                name: "CarRental",
                columns: table => new
                {
                    RentalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    InspectorID = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DriverID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    RentalPrice = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRental", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_CarRental_CarService_RegistrationNumber",
                        column: x => x.RegistrationNumber,
                        principalTable: "CarService",
                        principalColumn: "RegistrationNumber");
                    table.ForeignKey(
                        name: "FK_CarRental_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "DriverID");
                    table.ForeignKey(
                        name: "FK_CarRental_Inspector_InspectorID",
                        column: x => x.InspectorID,
                        principalTable: "Inspector",
                        principalColumn: "InspectorID");
                });

            migrationBuilder.CreateTable(
                name: "CarReturn",
                columns: table => new
                {
                    ReturnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "date", nullable: true),
                    FineAmount = table.Column<decimal>(type: "money", nullable: true),
                    ElapsedDays = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReturn", x => x.ReturnID);
                    table.ForeignKey(
                        name: "FK_CarReturn_CarRental_RentalID",
                        column: x => x.RentalID,
                        principalTable: "CarRental",
                        principalColumn: "RentalID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BodyTypeID",
                table: "Car",
                column: "BodyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_MakeID",
                table: "Car",
                column: "MakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RegistrationNumber",
                table: "Car",
                column: "RegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CarRental_DriverID",
                table: "CarRental",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_CarRental_InspectorID",
                table: "CarRental",
                column: "InspectorID");

            migrationBuilder.CreateIndex(
                name: "IX_CarRental_RegistrationNumber",
                table: "CarRental",
                column: "RegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CarReturn_RentalID",
                table: "CarReturn",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "UQ_Drivers_1",
                table: "Driver",
                column: "DetailID",
                unique: true,
                filter: "[DetailID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Inspector_1",
                table: "Inspector",
                column: "DetailID",
                unique: true,
                filter: "[DetailID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarReturn");

            migrationBuilder.DropTable(
                name: "CarBodyType");

            migrationBuilder.DropTable(
                name: "CarMake");

            migrationBuilder.DropTable(
                name: "CarRental");

            migrationBuilder.DropTable(
                name: "CarService");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Inspector");

            migrationBuilder.DropTable(
                name: "Detail");
        }
    }
}
