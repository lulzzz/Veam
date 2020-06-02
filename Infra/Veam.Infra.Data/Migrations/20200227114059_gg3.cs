using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veam.Infra.Data.Migrations
{
    public partial class gg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetUploads",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "CheckOut",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "PurchaseFiles",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "Asset",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "FileDetails",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "AssetPurchase",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "AssetStatus",
                schema: "EAM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EAM");

            migrationBuilder.CreateTable(
                name: "AssetPurchase",
                schema: "EAM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    vendorId = table.Column<long>(type: "bigint", nullable: false),
                    company_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    company_Country = table.Column<DateTime>(type: "datetime2", maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPurchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetStatus",
                schema: "EAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDetails",
                schema: "EAM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fileNotes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    fileSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                schema: "EAM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    assetName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    assetPurchaseId = table.Column<long>(type: "bigint", nullable: true),
                    assetTag = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    assetstatusId = table.Column<int>(type: "int", nullable: false),
                    assignTo = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serialNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    model_brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    model_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    model_number = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    model_product = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    warranty_EndDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true),
                    warranty_StartDate = table.Column<DateTime>(type: "datetime2", maxLength: 75, nullable: true),
                    warranty_notes = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    warranty_Months = table.Column<int>(type: "int", maxLength: 75, nullable: true),
                    warranty_By = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetPurchase_assetPurchaseId",
                        column: x => x.assetPurchaseId,
                        principalSchema: "EAM",
                        principalTable: "AssetPurchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_AssetStatus_assetstatusId",
                        column: x => x.assetstatusId,
                        principalSchema: "EAM",
                        principalTable: "AssetStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseFiles",
                schema: "EAM",
                columns: table => new
                {
                    AssetpurchaseId = table.Column<long>(type: "bigint", nullable: false),
                    FileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseFiles", x => new { x.AssetpurchaseId, x.FileId });
                    table.ForeignKey(
                        name: "FK_PurchaseFiles_AssetPurchase_AssetpurchaseId",
                        column: x => x.AssetpurchaseId,
                        principalSchema: "EAM",
                        principalTable: "AssetPurchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseFiles_FileDetails_FileId",
                        column: x => x.FileId,
                        principalSchema: "EAM",
                        principalTable: "FileDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetUploads",
                schema: "EAM",
                columns: table => new
                {
                    assetId = table.Column<long>(type: "bigint", nullable: false),
                    FileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetUploads", x => new { x.assetId, x.FileId });
                    table.ForeignKey(
                        name: "FK_AssetUploads_Asset_assetId",
                        column: x => x.assetId,
                        principalSchema: "EAM",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetUploads_FileDetails_assetId",
                        column: x => x.assetId,
                        principalSchema: "EAM",
                        principalTable: "FileDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckOut",
                schema: "EAM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    assetId = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    retiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    returnedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assignmentInfo_assetConditon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assignmentInfo_assignmentStatus = table.Column<int>(type: "int", nullable: true),
                    assignmentInfo_conditionNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestInfo_acceptedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestInfo_approveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requestInfo_approvedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestInfo_checkedOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requestInfo_requestedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestInfo_requestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    employeeId = table.Column<long>(type: "bigint", nullable: true),
                    managerId = table.Column<long>(type: "bigint", nullable: true),
                    subsideryId = table.Column<long>(type: "bigint", nullable: true),
                    centerId = table.Column<long>(type: "bigint", nullable: true),
                    hallId = table.Column<long>(type: "bigint", nullable: true),
                    CheckOutToLocation_managerId = table.Column<long>(type: "bigint", nullable: true),
                    CheckOutToLocation_subsideryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckOut_Asset_assetId",
                        column: x => x.assetId,
                        principalSchema: "EAM",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_assetPurchaseId",
                schema: "EAM",
                table: "Asset",
                column: "assetPurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_assetstatusId",
                schema: "EAM",
                table: "Asset",
                column: "assetstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_assetId",
                schema: "EAM",
                table: "CheckOut",
                column: "assetId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseFiles_FileId",
                schema: "EAM",
                table: "PurchaseFiles",
                column: "FileId");
        }
    }
}
