using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace playgroudaspschedule.Migrations
{
    public partial class first_schedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    location_id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.location_id);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    event_id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    location_id = table.Column<int>(isNullable: false),
                    start = table.Column<DateTime>(isNullable: false),
                    stop = table.Column<DateTime>(isNullable: false),
                    user_id = table.Column<int>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_Event_Location_location_id",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "location_id");
                    table.ForeignKey(
                        name: "FK_Event_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Event");
            migrationBuilder.DropTable("Location");
            migrationBuilder.DropTable("User");
        }
    }
}
