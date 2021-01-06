﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SoccerManageApp.Models;

namespace SoccerManageApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("match_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Attendance")
                        .HasColumnName("attendance")
                        .HasColumnType("integer");

                    b.Property<int>("AwayResTeamID")
                        .HasColumnName("awayresteam_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Datetime")
                        .HasColumnName("datetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("HomeResTeamID")
                        .HasColumnName("homeresteam_id")
                        .HasColumnType("integer");

                    b.Property<int>("StadiumID")
                        .HasColumnName("stadium_id")
                        .HasColumnType("integer");

                    b.HasKey("MatchID");

                    b.HasIndex("AwayResTeamID");

                    b.HasIndex("HomeResTeamID");

                    b.HasIndex("StadiumID");

                    b.ToTable("match");
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("player_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Country")
                        .HasColumnName("country_image")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("CountryImage")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<int>("Kit")
                        .HasColumnName("kit")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Position")
                        .HasColumnName("position")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<int>("TeamID")
                        .HasColumnName("team_id")
                        .HasColumnType("integer");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("player");
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Result", b =>
                {
                    b.Property<int>("MatchID")
                        .HasColumnName("match_id")
                        .HasColumnType("integer");

                    b.Property<int>("Awayres")
                        .HasColumnName("away_res")
                        .HasColumnType("integer");

                    b.Property<int>("Homeres")
                        .HasColumnName("home_res")
                        .HasColumnType("integer");

                    b.HasKey("MatchID");

                    b.ToTable("result");
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Score", b =>
                {
                    b.Property<int>("ScoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("score_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MatchID")
                        .HasColumnName("match_id")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerID")
                        .HasColumnName("player_id")
                        .HasColumnType("integer");

                    b.Property<int>("TeamID")
                        .HasColumnName("team_id")
                        .HasColumnType("integer");

                    b.HasKey("ScoreID");

                    b.HasIndex("MatchID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("score");
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Stadium", b =>
                {
                    b.Property<int>("StadiumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stadium_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Capacity")
                        .HasColumnName("capacity")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnName("stadium_name")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("StadiumID");

                    b.ToTable("stadium");
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("team_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("StadiumID")
                        .HasColumnType("integer");

                    b.Property<string>("TeamImage")
                        .IsRequired()
                        .HasColumnName("team_image")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnName("team_name")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("TeamID");

                    b.HasIndex("StadiumID")
                        .IsUnique();

                    b.ToTable("team");
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.TeamResult", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnName("team_id")
                        .HasColumnType("integer");

                    b.Property<int>("DrawMatch")
                        .HasColumnName("draw_match")
                        .HasColumnType("integer");

                    b.Property<int>("LoseMatch")
                        .HasColumnName("lose_match")
                        .HasColumnType("integer");

                    b.Property<int>("Point")
                        .HasColumnName("point")
                        .HasColumnType("integer");

                    b.Property<int>("WinMatch")
                        .HasColumnName("win_match")
                        .HasColumnType("integer");

                    b.HasKey("TeamID");

                    b.ToTable("team_result");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Match", b =>
                {
                    b.HasOne("SoccerManageApp.Models.Entities.Team", "AwayRes")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayResTeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManageApp.Models.Entities.Team", "HomeRes")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeResTeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManageApp.Models.Entities.Stadium", "Stadium")
                        .WithMany("Matches")
                        .HasForeignKey("StadiumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Player", b =>
                {
                    b.HasOne("SoccerManageApp.Models.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Result", b =>
                {
                    b.HasOne("SoccerManageApp.Models.Entities.Match", "Match")
                        .WithOne("Result")
                        .HasForeignKey("SoccerManageApp.Models.Entities.Result", "MatchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Score", b =>
                {
                    b.HasOne("SoccerManageApp.Models.Entities.Match", "Match")
                        .WithMany("Scores")
                        .HasForeignKey("MatchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManageApp.Models.Entities.Player", "Player")
                        .WithMany("Scores")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManageApp.Models.Entities.Team", "Team")
                        .WithMany("Scores")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.Team", b =>
                {
                    b.HasOne("SoccerManageApp.Models.Entities.Stadium", "Stadium")
                        .WithOne("Team")
                        .HasForeignKey("SoccerManageApp.Models.Entities.Team", "StadiumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManageApp.Models.Entities.TeamResult", b =>
                {
                    b.HasOne("SoccerManageApp.Models.Entities.Team", "Team")
                        .WithMany("TeamResults")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
