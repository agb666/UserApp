
SET QUOTED_IDENTIFIER ON
GO

BEGIN TRY
	BEGIN TRANSACTION UserTable
		IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
					WHERE TABLE_NAME = N'User')
		BEGIN
			--DROP TABLE [dbo].[User];
		    --PRINT "Exsiting USER Table Dropped"
			exec Sp_rename 'dbo.User', 'UserOLD'
			PRINT'Exsiting USER Table Renamed'
		END

		CREATE TABLE [dbo].[User] (
			[Id]       INT IDENTITY (1, 1) NOT NULL,
			[Email]    NVARCHAR (320) NOT NULL,
			[Password] NVARCHAR (255) NOT NULL
		CONSTRAINT PK_User PRIMARY KEY CLUSTERED (Id)
		);
	COMMIT TRANSACTION UserTable
	PRINT 'USER Table Created'
END TRY
BEGIN CATCH
IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION UserTable
		PRINT 'Error Creating USER Table, Changes Rolled Back'
	END
END CATCH

