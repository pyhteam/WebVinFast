using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using System;
using Web.VinFast.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Web.VinFast.Util;

namespace Web.VinFast.Data
{
    public class VinFastDbContext : DbContext
    {
        public VinFastDbContext(DbContextOptions<VinFastDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            // seed user
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = Common.CreatedMD5("12345"),
                    CreatedDate = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    Name = "Admin",
                    Email = "senms@gmail.com",
                    Password = Common.CreatedMD5("12345"),
                    CreatedDate = DateTime.Now
                }
            );
            // seed CarCategory
            modelBuilder.Entity<CarCategory>().HasData
            (
                new CarCategory()
                {
                    Id = 1,
                    Name = "Sedan",
                    CreatedDate = DateTime.Now
                },
                new CarCategory()
                {
                    Id = 2,
                    Name = "SUV",
                    CreatedDate = DateTime.Now
                },
                new CarCategory()
                {
                    Id = 3,
                    Name = "Coupe",
                    CreatedDate = DateTime.Now
                },
                new CarCategory()
                {
                    Id = 4,
                    Name = "Hatchback",
                    CreatedDate = DateTime.Now
                },
                new CarCategory()
                {
                    Id = 5,
                    Name = "Convertible",
                    CreatedDate = DateTime.Now
                }
            );
            // seed Car
            modelBuilder.Entity<Car>().HasData
            (
                new Car()
                {
                    Id = 1,
                    Name = "VINFAST FADIL",
                    Price = 352500000,
                    Description = "Tại thị trường Việt Nam ",
                    Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/fadil.png",
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },
                new Car()
                {
                    Id = 2,
                    Name = "VINFAST LUX A2.0",
                    Price = 881695000,
                    Description = "Tại thị trường Việt Nam ",
                    Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/luz-a.png",
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },
                new Car()
                {
                    Id = 3,
                    Name = "VINFAST LUX SA2.0",
                    Price = 1160965000,
                    Description = "Tại thị trường Việt Nam ",
                    Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/lux-sa.png",
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },
                new Car()
                {
                    Id = 4,
                    Name = "VINFAST VF8",
                    Price = 1260965000,
                    Description = "Tại thị trường Việt Nam ",
                    Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2022/03/vfe8_0-1.png",
                    CategoryId = 2,
                    CreatedDate = DateTime.Now
                }
            );

            // seed Post
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Bảng giá xe tải Kia Frontier mới nhất (10/2022)",
                    Image = "https://giaxeoto.vn/admin/upload/images/resize/640-gia-xe-tai-kia-frontier-k200.jpg",
                    Content = "Kia Frontier K200S -2WD (1 cầu, thùng 2,9m) có kích thước nhỏ hẹp nên vận hành rất linh hoạt trong",
                    UserId = 1,
                    CreatedDate = DateTime.Now
                },
                new Post
                {
                    Id = 2,
                    Title = "Bảng giá phim bảo vệ sơn ô tô PPF Orafol (10/2022)",
                    Image = "	https://giaxeoto.vn/admin/upload/images/resize/640-Phim-cach-nhiet-Orafol-tai-viet-nam.jpg",
                    Content = "Phim bảo vệ sơn (PPF) Oraguard có 05 dòng sản phẩm với độ dày và hiệu năng khác nhau nhằm đáp ứng nhu cầu của khách hàng.",
                    UserId = 1,
                    CreatedDate = DateTime.Now
                },
                new Post
                {
                    Id = 3,
                    Title = "Phí bảo hiểm ô tô Liberty (10/2022)",
                    Image = "https://giaxeoto.vn/admin/upload/images/resize/640-Bao-hiem-than-vo-xe.jpg",
                    Content = "Bảo hiểm Liberty là thành viên của Liberty Mutual Insurance - Tập đoàn bảo hiểm đa ngành toàn cầu, thành lập năm 1912 có trụ sở chính tại Boston, Hoa Kỳ.",
                    UserId = 1,
                    CreatedDate = DateTime.Now
                },
                new Post
                {
                    Id = 4,
                    Title = "Đại lý Hyundai Phạm Văn Đồng",
                    Image = "https://giaxeoto.vn/admin/upload/images/resize/640-dai-ly-hyundai-pham-van-dong1.jpg",
                    Content = "https://giaxeoto.vn/admin/upload/images/resize/640-dai-ly-hyundai-pham-van-dong1.jpg",
                    UserId = 1,
                    CreatedDate = DateTime.Now
                }
            );

        }
        public DbSet<User>? User { get; set; }
        public DbSet<Post>? Post { get; set; }
        public DbSet<CarCategory>? CarCategory { get; set; }
        public DbSet<Car>? Car { get; set; }

    }
}
