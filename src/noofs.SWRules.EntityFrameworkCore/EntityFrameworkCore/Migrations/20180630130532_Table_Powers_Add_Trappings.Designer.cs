﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace noofs.SWRules.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(SWRulesDbContext))]
    [Migration("20180630130532_add-trappings")]
    partial class Table_Powers_Add_Trappings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("noofs.SWRules.EntityFrameworkCore.Entities.Power", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Book");

                    b.Property<string>("Distance");

                    b.Property<string>("Duration");

                    b.Property<string>("Name");

                    b.Property<string>("Points");

                    b.Property<string>("Rank");

                    b.Property<string>("Text");

                    b.Property<string>("Trappings");

                    b.HasKey("Id");

                    b.ToTable("Powers");
                });
#pragma warning restore 612, 618
        }
    }
}