--CREATE TABLE SCRIPTS FOR Category, VideoFile, VideoFileCategory, VideoThumbnail

CREATE TABLE Category (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NULL
);

CREATE TABLE VideoFile (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DateUploaded DATETIME2 NOT NULL,
    Path NVARCHAR(1024) NOT NULL,
    Title NVARCHAR(255) NOT NULL,
    Size INT NOT NULL,
    ExtensionType NVARCHAR(50) NOT NULL,
    Description NVARCHAR(MAX) NULL
);

CREATE TABLE VideoFileCategory (
    VideoFileId INT NOT NULL,
    CategoryId INT NOT NULL,
    PRIMARY KEY (VideoFileId, CategoryId),
    FOREIGN KEY (VideoFileId) REFERENCES VideoFile(Id) ON DELETE CASCADE,
    FOREIGN KEY (CategoryId) REFERENCES Category(Id) ON DELETE CASCADE
);

CREATE TABLE [dbo].[VideoThumbnail] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Path] NVARCHAR(MAX) NOT NULL,
    [VideoFileId] INT NOT NULL,
    CONSTRAINT [FK_VideoThumbnail_VideoFile] FOREIGN KEY ([VideoFileId]) REFERENCES [dbo].[VideoFile]([Id])
);