CREATE TABLE [dbo].[EmployeeTrainings]
(
	[EmployeeId] UNIQUEIDENTIFIER NOT NULL, 
    [TrainingId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_EmployeeTrainings] PRIMARY KEY ([EmployeeId], [TrainingId]), 
    CONSTRAINT [FK_EmployeeTrainings_ToEmployees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_EmployeeTrainings_ToTrainings] FOREIGN KEY ([TrainingId]) REFERENCES [Trainings]([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_dbo_EmployeeTrainings_EmployeeId] ON [dbo].[EmployeeTrainings]([EmployeeId]);
GO

CREATE INDEX [IX_dbo_EmployeeTrainings_TrainingId] ON [dbo].[EmployeeTrainings]([TrainingId]);
GO