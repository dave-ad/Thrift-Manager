using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ThriftManager.Infrastructure.Migrations.ThriftMig
{
    /// <inheritdoc />
    public partial class migrate : Migration
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
                name: "group_groupid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "member_memberid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "sessionmember_sessionmemberid_seq",
                schema: "ThriftSchema",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SessionWallet_SessionWalletid_seq",
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
                name: "Country",
                schema: "ThriftSchema",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "ThriftSchema",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    ContributionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Slots = table.Column<int>(type: "integer", nullable: false),
                    Tenure = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    Name_Last = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name_First = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name_Others = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email_Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email_Hash = table.Column<int>(type: "integer", nullable: false),
                    MobileNumber_Value = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    MobileNumber_Hash = table.Column<int>(type: "integer", nullable: false),
                    NIN_Value = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    NIN_Hash = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "ThriftSchema",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "ThriftSchema",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributionSession",
                schema: "ThriftSchema",
                columns: table => new
                {
                    ContributionSessionId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    Slots = table.Column<int>(type: "integer", nullable: false),
                    ContributionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    Tenure = table.Column<int>(type: "integer", nullable: false),
                    DueDay = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdminId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributionSession", x => x.ContributionSessionId);
                    table.ForeignKey(
                        name: "FK_ContributionSession_Group_GroupId",
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
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    WalletNumber = table.Column<string>(type: "text", nullable: false),
                    Account_AccountNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Account_AccountName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Account_BVN = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Account_BankId = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWallet", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_MemberWallet_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "ThriftSchema",
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalGovtArea",
                schema: "ThriftSchema",
                columns: table => new
                {
                    LocalGovtAreaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalGovtArea", x => x.LocalGovtAreaId);
                    table.ForeignKey(
                        name: "FK_LocalGovtArea_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "ThriftSchema",
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionMember",
                schema: "ThriftSchema",
                columns: table => new
                {
                    SessionMemberId = table.Column<int>(type: "integer", nullable: false),
                    ContributionSessionId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    SlotPosition = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionMember", x => x.SessionMemberId);
                    table.ForeignKey(
                        name: "FK_SessionMember_ContributionSession_ContributionSessionId",
                        column: x => x.ContributionSessionId,
                        principalSchema: "ThriftSchema",
                        principalTable: "ContributionSession",
                        principalColumn: "ContributionSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionWallet",
                schema: "ThriftSchema",
                columns: table => new
                {
                    SessionWalletId = table.Column<long>(type: "bigint", nullable: false),
                    ContributionSessionId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    WalletNumber = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: false),
                    BankId = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionWallet", x => x.SessionWalletId);
                    table.ForeignKey(
                        name: "FK_SessionWallet_ContributionSession_ContributionSessionId",
                        column: x => x.ContributionSessionId,
                        principalSchema: "ThriftSchema",
                        principalTable: "ContributionSession",
                        principalColumn: "ContributionSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberWalletTransaction",
                schema: "ThriftSchema",
                columns: table => new
                {
                    MemberWalletTransactionId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    MemberWalletMemberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWalletTransaction", x => x.MemberWalletTransactionId);
                    table.ForeignKey(
                        name: "FK_MemberWalletTransaction_MemberWallet_MemberWalletMemberId",
                        column: x => x.MemberWalletMemberId,
                        principalSchema: "ThriftSchema",
                        principalTable: "MemberWallet",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberAddress",
                schema: "ThriftSchema",
                columns: table => new
                {
                    MemberAddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    StreetNumber = table.Column<string>(type: "text", nullable: false),
                    StreetName = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    LocalGovtAreaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAddress", x => x.MemberAddressId);
                    table.ForeignKey(
                        name: "FK_MemberAddress_LocalGovtArea_LocalGovtAreaId",
                        column: x => x.LocalGovtAreaId,
                        principalSchema: "ThriftSchema",
                        principalTable: "LocalGovtArea",
                        principalColumn: "LocalGovtAreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberAddress_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "ThriftSchema",
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionWalletTransaction",
                schema: "ThriftSchema",
                columns: table => new
                {
                    SessionWalletTransactionId = table.Column<long>(type: "bigint", nullable: false),
                    ContributionSessionId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    SessionWalletId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionWalletTransaction", x => x.SessionWalletTransactionId);
                    table.ForeignKey(
                        name: "FK_SessionWalletTransaction_SessionWallet_SessionWalletId",
                        column: x => x.SessionWalletId,
                        principalSchema: "ThriftSchema",
                        principalTable: "SessionWallet",
                        principalColumn: "SessionWalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContributionSession_GroupId",
                schema: "ThriftSchema",
                table: "ContributionSession",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGovtArea_StateId",
                schema: "ThriftSchema",
                table: "LocalGovtArea",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_LocalGovtAreaId",
                schema: "ThriftSchema",
                table: "MemberAddress",
                column: "LocalGovtAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_MemberId",
                schema: "ThriftSchema",
                table: "MemberAddress",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberWalletTransaction_MemberWalletMemberId",
                schema: "ThriftSchema",
                table: "MemberWalletTransaction",
                column: "MemberWalletMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionMember_ContributionSessionId",
                schema: "ThriftSchema",
                table: "SessionMember",
                column: "ContributionSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionWallet_ContributionSessionId",
                schema: "ThriftSchema",
                table: "SessionWallet",
                column: "ContributionSessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionWalletTransaction_SessionWalletId",
                schema: "ThriftSchema",
                table: "SessionWalletTransaction",
                column: "SessionWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                schema: "ThriftSchema",
                table: "State",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberAddress",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "MemberWalletTransaction",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "SessionMember",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "SessionWalletTransaction",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "LocalGovtArea",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "MemberWallet",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "SessionWallet",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "State",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "Member",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "ContributionSession",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "ThriftSchema");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "contributionsession_contributionsessionid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "group_groupid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "member_memberid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "sessionmember_sessionmemberid_seq",
                schema: "ThriftSchema");

            migrationBuilder.DropSequence(
                name: "SessionWallet_SessionWalletid_seq",
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
