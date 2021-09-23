CREATE TABLE [dbo].[Vacations]
(
	[Id] UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() NOT NULL, 
    [Begin] DATE NOT NULL, 
    [End] DATE NOT NULL, 
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Vacations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vacations_ToEmployees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [CK_Vacations_Begin] CHECK ([Begin] >= CONVERT(DATE, '01/01/2001')), 
    CONSTRAINT [CK_Vacations_End] CHECK ([End] >= [Begin])
);
GO

CREATE INDEX [IX_dbo_Vacations_EmployeeId] ON [dbo].[Vacations]([EmployeeId]);
GO