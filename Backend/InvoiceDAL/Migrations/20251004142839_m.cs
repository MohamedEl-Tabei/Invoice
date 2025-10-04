using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceDAL.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 1m),
                    SubCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => new { x.ItemId, x.CreatedOn });
                    table.ForeignKey(
                        name: "FK_Prices_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84", null, "Admin", "ADMIN" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe85", null, "Shop", "SHOP" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86", null, "Customer", "CUSTOMER" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86", null, "Restaurant", "RESTAURANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "28b21eb8-d6dc-4acf-9ab8-91bf746efe84", 0, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", "admin@invoice.com", false, false, null, "ADMIN@INVOICE.COM", null, "AQAAAAIAAYagAAAAEKPr74T9wKgN2Rckq/lrBX/SBjQmOeXJxxeikNvCivCUe3THuR7c/fmcvzMMhkppuA==", "01020210595", false, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", false, "admin" },
                    { "28b21eb8-d6dc-4acf-9ab8-91bf746efe85", 0, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", "shop@invoice.com", false, false, null, "SHOP@INVOICE.COM", null, "AQAAAAIAAYagAAAAEIK9uTYXCvIWty97KaIFFZD3WEtTOnLwhEEd8Rmeh8pVc2CT6Nz4SaZ29Q/gcAPsmQ==", "01020210795", false, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", false, "shop" },
                    { "28b21eb8-d6dc-4acf-9ab8-91bf746efe86", 0, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", "customer@invoice.com", false, false, null, "CUSTOMER@INVOICE.COM", null, "AQAAAAIAAYagAAAAEL7WjDMwY3woFxTEb0W7TPm2KCYv32cjIiqIycV9hbLbAQPGcBdVTUD6J0zqwNtEzQ==", "01020210495", false, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", false, "customer" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86", 0, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", "restaurant@invoice.com", false, false, null, "RESTAURANT@INVOICE.COM", null, "AQAAAAIAAYagAAAAEGdbCxXrHMnHDB8zj2UlxfY4/BPnIhBuTiykMG6xIwwGZXqwRZdtJBzu6bRIM98HQw==", "01020211595", false, "d0b1c8f2-3e4a-4c5b-8f6d-7e8f9a0b1c2d", false, "restaurant" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ConcurrencyStamp", "Name" },
                values: new object[,]
                {
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "Food" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "Electronics" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "Clothes" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "Furniture" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "Education" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "Transportation" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "Health" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "Services" },
                    { "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84", "28b21eb8-d6dc-4acf-9ab8-91bf746efe84" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe85", "28b21eb8-d6dc-4acf-9ab8-91bf746efe85" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe86", "28b21eb8-d6dc-4acf-9ab8-91bf746efe86" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86", "28b21eb8-d6dc-4dcf-9ab8-91bf886efe86" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "ConcurrencyStamp", "Name" },
                values: new object[,]
                {
                    { "03e2fca0-5313-4d59-b78d-303e70a17a71", "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "03e2fca0-5313-4d59-b78d-303e70a17a71", "Outdoor Furniture" },
                    { "10df0b8c-10a1-4cc5-95d0-7f0d3cce0f88", "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "10df0b8c-10a1-4cc5-95d0-7f0d3cce0f88", "Medicines & Pharmacy" },
                    { "1896315a-3c1e-4b20-b6af-423902cd8ee7", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "1896315a-3c1e-4b20-b6af-423902cd8ee7", "Public Transport" },
                    { "2033b319-2149-45bb-94a0-6804f883d49a", "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "2033b319-2149-45bb-94a0-6804f883d49a", "Games & Toys" },
                    { "20722ad6-174a-4eea-9e97-491e88f8e394", "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "20722ad6-174a-4eea-9e97-491e88f8e394", "Cinema & Movies" },
                    { "22622b36-1538-4de7-a171-9f40ce6232a8", "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "22622b36-1538-4de7-a171-9f40ce6232a8", "Beauty & Salon" },
                    { "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84", "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "28b21eb8-d6dc-4dcf-9ab8-91bf746efe84", "Men’s Wear" },
                    { "2cf7a9a5-1dd6-40a1-b04a-4eb1c7f54838", "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "2cf7a9a5-1dd6-40a1-b04a-4eb1c7f54838", "Shoes" },
                    { "38e37c89-0ef4-4a6a-951f-9a5bc82a2920", "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "38e37c89-0ef4-4a6a-951f-9a5bc82a2920", "Bakeries & Sweets" },
                    { "3e1e27a0-7261-4b62-8e4c-2a3fc7ebc090", "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "3e1e27a0-7261-4b62-8e4c-2a3fc7ebc090", "Fast Food" },
                    { "51dfd39d-564e-4de2-8135-0f05366d68d0", "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "51dfd39d-564e-4de2-8135-0f05366d68d0", "Online Courses" },
                    { "52f51a2a-4e85-4d91-a8a0-171a8a39e318", "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "52f51a2a-4e85-4d91-a8a0-171a8a39e318", "Mobile Phones" },
                    { "5b2ffca7-8af2-4c5b-9f45-2f908be9c1ea", "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "5b2ffca7-8af2-4c5b-9f45-2f908be9c1ea", "Laptops & Computers" },
                    { "6b9a5061-18a2-45cc-9e0e-2170f79cfe7b", "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "6b9a5061-18a2-45cc-9e0e-2170f79cfe7b", "Office Furniture" },
                    { "6bbf63c4-2528-4e30-8a68-33dcb4ee0ef3", "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "6bbf63c4-2528-4e30-8a68-33dcb4ee0ef3", "Accessories" },
                    { "6bbfcb72-5528-4f68-89e4-2cbfcd16621c", "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "6bbfcb72-5528-4f68-89e4-2cbfcd16621c", "Bedroom Furniture" },
                    { "7ef51658-cc02-4af9-89e0-29d189b30a69", "78b21eb8-d6dc-4acf-9ab8-91bf746efe84", "7ef51658-cc02-4af9-89e0-29d189b30a69", "Living Room Furniture" },
                    { "84d4485e-4060-4df3-80ed-64ff1d2099d3", "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "84d4485e-4060-4df3-80ed-64ff1d2099d3", "Books & Stationery" },
                    { "8d775015-7f63-43de-aab3-6c9cb2294170", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "8d775015-7f63-43de-aab3-6c9cb2294170", "Vehicle Maintenance" },
                    { "8e482041-1844-4d3b-bd7f-89dba3a10941", "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "8e482041-1844-4d3b-bd7f-89dba3a10941", "Private Lessons" },
                    { "8f5d2472-3f60-4f66-a4ee-7a26f57e2e0f", "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "8f5d2472-3f60-4f66-a4ee-7a26f57e2e0f", "Women’s Wear" },
                    { "9a1a3b1e-d066-4dd6-8e6a-4e97f7b2ef70", "78b21eb8-d6dc-4acf-9ab8-91bf746efe83", "9a1a3b1e-d066-4dd6-8e6a-4e97f7b2ef70", "Kids & Babies" },
                    { "9a6dcb70-899e-4c5f-b2d2-4bfb60126f5f", "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "9a6dcb70-899e-4c5f-b2d2-4bfb60126f5f", "Repair & Maintenance" },
                    { "a16cc45a-1ef0-4745-b7cc-25e699a40c47", "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "a16cc45a-1ef0-4745-b7cc-25e699a40c47", "Doctor Visits" },
                    { "aef55b58-19e0-4964-bf1c-8e0545276ef7", "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "aef55b58-19e0-4964-bf1c-8e0545276ef7", "Delivery Services" },
                    { "b69fc653-85bb-46f8-9c92-70e85eb0fc68", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "b69fc653-85bb-46f8-9c92-70e85eb0fc68", "Taxi & Ride Sharing" },
                    { "bbf29261-3bc1-42ba-9c63-7086f7a3cc39", "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "bbf29261-3bc1-42ba-9c63-7086f7a3cc39", "Fitness & Gym" },
                    { "c62e935d-5d7a-4ee0-9a30-c6888f2b4f6a", "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "c62e935d-5d7a-4ee0-9a30-c6888f2b4f6a", "Home Appliances" },
                    { "cbab53b5-76b3-41e1-8485-0d7585a61b85", "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "cbab53b5-76b3-41e1-8485-0d7585a61b85", "Groceries" },
                    { "cfcaf271-27c6-4b64-8470-5af597004003", "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "cfcaf271-27c6-4b64-8470-5af597004003", "Concerts & Events" },
                    { "d84df214-cf36-4eea-b3ec-422693e1c74f", "78b21eb8-d6dc-4acf-9ab8-91bf746efe86", "d84df214-cf36-4eea-b3ec-422693e1c74f", "Fuel" },
                    { "de5f74bc-33ff-4b3a-bc48-1c6993e1a40d", "78b21eb8-d6dc-4acf-9ab8-91bf746efe88", "de5f74bc-33ff-4b3a-bc48-1c6993e1a40d", "Cleaning Services" },
                    { "e1220173-0844-4a28-b3f0-bdb3ba6e5b54", "78b21eb8-d6dc-4acf-9ab8-91bf746efe89", "e1220173-0844-4a28-b3f0-bdb3ba6e5b54", "Streaming Subscriptions" },
                    { "e6895ef5-df64-4781-b099-98f2f7af5f70", "78b21eb8-d6dc-4acf-9ab8-91bf746efe87", "e6895ef5-df64-4781-b099-98f2f7af5f70", "Health Insurance" },
                    { "e9b9b4ae-84e3-4ef9-8920-baeac7cb241b", "78b21eb8-d6dc-4acf-9ab8-91bf746efe82", "e9b9b4ae-84e3-4ef9-8920-baeac7cb241b", "TV & Audio" },
                    { "f2a76835-c5cd-4d91-b355-37c818db9490", "78b21eb8-d6dc-4acf-9ab8-91bf746efe85", "f2a76835-c5cd-4d91-b355-37c818db9490", "School Supplies" },
                    { "fe8b4964-87e4-401f-9a44-45348d8d1af8", "78b21eb8-d6dc-4acf-9ab8-91bf746efe81", "fe8b4964-87e4-401f-9a44-45348d8d1af8", "Restaurants & Cafes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_AdminId",
                table: "AuditLogs",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_SubCategoryId",
                table: "Items",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Name",
                table: "SubCategories",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
