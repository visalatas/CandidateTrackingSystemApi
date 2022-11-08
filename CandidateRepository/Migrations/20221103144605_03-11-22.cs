﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateRepository.Migrations
{
    public partial class _031122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Persons");
        }
    }
}
