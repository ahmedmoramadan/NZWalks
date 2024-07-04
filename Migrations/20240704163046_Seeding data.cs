using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("64933176-8469-48f2-a7c6-1eef0aba09c4"), "Easy" },
                    { new Guid("74fc6221-ec69-48a2-b0d9-7c1c71b8451a"), "Hard" },
                    { new Guid("d7cf3178-e752-495c-b3e4-0fbfa11462fc"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2aa48e14-449e-4c3d-93d7-573bc83565e9"), "AKL", "Auckland", "https://www.aucklandnz.com/sites/build_auckland/files/styles/scale_and_crop_1440x900_/public/media-library/images/Explore%20more/Te%20Puia%20Rotorua%20Hot%20Pools%20%26%20Geysers.jpg" },
                    { new Guid("a3d3c8f6-c2a1-4a1b-bb1e-8f4e43efc9d2"), "DUD", "Dunedin", "https://upload.wikimedia.org/wikipedia/commons/f/f2/Dunedin_New_Zealand_01.jpg" },
                    { new Guid("b5d76e1e-8d45-4d2a-8d95-cf530f3a40c3"), "WLG", "Wellington", null },
                    { new Guid("d9d3d8e4-b91d-4c6e-9c2d-3f0a41cb8c85"), "CHC", "Christchurch", "https://upload.wikimedia.org/wikipedia/commons/6/67/Christchurch_%28NZ%29_-_flickr_-_spsmith.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("64933176-8469-48f2-a7c6-1eef0aba09c4"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("74fc6221-ec69-48a2-b0d9-7c1c71b8451a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d7cf3178-e752-495c-b3e4-0fbfa11462fc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2aa48e14-449e-4c3d-93d7-573bc83565e9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a3d3c8f6-c2a1-4a1b-bb1e-8f4e43efc9d2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b5d76e1e-8d45-4d2a-8d95-cf530f3a40c3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d9d3d8e4-b91d-4c6e-9c2d-3f0a41cb8c85"));
        }
    }
}
