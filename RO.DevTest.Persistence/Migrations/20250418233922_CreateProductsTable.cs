using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RO.DevTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProd = table.Column<Guid>(type: "uuid", nullable: false),
                    nameProd = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    descriptionProd = table.Column<string>(type: "character varying(600)", maxLength: 600, nullable: false),
                    priceProd = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    quantityStock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProd);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
