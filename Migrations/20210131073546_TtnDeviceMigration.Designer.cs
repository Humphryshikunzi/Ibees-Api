﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackTileBackend;

namespace TrackTileBackend.Migrations
{
    [DbContext(typeof(IbeesDbContext))]
    [Migration("20210131073546_TtnDeviceMigration")]
    partial class TtnDeviceMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TrackTileBackend.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AuthKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSignedIn")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SettingId")
                        .HasColumnType("int");

                    b.Property<bool>("TermsTermsAndConditionsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SettingId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TrackTileBackend.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("AppNotificationsOn")
                        .HasColumnType("bit");

                    b.Property<bool>("MarkettingNotificationsOn")
                        .HasColumnType("bit");

                    b.Property<bool>("NightModeOn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TtnDevices.Fields", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DataRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Measurement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelativeHumidity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TtnDevices.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Sensor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TtnDevices.TtnData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("FieldsId")
                        .HasColumnType("int");

                    b.Property<int?>("TagsId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldsId");

                    b.HasIndex("TagsId");

                    b.ToTable("TtnData");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TtnTest.gateways", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("altitude")
                        .HasColumnType("float");

                    b.Property<int>("channel")
                        .HasColumnType("int");

                    b.Property<string>("gtw_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<int>("rf_chain")
                        .HasColumnType("int");

                    b.Property<int>("rssi")
                        .HasColumnType("int");

                    b.Property<int>("snr")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("timestamp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("gateways");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TtnTest.payload_fields", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("relative_humidity_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temperature_2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("payload_fields");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TttnTestData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("app_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("confirmed")
                        .HasColumnType("bit");

                    b.Property<int>("counter")
                        .HasColumnType("int");

                    b.Property<string>("dev_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("downlink_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hardware_serial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_retry")
                        .HasColumnType("bit");

                    b.Property<int?>("metadataId")
                        .HasColumnType("int");

                    b.Property<int?>("payload_fieldsId")
                        .HasColumnType("int");

                    b.Property<string>("payload_raw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("port")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("metadataId");

                    b.HasIndex("payload_fieldsId");

                    b.ToTable("TttnTestData");
                });

            modelBuilder.Entity("TrackTileBackend.Models.metadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("altitude")
                        .HasColumnType("float");

                    b.Property<int>("bit_rate")
                        .HasColumnType("int");

                    b.Property<string>("coding_rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data_rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("frequency")
                        .HasColumnType("float");

                    b.Property<int?>("gatewaysId")
                        .HasColumnType("int");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("modulation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("gatewaysId");

                    b.ToTable("metadata");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TrackTileBackend.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TrackTileBackend.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrackTileBackend.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TrackTileBackend.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackTileBackend.Models.AppUser", b =>
                {
                    b.HasOne("TrackTileBackend.Models.Setting", "Setting")
                        .WithMany()
                        .HasForeignKey("SettingId");

                    b.Navigation("Setting");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TtnDevices.TtnData", b =>
                {
                    b.HasOne("TrackTileBackend.Models.TtnDevices.Fields", "Fields")
                        .WithMany()
                        .HasForeignKey("FieldsId");

                    b.HasOne("TrackTileBackend.Models.TtnDevices.Tags", "Tags")
                        .WithMany()
                        .HasForeignKey("TagsId");

                    b.Navigation("Fields");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("TrackTileBackend.Models.TttnTestData", b =>
                {
                    b.HasOne("TrackTileBackend.Models.metadata", "metadata")
                        .WithMany()
                        .HasForeignKey("metadataId");

                    b.HasOne("TrackTileBackend.Models.TtnTest.payload_fields", "payload_fields")
                        .WithMany()
                        .HasForeignKey("payload_fieldsId");

                    b.Navigation("metadata");

                    b.Navigation("payload_fields");
                });

            modelBuilder.Entity("TrackTileBackend.Models.metadata", b =>
                {
                    b.HasOne("TrackTileBackend.Models.TtnTest.gateways", "gateways")
                        .WithMany()
                        .HasForeignKey("gatewaysId");

                    b.Navigation("gateways");
                });
#pragma warning restore 612, 618
        }
    }
}
