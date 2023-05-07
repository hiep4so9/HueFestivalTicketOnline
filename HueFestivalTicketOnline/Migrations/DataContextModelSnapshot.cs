﻿// <auto-generated />
using System;
using HueFestivalTicketOnline.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HueFestivalTicketOnline.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HueFestivalTicketOnline.Model.Artist", b =>
                {
                    b.Property<int>("artistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("artistID"), 1L, 1);

                    b.Property<string>("artistName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("artistID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Artists_Invited", b =>
                {
                    b.Property<int>("artistID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("eventID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("artistID", "eventID");

                    b.HasIndex("eventID");

                    b.ToTable("Artists_Invited");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Customer", b =>
                {
                    b.Property<int>("customerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("identityCardNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("paymentInfo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("customerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Event", b =>
                {
                    b.Property<int>("eventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("eventID"), 1L, 1);

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("eventTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("eventID");

                    b.HasIndex("eventTypeID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Event_Images", b =>
                {
                    b.Property<int>("eventID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("eventImageID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.HasKey("eventID", "eventImageID");

                    b.HasIndex("eventImageID");

                    b.ToTable("Event_Images");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.EventImage", b =>
                {
                    b.Property<int>("eventImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("eventImageID"), 1L, 1);

                    b.Property<string>("eventImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("eventImageID");

                    b.ToTable("EventImage");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Events_Locations", b =>
                {
                    b.Property<int>("eventID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("locationID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("end_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("ticketQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("eventID", "locationID");

                    b.HasIndex("locationID");

                    b.ToTable("Events_Locations");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.EventType", b =>
                {
                    b.Property<int>("eventTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("eventTypeID"), 1L, 1);

                    b.Property<string>("eventTypeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("eventTypeID");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Location", b =>
                {
                    b.Property<int>("locationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("locationID"), 1L, 1);

                    b.Property<string>("description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("locationName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("locationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.News", b =>
                {
                    b.Property<int>("newsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("newsID"), 1L, 1);

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("eventID")
                        .HasColumnType("int");

                    b.Property<string>("newName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("newsContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("newsID");

                    b.HasIndex("eventID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Permission", b =>
                {
                    b.Property<int>("permissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("permissionID"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permissionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("permissionID");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("roleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Role_Permission", b =>
                {
                    b.Property<int>("roleID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("permissionID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("roleID", "permissionID");

                    b.HasIndex("permissionID");

                    b.ToTable("Role_Permission");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Ticket", b =>
                {
                    b.Property<int>("ticketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketID"), 1L, 1);

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<int>("eventID")
                        .HasColumnType("int");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("ticketName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticketTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("ticketID");

                    b.HasIndex("customerID");

                    b.HasIndex("eventID");

                    b.HasIndex("locationID");

                    b.HasIndex("ticketTypeID");

                    b.HasIndex("userID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.TicketCheckin", b =>
                {
                    b.Property<int>("ticketCheckinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketCheckinID"), 1L, 1);

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("ticketID")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("ticketCheckinID");

                    b.HasIndex("ticketID");

                    b.ToTable("TicketCheckin");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.TicketType", b =>
                {
                    b.Property<int>("ticketTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketTypeID"), 1L, 1);

                    b.Property<string>("ticketTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ticketTypeID");

                    b.ToTable("TicketType");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"), 1L, 1);

                    b.Property<string>("address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("userImage")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("userID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.User_Role", b =>
                {
                    b.Property<int>("userID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("roleID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("userID", "roleID");

                    b.HasIndex("roleID");

                    b.ToTable("User_Role");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Artists_Invited", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Model.Artist", "Artist")
                        .WithMany("Artists_Inviteds")
                        .HasForeignKey("artistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.Event", "Event")
                        .WithMany("Artists_Inviteds")
                        .HasForeignKey("eventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Event", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("eventTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Event_Images", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.Event", "Event")
                        .WithMany("Event_Images")
                        .HasForeignKey("eventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.EventImage", "EventImage")
                        .WithMany("Event_Images")
                        .HasForeignKey("eventImageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("EventImage");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Events_Locations", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.Event", "Event")
                        .WithMany("Events_Locations")
                        .HasForeignKey("eventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.Location", "Location")
                        .WithMany("Events_Locations")
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.News", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("eventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Role_Permission", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.Permission", "Permission")
                        .WithMany("Role_Permissions")
                        .HasForeignKey("permissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.Role", "Role")
                        .WithMany("Role_Permissions")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Ticket", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("eventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.TicketType", "TicketType")
                        .WithMany()
                        .HasForeignKey("ticketTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Event");

                    b.Navigation("Location");

                    b.Navigation("TicketType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.TicketCheckin", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("ticketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.User_Role", b =>
                {
                    b.HasOne("HueFestivalTicketOnline.Models.Role", "Role")
                        .WithMany("User_Roles")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HueFestivalTicketOnline.Models.User", "User")
                        .WithMany("User_Roles")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Model.Artist", b =>
                {
                    b.Navigation("Artists_Inviteds");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Event", b =>
                {
                    b.Navigation("Artists_Inviteds");

                    b.Navigation("Event_Images");

                    b.Navigation("Events_Locations");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.EventImage", b =>
                {
                    b.Navigation("Event_Images");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Location", b =>
                {
                    b.Navigation("Events_Locations");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Permission", b =>
                {
                    b.Navigation("Role_Permissions");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.Role", b =>
                {
                    b.Navigation("Role_Permissions");

                    b.Navigation("User_Roles");
                });

            modelBuilder.Entity("HueFestivalTicketOnline.Models.User", b =>
                {
                    b.Navigation("User_Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
