﻿// <auto-generated />
using Enongzi.MeetingReport.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Enongzi.MeetingReport.Migrations
{
    [DbContext(typeof(MeetingDbContext))]
    [Migration("20180313104011_update-subject-teacherid")]
    partial class updatesubjectteacherid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Enongzi.MeetingReport.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<bool>("Current");

                    b.Property<string>("Name");

                    b.Property<string>("Pic");

                    b.Property<string>("Summary");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("meeting");
                });

            modelBuilder.Entity("Enongzi.MeetingReport.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MeetingId");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("TeacherId");

                    b.ToTable("subject");
                });

            modelBuilder.Entity("Enongzi.MeetingReport.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("teacher");
                });

            modelBuilder.Entity("Enongzi.MeetingReport.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Referee");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Enongzi.MeetingReport.Models.Subject", b =>
                {
                    b.HasOne("Enongzi.MeetingReport.Models.Meeting")
                        .WithMany("Subjects")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Enongzi.MeetingReport.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}