using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veam.Infra.Data.Migrations
{
    public partial class checkgg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "assignedType",
                schema: "EAM",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "parentAssetId",
                schema: "EAM",
                table: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "requestedDate",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestInfo_requestedDate");

            migrationBuilder.RenameColumn(
                name: "requestedBy",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestInfo_requestedBy");

            migrationBuilder.RenameColumn(
                name: "conditionNote",
                schema: "EAM",
                table: "CheckOut",
                newName: "assignmentInfo_conditionNote");

            migrationBuilder.RenameColumn(
                name: "checkedOutDate",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestInfo_checkedOutDate");

            migrationBuilder.RenameColumn(
                name: "assignmentStatus",
                schema: "EAM",
                table: "CheckOut",
                newName: "assignmentInfo_assignmentStatus");

            migrationBuilder.RenameColumn(
                name: "assetConditon",
                schema: "EAM",
                table: "CheckOut",
                newName: "assignmentInfo_assetConditon");

            migrationBuilder.RenameColumn(
                name: "approvedBy",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestInfo_approvedBy");

            migrationBuilder.RenameColumn(
                name: "approveDate",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestInfo_approveDate");

            migrationBuilder.RenameColumn(
                name: "acceptedBy",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestInfo_acceptedBy");

            migrationBuilder.AlterColumn<long>(
                name: "subsideryId",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "managerId",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "hallId",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "employeeId",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "centerId",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "requestInfo_requestedDate",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "requestInfo_requestedBy",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "assignmentInfo_conditionNote",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "requestInfo_checkedOutDate",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "assignmentInfo_assignmentStatus",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "assignmentInfo_assetConditon",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "requestInfo_approvedBy",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "requestInfo_approveDate",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "requestInfo_acceptedBy",
                schema: "EAM",
                table: "CheckOut",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "to",
                schema: "EAM",
                table: "CheckOut",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CheckOutToLocation_managerId",
                schema: "EAM",
                table: "CheckOut",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CheckOutToLocation_subsideryId",
                schema: "EAM",
                table: "CheckOut",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "assignTo",
                schema: "EAM",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_productCode",
                schema: "Base",
                table: "Product",
                column: "productCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_productCode",
                schema: "Base",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "to",
                schema: "EAM",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "CheckOutToLocation_managerId",
                schema: "EAM",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "CheckOutToLocation_subsideryId",
                schema: "EAM",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "assignTo",
                schema: "EAM",
                table: "Asset");

            migrationBuilder.RenameColumn(
                name: "requestInfo_requestedDate",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestedDate");

            migrationBuilder.RenameColumn(
                name: "requestInfo_requestedBy",
                schema: "EAM",
                table: "CheckOut",
                newName: "requestedBy");

            migrationBuilder.RenameColumn(
                name: "requestInfo_checkedOutDate",
                schema: "EAM",
                table: "CheckOut",
                newName: "checkedOutDate");

            migrationBuilder.RenameColumn(
                name: "requestInfo_approvedBy",
                schema: "EAM",
                table: "CheckOut",
                newName: "approvedBy");

            migrationBuilder.RenameColumn(
                name: "requestInfo_approveDate",
                schema: "EAM",
                table: "CheckOut",
                newName: "approveDate");

            migrationBuilder.RenameColumn(
                name: "requestInfo_acceptedBy",
                schema: "EAM",
                table: "CheckOut",
                newName: "acceptedBy");

            migrationBuilder.RenameColumn(
                name: "assignmentInfo_conditionNote",
                schema: "EAM",
                table: "CheckOut",
                newName: "conditionNote");

            migrationBuilder.RenameColumn(
                name: "assignmentInfo_assignmentStatus",
                schema: "EAM",
                table: "CheckOut",
                newName: "assignmentStatus");

            migrationBuilder.RenameColumn(
                name: "assignmentInfo_assetConditon",
                schema: "EAM",
                table: "CheckOut",
                newName: "assetConditon");

            migrationBuilder.AlterColumn<long>(
                name: "hallId",
                schema: "EAM",
                table: "CheckOut",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "centerId",
                schema: "EAM",
                table: "CheckOut",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "subsideryId",
                schema: "EAM",
                table: "CheckOut",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "managerId",
                schema: "EAM",
                table: "CheckOut",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "employeeId",
                schema: "EAM",
                table: "CheckOut",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "requestedDate",
                schema: "EAM",
                table: "CheckOut",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "requestedBy",
                schema: "EAM",
                table: "CheckOut",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "checkedOutDate",
                schema: "EAM",
                table: "CheckOut",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "approvedBy",
                schema: "EAM",
                table: "CheckOut",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "approveDate",
                schema: "EAM",
                table: "CheckOut",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "acceptedBy",
                schema: "EAM",
                table: "CheckOut",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "conditionNote",
                schema: "EAM",
                table: "CheckOut",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "assignmentStatus",
                schema: "EAM",
                table: "CheckOut",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "assetConditon",
                schema: "EAM",
                table: "CheckOut",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "assignedType",
                schema: "EAM",
                table: "CheckOut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "parentAssetId",
                schema: "EAM",
                table: "CheckOut",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
