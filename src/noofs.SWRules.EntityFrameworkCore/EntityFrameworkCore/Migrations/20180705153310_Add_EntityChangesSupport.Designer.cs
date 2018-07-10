﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using noofs.SWRules.EntityFrameworkCore;

namespace noofs.SWRules.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(SWRulesDbContext))]
    [Migration("20180705153310_Add_EntityChangesSupport")]
    partial class Add_EntityChangesSupport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("Abp.EntityHistory.EntityChange", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ChangeTime");

                    b.Property<byte>("ChangeType");

                    b.Property<long>("EntityChangeSetId");

                    b.Property<string>("EntityId")
                        .HasMaxLength(48);

                    b.Property<string>("EntityTypeFullName")
                        .HasMaxLength(192);

                    b.Property<int?>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("EntityChangeSetId");

                    b.ToTable("AbpEntityChanges");
                });

            modelBuilder.Entity("Abp.EntityHistory.EntityChangeSet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrowserInfo")
                        .HasMaxLength(512);

                    b.Property<string>("ClientIpAddress")
                        .HasMaxLength(64);

                    b.Property<string>("ClientName")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("ExtensionData");

                    b.Property<int?>("ImpersonatorTenantId");

                    b.Property<long?>("ImpersonatorUserId");

                    b.Property<string>("Reason")
                        .HasMaxLength(256);

                    b.Property<int?>("TenantId");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AbpEntityChangeSets");
                });

            modelBuilder.Entity("Abp.EntityHistory.EntityPropertyChange", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("EntityChangeId");

                    b.Property<string>("NewValue")
                        .HasMaxLength(512);

                    b.Property<string>("OriginalValue")
                        .HasMaxLength(512);

                    b.Property<string>("PropertyName")
                        .HasMaxLength(96);

                    b.Property<string>("PropertyTypeFullName")
                        .HasMaxLength(192);

                    b.Property<int?>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("EntityChangeId");

                    b.ToTable("AbpEntityPropertyChanges");
                });

            modelBuilder.Entity("noofs.SWRules.Rules.Power", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Book");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Distance");

                    b.Property<string>("Duration");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name");

                    b.Property<string>("Points");

                    b.Property<string>("Rank");

                    b.Property<string>("Text");

                    b.Property<string>("Trappings");

                    b.HasKey("Id");

                    b.ToTable("Powers");
                });

            modelBuilder.Entity("Abp.EntityHistory.EntityChange", b =>
                {
                    b.HasOne("Abp.EntityHistory.EntityChangeSet")
                        .WithMany("EntityChanges")
                        .HasForeignKey("EntityChangeSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Abp.EntityHistory.EntityPropertyChange", b =>
                {
                    b.HasOne("Abp.EntityHistory.EntityChange")
                        .WithMany("PropertyChanges")
                        .HasForeignKey("EntityChangeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}