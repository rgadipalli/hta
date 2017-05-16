using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HTA.Migrations
{
    public partial class DateFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Wedding_Date",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "StateID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Star_ID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MemberType_ID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_Modified",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_LoggedIn",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gothram_ID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Created",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Wedding_Date",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Star_ID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberType_ID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Last_Modified",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_LoggedIn",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gothram_ID",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Created",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                schema: "dbo",
                table: "tbl_devotee",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
