using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employee.Migrations
{
    /// <inheritdoc />
    public partial class AddedHRIdToemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HRId",
                table: "AppEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployee_HRId",
                table: "AppEmployee",
                column: "HRId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployee_AppHRS_HRId",
                table: "AppEmployee",
                column: "HRId",
                principalTable: "AppHRS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployee_AppHRS_HRId",
                table: "AppEmployee");

            migrationBuilder.DropIndex(
                name: "IX_AppEmployee_HRId",
                table: "AppEmployee");

            migrationBuilder.DropColumn(
                name: "HRId",
                table: "AppEmployee");
        }
    }
}
