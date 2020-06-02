using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veam.EAM.Data.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EAM");

            migrationBuilder.CreateTable(
                name: "AssetPurchase",
                schema: "EAM",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    company_Name = table.Column<string>(maxLength: 75, nullable: true),
                    company_Country = table.Column<DateTime>(maxLength: 75, nullable: true),
                    vendorId = table.Column<long>(nullable: false),
                    notes = table.Column<string>(maxLength: 250, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(nullable: true)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    FileUrl = table.Column<string>(nullable: true),
                    fileName = table.Column<string>(maxLength: 100, nullable: true),
                    fileSize = table.Column<string>(maxLength: 50, nullable: true),
                    fileNotes = table.Column<string>(maxLength: 250, nullable: true)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    assetName = table.Column<string>(maxLength: 150, nullable: true),
                    assetTag = table.Column<string>(maxLength: 150, nullable: true),
                    serialNo = table.Column<string>(maxLength: 150, nullable: true),
                    model_Name = table.Column<string>(maxLength: 75, nullable: true),
                    model_number = table.Column<string>(maxLength: 75, nullable: true),
                    model_brand = table.Column<string>(maxLength: 50, nullable: true),
                    model_product = table.Column<string>(maxLength: 75, nullable: true),
                    warranty_Months = table.Column<int>(maxLength: 75, nullable: true),
                    warranty_StartDate = table.Column<DateTime>(maxLength: 75, nullable: true),
                    warranty_EndDate = table.Column<DateTime>(maxLength: 50, nullable: true),
                    warranty_By = table.Column<string>(maxLength: 30, nullable: true),
                    warranty_notes = table.Column<string>(maxLength: 6, nullable: true),
                    assetstatusId = table.Column<int>(nullable: false),
                    assetPurchaseId = table.Column<long>(nullable: true),
                    assignTo = table.Column<int>(nullable: false)
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
                    AssetpurchaseId = table.Column<long>(nullable: false),
                    FileId = table.Column<long>(nullable: false)
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
                    assetId = table.Column<long>(nullable: false),
                    FileId = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    checkedOutDate = table.Column<DateTime>(nullable: false),
                    assetId = table.Column<long>(nullable: false),
                    requestInfo_approveDate = table.Column<DateTime>(nullable: true),
                    requestInfo_approvedBy = table.Column<string>(nullable: true),
                    requestInfo_requestedDate = table.Column<DateTime>(nullable: true),
                    requestInfo_requestedBy = table.Column<string>(nullable: true),
                    assignmentInfo_assetConditon = table.Column<string>(nullable: true),
                    assignmentInfo_conditionNote = table.Column<string>(nullable: true),
                    assignmentInfo_assignmentStatus = table.Column<int>(nullable: true),
                    toLocation_subsideryId = table.Column<long>(nullable: true),
                    toLocation_centerId = table.Column<long>(nullable: true),
                    toLocation_hallId = table.Column<long>(nullable: true),
                    toLocation_managerId = table.Column<long>(nullable: true),
                    toEmployee_subsideryId = table.Column<long>(nullable: true),
                    toEmployee_employeeId = table.Column<long>(nullable: true),
                    toEmployee_departmentId = table.Column<long>(nullable: true),
                    toParentAsset_parentAssetId = table.Column<long>(nullable: true),
                    returnedDate = table.Column<DateTime>(nullable: false),
                    retiredDate = table.Column<DateTime>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
