IF NOT EXISTS (SELECT 1 FROM [dbo].[Role])
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[Role] (Id, [Name], Code, CreatedOn, [State])
        VALUES
            (NEWID(), 'Administrador', 'ADMIN', GETDATE(), 1),
            (NEWID(), 'Cliente', 'CLIENT', GETDATE(), 1),
            (NEWID(), 'Usuario', 'USER', GETDATE(), 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[User])
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[User] (Id, UserName, [Password], RoleId, CreatedOn, [State])
        VALUES
            (NEWID(), 'Uafj6cA0vMLBEGdP23UyVfRefWfRD8HSik8Vc2eguYdeZ6xmKtg6Bbkvbz/PtXe96SS9fYA5/WZ6ba9Z9pB3Gw==', 
            'Dy4RAGWJLT6dbXXAIAx8i7ows/m+JUNFFJbyQ1TZdIE=', 
            (SELECT Id FROM [dbo].[Role] WHERE Code = 'ADMIN'),  GETDATE(),  1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
