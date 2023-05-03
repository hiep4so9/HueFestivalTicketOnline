using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestivalTicketOnline.Migrations
{
    public partial class DbAddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "permissionID",
                table: "Role_Permission",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "roleID",
                table: "Role_Permission",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_roleID",
                table: "User_Role",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permission_permissionID",
                table: "Role_Permission",
                column: "permissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Locations_locationID",
                table: "Events_Locations",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Images_eventImageID",
                table: "Event_Images",
                column: "eventImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Invited_eventID",
                table: "Artists_Invited",
                column: "eventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Invited_Artist_artistID",
                table: "Artists_Invited",
                column: "artistID",
                principalTable: "Artist",
                principalColumn: "artistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Invited_Event_eventID",
                table: "Artists_Invited",
                column: "eventID",
                principalTable: "Event",
                principalColumn: "eventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Images_Event_eventID",
                table: "Event_Images",
                column: "eventID",
                principalTable: "Event",
                principalColumn: "eventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Images_EventImage_eventImageID",
                table: "Event_Images",
                column: "eventImageID",
                principalTable: "EventImage",
                principalColumn: "eventImageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_Event_eventID",
                table: "Events_Locations",
                column: "eventID",
                principalTable: "Event",
                principalColumn: "eventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_Location_locationID",
                table: "Events_Locations",
                column: "locationID",
                principalTable: "Location",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permission_Permission_permissionID",
                table: "Role_Permission",
                column: "permissionID",
                principalTable: "Permission",
                principalColumn: "permissionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permission_Role_roleID",
                table: "Role_Permission",
                column: "roleID",
                principalTable: "Role",
                principalColumn: "roleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Role_roleID",
                table: "User_Role",
                column: "roleID",
                principalTable: "Role",
                principalColumn: "roleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_User_userID",
                table: "User_Role",
                column: "userID",
                principalTable: "User",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Invited_Artist_artistID",
                table: "Artists_Invited");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Invited_Event_eventID",
                table: "Artists_Invited");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Images_Event_eventID",
                table: "Event_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Images_EventImage_eventImageID",
                table: "Event_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_Event_eventID",
                table: "Events_Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_Location_locationID",
                table: "Events_Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permission_Permission_permissionID",
                table: "Role_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permission_Role_roleID",
                table: "Role_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Role_roleID",
                table: "User_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_User_userID",
                table: "User_Role");

            migrationBuilder.DropIndex(
                name: "IX_User_Role_roleID",
                table: "User_Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_Permission_permissionID",
                table: "Role_Permission");

            migrationBuilder.DropIndex(
                name: "IX_Events_Locations_locationID",
                table: "Events_Locations");

            migrationBuilder.DropIndex(
                name: "IX_Event_Images_eventImageID",
                table: "Event_Images");

            migrationBuilder.DropIndex(
                name: "IX_Artists_Invited_eventID",
                table: "Artists_Invited");

            migrationBuilder.AlterColumn<int>(
                name: "permissionID",
                table: "Role_Permission",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "roleID",
                table: "Role_Permission",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);
        }
    }
}
