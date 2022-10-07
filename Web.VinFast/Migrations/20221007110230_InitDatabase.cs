using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.VinFast.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CarCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarCategory",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9133), "Sedan" },
                    { 2, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9135), "SUV" },
                    { 3, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9136), "Coupe" },
                    { 4, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9137), "Hatchback" },
                    { 5, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9138), "Convertible" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(8910), "admin@gmail.com", "Admin", "827CCB0EEA8A706C4C34A16891F84E7B" },
                    { 2, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(8964), "senms@gmail.com", "Admin", "827CCB0EEA8A706C4C34A16891F84E7B" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9174), "Tại thị trường Việt Nam ", "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/fadil.png", "VINFAST FADIL", 352500000m },
                    { 2, 1, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9177), "Tại thị trường Việt Nam ", "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/luz-a.png", "VINFAST LUX A2.0", 881695000m },
                    { 3, 1, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9178), "Tại thị trường Việt Nam ", "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/lux-sa.png", "VINFAST LUX SA2.0", 1160965000m },
                    { 4, 2, new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9179), "Tại thị trường Việt Nam ", "https://vinfast-hochiminh.vn/wp-content/uploads/2022/03/vfe8_0-1.png", "VINFAST VF8", 1260965000m }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "CreatedDate", "Image", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Kia Frontier K200S -2WD (1 cầu, thùng 2,9m) có kích thước nhỏ hẹp nên vận hành rất linh hoạt trong", new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9204), "https://giaxeoto.vn/admin/upload/images/resize/640-gia-xe-tai-kia-frontier-k200.jpg", "Bảng giá xe tải Kia Frontier mới nhất (10/2022)", 1 },
                    { 2, "Phim bảo vệ sơn (PPF) Oraguard có 05 dòng sản phẩm với độ dày và hiệu năng khác nhau nhằm đáp ứng nhu cầu của khách hàng.", new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9207), "	https://giaxeoto.vn/admin/upload/images/resize/640-Phim-cach-nhiet-Orafol-tai-viet-nam.jpg", "Bảng giá phim bảo vệ sơn ô tô PPF Orafol (10/2022)", 1 },
                    { 3, "Bảo hiểm Liberty là thành viên của Liberty Mutual Insurance - Tập đoàn bảo hiểm đa ngành toàn cầu, thành lập năm 1912 có trụ sở chính tại Boston, Hoa Kỳ.", new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9208), "https://giaxeoto.vn/admin/upload/images/resize/640-Bao-hiem-than-vo-xe.jpg", "Phí bảo hiểm ô tô Liberty (10/2022)", 1 },
                    { 4, "https://giaxeoto.vn/admin/upload/images/resize/640-dai-ly-hyundai-pham-van-dong1.jpg", new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9210), "https://giaxeoto.vn/admin/upload/images/resize/640-dai-ly-hyundai-pham-van-dong1.jpg", "Đại lý Hyundai Phạm Văn Đồng", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CategoryId",
                table: "Car",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
