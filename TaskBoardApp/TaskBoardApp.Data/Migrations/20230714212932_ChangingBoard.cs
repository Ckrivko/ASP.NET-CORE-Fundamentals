using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class ChangingBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("61ad1e5f-36f3-4852-af4e-7d53bbb7b35f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("7106e71d-7135-43f7-830f-f01f0e045882"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("71e68cc5-aa3a-4a66-b39c-88f8cd2f946c"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f6813a8f-0879-405a-b8e5-420e363fd966"));

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Tasks",
                newName: "CreatedOn");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("12ee761d-f5f0-409f-94fc-83f48bcd8501"), 1, new DateTime(2023, 7, 10, 0, 29, 31, 654, DateTimeKind.Local).AddTicks(5431), "Create Android client- app for RESTFUL  TaskBoard", "287004ef-d23f-4331-85ca-1f91d7abf8cf", "Android client App" },
                    { new Guid("8144d08f-c668-48b6-a370-a02f537ba50f"), 2, new DateTime(2023, 7, 14, 0, 29, 31, 654, DateTimeKind.Local).AddTicks(5438), "Create really cool dectop application", "167c8d87-45bf-4c19-ba39-88d1b052f693", "Desctop client App" },
                    { new Guid("97f4896e-5ba8-4461-bb1b-6cdb76fa8c3e"), 1, new DateTime(2022, 12, 27, 0, 29, 31, 654, DateTimeKind.Local).AddTicks(5362), "Implement better styling for better pagfes", "167c8d87-45bf-4c19-ba39-88d1b052f693", "Improve CSS Style" },
                    { new Guid("e544af95-b92a-4d60-8129-8c714a28696a"), 3, new DateTime(2023, 7, 14, 0, 29, 31, 654, DateTimeKind.Local).AddTicks(5444), "Implement create- task functionality for any kind of app", "167c8d87-45bf-4c19-ba39-88d1b052f693", "Create tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("12ee761d-f5f0-409f-94fc-83f48bcd8501"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("8144d08f-c668-48b6-a370-a02f537ba50f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("97f4896e-5ba8-4461-bb1b-6cdb76fa8c3e"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e544af95-b92a-4d60-8129-8c714a28696a"));

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Tasks",
                newName: "CreateOn");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreateOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("61ad1e5f-36f3-4852-af4e-7d53bbb7b35f"), 1, new DateTime(2022, 12, 24, 23, 36, 57, 709, DateTimeKind.Local).AddTicks(3790), "Implement better styling for better pagfes", "167c8d87-45bf-4c19-ba39-88d1b052f693", "Improve CSS Style" },
                    { new Guid("7106e71d-7135-43f7-830f-f01f0e045882"), 3, new DateTime(2023, 7, 11, 23, 36, 57, 709, DateTimeKind.Local).AddTicks(3856), "Implement create- task functionality for any kind of app", "167c8d87-45bf-4c19-ba39-88d1b052f693", "Create tasks" },
                    { new Guid("71e68cc5-aa3a-4a66-b39c-88f8cd2f946c"), 1, new DateTime(2023, 7, 7, 23, 36, 57, 709, DateTimeKind.Local).AddTicks(3834), "Create Android client- app for RESTFUL  TaskBoard", "287004ef-d23f-4331-85ca-1f91d7abf8cf", "Android client App" },
                    { new Guid("f6813a8f-0879-405a-b8e5-420e363fd966"), 2, new DateTime(2023, 7, 11, 23, 36, 57, 709, DateTimeKind.Local).AddTicks(3851), "Create really cool dectop application", "167c8d87-45bf-4c19-ba39-88d1b052f693", "Desctop client App" }
                });
        }
    }
}
