using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HTA.Migrations
{
    public partial class BookingService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_bookingitem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_booking",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_service",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_servicegroup",
                schema: "dbo");
        }
    }
}
