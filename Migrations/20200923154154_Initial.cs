using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JobTo.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "grid_seq");

            migrationBuilder.CreateSequence<int>(
                name: "person_cod_seq");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    grid = table.Column<long>(nullable: false, defaultValueSql: "nextval('grid_seq')"),
                    doc = table.Column<string>(nullable: true),
                    code = table.Column<int>(nullable: true, defaultValueSql: "nextval('person_cod_seq')"),
                    name = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: true, defaultValue: true),
                    type = table.Column<string>(nullable: true, defaultValue: "C"),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.grid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    employee_grid = table.Column<long>(nullable: true),
                    role = table.Column<string>(nullable: true, defaultValue: "User"),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_people_employee_grid",
                        column: x => x.employee_grid,
                        principalTable: "people",
                        principalColumn: "grid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_employee_grid",
                table: "users",
                column: "employee_grid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropSequence(
                name: "grid_seq");

            migrationBuilder.DropSequence(
                name: "person_cod_seq");
        }
    }
}
