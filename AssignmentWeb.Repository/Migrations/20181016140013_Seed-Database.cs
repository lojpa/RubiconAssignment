using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentWeb.Repository.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "Body", "CreatedAt", "Description", "Slug", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Body test", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc), "Description test", "title-test", "Title test", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc) },
                    { 2, "Body test2", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc), "Description test2", "title-test2", "Title test2", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc) },
                    { 3, "Body test3", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc), "Description test3", "title-test3", "Title test3", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc) },
                    { 4, "Body test4", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc), "Description test4", "title-test4", "Title test4", new DateTime(2018, 10, 16, 14, 0, 12, 838, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                column: "TagId",
                values: new object[]
                {
                    "tag1",
                    "tag2",
                    "tag3",
                    "tag4"
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, "tag1" },
                    { 2, "tag2" },
                    { 3, "tag3" },
                    { 2, "tag3" },
                    { 4, "tag4" },
                    { 1, "tag4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, "tag1" });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 1, "tag4" });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 2, "tag2" });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 2, "tag3" });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 3, "tag3" });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 4, "tag4" });

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: "tag1");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: "tag2");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: "tag3");

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: "tag4");
        }
    }
}
