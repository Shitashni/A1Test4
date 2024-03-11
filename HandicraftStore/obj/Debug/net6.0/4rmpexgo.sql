IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
                VALUES ('3f11d06f-1c8f-4e1f-a0e0-e005add0be71', 'Administrator', 'ADMINISTRATOR', null);
GO

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
                VALUES ('081584cc-6b5c-4da8-a4cc-315adec3074c', 'Manager', 'MANAGER', null);
GO

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
                VALUES ('702d41a5-7aeb-4492-bee3-7b17099f7059', 'User', 'USER', null);
GO

INSERT INTO [dbo].[AspNetUsers] ([Id],[UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed]
                ,[PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]
                ,[LockoutEnd], [LockoutEnabled], [AccessFailedCount])
                                VALUES (N'287fe59a-9a26-4f08-bfc9-c8b19765348d', N'Test@test.com', N'Test@test.com', N'Test@test.com', N'Test@test.com',0,
                N'AQAAAAEAACcQAAAAEI6+3ncQeMxy2vlXGuGYVm2y0PROoY9n2Vcl1JBxFZK/A4o1dVeG6sZp+cfC/MC8DA==',
                N'WQ5V75FXNM4HNDRP5G4SEB7CLEQKR54O', N'ff32eeae-19d7-4886-bad9-805c020e4925', null, 0,0,NULL,1,0)
GO

INSERT INTO [dbo].[AspNetUsers] ([Id],[UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed]
                ,[PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]
                ,[LockoutEnd], [LockoutEnabled], [AccessFailedCount])
                                VALUES (N'0f48989e-9e8e-4783-b690-0fc7ebd4d0c9', N'Test2@test.com', N'Test2@test.com', N'Test2@test.com', N'Test2@test.com',0,
                N'AQAAAAEAACcQAAAAEI6+3ncQeMxy2vlXGuGYVm2y0PROoY9n2Vcl1JBxFZK/A4o1dVeG6sZp+cfC/MC8DA==',
                N'WQ5V75FXNM4HNDRP5G4SEB7CLEQKR54O', N'ff32eeae-19d7-4886-bad9-805c020e4925', null, 0,0,NULL,1,0)
GO

 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
            VALUES ('287fe59a-9a26-4f08-bfc9-c8b19765348d', '081584cc-6b5c-4da8-a4cc-315adec3074c');
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
                VALUES ('287fe59a-9a26-4f08-bfc9-c8b19765348d', '702d41a5-7aeb-4492-bee3-7b17099f7059');
GO

 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
            VALUES ('0f48989e-9e8e-4783-b690-0fc7ebd4d0c9', '3f11d06f-1c8f-4e1f-a0e0-e005add0be71');
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
                VALUES ('0f48989e-9e8e-4783-b690-0fc7ebd4d0c9', '081584cc-6b5c-4da8-a4cc-315adec3074c');
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231003224537_InitialMigration', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Handicrafts] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [Amount] SmallMoney NOT NULL,
    [HandicraftImage] nvarchar(max) NULL,
    CONSTRAINT [PK_Handicrafts] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231004011231_AddCurrencies', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [Handicrafts];
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [Amount] SmallMoney NOT NULL,
    [ImageUrl] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231004115518_StoreImage', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [AspNetUsers] ADD [firstName] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [AspNetUsers] ADD [lastName] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [AspNetUsers] ADD [userId] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231006104227_modifyuser', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[AspNetUsers].[userId]', N'UserId', N'COLUMN';
GO

EXEC sp_rename N'[AspNetUsers].[lastName]', N'LastName', N'COLUMN';
GO

EXEC sp_rename N'[AspNetUsers].[firstName]', N'FirstName', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231006113135_modifyuserkey9', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231006122920_modifyuserkey10', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [Customers];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'UserId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [AspNetUsers] DROP COLUMN [UserId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231007082658_TxnTable', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231007094052_TxnTablemigrate', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TransactionDetails] (
    [Id] int NOT NULL IDENTITY,
    [Email] int NOT NULL,
    [ProductId] int NOT NULL,
    [intQuantity] int NOT NULL,
    [decAmount] decimal(18,2) NOT NULL,
    [intOrderNumber] int NOT NULL,
    [dtmCreatedDate] datetime2 NOT NULL,
    [dtmLastUpdatedDate] datetime2 NOT NULL,
    [strOrderStatus] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TransactionDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TransactionDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_TransactionDetails_ProductId] ON [TransactionDetails] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231007094145_TxnTablemigration', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [TransactionDetails];
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [Email] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [OrderStatus] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Orders_ProductId] ON [Orders] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231014094133_UpdateOrderTable', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'Email');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Orders] ALTER COLUMN [Email] nvarchar(max) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231014094915_UpdateOrderTable1', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231014101859_UpdateOrderTable2', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ExchangeRate] (
    [Id] int NOT NULL IDENTITY,
    [Country] nvarchar(max) NOT NULL,
    [Rate] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ExchangeRate] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231103084145_currencyadd', N'6.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ExchangeRate] DROP CONSTRAINT [PK_ExchangeRate];
GO

EXEC sp_rename N'[ExchangeRate]', N'ExchangeRates';
GO

ALTER TABLE [ExchangeRates] ADD CONSTRAINT [PK_ExchangeRates] PRIMARY KEY ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231103093432_currencytable', N'6.0.23');
GO

COMMIT;
GO

