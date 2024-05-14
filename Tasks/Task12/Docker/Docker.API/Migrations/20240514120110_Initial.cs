using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Docker.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DockerEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockerEntities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DockerEntities",
                columns: new[] { "Id", "Message" },
                values: new object[] { new Guid("42d3536b-97e9-43de-97aa-8e22defc0b94"), "I ❤️ Docker, Docker secret is https://ibb.co/hZQghy0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DockerEntities");
        }
    }
}
