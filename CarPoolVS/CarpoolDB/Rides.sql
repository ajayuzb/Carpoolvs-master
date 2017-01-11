CREATE TABLE [dbo].[Rides]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Empid] INT NULL, 
    [Source] VARCHAR(200) NULL, 
    [Destination] VARCHAR(200) NULL, 
    [Ride_Date] DATE NULL, 
    [Ride_Time] DATETIME NULL
)
