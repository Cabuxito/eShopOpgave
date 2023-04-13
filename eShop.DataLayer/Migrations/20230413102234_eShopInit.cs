using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class eShopInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PayOptions",
                columns: table => new
                {
                    PayOptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayOptionsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayOptions", x => x.PayOptionsId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                columns: table => new
                {
                    ZipCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodes", x => x.ZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayOptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrdersId);
                    table.ForeignKey(
                        name: "FK_Orders_PayOptions_PayOptionsId",
                        column: x => x.PayOptionsId,
                        principalTable: "PayOptions",
                        principalColumn: "PayOptionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImagesId);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_ZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "ZipCodes",
                        principalColumn: "ZipCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.ProductId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "OrdersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCustomer",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCustomer", x => new { x.OrdersId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_OrderCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCustomer_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "OrdersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Accion" },
                    { 2, "Platform" },
                    { 3, "Survival" },
                    { 4, "Race" },
                    { 5, "Horror" },
                    { 6, "Maximus Prime" },
                    { 7, "18+" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImageId", "Manufacture", "Price", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 1, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 2, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 2, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 3, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 3, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 4, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 4, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 5, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 5, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 6, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 6, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 7, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 7, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 8, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 8, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 9, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 9, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 10, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 10, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 11, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 11, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 12, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 12, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 13, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 13, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 14, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 14, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 15, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 15, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 16, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 16, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 17, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 17, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 18, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 18, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 19, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 19, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 20, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 20, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 21, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 21, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 22, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 22, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 23, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 23, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 24, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 24, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 25, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 25, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 26, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 26, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 27, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 27, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 28, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 28, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 29, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 29, "Blizzard", 69.989999999999995, 100, "Diablo III" },
                    { 30, "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.", 30, "Blizzard", 69.989999999999995, 100, "Diablo III" }
                });

            migrationBuilder.InsertData(
                table: "ZipCodes",
                columns: new[] { "ZipCodeId", "ZipCodeName" },
                values: new object[,]
                {
                    { 1050, "København K" },
                    { 1051, "København K" },
                    { 1052, "København K" },
                    { 1053, "København K" },
                    { 1054, "København K" },
                    { 1055, "København K" },
                    { 1056, "København K" },
                    { 1057, "København K" },
                    { 1058, "København K" },
                    { 1059, "København K" },
                    { 1060, "København K" },
                    { 1061, "København K" },
                    { 1062, "København K" },
                    { 1063, "København K" },
                    { 1064, "København K" },
                    { 1065, "København K" },
                    { 1066, "København K" },
                    { 1067, "København K" },
                    { 1068, "København K" },
                    { 1069, "København K" },
                    { 1070, "København K" },
                    { 1071, "København K" },
                    { 1072, "København K" },
                    { 1073, "København K" },
                    { 1074, "København K" },
                    { 1100, "København K" },
                    { 1101, "København K" },
                    { 1102, "København K" },
                    { 1103, "København K" },
                    { 1104, "København K" },
                    { 1105, "København K" },
                    { 1106, "København K" },
                    { 1107, "København K" },
                    { 1110, "København K" },
                    { 1111, "København K" },
                    { 1112, "København K" },
                    { 1113, "København K" },
                    { 1114, "København K" },
                    { 1115, "København K" },
                    { 1116, "København K" },
                    { 1117, "København K" },
                    { 1118, "København K" },
                    { 1119, "København K" },
                    { 1120, "København K" },
                    { 1121, "København K" },
                    { 1122, "København K" },
                    { 1123, "København K" },
                    { 1124, "København K" },
                    { 1125, "København K" },
                    { 1126, "København K" },
                    { 1127, "København K" },
                    { 1128, "København K" },
                    { 1129, "København K" },
                    { 1130, "København K" },
                    { 1131, "København K" },
                    { 1150, "København K" },
                    { 1151, "København K" },
                    { 1152, "København K" },
                    { 1153, "København K" },
                    { 1154, "København K" },
                    { 1155, "København K" },
                    { 1156, "København K" },
                    { 1157, "København K" },
                    { 1158, "København K" },
                    { 1159, "København K" },
                    { 1160, "København K" },
                    { 1161, "København K" },
                    { 1162, "København K" },
                    { 1164, "København K" },
                    { 1165, "København K" },
                    { 1166, "København K" },
                    { 1167, "København K" },
                    { 1168, "København K" },
                    { 1169, "København K" },
                    { 1170, "København K" },
                    { 1171, "København K" },
                    { 1172, "København K" },
                    { 1173, "København K" },
                    { 1174, "København K" },
                    { 1175, "København K" },
                    { 1200, "København K" },
                    { 1201, "København K" },
                    { 1202, "København K" },
                    { 1203, "København K" },
                    { 1204, "København K" },
                    { 1205, "København K" },
                    { 1206, "København K" },
                    { 1207, "København K" },
                    { 1208, "København K" },
                    { 1209, "København K" },
                    { 1210, "København K" },
                    { 1211, "København K" },
                    { 1212, "København K" },
                    { 1213, "København K" },
                    { 1214, "København K" },
                    { 1215, "København K" },
                    { 1216, "København K" },
                    { 1218, "København K" },
                    { 1219, "København K" },
                    { 1220, "København K" },
                    { 1221, "København K" },
                    { 1250, "København K" },
                    { 1251, "København K" },
                    { 1252, "København K" },
                    { 1253, "København K" },
                    { 1254, "København K" },
                    { 1255, "København K" },
                    { 1256, "København K" },
                    { 1257, "København K" },
                    { 1259, "København K" },
                    { 1260, "København K" },
                    { 1261, "København K" },
                    { 1263, "København K" },
                    { 1264, "København K" },
                    { 1265, "København K" },
                    { 1266, "København K" },
                    { 1267, "København K" },
                    { 1268, "København K" },
                    { 1270, "København K" },
                    { 1271, "København K" },
                    { 1300, "København K" },
                    { 1301, "København K" },
                    { 1302, "København K" },
                    { 1303, "København K" },
                    { 1304, "København K" },
                    { 1306, "København K" },
                    { 1307, "København K" },
                    { 1308, "København K" },
                    { 1309, "København K" },
                    { 1310, "København K" },
                    { 1311, "København K" },
                    { 1312, "København K" },
                    { 1313, "København K" },
                    { 1314, "København K" },
                    { 1315, "København K" },
                    { 1316, "København K" },
                    { 1317, "København K" },
                    { 1318, "København K" },
                    { 1319, "København K" },
                    { 1320, "København K" },
                    { 1321, "København K" },
                    { 1322, "København K" },
                    { 1323, "København K" },
                    { 1324, "København K" },
                    { 1325, "København K" },
                    { 1326, "København K" },
                    { 1327, "København K" },
                    { 1328, "København K" },
                    { 1329, "København K" },
                    { 1350, "København K" },
                    { 1352, "København K" },
                    { 1353, "København K" },
                    { 1354, "København K" },
                    { 1355, "København K" },
                    { 1356, "København K" },
                    { 1357, "København K" },
                    { 1358, "København K" },
                    { 1359, "København K" },
                    { 1360, "København K" },
                    { 1361, "København K" },
                    { 1362, "København K" },
                    { 1363, "København K" },
                    { 1364, "København K" },
                    { 1365, "København K" },
                    { 1366, "København K" },
                    { 1367, "København K" },
                    { 1368, "København K" },
                    { 1369, "København K" },
                    { 1370, "København K" },
                    { 1371, "København K" },
                    { 1400, "København K" },
                    { 1401, "København K" },
                    { 1402, "København K" },
                    { 1403, "København K" },
                    { 1406, "København K" },
                    { 1407, "København K" },
                    { 1408, "København K" },
                    { 1409, "København K" },
                    { 1410, "København K" },
                    { 1411, "København K" },
                    { 1412, "København K" },
                    { 1413, "København K" },
                    { 1414, "København K" },
                    { 1415, "København K" },
                    { 1416, "København K" },
                    { 1417, "København K" },
                    { 1418, "København K" },
                    { 1419, "København K" },
                    { 1420, "København K" },
                    { 1421, "København K" },
                    { 1422, "København K" },
                    { 1423, "København K" },
                    { 1424, "København K" },
                    { 1425, "København K" },
                    { 1426, "København K" },
                    { 1427, "København K" },
                    { 1428, "København K" },
                    { 1429, "København K" },
                    { 1430, "København K" },
                    { 1432, "København K" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 25 },
                    { 1, 26 },
                    { 1, 27 },
                    { 1, 28 },
                    { 1, 29 },
                    { 1, 30 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImagesId", "DefaultText", "ImgPath", "ProductId" },
                values: new object[,]
                {
                    { 1, "Image not load", "/Images/diablo-3-pc-20394.png", 1 },
                    { 2, "Image not load", "/Images/diablo-3-pc-20394.png", 2 },
                    { 3, "Image not load", "/Images/diablo-3-pc-20394.png", 3 },
                    { 4, "Image not load", "/Images/diablo-3-pc-20394.png", 4 },
                    { 5, "Image not load", "/Images/diablo-3-pc-20394.png", 5 },
                    { 6, "Image not load", "/Images/diablo-3-pc-20394.png", 6 },
                    { 7, "Image not load", "/Images/diablo-3-pc-20394.png", 7 },
                    { 8, "Image not load", "/Images/diablo-3-pc-20394.png", 8 },
                    { 9, "Image not load", "/Images/diablo-3-pc-20394.png", 9 },
                    { 10, "Image not load", "/Images/diablo-3-pc-20394.png", 10 },
                    { 11, "Image not load", "/Images/diablo-3-pc-20394.png", 11 },
                    { 12, "Image not load", "/Images/diablo-3-pc-20394.png", 12 },
                    { 13, "Image not load", "/Images/diablo-3-pc-20394.png", 13 },
                    { 14, "Image not load", "/Images/diablo-3-pc-20394.png", 14 },
                    { 15, "Image not load", "/Images/diablo-3-pc-20394.png", 15 },
                    { 16, "Image not load", "/Images/diablo-3-pc-20394.png", 16 },
                    { 17, "Image not load", "/Images/diablo-3-pc-20394.png", 17 },
                    { 18, "Image not load", "/Images/diablo-3-pc-20394.png", 18 },
                    { 19, "Image not load", "/Images/diablo-3-pc-20394.png", 19 },
                    { 20, "Image not load", "/Images/diablo-3-pc-20394.png", 20 },
                    { 21, "Image not load", "/Images/diablo-3-pc-20394.png", 21 },
                    { 22, "Image not load", "/Images/diablo-3-pc-20394.png", 22 },
                    { 23, "Image not load", "/Images/diablo-3-pc-20394.png", 23 },
                    { 24, "Image not load", "/Images/diablo-3-pc-20394.png", 24 },
                    { 25, "Image not load", "/Images/diablo-3-pc-20394.png", 25 },
                    { 26, "Image not load", "/Images/diablo-3-pc-20394.png", 26 },
                    { 27, "Image not load", "/Images/diablo-3-pc-20394.png", 27 },
                    { 28, "Image not load", "/Images/diablo-3-pc-20394.png", 28 },
                    { 29, "Image not load", "/Images/diablo-3-pc-20394.png", 29 },
                    { 30, "Image not load", "/Images/diablo-3-pc-20394.png", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_ProductId",
                table: "CategoryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ZipCodeId",
                table: "Customers",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderCustomer_CustomerId",
                table: "OrderCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrdersId",
                table: "OrderProduct",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PayOptionsId",
                table: "Orders",
                column: "PayOptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderCustomer");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ZipCodes");

            migrationBuilder.DropTable(
                name: "PayOptions");
        }
    }
}
