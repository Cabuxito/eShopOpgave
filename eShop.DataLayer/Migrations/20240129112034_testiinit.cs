using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class testiinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "Email", "Firstname", "IsAdmin", "IsDeleted", "Lastname", "Password", "ZipCodeId" },
                values: new object[] { 1, "Admin", "admin@admin.com", "Admin", true, false, "Admin", "admin", 1050 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 4,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 5,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 6,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 7,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 8,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 9,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 10,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 11,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 12,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 13,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 14,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 15,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 16,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 17,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 18,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 19,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 20,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 21,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 22,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 23,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 24,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 25,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 26,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 27,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 28,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 29,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 30,
                column: "ImgPath",
                value: "/Images/diablo-3-pc-20394.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 4,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 5,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 6,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 7,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 8,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 9,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 10,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 11,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 12,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 13,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 14,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 15,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 16,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 17,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 18,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 19,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 20,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 21,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 22,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 23,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 24,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 25,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 26,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 27,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 28,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 29,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 30,
                column: "ImgPath",
                value: "/Image/diablo-3-pc-20394.png");
        }
    }
}
