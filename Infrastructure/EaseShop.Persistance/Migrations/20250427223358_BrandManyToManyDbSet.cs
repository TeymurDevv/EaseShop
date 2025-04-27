using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EaseShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class BrandManyToManyDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBrand_Brand_BrandId",
                table: "SubCategoryBrand");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBrand_SubCategories_SubCategoryId",
                table: "SubCategoryBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryBrand",
                table: "SubCategoryBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "SubCategoryBrand",
                newName: "SubCategoryBrands");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryBrand_BrandId",
                table: "SubCategoryBrands",
                newName: "IX_SubCategoryBrands_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryBrands",
                table: "SubCategoryBrands",
                columns: new[] { "SubCategoryId", "BrandId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBrands_Brands_BrandId",
                table: "SubCategoryBrands",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBrands_SubCategories_SubCategoryId",
                table: "SubCategoryBrands",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBrands_Brands_BrandId",
                table: "SubCategoryBrands");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryBrands_SubCategories_SubCategoryId",
                table: "SubCategoryBrands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryBrands",
                table: "SubCategoryBrands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "SubCategoryBrands",
                newName: "SubCategoryBrand");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryBrands_BrandId",
                table: "SubCategoryBrand",
                newName: "IX_SubCategoryBrand_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryBrand",
                table: "SubCategoryBrand",
                columns: new[] { "SubCategoryId", "BrandId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBrand_Brand_BrandId",
                table: "SubCategoryBrand",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryBrand_SubCategories_SubCategoryId",
                table: "SubCategoryBrand",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
