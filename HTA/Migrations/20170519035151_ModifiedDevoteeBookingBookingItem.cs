using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HTA.Migrations
{
    public partial class ModifiedDevoteeBookingBookingItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_booking_tbl_devotee_DevoteeId",
                schema: "dbo",
                table: "tbl_booking");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_bookingitem_tbl_service_Service_Id",
                schema: "dbo",
                table: "tbl_bookingitem");

            migrationBuilder.DropColumn(
                name: "Booking_Id",
                schema: "dbo",
                table: "tbl_bookingitem");

            migrationBuilder.DropColumn(
                name: "ServiceForDevoteeId",
                schema: "dbo",
                table: "tbl_booking");

            migrationBuilder.RenameColumn(
                name: "Service_Id",
                schema: "dbo",
                table: "tbl_bookingitem",
                newName: "Service_ID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_bookingitem_Service_Id",
                schema: "dbo",
                table: "tbl_bookingitem",
                newName: "IX_tbl_bookingitem_Service_ID");

            migrationBuilder.AlterColumn<int>(
                name: "Service_ID",
                schema: "dbo",
                table: "tbl_bookingitem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DevoteeId",
                schema: "dbo",
                table: "tbl_booking",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_booking_tbl_devotee_DevoteeId",
                schema: "dbo",
                table: "tbl_booking",
                column: "DevoteeId",
                principalSchema: "dbo",
                principalTable: "tbl_devotee",
                principalColumn: "Devotee_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_bookingitem_tbl_service_Service_ID",
                schema: "dbo",
                table: "tbl_bookingitem",
                column: "Service_ID",
                principalSchema: "dbo",
                principalTable: "tbl_service",
                principalColumn: "Service_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
