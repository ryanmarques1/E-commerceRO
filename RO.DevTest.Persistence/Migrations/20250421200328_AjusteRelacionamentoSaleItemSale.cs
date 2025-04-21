using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RO.DevTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoSaleItemSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSale_Products_ProductId",
                table: "ItemSale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_UserId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemSale",
                table: "ItemSale");

            migrationBuilder.DropIndex(
                name: "IX_ItemSale_ProductId",
                table: "ItemSale");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "IdItemSale",
                table: "ItemSale");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ItemSale",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemSale",
                table: "ItemSale",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemSale",
                table: "ItemSale");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemSale");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Sales",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdItemSale",
                table: "ItemSale",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemSale",
                table: "ItemSale",
                column: "IdItemSale");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSale_ProductId",
                table: "ItemSale",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSale_Products_ProductId",
                table: "ItemSale",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "IdProd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
