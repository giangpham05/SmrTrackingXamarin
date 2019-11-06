using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMR.Tracking.DataAccess.Migrations
{
    public partial class CloudDbMigrationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(fixedLength: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiRailAssetTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(fixedLength: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiRailAssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiRailLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(fixedLength: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiRailLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(fixedLength: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationPrefixes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPrefixes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(unicode: false, nullable: true),
                    DueDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repairers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiRailInspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    AssetConditionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiRailInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiRailInspections_AssetConditions_AssetConditionId",
                        column: x => x.AssetConditionId,
                        principalTable: "AssetConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "St1s",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(unicode: false, nullable: true),
                    AtId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_St1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_St1s_Ats_AtId",
                        column: x => x.AtId,
                        principalTable: "Ats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LocationIncrements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LocationPrefixId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationIncrements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationIncrements_LocationPrefixes_LocationPrefixId",
                        column: x => x.LocationPrefixId,
                        principalTable: "LocationPrefixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalkByInspections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    Gauge = table.Column<string>(unicode: false, nullable: true),
                    Super = table.Column<string>(unicode: false, nullable: true),
                    PoorSleepers = table.Column<string>(unicode: false, nullable: true),
                    AssetConditionId = table.Column<Guid>(nullable: true),
                    LocationPrefixId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkByInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalkByInspections_AssetConditions_AssetConditionId",
                        column: x => x.AssetConditionId,
                        principalTable: "AssetConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WalkByInspections_LocationPrefixes_LocationPrefixId",
                        column: x => x.LocationPrefixId,
                        principalTable: "LocationPrefixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HiRailInspectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    HiRailInspectionId = table.Column<Guid>(nullable: true),
                    InspectorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiRailInspectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiRailInspectors_HiRailInspections_HiRailInspectionId",
                        column: x => x.HiRailInspectionId,
                        principalTable: "HiRailInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HiRailInspectors_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HiRailMatrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    HiRailInspectionId = table.Column<Guid>(nullable: true),
                    HiRailLocationId = table.Column<Guid>(nullable: true),
                    HiRailAssetTypeId = table.Column<Guid>(nullable: true),
                    AssetConditionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiRailMatrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiRailMatrices_AssetConditions_AssetConditionId",
                        column: x => x.AssetConditionId,
                        principalTable: "AssetConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HiRailMatrices_HiRailAssetTypes_HiRailAssetTypeId",
                        column: x => x.HiRailAssetTypeId,
                        principalTable: "HiRailAssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HiRailMatrices_HiRailInspections_HiRailInspectionId",
                        column: x => x.HiRailInspectionId,
                        principalTable: "HiRailInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HiRailMatrices_HiRailLocations_HiRailLocationId",
                        column: x => x.HiRailLocationId,
                        principalTable: "HiRailLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "St2s",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(unicode: false, nullable: true),
                    St1Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_St2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_St2s_St1s_St1Id",
                        column: x => x.St1Id,
                        principalTable: "St1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WalkByInspectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    WalkByInspectionId = table.Column<Guid>(nullable: true),
                    InspectorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkByInspectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalkByInspectors_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WalkByInspectors_WalkByInspections_WalkByInspectionId",
                        column: x => x.WalkByInspectionId,
                        principalTable: "WalkByInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DefectTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    St2Id = table.Column<Guid>(nullable: true),
                    Label = table.Column<string>(unicode: false, nullable: true),
                    PriorityId = table.Column<Guid>(nullable: true),
                    DefectAction = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectTypes_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DefectTypes_St2s_St2Id",
                        column: x => x.St2Id,
                        principalTable: "St2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Defects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalkByInspectionId = table.Column<Guid>(nullable: true),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    LocationFrom = table.Column<int>(nullable: false),
                    LocationTo = table.Column<int>(nullable: false),
                    LocationFromDesc = table.Column<string>(unicode: false, nullable: true),
                    LocationToDesc = table.Column<string>(unicode: false, nullable: true),
                    AtId = table.Column<Guid>(nullable: true),
                    St1Id = table.Column<Guid>(nullable: true),
                    St2Id = table.Column<Guid>(nullable: true),
                    DefectTypeId = table.Column<Guid>(nullable: true),
                    DefectAction = table.Column<string>(nullable: true),
                    PriorityId = table.Column<Guid>(nullable: true),
                    RepairDateDue = table.Column<DateTime>(nullable: false),
                    RepairDate = table.Column<DateTime>(nullable: true),
                    RepairerId = table.Column<Guid>(nullable: true),
                    RepairComments = table.Column<string>(unicode: false, nullable: true),
                    Comments = table.Column<string>(unicode: false, nullable: true),
                    StatusId = table.Column<Guid>(nullable: true),
                    LocationPrefixId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defects_Ats_AtId",
                        column: x => x.AtId,
                        principalTable: "Ats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Defects_Repairers_AtId",
                        column: x => x.AtId,
                        principalTable: "Repairers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Defects_DefectTypes_DefectTypeId",
                        column: x => x.DefectTypeId,
                        principalTable: "DefectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Defects_LocationPrefixes_LocationPrefixId",
                        column: x => x.LocationPrefixId,
                        principalTable: "LocationPrefixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Defects_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Defects_St1s_St1Id",
                        column: x => x.St1Id,
                        principalTable: "St1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Defects_St2s_St2Id",
                        column: x => x.St2Id,
                        principalTable: "St2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Defects_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Defects_WalkByInspections_WalkByInspectionId",
                        column: x => x.WalkByInspectionId,
                        principalTable: "WalkByInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DefectInspectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DefectId = table.Column<Guid>(nullable: true),
                    InspectorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectInspectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectInspectors_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DefectInspectors_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DefectRepairLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    InventoryId = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    DefectId = table.Column<Guid>(nullable: true),
                    RepaierId = table.Column<Guid>(nullable: true),
                    RepairDate = table.Column<DateTime>(nullable: false),
                    RepairComment = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectRepairLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectRepairLine_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DefectRepairLine_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DefectRepairLine_Repairers_RepaierId",
                        column: x => x.RepaierId,
                        principalTable: "Repairers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Attachment = table.Column<byte[]>(nullable: true),
                    Filename = table.Column<string>(unicode: false, nullable: true),
                    Filesize = table.Column<long>(nullable: false),
                    Mimetype = table.Column<string>(unicode: false, nullable: true),
                    DefectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAttachments_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefectInspectors_DefectId",
                table: "DefectInspectors",
                column: "DefectId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectInspectors_InspectorId",
                table: "DefectInspectors",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectRepairLine_DefectId",
                table: "DefectRepairLine",
                column: "DefectId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectRepairLine_InventoryId",
                table: "DefectRepairLine",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectRepairLine_RepaierId",
                table: "DefectRepairLine",
                column: "RepaierId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_AtId",
                table: "Defects",
                column: "AtId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_DefectTypeId",
                table: "Defects",
                column: "DefectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_LocationPrefixId",
                table: "Defects",
                column: "LocationPrefixId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_PriorityId",
                table: "Defects",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_St1Id",
                table: "Defects",
                column: "St1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_St2Id",
                table: "Defects",
                column: "St2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_StatusId",
                table: "Defects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_WalkByInspectionId",
                table: "Defects",
                column: "WalkByInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectTypes_PriorityId",
                table: "DefectTypes",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectTypes_St2Id",
                table: "DefectTypes",
                column: "St2Id");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_DefectId",
                table: "FileAttachments",
                column: "DefectId");

            migrationBuilder.CreateIndex(
                name: "IX_HiRailInspections_AssetConditionId",
                table: "HiRailInspections",
                column: "AssetConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_HiRailInspectors_HiRailInspectionId",
                table: "HiRailInspectors",
                column: "HiRailInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HiRailInspectors_InspectorId",
                table: "HiRailInspectors",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_HiRailMatrices_AssetConditionId",
                table: "HiRailMatrices",
                column: "AssetConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_HiRailMatrices_HiRailAssetTypeId",
                table: "HiRailMatrices",
                column: "HiRailAssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HiRailMatrices_HiRailInspectionId",
                table: "HiRailMatrices",
                column: "HiRailInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HiRailMatrices_HiRailLocationId",
                table: "HiRailMatrices",
                column: "HiRailLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationIncrements_LocationPrefixId",
                table: "LocationIncrements",
                column: "LocationPrefixId");

            migrationBuilder.CreateIndex(
                name: "IX_St1s_AtId",
                table: "St1s",
                column: "AtId");

            migrationBuilder.CreateIndex(
                name: "IX_St2s_St1Id",
                table: "St2s",
                column: "St1Id");

            migrationBuilder.CreateIndex(
                name: "IX_WalkByInspections_AssetConditionId",
                table: "WalkByInspections",
                column: "AssetConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkByInspections_LocationPrefixId",
                table: "WalkByInspections",
                column: "LocationPrefixId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkByInspectors_InspectorId",
                table: "WalkByInspectors",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkByInspectors_WalkByInspectionId",
                table: "WalkByInspectors",
                column: "WalkByInspectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefectInspectors");

            migrationBuilder.DropTable(
                name: "DefectRepairLine");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "HiRailInspectors");

            migrationBuilder.DropTable(
                name: "HiRailMatrices");

            migrationBuilder.DropTable(
                name: "LocationIncrements");

            migrationBuilder.DropTable(
                name: "WalkByInspectors");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Defects");

            migrationBuilder.DropTable(
                name: "HiRailAssetTypes");

            migrationBuilder.DropTable(
                name: "HiRailInspections");

            migrationBuilder.DropTable(
                name: "HiRailLocations");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropTable(
                name: "Repairers");

            migrationBuilder.DropTable(
                name: "DefectTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "WalkByInspections");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "St2s");

            migrationBuilder.DropTable(
                name: "AssetConditions");

            migrationBuilder.DropTable(
                name: "LocationPrefixes");

            migrationBuilder.DropTable(
                name: "St1s");

            migrationBuilder.DropTable(
                name: "Ats");
        }
    }
}
