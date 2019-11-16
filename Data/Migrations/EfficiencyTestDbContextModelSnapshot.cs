﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(EfficiencyTestDbContext))]
    partial class EfficiencyTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Data.Models.Endpoint", b =>
                {
                    b.Property<int>("EndpointId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EndpointName");

                    b.Property<string>("HttpMethod");

                    b.HasKey("EndpointId");

                    b.ToTable("Endpoints");
                });

            modelBuilder.Entity("Data.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ApiTestTime");

                    b.Property<DateTime>("ApplicationTestTime");

                    b.Property<DateTime>("DatabaseTestTime");

                    b.Property<int>("EndpointId");

                    b.Property<int>("TestParametersId");

                    b.Property<int>("UserId");

                    b.HasKey("TestId");

                    b.HasIndex("EndpointId");

                    b.HasIndex("TestParametersId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Data.Models.TestParameters", b =>
                {
                    b.Property<int>("TestParametersId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("MaxBuyPrice");

                    b.Property<double>("MaxSellPrice");

                    b.Property<double>("MinBuyPrice");

                    b.Property<double>("MinSellPrice");

                    b.Property<int>("NumberOfRequests");

                    b.Property<int>("NumberOfUsers");

                    b.HasKey("TestParametersId");

                    b.ToTable("TestParameters");
                });

            modelBuilder.Entity("Data.Models.Test", b =>
                {
                    b.HasOne("Data.Models.Endpoint", "Endpoint")
                        .WithMany("Tests")
                        .HasForeignKey("EndpointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Models.TestParameters", "TestParameters")
                        .WithMany("Tests")
                        .HasForeignKey("TestParametersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
