CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Caption] NVARCHAR(MAX) NOT NULL, 
    [TypeNumber] NVARCHAR(MAX) NOT NULL, 
    [Manufacturer] NVARCHAR(MAX) NOT NULL, 
    [Lens] NVARCHAR(MAX) NULL, 
    [Discriminator] NVARCHAR(128) NOT NULL, 
    [LensMount] NVARCHAR(MAX) NULL, 
    [FocalLength] NVARCHAR(MAX) NULL, 
    [MaxAperture] NVARCHAR(MAX) NULL
)
