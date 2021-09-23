CREATE TABLE [dbo].[Trainings]
(
	[Id] UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() NOT NULL, 
    [Name] NVARCHAR(64) NOT NULL, 
    [Begin] DATE NOT NULL, 
    [End] DATE NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Trainings] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Trainings_Begin] CHECK([Begin] >= CONVERT(DATE, '01/01/2001')), 
    CONSTRAINT [CK_Trainings_End] CHECK([End] >= [Begin])
)
