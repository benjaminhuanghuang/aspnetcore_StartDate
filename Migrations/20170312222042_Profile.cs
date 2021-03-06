﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspnetcore_StartDate.Migrations
{
    public partial class Profile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Occupation = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Smoking = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profile_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profile_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UseName",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
