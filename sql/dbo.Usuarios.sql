CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nick] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [IdEmpleado] INT NULL, 
    CONSTRAINT [FK_Usuarios_Empleados] FOREIGN KEY ([IdEmpleado]) REFERENCES [Empleados]([Id])
)
