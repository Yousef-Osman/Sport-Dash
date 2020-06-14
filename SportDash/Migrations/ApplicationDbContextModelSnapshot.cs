﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportDash.Data;

namespace SportDash.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "4edd9bb1-57fe-4d49-8da1-07c553a5329d",
                            ConcurrencyStamp = "c37f4ec3-424f-4abb-b8cc-d8bb86a2a6d2",
                            Name = "Playground",
                            NormalizedName = "PLAYGROUND"
                        },
                        new
                        {
                            Id = "c999ec64-0f8c-41a3-8c5a-7f8f417533f2",
                            ConcurrencyStamp = "0bc8d4ed-ca02-46c5-a30d-8db131a80e35",
                            Name = "Gym",
                            NormalizedName = "GYM"
                        },
                        new
                        {
                            Id = "c74273aa-df1b-4935-b37d-429991785bc8",
                            ConcurrencyStamp = "83a4d002-f58c-41b5-a3af-e5918541546b",
                            Name = "Coach",
                            NormalizedName = "COACH"
                        },
                        new
                        {
                            Id = "21cf6c75-fedc-4280-b84f-74e2b81b8eaf",
                            ConcurrencyStamp = "00ef2bbf-e5d8-410b-a3c4-44a14931a2ff",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

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
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SportDash.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool?>("BallRenting")
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("ForLadies")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasNewMsgs")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("LockerRoom")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("Safe")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SportType")
                        .HasColumnType("int");

                    b.Property<bool?>("Toilet")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("biography")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SportDash.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SportDash.Models.ConnectedUser", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConnectionId");

                    b.HasIndex("UserId");

                    b.ToTable("ConnectedUsers");
                });

            modelBuilder.Entity("SportDash.Models.GymPrices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GymId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Subscribtion_Price")
                        .HasColumnType("float");

                    b.Property<int>("Subscribtion_Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.ToTable("GymPrices");
                });

            modelBuilder.Entity("SportDash.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsProfileImg")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SportDash.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SportDash.Models.PlaygroundPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<string>("PlaygroundId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("PlaygroundId");

                    b.ToTable("playgroundPrices");
                });

            modelBuilder.Entity("SportDash.Models.PlaygroundReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaygroundId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PlaygroundId");

                    b.HasIndex("UserId");

                    b.ToTable("playgroundReservations");
                });

            modelBuilder.Entity("SportDash.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SportDash.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("Review_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TargetId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("TargetId");

                    b.ToTable("Reviews");
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
                    b.HasOne("SportDash.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", null)
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

                    b.HasOne("SportDash.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportDash.Models.Comment", b =>
                {
                    b.HasOne("SportDash.Models.Question", "Question")
                        .WithMany("Comments")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportDash.Data.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SportDash.Models.ConnectedUser", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "User")
                        .WithMany("ConnectedUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SportDash.Models.GymPrices", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "Gym")
                        .WithMany("GymPrices")
                        .HasForeignKey("GymId");
                });

            modelBuilder.Entity("SportDash.Models.Image", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SportDash.Models.Message", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "Receiver")
                        .WithMany("ReceiverMessages")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("SportDash.Data.ApplicationUser", "Sender")
                        .WithMany("SenderMessages")
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("SportDash.Models.PlaygroundPrice", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "Playground")
                        .WithMany("PlaygroundPrices")
                        .HasForeignKey("PlaygroundId");
                });

            modelBuilder.Entity("SportDash.Models.PlaygroundReservation", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "Playground")
                        .WithMany("Playgrounds")
                        .HasForeignKey("PlaygroundId");

                    b.HasOne("SportDash.Data.ApplicationUser", "User")
                        .WithMany("UserReservations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SportDash.Models.Question", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SportDash.Models.Review", b =>
                {
                    b.HasOne("SportDash.Data.ApplicationUser", "Reviewer")
                        .WithMany("ReviewerReviews")
                        .HasForeignKey("ReviewerId");

                    b.HasOne("SportDash.Data.ApplicationUser", "Target")
                        .WithMany("TargetReviews")
                        .HasForeignKey("TargetId");
                });
#pragma warning restore 612, 618
        }
    }
}
