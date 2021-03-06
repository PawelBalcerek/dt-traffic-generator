﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    EndpointId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EndpointName = table.Column<string>(nullable: true),
                    HttpMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.EndpointId);
                });

            migrationBuilder.CreateTable(
                name: "TestParameters",
                columns: table => new
                {
                    TestParametersId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TestName = table.Column<string>(nullable: true),
                    NumberOfUsers = table.Column<int>(nullable: false),
                    NumberOfRequests = table.Column<int>(nullable: false),
                    MinBuyPrice = table.Column<double>(nullable: false),
                    MaxBuyPrice = table.Column<double>(nullable: false),
                    MinSellPrice = table.Column<double>(nullable: false),
                    MaxSellPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestParameters", x => x.TestParametersId);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TestParametersId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    EndpointId = table.Column<long>(nullable: false),
                    DatabaseTestTime = table.Column<double>(nullable: false),
                    ApplicationTestTime = table.Column<double>(nullable: false),
                    ApiTestTime = table.Column<double>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_Endpoints_EndpointId",
                        column: x => x.EndpointId,
                        principalTable: "Endpoints",
                        principalColumn: "EndpointId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_TestParameters_TestParametersId",
                        column: x => x.TestParametersId,
                        principalTable: "TestParameters",
                        principalColumn: "TestParametersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_EndpointId",
                table: "Tests",
                column: "EndpointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestParametersId",
                table: "Tests",
                column: "TestParametersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "TestParameters");
        }
    }
}
