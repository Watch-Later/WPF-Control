﻿// <auto-generated />
using System;
using H.Test.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H.Test.Sqlite.Migrations
{
    [DbContext(typeof(MyDataContext))]
    [Migration("20231101115422_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("H.Test.Sqlite.mbc_dv_image", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("AreaType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArticulationType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Aspect")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("CaseType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtendType")
                        .HasColumnType("TEXT");

                    b.Property<string>("FromType")
                        .HasColumnType("TEXT");

                    b.Property<int>("ISENBLED")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MediaType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderNum")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayCount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Resoluction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Score")
                        .HasColumnType("TEXT");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagTypes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UDATE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VipType")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("mbc_dv_images");
                });
#pragma warning restore 612, 618
        }
    }
}
