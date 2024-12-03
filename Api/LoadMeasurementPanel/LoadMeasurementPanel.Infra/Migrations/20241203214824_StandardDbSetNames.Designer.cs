﻿// <auto-generated />
using System;
using LoadMeasurementPanel.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoadMeasurementPanel.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241203214824_StandardDbSetNames")]
    partial class StandardDbSetNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoadMeasurementPanel.Domain.Entities.EnergyConsumptionPerDay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("AverageConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HoursWithoutRegistration")
                        .HasColumnType("int");

                    b.Property<long>("MeasuringPointId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ConsumoDiarioPorPonto");
                });

            modelBuilder.Entity("LoadMeasurementPanel.Domain.Entities.MeasuringPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PontosMedicao");
                });
#pragma warning restore 612, 618
        }
    }
}
