﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veam.Data;

namespace Veam.EAM.Data.Migrations
{
    [DbContext(typeof(EAMDbContext))]
    [Migration("20200301151948_gg2")]
    partial class gg2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Veam.EAM.Domain.Asset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("assetName")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<long?>("assetPurchaseId")
                        .HasColumnType("bigint");

                    b.Property<string>("assetTag")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int?>("assetstatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("assignTo")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("modifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serialNo")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("assetPurchaseId");

                    b.HasIndex("assetstatusId");

                    b.ToTable("Asset","EAM");
                });

            modelBuilder.Entity("Veam.EAM.Domain.AssetPurchase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("modifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<long>("vendorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("AssetPurchase","EAM");
                });

            modelBuilder.Entity("Veam.EAM.Domain.AssetStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetStatus","EAM");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            status = "InStock"
                        },
                        new
                        {
                            Id = 2,
                            status = "Assigned"
                        },
                        new
                        {
                            Id = 3,
                            status = "InMaintenance"
                        },
                        new
                        {
                            Id = 4,
                            status = "Archived"
                        });
                });

            modelBuilder.Entity("Veam.EAM.Domain.AssetUploads", b =>
                {
                    b.Property<long>("assetId")
                        .HasColumnType("bigint");

                    b.Property<long>("FileId")
                        .HasColumnType("bigint");

                    b.HasKey("assetId", "FileId");

                    b.ToTable("AssetUploads","EAM");
                });

            modelBuilder.Entity("Veam.EAM.Domain.CheckOut", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("assetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("checkedOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset?>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("modifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("retiredDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("returnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("assetId");

                    b.ToTable("CheckOut","EAM");
                });

            modelBuilder.Entity("Veam.EAM.Domain.FileDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("fileNotes")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("fileSize")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset?>("modifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileDetails","EAM");
                });

            modelBuilder.Entity("Veam.EAM.Domain.PurchaseFiles", b =>
                {
                    b.Property<long>("AssetpurchaseId")
                        .HasColumnType("bigint");

                    b.Property<long>("FileId")
                        .HasColumnType("bigint");

                    b.HasKey("AssetpurchaseId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("PurchaseFiles","EAM");
                });

            modelBuilder.Entity("Veam.EAM.Domain.Asset", b =>
                {
                    b.HasOne("Veam.EAM.Domain.AssetPurchase", "assetPurchase")
                        .WithMany("Assets")
                        .HasForeignKey("assetPurchaseId");

                    b.HasOne("Veam.EAM.Domain.AssetStatus", "assetstatus")
                        .WithMany()
                        .HasForeignKey("assetstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Veam.EAM.Domain.AssetModel", "assetModel", b1 =>
                        {
                            b1.Property<long>("AssetId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("brand")
                                .HasColumnName("model_brand")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("name")
                                .HasColumnName("model_Name")
                                .HasColumnType("nvarchar(75)")
                                .HasMaxLength(75);

                            b1.Property<string>("number")
                                .HasColumnName("model_number")
                                .HasColumnType("nvarchar(75)")
                                .HasMaxLength(75);

                            b1.Property<string>("product")
                                .HasColumnName("model_product")
                                .HasColumnType("nvarchar(75)")
                                .HasMaxLength(75);

                            b1.HasKey("AssetId");

                            b1.ToTable("Asset");

                            b1.WithOwner()
                                .HasForeignKey("AssetId");
                        });

                    b.OwnsOne("Veam.EAM.Domain.WarrantyInfo", "warranty", b1 =>
                        {
                            b1.Property<long>("AssetId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("EndDate")
                                .HasColumnName("warranty_EndDate")
                                .HasColumnType("datetime2")
                                .HasMaxLength(50);

                            b1.Property<DateTime>("StartDate")
                                .HasColumnName("warranty_StartDate")
                                .HasColumnType("datetime2")
                                .HasMaxLength(75);

                            b1.Property<string>("notes")
                                .HasColumnName("warranty_notes")
                                .HasColumnType("nvarchar(6)")
                                .HasMaxLength(6);

                            b1.Property<int>("periodinMonths")
                                .HasColumnName("warranty_Months")
                                .HasColumnType("int")
                                .HasMaxLength(75);

                            b1.Property<string>("warrantyBy")
                                .HasColumnName("warranty_By")
                                .HasColumnType("nvarchar(30)")
                                .HasMaxLength(30);

                            b1.HasKey("AssetId");

                            b1.ToTable("Asset");

                            b1.WithOwner()
                                .HasForeignKey("AssetId");
                        });
                });

            modelBuilder.Entity("Veam.EAM.Domain.AssetPurchase", b =>
                {
                    b.OwnsOne("Veam.EAM.Domain.BillDetails", "assetBills", b1 =>
                        {
                            b1.Property<long>("AssetPurchaseId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("billNo")
                                .IsRequired()
                                .HasColumnName("company_Name")
                                .HasColumnType("nvarchar(75)")
                                .HasMaxLength(75);

                            b1.Property<DateTime>("billedDate")
                                .HasColumnName("company_Country")
                                .HasColumnType("datetime2")
                                .HasMaxLength(75);

                            b1.HasKey("AssetPurchaseId");

                            b1.ToTable("AssetPurchase");

                            b1.WithOwner()
                                .HasForeignKey("AssetPurchaseId");
                        });
                });

            modelBuilder.Entity("Veam.EAM.Domain.AssetUploads", b =>
                {
                    b.HasOne("Veam.EAM.Domain.Asset", "asset")
                        .WithMany("assetUploads")
                        .HasForeignKey("assetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veam.EAM.Domain.FileDetails", "files")
                        .WithMany()
                        .HasForeignKey("assetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Veam.EAM.Domain.CheckOut", b =>
                {
                    b.HasOne("Veam.EAM.Domain.Asset", "asset")
                        .WithMany("Checkouts")
                        .HasForeignKey("assetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Veam.EAM.Domain.AssignmentInfo", "assignmentInfo", b1 =>
                        {
                            b1.Property<long>("CheckOutId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("assetConditon")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("assignmentStatus")
                                .HasColumnType("int");

                            b1.Property<string>("conditionNote")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CheckOutId");

                            b1.ToTable("CheckOut");

                            b1.WithOwner()
                                .HasForeignKey("CheckOutId");
                        });

                    b.OwnsOne("Veam.EAM.Domain.CheckOutToEmployee", "toEmployee", b1 =>
                        {
                            b1.Property<long>("CheckOutId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<long>("departmentId")
                                .HasColumnType("bigint");

                            b1.Property<long>("employeeId")
                                .HasColumnType("bigint");

                            b1.Property<long>("subsideryId")
                                .HasColumnType("bigint");

                            b1.HasKey("CheckOutId");

                            b1.ToTable("CheckOut");

                            b1.WithOwner()
                                .HasForeignKey("CheckOutId");
                        });

                    b.OwnsOne("Veam.EAM.Domain.CheckOutToLocation", "toLocation", b1 =>
                        {
                            b1.Property<long>("CheckOutId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<long>("centerId")
                                .HasColumnType("bigint");

                            b1.Property<long>("hallId")
                                .HasColumnType("bigint");

                            b1.Property<long>("managerId")
                                .HasColumnType("bigint");

                            b1.Property<long>("subsideryId")
                                .HasColumnType("bigint");

                            b1.HasKey("CheckOutId");

                            b1.ToTable("CheckOut");

                            b1.WithOwner()
                                .HasForeignKey("CheckOutId");
                        });

                    b.OwnsOne("Veam.EAM.Domain.CheckOutToParentAsset", "toParentAsset", b1 =>
                        {
                            b1.Property<long>("CheckOutId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<long>("parentAssetId")
                                .HasColumnType("bigint");

                            b1.HasKey("CheckOutId");

                            b1.ToTable("CheckOut");

                            b1.WithOwner()
                                .HasForeignKey("CheckOutId");
                        });

                    b.OwnsOne("Veam.EAM.Domain.RequestInfo", "requestInfo", b1 =>
                        {
                            b1.Property<long>("CheckOutId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("approveDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("approvedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("requestedBy")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("requestedDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("CheckOutId");

                            b1.ToTable("CheckOut");

                            b1.WithOwner()
                                .HasForeignKey("CheckOutId");
                        });
                });

            modelBuilder.Entity("Veam.EAM.Domain.PurchaseFiles", b =>
                {
                    b.HasOne("Veam.EAM.Domain.AssetPurchase", "AssetPurchase")
                        .WithMany("purchaseFiles")
                        .HasForeignKey("AssetpurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veam.EAM.Domain.FileDetails", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
