using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandicraftStore.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        //public partial class SeedRoles : Migration

        //{
            private string ManagerRoleId = Guid.NewGuid().ToString();
            private string UserRoleId = Guid.NewGuid().ToString();
            private string AdminRoleId = Guid.NewGuid().ToString();

            private string User1Id = Guid.NewGuid().ToString();
            private string User2Id = Guid.NewGuid().ToString();

            protected override void Up(MigrationBuilder migrationBuilder)
            {
                SeedRolesSQL(migrationBuilder);
                Seeduser(migrationBuilder);
                SeedUserRoles(migrationBuilder);
            }

            private void SeedUserRoles(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.Sql(@$" INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
            VALUES ('{User1Id}', '{ManagerRoleId}');
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
                VALUES ('{User1Id}', '{UserRoleId}');");

                migrationBuilder.Sql(@$" INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
            VALUES ('{User2Id}', '{AdminRoleId}');
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
                VALUES ('{User2Id}', '{ManagerRoleId}');");
            }

            private void Seeduser(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetUsers] ([Id],[UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed]
                ,[PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]
                ,[LockoutEnd], [LockoutEnabled], [AccessFailedCount])
                                VALUES (N'{User1Id}', N'Test@test.com', N'Test@test.com', N'Test@test.com', N'Test@test.com',0,
                N'AQAAAAEAACcQAAAAEI6+3ncQeMxy2vlXGuGYVm2y0PROoY9n2Vcl1JBxFZK/A4o1dVeG6sZp+cfC/MC8DA==',
                N'WQ5V75FXNM4HNDRP5G4SEB7CLEQKR54O', N'ff32eeae-19d7-4886-bad9-805c020e4925', null, 0,0,NULL,1,0)");

                migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetUsers] ([Id],[UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed]
                ,[PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]
                ,[LockoutEnd], [LockoutEnabled], [AccessFailedCount])
                                VALUES (N'{User2Id}', N'Test2@test.com', N'Test2@test.com', N'Test2@test.com', N'Test2@test.com',0,
                N'AQAAAAEAACcQAAAAEI6+3ncQeMxy2vlXGuGYVm2y0PROoY9n2Vcl1JBxFZK/A4o1dVeG6sZp+cfC/MC8DA==',
                N'WQ5V75FXNM4HNDRP5G4SEB7CLEQKR54O', N'ff32eeae-19d7-4886-bad9-805c020e4925', null, 0,0,NULL,1,0)");
            }

            private void SeedRolesSQL(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
                VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
                migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
                VALUES ('{ManagerRoleId}', 'Manager', 'MANAGER', null);");
                migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
                VALUES ('{UserRoleId}', 'User', 'USER', null);");
            }
          

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
