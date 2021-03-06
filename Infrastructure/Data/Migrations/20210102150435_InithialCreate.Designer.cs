﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20210102150435_InithialCreate")]
    partial class InithialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Core.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DataStatus")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ModifiedOn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostDescription")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("PostedBy")
                        .HasColumnType("TEXT");

                    b.Property<long>("SetOn")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Core.Entities.PostComments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentText")
                        .HasColumnType("TEXT");

                    b.Property<int>("DataStatus")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ModifiedOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoOfDisLike")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoOfLike")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SetOn")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostComments");
                });

            modelBuilder.Entity("Core.Entities.PostComments", b =>
                {
                    b.HasOne("Core.Entities.Post", "Post")
                        .WithMany("ProductVariations")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
