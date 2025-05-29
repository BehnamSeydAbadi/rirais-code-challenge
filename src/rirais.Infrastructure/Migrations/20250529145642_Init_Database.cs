using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rirais.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName_FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FullName_LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    NationalCode_Value = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth_Value = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalCode_Value",
                table: "Users",
                column: "NationalCode_Value",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
