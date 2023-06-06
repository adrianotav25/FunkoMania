using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunkoMania.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClient_Api : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "fm_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 6, 17, 19, 43, 725, DateTimeKind.Local).AddTicks(7823),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 5, 17, 46, 22, 948, DateTimeKind.Local).AddTicks(2032));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "fm_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 5, 17, 46, 22, 948, DateTimeKind.Local).AddTicks(2032),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 6, 17, 19, 43, 725, DateTimeKind.Local).AddTicks(7823));
        }
    }
}
