using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriftManager.Infrastructure.Migrations.ThriftMig
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ThriftSchema");

            migrationBuilder.CreateSequence(
                name: "contributionsession_contributionsessionid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "contributionwallet_contributionwalletid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "group_groupid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "memberwallet_memberwalletid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "sessionmember_sessionmemberid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "sessionwallettransaction_sessionwallettransactionid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "wallettransaction_wallettransactionid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "ThriftSchema",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "ThriftSchema",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timeline_Slots = table.Column<int>(type: "int", nullable: false),
                    Timeline_Period = table.Column<int>(type: "int", nullable: false),
                    Timeline_DueDay = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                schema: "ThriftSchema",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Last = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name_First = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name_Others = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email_Hash = table.Column<int>(type: "int", nullable: false),
                    MobileNumber_Value = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MobileNumber_Hash = table.Column<int>(type: "int", nullable: false),
                    NIN_Value = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NIN_Hash = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BankAccount_AccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankAccount_AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccount_BVN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BankAccount_BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Contribution",
                schema: "ThriftSchema",
                columns: table => new
                {
                    ContributionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    ContributionWalletId = table.Column<int>(type: "int", nullable: false),
                    Timeline_Slots = table.Column<int>(type: "int", nullable: false),
                    Timeline_Period = table.Column<int>(type: "int", nullable: false),
                    Timeline_DueDay = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribution", x => x.ContributionId);
                    table.ForeignKey(
                        name: "FK_Contribution_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "ThriftSchema",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberWallet",
                schema: "ThriftSchema",
                columns: table => new
                {
                    MemberWalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    WalletNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_AccountNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Account_AccountName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Account_BVN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Account_BankName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWallet", x => x.MemberWalletId);
                    table.ForeignKey(
                        name: "FK_MemberWallet_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "ThriftSchema",
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributingMember",
                schema: "ThriftSchema",
                columns: table => new
                {
                    ContributingMemberId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContributionId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    SlotPosition = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributingMember", x => x.ContributingMemberId);
                    table.ForeignKey(
                        name: "FK_ContributingMember_Contribution_ContributionId",
                        column: x => x.ContributionId,
                        principalSchema: "ThriftSchema",
                        principalTable: "Contribution",
                        principalColumn: "ContributionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributionWallet",
                schema: "ThriftSchema",
                columns: table => new
                {
                    ContributionWalletId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContributionId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_AccountNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Account_AccountName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Account_BVN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Account_BankName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributionWallet", x => x.ContributionWalletId);
                    table.ForeignKey(
                        name: "FK_ContributionWallet_Contribution_ContributionId",
                        column: x => x.ContributionId,
                        principalSchema: "ThriftSchema",
                        principalTable: "Contribution",
                        principalColumn: "ContributionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberWalletTransaction",
                schema: "ThriftSchema",
                columns: table => new
                {
                    MemberWalletTransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberWalletId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWalletTransaction", x => x.MemberWalletTransactionId);
                    table.ForeignKey(
                        name: "FK_MemberWalletTransaction_MemberWallet_MemberWalletId",
                        column: x => x.MemberWalletId,
                        principalSchema: "ThriftSchema",
                        principalTable: "MemberWallet",
                        principalColumn: "MemberWalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributionWalletTransaction",
                schema: "ThriftSchema",
                columns: table => new
                {
                    ContributionWalletTransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContributionId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    ContributionWalletId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributionWalletTransaction", x => x.ContributionWalletTransactionId);
                    table.ForeignKey(
                        name: "FK_ContributionWalletTransaction_ContributionWallet_ContributionWalletId",
                        column: x => x.ContributionWalletId,
                        principalSchema: "ThriftSchema",
                        principalTable: "ContributionWallet",
                        principalColumn: "ContributionWalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContributingMember_ContributionId",
                schema: "ThriftSchema",
                table: "ContributingMember",
                column: "ContributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_GroupId",
                schema: "ThriftSchema",
                table: "Contribution",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributionWallet_ContributionId",
                schema: "ThriftSchema",
                table: "ContributionWallet",
                column: "ContributionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContributionWalletTransaction_ContributionWalletId",
                schema: "ThriftSchema",
                table: "ContributionWalletTransaction",
                column: "ContributionWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberWallet_MemberId",
                schema: "ThriftSchema",
                table: "MemberWallet",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberWalletTransaction_MemberWalletId",
                schema: "ThriftSchema",
                table: "MemberWalletTransaction",
                column: "MemberWalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "ContributingMember",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "ContributionWalletTransaction",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "MemberWalletTransaction",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "ContributionWallet",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "MemberWallet",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "Contribution",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "Member",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "contributionsession_contributionsessionid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "contributionwallet_contributionwalletid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "group_groupid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "memberwallet_memberwalletid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "sessionmember_sessionmemberid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "sessionwallettransaction_sessionwallettransactionid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "wallettransaction_wallettransactionid_seq",
                schema: "ThriftSchema");
        }
    }
}
