using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VideoApp.Migrations
{
    public partial class InitCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorVideo",
                columns: table => new
                {
                    ActorsActorId = table.Column<int>(type: "int", nullable: false),
                    VideosVideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorVideo", x => new { x.ActorsActorId, x.VideosVideoId });
                    table.ForeignKey(
                        name: "FK_ActorVideo_Actors_ActorsActorId",
                        column: x => x.ActorsActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorVideo_Videos_VideosVideoId",
                        column: x => x.VideosVideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "DayOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1955, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruce", "Willis" },
                    { 2, new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johny", "Depp" },
                    { 3, new DateTime(1957, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bernie", "Mac" },
                    { 4, new DateTime(1979, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", "Hart" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Sci-Fi" },
                    { 4, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "GenreId", "Name" },
                values: new object[,]
                {
                    { 2, 1, "Oceans 11" },
                    { 1, 2, "Ride Along" },
                    { 4, 3, "Transcendence" },
                    { 3, 4, "The Sixth Sense" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorVideo_VideosVideoId",
                table: "ActorVideo",
                column: "VideosVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_GenreId",
                table: "Videos",
                column: "GenreId");

            migrationBuilder.InsertData(
                table: "ActorVideo",
                columns: new[] { "ActorsActorId", "VideosVideoId" },
                values: new object[,]
                {
                    {1,1 },
                    {2,2 },
                    {3,3 },
                    {4,4 }
                });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorVideo");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
