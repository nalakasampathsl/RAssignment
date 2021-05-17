USE [AircraftSightingDB]
GO

/****** Object:  Table [dbo].[AircraftSighting]    Script Date: 5/16/2021 6:07:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AircraftSighting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](128) NOT NULL,
	[Model] [nvarchar](128) NOT NULL,
	[Registration] [nvarchar](8) NOT NULL,
	[Location] [nvarchar](255) NOT NULL,
	[DateAndTime] [datetime] NOT NULL,
	[ImgFilePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_AircraftSighting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

