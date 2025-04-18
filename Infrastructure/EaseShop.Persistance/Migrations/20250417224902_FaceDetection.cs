using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EaseShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FaceDetection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FaceEmbedding",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceEmbedding",
                table: "AspNetUsers");
        }
    }
}
