using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HTA.Migrations
{
    public partial class AddedHeadDevotee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_devotee_tbl_devotee_Head_Devotee_ID",
                schema: "dbo",
                table: "tbl_devotee");

            migrationBuilder.DropIndex(
                name: "IX_tbl_devotee_Head_Devotee_ID",
                schema: "dbo",
                table: "tbl_devotee");

            migrationBuilder.DropColumn(
                name: "Head_Devotee_ID",
                schema: "dbo",
                table: "tbl_devotee");

            migrationBuilder.AddColumn<int>(
                name: "DevoteeMemID",
                schema: "dbo",
                table: "tbl_booking",
                nullable: true);
        }
    }
}
