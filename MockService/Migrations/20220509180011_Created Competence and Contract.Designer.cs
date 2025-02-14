﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MockService.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MockService.Migrations
{
    [DbContext(typeof(MockServiceContext))]
    [Migration("20220509180011_Created Competence and Contract")]
    partial class CreatedCompetenceandContract
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MockService.Models.Competence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("MockService.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MockService.Models.EmployeeContract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("ScheduleCompetence")
                        .HasColumnType("text");

                    b.Property<DateTime?>("TrialPeriodEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeContracts");
                });

            modelBuilder.Entity("MockService.Models.EmployeeContractCompetence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompetenceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeContractId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("validFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly>("validTo")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CompetenceId");

                    b.HasIndex("EmployeeContractId");

                    b.ToTable("EmployeeContractCompetences");
                });

            modelBuilder.Entity("MockService.Models.EmployeeContract", b =>
                {
                    b.HasOne("MockService.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MockService.Models.EmployeeContractCompetence", b =>
                {
                    b.HasOne("MockService.Models.Competence", "Competence")
                        .WithMany()
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MockService.Models.EmployeeContract", "EmployeeContract")
                        .WithMany()
                        .HasForeignKey("EmployeeContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competence");

                    b.Navigation("EmployeeContract");
                });
#pragma warning restore 612, 618
        }
    }
}
