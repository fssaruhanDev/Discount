using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discount.Data.Migrations
{
    /// <inheritdoc />
    public partial class BasketAndBasketProduct2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T210_Basket_T100_Users_UserID",
                table: "T210_Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_T211_BasketProduct_T200_Products_ProductID",
                table: "T211_BasketProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_T211_BasketProduct_T210_Basket_BasketID",
                table: "T211_BasketProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T211_BasketProduct",
                table: "T211_BasketProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T210_Basket",
                table: "T210_Basket");

            migrationBuilder.RenameTable(
                name: "T211_BasketProduct",
                newName: "T211_BasketProducts");

            migrationBuilder.RenameTable(
                name: "T210_Basket",
                newName: "T201_Baskets");

            migrationBuilder.RenameIndex(
                name: "IX_T211_BasketProduct_ProductID",
                table: "T211_BasketProducts",
                newName: "IX_T211_BasketProducts_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_T211_BasketProduct_BasketID",
                table: "T211_BasketProducts",
                newName: "IX_T211_BasketProducts_BasketID");

            migrationBuilder.RenameIndex(
                name: "IX_T210_Basket_UserID",
                table: "T201_Baskets",
                newName: "IX_T201_Baskets_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T211_BasketProducts",
                table: "T211_BasketProducts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T201_Baskets",
                table: "T201_Baskets",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_T201_Baskets_T100_Users_UserID",
                table: "T201_Baskets",
                column: "UserID",
                principalTable: "T100_Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T211_BasketProducts_T200_Products_ProductID",
                table: "T211_BasketProducts",
                column: "ProductID",
                principalTable: "T200_Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T211_BasketProducts_T201_Baskets_BasketID",
                table: "T211_BasketProducts",
                column: "BasketID",
                principalTable: "T201_Baskets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T201_Baskets_T100_Users_UserID",
                table: "T201_Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_T211_BasketProducts_T200_Products_ProductID",
                table: "T211_BasketProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_T211_BasketProducts_T201_Baskets_BasketID",
                table: "T211_BasketProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T211_BasketProducts",
                table: "T211_BasketProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T201_Baskets",
                table: "T201_Baskets");

            migrationBuilder.RenameTable(
                name: "T211_BasketProducts",
                newName: "T211_BasketProduct");

            migrationBuilder.RenameTable(
                name: "T201_Baskets",
                newName: "T210_Basket");

            migrationBuilder.RenameIndex(
                name: "IX_T211_BasketProducts_ProductID",
                table: "T211_BasketProduct",
                newName: "IX_T211_BasketProduct_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_T211_BasketProducts_BasketID",
                table: "T211_BasketProduct",
                newName: "IX_T211_BasketProduct_BasketID");

            migrationBuilder.RenameIndex(
                name: "IX_T201_Baskets_UserID",
                table: "T210_Basket",
                newName: "IX_T210_Basket_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T211_BasketProduct",
                table: "T211_BasketProduct",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T210_Basket",
                table: "T210_Basket",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_T210_Basket_T100_Users_UserID",
                table: "T210_Basket",
                column: "UserID",
                principalTable: "T100_Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T211_BasketProduct_T200_Products_ProductID",
                table: "T211_BasketProduct",
                column: "ProductID",
                principalTable: "T200_Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T211_BasketProduct_T210_Basket_BasketID",
                table: "T211_BasketProduct",
                column: "BasketID",
                principalTable: "T210_Basket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
