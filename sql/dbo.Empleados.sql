CREATE TABLE [dbo].[Empleados]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdDepartamento] INT NOT NULL, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [FechaDeNacimiento] DATE NULL, 
    [Sueldo] MONEY NOT NULL, 
    [DNI] NCHAR(9) NOT NULL, 
    CONSTRAINT [FK_Empleados_Departamentos] FOREIGN KEY ([IdDepartamento]) REFERENCES [Departamentos]([Id])
)
