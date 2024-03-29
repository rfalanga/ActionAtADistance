USE [master]
GO
/****** Object:  Database [Authors]    Script Date: 2/21/2020 9:35:11 PM ******/

/* This SQL script to generate the Authors database, is no longer needed. It's left here for historical purposes. */
CREATE DATABASE [Authors]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Authors', FILENAME = N'C:\Databases\Authors.MDF' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Authors_log', FILENAME = N'C:\Databases\Authors.LDF' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Authors] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Authors].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Authors] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Authors] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Authors] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Authors] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Authors] SET ARITHABORT OFF 
GO
ALTER DATABASE [Authors] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Authors] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Authors] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Authors] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Authors] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Authors] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Authors] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Authors] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Authors] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Authors] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Authors] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Authors] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Authors] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Authors] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Authors] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Authors] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Authors] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Authors] SET RECOVERY FULL 
GO
ALTER DATABASE [Authors] SET  MULTI_USER 
GO
ALTER DATABASE [Authors] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Authors] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Authors] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Authors] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Authors] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Authors', N'ON'
GO
ALTER DATABASE [Authors] SET QUERY_STORE = OFF
GO
USE [Authors]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Authors]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 2/21/2020 9:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleInitial] [nvarchar](50) NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[DateOfBirth] [datetime] NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MysteryBook]    Script Date: 2/21/2020 9:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MysteryBook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[BookTitle] [nvarchar](200) NOT NULL,
	[PublishDate] [datetime] NULL,
	[MysteryGenreID] [int] NOT NULL,
 CONSTRAINT [PK_MysteryBook] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MysteryGenre]    Script Date: 2/21/2020 9:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MysteryGenre](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_MysteryGenre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([ID], [FirstName], [MiddleInitial], [LastName], [DateOfBirth]) VALUES (1, N'Ellis', NULL, N'Peters', CAST(N'1913-09-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Author] ([ID], [FirstName], [MiddleInitial], [LastName], [DateOfBirth]) VALUES (2, N'Agatha', NULL, N'Christie', CAST(N'1890-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Author] ([ID], [FirstName], [MiddleInitial], [LastName], [DateOfBirth]) VALUES (3, N'Arthur', N'Conan', N'Doyle', CAST(N'1859-05-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[MysteryBook] ON 

INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (1, 3, N'A Study in Scarlet', CAST(N'1887-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (2, 2, N'The Mysterious Affair at Styles', CAST(N'1920-10-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (3, 1, N'A Morbid Taste for Bones', CAST(N'1977-08-25T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (4, 1, N'One Corpse Too Many', CAST(N'1979-07-19T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (5, 1, N'The Leper of Saint Giles', CAST(N'1981-08-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (6, 2, N'The Murder of Roger Ackroyd', CAST(N'1926-06-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (7, 2, N'Murder on the Orient Express', CAST(N'1934-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MysteryBook] ([ID], [AuthorID], [BookTitle], [PublishDate], [MysteryGenreID]) VALUES (8, 3, N'The Hound of the Baskervilles', CAST(N'1914-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[MysteryBook] OFF
SET IDENTITY_INSERT [dbo].[MysteryGenre] ON 

INSERT [dbo].[MysteryGenre] ([ID], [Description]) VALUES (1, N'Mysteries - Golden Age')
INSERT [dbo].[MysteryGenre] ([ID], [Description]) VALUES (2, N'Mysteries - Historial')
SET IDENTITY_INSERT [dbo].[MysteryGenre] OFF
ALTER TABLE [dbo].[MysteryBook]  WITH CHECK ADD  CONSTRAINT [FK_MysteryBook_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([ID])
GO
ALTER TABLE [dbo].[MysteryBook] CHECK CONSTRAINT [FK_MysteryBook_Author]
GO
ALTER TABLE [dbo].[MysteryBook]  WITH CHECK ADD  CONSTRAINT [FK_MysteryBook_MysteryGenre] FOREIGN KEY([MysteryGenreID])
REFERENCES [dbo].[MysteryGenre] ([ID])
GO
ALTER TABLE [dbo].[MysteryBook] CHECK CONSTRAINT [FK_MysteryBook_MysteryGenre]
GO
USE [master]
GO
ALTER DATABASE [Authors] SET  READ_WRITE 
GO
