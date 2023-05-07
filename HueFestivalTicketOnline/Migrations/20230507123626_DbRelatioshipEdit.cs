using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestivalTicketOnline.Migrations
{
    public partial class DbRelatioshipEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventType_eventTypeID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Event_eventID",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_customerID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Event_eventID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Location_locationID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketType_ticketTypeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_userID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCheckin_Ticket_ticketID",
                table: "TicketCheckin");

            migrationBuilder.AlterColumn<int>(
                name: "ticketID",
                table: "TicketCheckin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ticketTypeID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "locationID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "eventID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customerID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "eventID",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "eventTypeID",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventType_eventTypeID",
                table: "Event",
                column: "eventTypeID",
                principalTable: "EventType",
                principalColumn: "eventTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Event_eventID",
                table: "News",
                column: "eventID",
                principalTable: "Event",
                principalColumn: "eventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_customerID",
                table: "Ticket",
                column: "customerID",
                principalTable: "Customer",
                principalColumn: "customerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Event_eventID",
                table: "Ticket",
                column: "eventID",
                principalTable: "Event",
                principalColumn: "eventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Location_locationID",
                table: "Ticket",
                column: "locationID",
                principalTable: "Location",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketType_ticketTypeID",
                table: "Ticket",
                column: "ticketTypeID",
                principalTable: "TicketType",
                principalColumn: "ticketTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_userID",
                table: "Ticket",
                column: "userID",
                principalTable: "User",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCheckin_Ticket_ticketID",
                table: "TicketCheckin",
                column: "ticketID",
                principalTable: "Ticket",
                principalColumn: "ticketID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventType_eventTypeID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Event_eventID",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_customerID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Event_eventID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Location_locationID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketType_ticketTypeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_userID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCheckin_Ticket_ticketID",
                table: "TicketCheckin");

            migrationBuilder.AlterColumn<int>(
                name: "ticketID",
                table: "TicketCheckin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ticketTypeID",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "locationID",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "eventID",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "customerID",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "eventID",
                table: "News",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "eventTypeID",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventType_eventTypeID",
                table: "Event",
                column: "eventTypeID",
                principalTable: "EventType",
                principalColumn: "eventTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Event_eventID",
                table: "News",
                column: "eventID",
                principalTable: "Event",
                principalColumn: "eventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_customerID",
                table: "Ticket",
                column: "customerID",
                principalTable: "Customer",
                principalColumn: "customerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Event_eventID",
                table: "Ticket",
                column: "eventID",
                principalTable: "Event",
                principalColumn: "eventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Location_locationID",
                table: "Ticket",
                column: "locationID",
                principalTable: "Location",
                principalColumn: "locationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketType_ticketTypeID",
                table: "Ticket",
                column: "ticketTypeID",
                principalTable: "TicketType",
                principalColumn: "ticketTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_userID",
                table: "Ticket",
                column: "userID",
                principalTable: "User",
                principalColumn: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCheckin_Ticket_ticketID",
                table: "TicketCheckin",
                column: "ticketID",
                principalTable: "Ticket",
                principalColumn: "ticketID");
        }
    }
}
