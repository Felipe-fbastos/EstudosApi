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

CREATE TABLE [TB_ALUNO] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] nvarchar(max) NOT NULL,
    [DtaNascimento] datetime2 NOT NULL,
    [Latitude] float NOT NULL,
    [Longitude] float NOT NULL,
    [Email] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    CONSTRAINT [PK_TB_ALUNO] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DtaNascimento', N'Email', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[TB_ALUNO]'))
    SET IDENTITY_INSERT [TB_ALUNO] ON;
INSERT INTO [TB_ALUNO] ([Id], [Cpf], [DtaNascimento], [Email], [Latitude], [Longitude], [Nome], [PasswordHash], [PasswordSalt])
VALUES (1, N'12345678911', '0001-01-01T00:00:00.0000000', NULL, 0.0E0, 0.0E0, N'Felipe', NULL, NULL),
(2, N'12345678917', '0001-01-01T00:00:00.0000000', NULL, 0.0E0, 0.0E0, N'Rebecca', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DtaNascimento', N'Email', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[TB_ALUNO]'))
    SET IDENTITY_INSERT [TB_ALUNO] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241101183639_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241101183821_TB_ALUNOS', N'8.0.10');
GO

COMMIT;
GO

