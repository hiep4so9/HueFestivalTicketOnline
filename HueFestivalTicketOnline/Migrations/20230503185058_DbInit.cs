using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestivalTicketOnline.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    artistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    artistName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.artistID);
                });

            migrationBuilder.CreateTable(
                name: "Artists_Invited",
                columns: table => new
                {
                    artistID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists_Invited", x => new { x.artistID, x.eventID });
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    identityCardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    paymentInfo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "Event_Images",
                columns: table => new
                {
                    eventImageID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Images", x => new { x.eventID, x.eventImageID });
                });

            migrationBuilder.CreateTable(
                name: "EventImage",
                columns: table => new
                {
                    eventImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventImage", x => x.eventImageID);
                });

            migrationBuilder.CreateTable(
                name: "Events_Locations",
                columns: table => new
                {
                    locationID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false),
                    ticketQuantity = table.Column<int>(type: "int", nullable: false),
                    start_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events_Locations", x => new { x.eventID, x.locationID });
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    eventTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.eventTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.locationID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    permissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.permissionID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "Role_Permission",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false),
                    permissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Permission", x => new { x.roleID, x.permissionID });
                });

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    ticketTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.ticketTypeID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    userImage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    roleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role", x => new { x.userID, x.roleID });
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    eventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.eventID);
                    table.ForeignKey(
                        name: "FK_Event_EventType_eventTypeID",
                        column: x => x.eventTypeID,
                        principalTable: "EventType",
                        principalColumn: "eventTypeID");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    newsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    newName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    newsContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.newsID);
                    table.ForeignKey(
                        name: "FK_News_Event_eventID",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "eventID");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: true),
                    locationID = table.Column<int>(type: "int", nullable: true),
                    eventID = table.Column<int>(type: "int", nullable: true),
                    ticketTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ticketID);
                    table.ForeignKey(
                        name: "FK_Ticket_Customer_customerID",
                        column: x => x.customerID,
                        principalTable: "Customer",
                        principalColumn: "customerID");
                    table.ForeignKey(
                        name: "FK_Ticket_Event_eventID",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "eventID");
                    table.ForeignKey(
                        name: "FK_Ticket_Location_locationID",
                        column: x => x.locationID,
                        principalTable: "Location",
                        principalColumn: "locationID");
                    table.ForeignKey(
                        name: "FK_Ticket_TicketType_ticketTypeID",
                        column: x => x.ticketTypeID,
                        principalTable: "TicketType",
                        principalColumn: "ticketTypeID");
                    table.ForeignKey(
                        name: "FK_Ticket_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "TicketCheckin",
                columns: table => new
                {
                    ticketCheckinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticketID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCheckin", x => x.ticketCheckinID);
                    table.ForeignKey(
                        name: "FK_TicketCheckin_Ticket_ticketID",
                        column: x => x.ticketID,
                        principalTable: "Ticket",
                        principalColumn: "ticketID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_eventTypeID",
                table: "Event",
                column: "eventTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_News_eventID",
                table: "News",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_customerID",
                table: "Ticket",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_eventID",
                table: "Ticket",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_locationID",
                table: "Ticket",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ticketTypeID",
                table: "Ticket",
                column: "ticketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_userID",
                table: "Ticket",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCheckin_ticketID",
                table: "TicketCheckin",
                column: "ticketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Artists_Invited");

            migrationBuilder.DropTable(
                name: "Event_Images");

            migrationBuilder.DropTable(
                name: "EventImage");

            migrationBuilder.DropTable(
                name: "Events_Locations");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Role_Permission");

            migrationBuilder.DropTable(
                name: "TicketCheckin");

            migrationBuilder.DropTable(
                name: "User_Role");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EventType");
        }
    }
}
