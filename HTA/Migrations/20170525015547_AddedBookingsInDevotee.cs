using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HTA.Migrations
{
    public partial class AddedBookingsInDevotee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_booking_tbl_servicegroup_ServiceGroup_ID",
                schema: "dbo",
                table: "tbl_booking");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_bookingitem_Service_Service_Id",
                schema: "dbo",
                table: "tbl_bookingitem");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_tbl_servicegroup_ServiceGroup_ID",
                schema: "dbo",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                schema: "dbo",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_tbl_booking_ServiceGroup_ID",
                schema: "dbo",
                table: "tbl_booking");

            migrationBuilder.DropColumn(
                name: "ServiceGroup_ID",
                schema: "dbo",
                table: "tbl_booking");

            migrationBuilder.RenameTable(
                name: "Service",
                schema: "dbo",
                newName: "tbl_service");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ServiceGroup_ID",
                schema: "dbo",
                table: "tbl_service",
                newName: "IX_tbl_service_ServiceGroup_ID");

            migrationBuilder.RenameColumn(
                name: "DevoteeMemID",
                schema: "dbo",
                table: "tbl_booking",
                newName: "DevoteeMemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_service",
                schema: "dbo",
                table: "tbl_service",
                column: "Service_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_bookingitem_tbl_service_Service_Id",
                schema: "dbo",
                table: "tbl_bookingitem",
                column: "Service_Id",
                principalSchema: "dbo",
                principalTable: "tbl_service",
                principalColumn: "Service_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_service_tbl_servicegroup_ServiceGroup_ID",
                schema: "dbo",
                table: "tbl_service",
                column: "ServiceGroup_ID",
                principalSchema: "dbo",
                principalTable: "tbl_servicegroup",
                principalColumn: "ServiceGroup_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
