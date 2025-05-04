using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RowCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SectionCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TierCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CellCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteShoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShoesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Article = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteShoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConcreteShoes_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Shoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    WareHouseId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Placements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcreteShoesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WareHouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Row = table.Column<int>(type: "INTEGER", nullable: false),
                    Section = table.Column<int>(type: "INTEGER", nullable: false),
                    Tier = table.Column<int>(type: "INTEGER", nullable: false),
                    Cell = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Placements_ConcreteShoes_ConcreteShoesId",
                        column: x => x.ConcreteShoesId,
                        principalTable: "ConcreteShoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placements_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FromWareHouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ToWareHouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    ConcreteShoesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transfers_ConcreteShoes_ConcreteShoesId",
                        column: x => x.ConcreteShoesId,
                        principalTable: "ConcreteShoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_WareHouses_FromWareHouseId",
                        column: x => x.FromWareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_WareHouses_ToWareHouseId",
                        column: x => x.ToWareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomingInvoices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WareHouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcreteShoesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingInvoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_IncomingInvoices_ConcreteShoes_ConcreteShoesId",
                        column: x => x.ConcreteShoesId,
                        principalTable: "ConcreteShoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomingInvoices_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomingInvoices_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutgoingInvoices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WareHouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcreteShoesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingInvoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_OutgoingInvoices_ConcreteShoes_ConcreteShoesId",
                        column: x => x.ConcreteShoesId,
                        principalTable: "ConcreteShoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutgoingInvoices_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutgoingInvoices_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WriteOffs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WareHouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcreteShoesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffs", x => x.id);
                    table.ForeignKey(
                        name: "FK_WriteOffs_ConcreteShoes_ConcreteShoesId",
                        column: x => x.ConcreteShoesId,
                        principalTable: "ConcreteShoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WriteOffs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WriteOffs_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteShoes_ShoesId",
                table: "ConcreteShoes",
                column: "ShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WareHouseId",
                table: "Employees",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingInvoices_ConcreteShoesId",
                table: "IncomingInvoices",
                column: "ConcreteShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingInvoices_EmployeeId",
                table: "IncomingInvoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingInvoices_WareHouseId",
                table: "IncomingInvoices",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingInvoices_ConcreteShoesId",
                table: "OutgoingInvoices",
                column: "ConcreteShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingInvoices_EmployeeId",
                table: "OutgoingInvoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingInvoices_WareHouseId",
                table: "OutgoingInvoices",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_ConcreteShoesId",
                table: "Placements",
                column: "ConcreteShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_WareHouseId",
                table: "Placements",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_ConcreteShoesId",
                table: "Transfers",
                column: "ConcreteShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_FromWareHouseId",
                table: "Transfers",
                column: "FromWareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_ToWareHouseId",
                table: "Transfers",
                column: "ToWareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffs_ConcreteShoesId",
                table: "WriteOffs",
                column: "ConcreteShoesId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffs_EmployeeId",
                table: "WriteOffs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffs_WareHouseId",
                table: "WriteOffs",
                column: "WareHouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomingInvoices");

            migrationBuilder.DropTable(
                name: "OutgoingInvoices");

            migrationBuilder.DropTable(
                name: "Placements");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "WriteOffs");

            migrationBuilder.DropTable(
                name: "ConcreteShoes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "WareHouses");
        }
    }
}
