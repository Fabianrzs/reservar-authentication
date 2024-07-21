﻿CREATE TABLE [dbo].[Session]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [StartTime] DATETIME NOT NULL DEFAULT GETDATE(),
    [EndTime] DATETIME NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [Active] BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Session_User FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id)
);