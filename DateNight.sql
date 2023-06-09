USE [master]
GO
/****** Object:  Database [DateNight]    Script Date: 4/21/2023 10:05:21 AM ******/
CREATE DATABASE [DateNight]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DateNight', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DateNight.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DateNight_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DateNight_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DateNight] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DateNight].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DateNight] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DateNight] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DateNight] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DateNight] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DateNight] SET ARITHABORT OFF 
GO
ALTER DATABASE [DateNight] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DateNight] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DateNight] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DateNight] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DateNight] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DateNight] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DateNight] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DateNight] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DateNight] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DateNight] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DateNight] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DateNight] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DateNight] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DateNight] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DateNight] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DateNight] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DateNight] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DateNight] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DateNight] SET  MULTI_USER 
GO
ALTER DATABASE [DateNight] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DateNight] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DateNight] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DateNight] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DateNight] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DateNight] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DateNight] SET QUERY_STORE = OFF
GO
USE [DateNight]
GO
/****** Object:  Table [dbo].[dates]    Script Date: 4/21/2023 10:05:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dates](
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Location] [nvarchar](50) NULL,
	[Link] [nvarchar](max) NULL,
	[Completed] [bit] NOT NULL,
	[Added_By] [nvarchar](50) NULL,
	[Date_Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[dates] ON 

INSERT [dbo].[dates] ([Name], [Description], [Location], [Link], [Completed], [Added_By], [Date_Id]) VALUES (N'Phipps', N'Going to Phipps', N'Oakland', NULL, 1, N'Mike', 1)
INSERT [dbo].[dates] ([Name], [Description], [Location], [Link], [Completed], [Added_By], [Date_Id]) VALUES (N'Garden', N'Botanical garden in pittsburgh', N'Carnegie?', NULL, 0, N'Mike', 2)
INSERT [dbo].[dates] ([Name], [Description], [Location], [Link], [Completed], [Added_By], [Date_Id]) VALUES (N'Picnic', N'Picnic at keystone lake', N'Keystone', N'', 0, N'Mike', 6)
INSERT [dbo].[dates] ([Name], [Description], [Location], [Link], [Completed], [Added_By], [Date_Id]) VALUES (N'Hiking', N'Going for a hike on a nice day', N'Townsend', N'', 0, N'Mike', 7)
INSERT [dbo].[dates] ([Name], [Description], [Location], [Link], [Completed], [Added_By], [Date_Id]) VALUES (N'Pottery Painting', N'Painting pottery at brushes and beans', N'Brushes and Beans', N'', 0, N'Fiona', 11)
INSERT [dbo].[dates] ([Name], [Description], [Location], [Link], [Completed], [Added_By], [Date_Id]) VALUES (N'Legos in the Park', N'Going to the lego store or target to pick out a lego set to build in a park on a nice day', N'Park near me', N'', 0, N'Fiona', 12)
INSERT [dbo].[dates] ([Name], [Description], [Location], [Link], [Completed], [Added_By], [Date_Id]) VALUES (N'Fort Movie Night', N'Get all the blankets and pillows and sheets we can then set up a projector to watch a movie', N'Home', N'', 0, N'Mike', 13)
SET IDENTITY_INSERT [dbo].[dates] OFF
GO
ALTER TABLE [dbo].[dates] ADD  CONSTRAINT [DF_Dates_Completed]  DEFAULT ((0)) FOR [Completed]
GO
USE [master]
GO
ALTER DATABASE [DateNight] SET  READ_WRITE 
GO
