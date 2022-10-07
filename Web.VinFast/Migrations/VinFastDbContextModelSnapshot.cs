﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.VinFast.Data;

#nullable disable

namespace Web.VinFast.Migrations
{
    [DbContext(typeof(VinFastDbContext))]
    partial class VinFastDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Web.VinFast.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9174),
                            Description = "Tại thị trường Việt Nam ",
                            Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/fadil.png",
                            Name = "VINFAST FADIL",
                            Price = 352500000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9177),
                            Description = "Tại thị trường Việt Nam ",
                            Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/luz-a.png",
                            Name = "VINFAST LUX A2.0",
                            Price = 881695000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9178),
                            Description = "Tại thị trường Việt Nam ",
                            Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2020/03/lux-sa.png",
                            Name = "VINFAST LUX SA2.0",
                            Price = 1160965000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9179),
                            Description = "Tại thị trường Việt Nam ",
                            Image = "https://vinfast-hochiminh.vn/wp-content/uploads/2022/03/vfe8_0-1.png",
                            Name = "VINFAST VF8",
                            Price = 1260965000m
                        });
                });

            modelBuilder.Entity("Web.VinFast.Models.CarCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("CarCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9133),
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9135),
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9136),
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9137),
                            Name = "Hatchback"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9138),
                            Name = "Convertible"
                        });
                });

            modelBuilder.Entity("Web.VinFast.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Kia Frontier K200S -2WD (1 cầu, thùng 2,9m) có kích thước nhỏ hẹp nên vận hành rất linh hoạt trong",
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9204),
                            Image = "https://giaxeoto.vn/admin/upload/images/resize/640-gia-xe-tai-kia-frontier-k200.jpg",
                            Title = "Bảng giá xe tải Kia Frontier mới nhất (10/2022)",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Phim bảo vệ sơn (PPF) Oraguard có 05 dòng sản phẩm với độ dày và hiệu năng khác nhau nhằm đáp ứng nhu cầu của khách hàng.",
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9207),
                            Image = "	https://giaxeoto.vn/admin/upload/images/resize/640-Phim-cach-nhiet-Orafol-tai-viet-nam.jpg",
                            Title = "Bảng giá phim bảo vệ sơn ô tô PPF Orafol (10/2022)",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "Bảo hiểm Liberty là thành viên của Liberty Mutual Insurance - Tập đoàn bảo hiểm đa ngành toàn cầu, thành lập năm 1912 có trụ sở chính tại Boston, Hoa Kỳ.",
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9208),
                            Image = "https://giaxeoto.vn/admin/upload/images/resize/640-Bao-hiem-than-vo-xe.jpg",
                            Title = "Phí bảo hiểm ô tô Liberty (10/2022)",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Content = "https://giaxeoto.vn/admin/upload/images/resize/640-dai-ly-hyundai-pham-van-dong1.jpg",
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(9210),
                            Image = "https://giaxeoto.vn/admin/upload/images/resize/640-dai-ly-hyundai-pham-van-dong1.jpg",
                            Title = "Đại lý Hyundai Phạm Văn Đồng",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Web.VinFast.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(8910),
                            Email = "admin@gmail.com",
                            Name = "Admin",
                            Password = "827CCB0EEA8A706C4C34A16891F84E7B"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 10, 7, 18, 2, 29, 922, DateTimeKind.Local).AddTicks(8964),
                            Email = "senms@gmail.com",
                            Name = "Admin",
                            Password = "827CCB0EEA8A706C4C34A16891F84E7B"
                        });
                });

            modelBuilder.Entity("Web.VinFast.Models.Car", b =>
                {
                    b.HasOne("Web.VinFast.Models.CarCategory", "CarCategory")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarCategory");
                });

            modelBuilder.Entity("Web.VinFast.Models.Post", b =>
                {
                    b.HasOne("Web.VinFast.Models.User", "User")
                        .WithMany("Post")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web.VinFast.Models.CarCategory", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Web.VinFast.Models.User", b =>
                {
                    b.Navigation("Post");
                });
#pragma warning restore 612, 618
        }
    }
}
