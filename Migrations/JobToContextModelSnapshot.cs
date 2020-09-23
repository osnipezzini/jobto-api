﻿// <auto-generated />
using System;
using JobTo.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JobTo.API.Migrations
{
    [DbContext(typeof(JobToContext))]
    partial class JobToContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.grid_seq", "'grid_seq', '', '1', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.person_cod_seq", "'person_cod_seq', '', '1', '1', '', '', 'Int32', 'False'");

            modelBuilder.Entity("JobTo.Common.Models.Person", b =>
                {
                    b.Property<long>("Grid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("grid")
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('grid_seq')");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("active")
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<int?>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("code")
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('person_cod_seq')");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnName("deleted_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Doc")
                        .HasColumnName("doc")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("type")
                        .HasColumnType("text")
                        .HasDefaultValue("C");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("updated_at")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Grid")
                        .HasName("pk_people");

                    b.ToTable("people");
                });

            modelBuilder.Entity("JobTo.Common.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<long?>("EmployeeGrid")
                        .HasColumnName("employee_grid")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("role")
                        .HasColumnType("text")
                        .HasDefaultValue("User");

                    b.Property<string>("Token")
                        .HasColumnName("token")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("EmployeeGrid")
                        .HasName("ix_users_employee_grid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("JobTo.Common.Models.User", b =>
                {
                    b.HasOne("JobTo.Common.Models.Person", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeGrid")
                        .HasConstraintName("fk_users_people_employee_grid");
                });
#pragma warning restore 612, 618
        }
    }
}