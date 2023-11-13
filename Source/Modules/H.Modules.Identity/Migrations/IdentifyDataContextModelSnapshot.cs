﻿// <auto-generated />
using System;
using H.Modules.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H.Modules.Identity.Migrations
{
    [DbContext(typeof(IdentifyDataContext))]
    partial class IdentifyDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("H.Modules.Identity.hi_dd_author", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("AuthorCode")
                        .HasColumnType("TEXT")
                        .HasColumnName("author_code")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("author_name")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("hi_dd_authors");

                    b.HasData(
                        new
                        {
                            ID = "{63860D6B-BD59-4620-919D-0DE51877676F}",
                            CDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(257),
                            ISENBLED = 1,
                            Name = "用户管理",
                            UDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(257)
                        },
                        new
                        {
                            ID = "{DE3B4992-A5BF-4AD2-80D8-2C9654C47A34}",
                            CDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(290),
                            ISENBLED = 1,
                            Name = "角色管理",
                            UDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(290)
                        });
                });

            modelBuilder.Entity("H.Modules.Identity.hi_dd_role", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT")
                        .HasColumnName("role_code")
                        .HasColumnOrder(2);

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role_name")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("hi_dd_roles");

                    b.HasData(
                        new
                        {
                            ID = "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}",
                            CDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(297),
                            Code = "01",
                            ISENBLED = 1,
                            Name = "管理员",
                            UDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(297)
                        },
                        new
                        {
                            ID = "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}",
                            CDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(302),
                            Code = "02",
                            ISENBLED = 1,
                            Name = "普通用户",
                            UDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(302)
                        });
                });

            modelBuilder.Entity("H.Modules.Identity.hi_dd_user", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("account")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT")
                        .HasColumnName("display")
                        .HasColumnOrder(4);

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("user_name")
                        .HasColumnOrder(1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password")
                        .HasColumnOrder(3);

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role_id")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("hi_dd_users");

                    b.HasData(
                        new
                        {
                            ID = "{E12E19D6-FDD9-4DCE-B211-55E58FAFC207}",
                            Account = "admin",
                            CDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(305),
                            ISENBLED = 1,
                            Name = "超级用户",
                            Password = "123456",
                            RoleID = "{4360CE12-E5F4-4EA6-937C-9FDEA4DF06F6}",
                            UDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(305)
                        },
                        new
                        {
                            ID = "{A8EE1331-0DA7-42F1-80E2-CD2A20D62BC9}",
                            Account = "hebiangu",
                            CDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(312),
                            ISENBLED = 1,
                            Name = "HeBianGu",
                            Password = "123456",
                            RoleID = "{0E465AF1-4C5B-417B-B496-E74E8A0D7E5C}",
                            UDATE = new DateTime(2023, 11, 14, 17, 43, 38, 515, DateTimeKind.Local).AddTicks(312)
                        });
                });

            modelBuilder.Entity("hi_dd_authorhi_dd_role", b =>
                {
                    b.Property<string>("AuthorsID")
                        .HasColumnType("TEXT");

                    b.Property<string>("RolesID")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorsID", "RolesID");

                    b.HasIndex("RolesID");

                    b.ToTable("hi_dd_authorhi_dd_role");
                });

            modelBuilder.Entity("H.Modules.Identity.hi_dd_user", b =>
                {
                    b.HasOne("H.Modules.Identity.hi_dd_role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("hi_dd_authorhi_dd_role", b =>
                {
                    b.HasOne("H.Modules.Identity.hi_dd_author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("H.Modules.Identity.hi_dd_role", null)
                        .WithMany()
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("H.Modules.Identity.hi_dd_role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
