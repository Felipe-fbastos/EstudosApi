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

CREATE TABLE [TB_ALUNOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] nvarchar(max) NOT NULL,
    [DtaNascimento] datetime2 NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [Email] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    CONSTRAINT [PK_TB_ALUNOS] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_PROFESSORES] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] nvarchar(max) NOT NULL,
    [DtaNascimento] datetime2 NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [Email] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    CONSTRAINT [PK_TB_PROFESSORES] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_MATERIAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [HorasDoCurso] int NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [DataCriacao] datetime2 NULL,
    [StatusMateria] int NOT NULL,
    [IdProfessor] int NOT NULL,
    CONSTRAINT [PK_TB_MATERIAS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_MATERIAS_TB_PROFESSORES_IdProfessor] FOREIGN KEY ([IdProfessor]) REFERENCES [TB_PROFESSORES] ([Id])
);
GO

CREATE TABLE [TB_MATRICULAS] (
    [AlunoId] int NOT NULL,
    [MateriaId] int NOT NULL,
    [DataMatricula] datetime2 NULL,
    CONSTRAINT [PK_TB_MATRICULAS] PRIMARY KEY ([AlunoId], [MateriaId]),
    CONSTRAINT [FK_TB_MATRICULAS_TB_ALUNOS_AlunoId] FOREIGN KEY ([AlunoId]) REFERENCES [TB_ALUNOS] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_MATRICULAS_TB_MATERIAS_MateriaId] FOREIGN KEY ([MateriaId]) REFERENCES [TB_MATERIAS] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DtaNascimento', N'Email', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[TB_ALUNOS]'))
    SET IDENTITY_INSERT [TB_ALUNOS] ON;
INSERT INTO [TB_ALUNOS] ([Id], [Cpf], [DtaNascimento], [Email], [Latitude], [Longitude], [Nome], [PasswordHash], [PasswordSalt])
VALUES (1, N'12345678911', NULL, NULL, NULL, NULL, N'Felipe', NULL, NULL),
(2, N'12345678917', NULL, NULL, NULL, NULL, N'Rebecca', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DtaNascimento', N'Email', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[TB_ALUNOS]'))
    SET IDENTITY_INSERT [TB_ALUNOS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DtaNascimento', N'Email', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[TB_PROFESSORES]'))
    SET IDENTITY_INSERT [TB_PROFESSORES] ON;
INSERT INTO [TB_PROFESSORES] ([Id], [Cpf], [DtaNascimento], [Email], [Latitude], [Longitude], [Nome], [PasswordHash], [PasswordSalt])
VALUES (1, N'12345678910', NULL, NULL, NULL, NULL, N'Luiz', NULL, NULL),
(2, N'22345678910', NULL, NULL, NULL, NULL, N'Marion', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DtaNascimento', N'Email', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[TB_PROFESSORES]'))
    SET IDENTITY_INSERT [TB_PROFESSORES] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataCriacao', N'Descricao', N'HorasDoCurso', N'IdProfessor', N'Nome', N'StatusMateria') AND [object_id] = OBJECT_ID(N'[TB_MATERIAS]'))
    SET IDENTITY_INSERT [TB_MATERIAS] ON;
INSERT INTO [TB_MATERIAS] ([Id], [DataCriacao], [Descricao], [HorasDoCurso], [IdProfessor], [Nome], [StatusMateria])
VALUES (1, NULL, N'Curso para lógica de C#', 36, 1, N'C# e Suas Descobertas', 0),
(2, NULL, N'Curso para lógica de Java', 88, 2, N'Java e Suas Grandezas', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataCriacao', N'Descricao', N'HorasDoCurso', N'IdProfessor', N'Nome', N'StatusMateria') AND [object_id] = OBJECT_ID(N'[TB_MATERIAS]'))
    SET IDENTITY_INSERT [TB_MATERIAS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AlunoId', N'MateriaId', N'DataMatricula') AND [object_id] = OBJECT_ID(N'[TB_MATRICULAS]'))
    SET IDENTITY_INSERT [TB_MATRICULAS] ON;
INSERT INTO [TB_MATRICULAS] ([AlunoId], [MateriaId], [DataMatricula])
VALUES (1, 1, NULL),
(1, 2, NULL),
(2, 1, NULL),
(2, 2, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AlunoId', N'MateriaId', N'DataMatricula') AND [object_id] = OBJECT_ID(N'[TB_MATRICULAS]'))
    SET IDENTITY_INSERT [TB_MATRICULAS] OFF;
GO

CREATE INDEX [IX_TB_MATERIAS_IdProfessor] ON [TB_MATERIAS] ([IdProfessor]);
GO

CREATE INDEX [IX_TB_MATRICULAS_MateriaId] ON [TB_MATRICULAS] ([MateriaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112184620_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241112184636_TudoFeito', N'8.0.10');
GO

COMMIT;
GO

