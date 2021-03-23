using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Web.Migrations
{
    public partial class initialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Characteristics = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<double>(type: "double precision", nullable: false),
                    Responsibilities = table.Column<string>(type: "text", nullable: true),
                    Requirements = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Passport = table.Column<string>(type: "text", nullable: true),
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    BodyNumber = table.Column<string>(type: "text", nullable: true),
                    Characteristics = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CarBodyId = table.Column<int>(type: "integer", nullable: false),
                    ManufacturerId = table.Column<int>(type: "integer", nullable: false),
                    Equipment1Id = table.Column<int>(type: "integer", nullable: true),
                    Equipment2Id = table.Column<int>(type: "integer", nullable: true),
                    Equipment3Id = table.Column<int>(type: "integer", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarBodies_CarBodyId",
                        column: x => x.CarBodyId,
                        principalTable: "CarBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Equipments_Equipment1Id",
                        column: x => x.Equipment1Id,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Equipments_Equipment2Id",
                        column: x => x.Equipment2Id,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Equipments_Equipment3Id",
                        column: x => x.Equipment3Id,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Passport = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    IsPayment = table.Column<bool>(type: "boolean", nullable: false),
                    PrepaymentPercentage = table.Column<double>(type: "double precision", nullable: false),
                    CarId = table.Column<int>(type: "integer", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CarBodies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Sedan" },
                    { 2, null, "Coupe" },
                    { 3, null, "Hatchback" },
                    { 4, null, "Limousine" },
                    { 5, null, "Minivan" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Characteristics", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "First Aid Kit", 100.0 },
                    { 2, null, "Tactical Flashlight", 200.0 },
                    { 3, null, "Multi-Tool", 50.0 },
                    { 4, null, "Car Hammer", 150.0 },
                    { 5, null, "Ice-scraper", 99.0 }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name", "Requirements", "Responsibilities", "Salary" },
                values: new object[,]
                {
                    { 1, "Sales Manager", null, null, 1000.0 },
                    { 2, "Finance Manager", null, null, 1500.0 },
                    { 3, "Customer Service Representative", null, null, 2000.0 },
                    { 4, "Car Detailer", null, null, 3000.0 },
                    { 5, "Lot Manager", null, null, 6000.0 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Age", "FullName", "Gender", "Passport", "Phone", "PositionId" },
                values: new object[,]
                {
                    { 5, null, 22, "Tara T Fenn", 2, null, null, 1 },
                    { 6, null, 23, "Freda G Brooks", 0, null, null, 1 },
                    { 7, null, 24, "Brian R Atkinson", 0, null, null, 1 },
                    { 1, null, 18, "George F Marks", 1, null, null, 2 },
                    { 3, null, 20, "Sergio C Hunter", 1, null, null, 2 },
                    { 8, null, 25, "Kenneth J Goudreau", 1, null, null, 2 },
                    { 2, null, 19, "Robert J Shaw", 1, null, null, 3 },
                    { 9, null, 26, "Kristina K Denis", 2, null, null, 3 },
                    { 4, null, 21, "Betty L Johnson", 2, null, null, 4 },
                    { 10, null, 27, "June D Hudson", 2, null, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Address", "Country", "Description", "EmployeeId", "Name" },
                values: new object[,]
                {
                    { 2, "1607  Owen Lane", "Japan", "TOYOTA MOTOR CORPORATION is a Japan-based company engaged in the automobile business, finance business and other businesses. ", 5, "Toyota Motor Corp." },
                    { 5, "3599  Thomas Street", "France", "Formerly known as PSA Peugeot Citroën from 1991 to 2016), was a French multinational manufacturer of automobiles and motorcycles sold under the Peugeot, Citroën, DS,", 6, "PSA Group" },
                    { 3, "3853  Zappia Drive", "German", "Volkswagen Group, also called Volkswagen AG, major German automobile manufacturer, founded by the German government in 1937 to mass-produce a low-priced “people's car.”", 7, "Volkswagen Group" },
                    { 1, "185  West Side Avenue", "USA", "General Motors (GM), one of the world's largest auto manufacturers, makes and sells cars and trucks worldwide under well-known brands such as Buick, Cadillac, Chevrolet, and GMC.", 1, "General Motors" },
                    { 4, "2628  Sycamore Fork Road", "German", "Bayerische Motoren Werke AG, commonly known as Bavarian Motor Works, BMW or BMW AG, is a German automobile, motorcycle and engine manufacturing company founded in 1916", 2, "BMW Group" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyNumber", "Brand", "CarBodyId", "Characteristics", "Color", "EmployeeId", "Equipment1Id", "Equipment2Id", "Equipment3Id", "ManufactureDate", "ManufacturerId", "Price" },
                values: new object[,]
                {
                    { 2, "JTHBE262962076696", "Toyota", 2, null, "Color [Firebrick]", 2, 1, 2, 3, new DateTime(2020, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3479), 2, 20500.0 },
                    { 5, "KNAGE123175119229", "Toyota", 5, null, "Color [Azure]", 6, 1, 2, 3, new DateTime(2019, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3683), 2, 20700.0 },
                    { 7, "1ZVHT80N365193130", "Toyota", 2, null, "Color [Linen]", 7, 1, 2, 3, new DateTime(2020, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3753), 2, 25000.0 },
                    { 3, "JTEZT14R168050778", "Peugeot", 4, null, "Color [Gainsboro]", 4, 1, 2, 3, new DateTime(2018, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3605), 5, 50000.0 },
                    { 6, "1G1ZS518X6F146715", "Peugeot", 4, null, "Color [YellowGreen]", 2, 1, 2, 3, new DateTime(2021, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3718), 5, 30000.0 },
                    { 4, "3LNHL2GC6CR898612", "Volkswagen", 3, null, "Color [Yellow]", 5, 1, 2, 3, new DateTime(2017, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3647), 3, 26000.0 },
                    { 10, "1G11H5SA3DU187967", "Volkswagen", 5, null, "Color [PowderBlue]", 9, 1, 2, 3, new DateTime(2019, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3857), 3, 99000.0 },
                    { 1, "5TFJX4GNXDX018902", "Chevrolet", 1, null, "Color [Aqua]", 1, 1, 2, 3, new DateTime(2019, 3, 20, 12, 1, 18, 446, DateTimeKind.Local).AddTicks(5288), 1, 20000.0 },
                    { 9, "WMWZC3C50DWP16002", "Cadillac", 1, null, "Color [Cornsilk]", 2, 1, 2, 3, new DateTime(2020, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3824), 1, 80000.0 },
                    { 8, "2A8HR54PX8R129788", "BMW", 4, null, "Color [Teal]", 8, 1, 2, 3, new DateTime(2019, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(3788), 4, 23000.0 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CarId", "EmployeeId", "IsDone", "IsPayment", "Name", "OrderDate", "Passport", "Phone", "PrepaymentPercentage", "SaleDate" },
                values: new object[,]
                {
                    { new Guid("883e07ef-63af-4378-883c-fa9b4d51c9b3"), "2981  Tipple Road", 2, 5, false, true, "Jacob A Frazier", new DateTime(2019, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(6741), "204-64-7000", "215-756-7457", 10.0, new DateTime(2018, 3, 20, 12, 1, 18, 450, DateTimeKind.Local).AddTicks(7622) },
                    { new Guid("e31d77d3-7905-4b47-a904-36edb687488d"), "3226  Goodwin Avenue", 5, 6, false, false, "Rebecca M McIntosh", new DateTime(2017, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(1921), "532-38-6188", "509-305-4300", 12.0, new DateTime(2019, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(1962) },
                    { new Guid("10b84f9a-7148-4336-aff5-f771d92f6f87"), "2994  Briarwood Road", 5, 2, false, true, "Tracy C Robinson", new DateTime(2019, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2098), "292-26-7557", "508-926-8765", 99.0, new DateTime(2020, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2123) },
                    { new Guid("e609fd65-076d-4a23-a2c2-52cc684c74e6"), "535  Boundary Street", 7, 4, true, true, "Norman L Hernandez", new DateTime(2017, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2217), "366-21-9992", "405-733-5090", 22.0, new DateTime(2017, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2241) },
                    { new Guid("96b04ac7-1e32-419f-bb95-3621904a0e45"), "3601  Dovetail Estates", 6, 7, true, true, "George E Lindquist", new DateTime(2019, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(1993), "287-90-1608", "580-977-7609", 14.0, new DateTime(2018, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2017) },
                    { new Guid("0f30579b-5d4f-4c0a-9170-e71052892476"), "1887  Sigley Road", 4, 5, false, false, "Tammy E Wolf", new DateTime(2021, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2149), "366-21-9992", "818-840-4421", 1.0, new DateTime(2021, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2175) },
                    { new Guid("0bb63653-d408-4f83-b08f-7b84a685a269"), "4480  Roosevelt Street", 1, 1, true, true, "Jeremy M Sanson", new DateTime(2021, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2321), "551-81-0381", "805-907-2039", 76.0, new DateTime(2017, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2345) },
                    { new Guid("1888b96e-e929-4f8f-868f-627533178100"), "3504  Henery Street", 9, 9, false, false, "Angela C Moreno", new DateTime(2020, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2372), "287-22-1837", "614-499-4827", 100.0, new DateTime(2020, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2397) },
                    { new Guid("5797f76d-3f68-4701-974f-9437f487e42a"), "2670  Hillhaven Drive", 8, 8, false, false, "Joanne A Freeman", new DateTime(2018, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2046), "568-41-0182", "201-584-5301", 56.0, new DateTime(2017, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2071) },
                    { new Guid("23334ee4-7f5e-4820-b2af-1a471233af0e"), "585  Leisure Lane", 8, 2, false, false, "Scott J Harris", new DateTime(2021, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2269), "450-39-0363", "301-236-7537", 54.0, new DateTime(2021, 3, 20, 12, 1, 18, 451, DateTimeKind.Local).AddTicks(2294) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBodyId",
                table: "Cars",
                column: "CarBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EmployeeId",
                table: "Cars",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Equipment1Id",
                table: "Cars",
                column: "Equipment1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Equipment2Id",
                table: "Cars",
                column: "Equipment2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Equipment3Id",
                table: "Cars",
                column: "Equipment3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CarId",
                table: "Customers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmployeeId",
                table: "Customers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_EmployeeId",
                table: "Manufacturers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });
        }

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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarBodies");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
