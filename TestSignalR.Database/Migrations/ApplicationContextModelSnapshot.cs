﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestSignalR.Database;

#nullable disable

namespace TestSignalR.Database.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestSignalR.Database.Models.Dialog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FriendshipId")
                        .HasColumnType("int");

                    b.Property<int>("LastMessageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendshipId");

                    b.HasIndex("LastMessageId");

                    b.ToTable("Dialog");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.DialogMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DialogId")
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DialogId");

                    b.HasIndex("MessageId");

                    b.ToTable("DialogMessage");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Friendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstFriendUserId")
                        .HasColumnType("int");

                    b.Property<int>("SecondFriendUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstFriendUserId");

                    b.HasIndex("SecondFriendUserId");

                    b.ToTable("Friendship");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SenderUserId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.RequestOfFriendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReceiverUserId")
                        .HasColumnType("int");

                    b.Property<int>("SenderUserId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("RequestOfFriendship");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronimyc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Dialog", b =>
                {
                    b.HasOne("TestSignalR.Database.Models.Friendship", "Friendship")
                        .WithMany("Dialogs")
                        .HasForeignKey("FriendshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestSignalR.Database.Models.Message", "LastMessage")
                        .WithMany("Dialogs")
                        .HasForeignKey("LastMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friendship");

                    b.Navigation("LastMessage");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.DialogMessage", b =>
                {
                    b.HasOne("TestSignalR.Database.Models.Dialog", "Dialog")
                        .WithMany("DialogMessages")
                        .HasForeignKey("DialogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestSignalR.Database.Models.Message", "Message")
                        .WithMany("DialogMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Dialog");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Friendship", b =>
                {
                    b.HasOne("TestSignalR.Database.Models.User", "FirstFriend")
                        .WithMany("Friendship")
                        .HasForeignKey("FirstFriendUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestSignalR.Database.Models.User", "SecondFriend")
                        .WithMany("Friendship1")
                        .HasForeignKey("SecondFriendUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FirstFriend");

                    b.Navigation("SecondFriend");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Message", b =>
                {
                    b.HasOne("TestSignalR.Database.Models.User", "SenderUser")
                        .WithMany()
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.RequestOfFriendship", b =>
                {
                    b.HasOne("TestSignalR.Database.Models.User", "ReceiverUser")
                        .WithMany("RequestOfFriendship1")
                        .HasForeignKey("ReceiverUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestSignalR.Database.Models.User", "SenderUser")
                        .WithMany("RequestOfFriendship")
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReceiverUser");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Dialog", b =>
                {
                    b.Navigation("DialogMessages");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Friendship", b =>
                {
                    b.Navigation("Dialogs");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.Message", b =>
                {
                    b.Navigation("DialogMessages");

                    b.Navigation("Dialogs");
                });

            modelBuilder.Entity("TestSignalR.Database.Models.User", b =>
                {
                    b.Navigation("Friendship");

                    b.Navigation("Friendship1");

                    b.Navigation("RequestOfFriendship");

                    b.Navigation("RequestOfFriendship1");
                });
#pragma warning restore 612, 618
        }
    }
}