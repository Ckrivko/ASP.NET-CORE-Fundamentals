using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTaksAndBoardsAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
