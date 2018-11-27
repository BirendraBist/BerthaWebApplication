﻿// <auto-generated />
using System;
using BerthaWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BerthaWebApplication.Migrations
{
    [DbContext(typeof(BerthaContext))]
    partial class BerthaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BerthaWebApplication.Models.Environment", b =>
                {
                    b.Property<int>("EvnironmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Carbonmonoxide");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<double>("Dustpartical");

                    b.Property<string>("Location");

                    b.Property<double>("Nitrogen");

                    b.Property<double>("Oxygen");

                    b.Property<int>("UserId");

                    b.HasKey("EvnironmentId");

                    b.ToTable("EnvironmentRecord");
                });

            modelBuilder.Entity("BerthaWebApplication.Models.Health", b =>
                {
                    b.Property<int>("HealthId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BodyTemperature");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<double>("Heartbeat");

                    b.Property<string>("Location");

                    b.Property<double>("LowerbloodPressure");

                    b.Property<double>("UpperbloodPressure");

                    b.Property<int>("UserId");

                    b.HasKey("HealthId");

                    b.ToTable("HealthRecord");
                });

            modelBuilder.Entity("BerthaWebApplication.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName");

                    b.Property<string>("UserPassword");

                    b.Property<string>("UserType");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
