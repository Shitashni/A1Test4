﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandicraftStore.Data.Migrations
{
    public partial class TxnTablemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    intQuantity = table.Column<int>(type: "int", nullable: false),
                    decAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    intOrderNumber = table.Column<int>(type: "int", nullable: false),
                    dtmCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtmLastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    strOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_ProductId",
                table: "TransactionDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDetails");
        }
    }
}
