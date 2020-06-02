using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veam.Infra.Data.Migrations
{
    public partial class g2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.EnsureSchema(
                name: "Rent");

            migrationBuilder.EnsureSchema(
                name: "EAM");

            migrationBuilder.CreateTable(
                name: "CenterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subsideries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsideries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "Base",
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
                    company_Country = table.Column<string>(maxLength: 75, nullable: true),
                    company_GstNo = table.Column<string>(maxLength: 50, nullable: true),
                    add_line1 = table.Column<string>(maxLength: 75, nullable: true),
                    add_line2 = table.Column<string>(maxLength: 75, nullable: true),
                    add_city = table.Column<string>(maxLength: 50, nullable: true),
                    add_state = table.Column<string>(maxLength: 30, nullable: true),
                    add_zip = table.Column<string>(maxLength: 6, nullable: true),
                    contact_Mobile = table.Column<string>(maxLength: 75, nullable: true),
                    contact_Phone = table.Column<string>(maxLength: 75, nullable: true),
                    contact_personalEmail = table.Column<string>(maxLength: 50, nullable: true),
                    contact_workEmail = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

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
                name: "Building",
                schema: "Rent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    buildingName = table.Column<string>(maxLength: 50, nullable: false),
                    buildingNo = table.Column<string>(maxLength: 2, nullable: false),
                    add_line1 = table.Column<string>(maxLength: 75, nullable: true),
                    add_line2 = table.Column<string>(maxLength: 75, nullable: true),
                    add_city = table.Column<string>(maxLength: 50, nullable: true),
                    add_state = table.Column<string>(maxLength: 30, nullable: true),
                    add_zip = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterType",
                schema: "Rent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MetertypeNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    centerName = table.Column<string>(maxLength: 50, nullable: false),
                    subsideryId = table.Column<int>(nullable: false),
                    centerTypeId = table.Column<int>(nullable: false),
                    buildingId = table.Column<long>(nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: true),
                    isHQ = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Center_CenterTypes_centerTypeId",
                        column: x => x.centerTypeId,
                        principalTable: "CenterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Center_Subsideries_subsideryId",
                        column: x => x.subsideryId,
                        principalTable: "Subsideries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    productCode = table.Column<string>(maxLength: 3, nullable: false),
                    productName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: true),
                    uom = table.Column<string>(maxLength: 25, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Base",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Base",
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorLine",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    jobTitle = table.Column<string>(maxLength: 50, nullable: true),
                    note = table.Column<string>(maxLength: 250, nullable: true),
                    person_Fname = table.Column<string>(maxLength: 75, nullable: true),
                    person_Lname = table.Column<string>(maxLength: 75, nullable: true),
                    person_Mname = table.Column<string>(maxLength: 50, nullable: true),
                    person_Nname = table.Column<string>(maxLength: 50, nullable: true),
                    person_Gender = table.Column<string>(maxLength: 50, nullable: true),
                    person_Salutation = table.Column<string>(maxLength: 50, nullable: true),
                    contact_Mobile = table.Column<string>(maxLength: 75, nullable: true),
                    contact_Phone = table.Column<string>(maxLength: 75, nullable: true),
                    contact_personalEmail = table.Column<string>(maxLength: 50, nullable: true),
                    contact_workEmail = table.Column<string>(maxLength: 50, nullable: true),
                    vendorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorLine_Vendor_vendorId",
                        column: x => x.vendorId,
                        principalSchema: "Base",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    assetPurchaseId = table.Column<long>(nullable: true)
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
                name: "Permises",
                schema: "Rent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    hallNo = table.Column<string>(maxLength: 3, nullable: false),
                    floorNo = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: true),
                    locationNo = table.Column<string>(maxLength: 5, nullable: false),
                    buildingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permises_Building_buildingId",
                        column: x => x.buildingId,
                        principalSchema: "Rent",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    modifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    modifiedBy = table.Column<string>(nullable: true),
                    hallName = table.Column<string>(maxLength: 50, nullable: false),
                    hallNo = table.Column<string>(maxLength: 3, nullable: false),
                    floorNo = table.Column<string>(maxLength: 50, nullable: false),
                    locationNo = table.Column<string>(maxLength: 5, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: true),
                    centerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hall_Center_centerId",
                        column: x => x.centerId,
                        principalTable: "Center",
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
                    assignedType = table.Column<int>(nullable: false),
                    assignmentStatus = table.Column<int>(nullable: false),
                    assetId = table.Column<long>(nullable: false),
                    checkedOutDate = table.Column<DateTime>(nullable: false),
                    assetConditon = table.Column<int>(nullable: false),
                    conditionNote = table.Column<string>(nullable: false),
                    approveDate = table.Column<DateTime>(nullable: false),
                    approvedBy = table.Column<string>(nullable: false),
                    acceptedBy = table.Column<string>(nullable: false),
                    requestedDate = table.Column<DateTime>(nullable: false),
                    requestedBy = table.Column<string>(nullable: false),
                    returnedDate = table.Column<DateTime>(nullable: false),
                    retiredDate = table.Column<DateTime>(nullable: false),
                    parentAssetId = table.Column<long>(nullable: false),
                    subsideryId = table.Column<long>(nullable: false),
                    centerId = table.Column<long>(nullable: false),
                    hallId = table.Column<long>(nullable: false),
                    employeeId = table.Column<long>(nullable: false),
                    managerId = table.Column<long>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Meters",
                schema: "Rent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permiseId = table.Column<long>(nullable: true),
                    meterTypeId = table.Column<int>(nullable: true),
                    MeterNo = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meters_MeterType_meterTypeId",
                        column: x => x.meterTypeId,
                        principalSchema: "Rent",
                        principalTable: "MeterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meters_Permises_permiseId",
                        column: x => x.permiseId,
                        principalSchema: "Rent",
                        principalTable: "Permises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Center_centerTypeId",
                table: "Center",
                column: "centerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Center_subsideryId",
                table: "Center",
                column: "subsideryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hall_centerId",
                table: "Hall",
                column: "centerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "Base",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeId",
                schema: "Base",
                table: "Product",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorLine_vendorId",
                schema: "Base",
                table: "VendorLine",
                column: "vendorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Meters_meterTypeId",
                schema: "Rent",
                table: "Meters",
                column: "meterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meters_permiseId",
                schema: "Rent",
                table: "Meters",
                column: "permiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Permises_buildingId",
                schema: "Rent",
                table: "Permises",
                column: "buildingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "VendorLine",
                schema: "Base");

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
                name: "Meters",
                schema: "Rent");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Asset",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "FileDetails",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "MeterType",
                schema: "Rent");

            migrationBuilder.DropTable(
                name: "Permises",
                schema: "Rent");

            migrationBuilder.DropTable(
                name: "CenterTypes");

            migrationBuilder.DropTable(
                name: "Subsideries");

            migrationBuilder.DropTable(
                name: "AssetPurchase",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "AssetStatus",
                schema: "EAM");

            migrationBuilder.DropTable(
                name: "Building",
                schema: "Rent");
        }
    }
}
