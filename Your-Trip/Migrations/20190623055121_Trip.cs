using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YourTrip.Migrations
{
    public partial class Trip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Passport = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Mail = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Passport);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ExtraPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyValue = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    PlaneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerPassport = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerPassport",
                        column: x => x.CustomerPassport,
                        principalTable: "Customer",
                        principalColumn: "Passport",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaneDepartment",
                columns: table => new
                {
                    PlaneId = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneDepartment", x => new { x.PlaneId, x.DepartmentName });
                    table.ForeignKey(
                        name: "FK_PlaneDepartment_Department_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Department",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaneDepartment_Plane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Plane",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DestinationId = table.Column<int>(nullable: true),
                    Landing = table.Column<DateTime>(nullable: false),
                    PlaneId = table.Column<int>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    TakeOff = table.Column<DateTime>(nullable: false),
                    TerminalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_Flight_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Plane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Plane",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Terminal_TerminalName",
                        column: x => x.TerminalName,
                        principalTable: "Terminal",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerPassport = table.Column<int>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    FlightNumber = table.Column<int>(nullable: true),
                    LandingDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    TakeOffTime = table.Column<DateTime>(nullable: false),
                    TerminalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketNumber);
                    table.ForeignKey(
                        name: "FK_Ticket_Customer_CustomerPassport",
                        column: x => x.CustomerPassport,
                        principalTable: "Customer",
                        principalColumn: "Passport",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Department_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Department",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightNumber",
                        column: x => x.FlightNumber,
                        principalTable: "Flight",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Terminal_TerminalName",
                        column: x => x.TerminalName,
                        principalTable: "Terminal",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaneId = table.Column<int>(nullable: true),
                    TicketNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_Plane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Plane",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seat_Ticket_TicketNumber",
                        column: x => x.TicketNumber,
                        principalTable: "Ticket",
                        principalColumn: "TicketNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationId",
                table: "Flight",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PlaneId",
                table: "Flight",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_TerminalName",
                table: "Flight",
                column: "TerminalName");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerPassport",
                table: "Order",
                column: "CustomerPassport");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneDepartment_DepartmentName",
                table: "PlaneDepartment",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_PlaneId",
                table: "Seat",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TicketNumber",
                table: "Seat",
                column: "TicketNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerPassport",
                table: "Ticket",
                column: "CustomerPassport");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DepartmentName",
                table: "Ticket",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightNumber",
                table: "Ticket",
                column: "FlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderId",
                table: "Ticket",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TerminalName",
                table: "Ticket",
                column: "TerminalName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaneDepartment");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Plane");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
