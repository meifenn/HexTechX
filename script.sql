USE [master]
GO
/****** Object:  Database [SocialDb]    Script Date: 1/2/2025 10:38:00 AM ******/
CREATE DATABASE [SocialDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SocialDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SocialDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SocialDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SocialDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SocialDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SocialDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SocialDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SocialDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SocialDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SocialDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SocialDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SocialDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SocialDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SocialDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SocialDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SocialDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SocialDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SocialDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SocialDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SocialDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SocialDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SocialDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SocialDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SocialDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SocialDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SocialDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SocialDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SocialDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SocialDb] SET RECOVERY FULL 
GO
ALTER DATABASE [SocialDb] SET  MULTI_USER 
GO
ALTER DATABASE [SocialDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SocialDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SocialDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SocialDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SocialDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SocialDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SocialDb', N'ON'
GO
ALTER DATABASE [SocialDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [SocialDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SocialDb]
GO
/****** Object:  User [root]    Script Date: 1/2/2025 10:38:01 AM ******/
CREATE USER [root] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[root]
GO
/****** Object:  Schema [root]    Script Date: 1/2/2025 10:38:01 AM ******/
CREATE SCHEMA [root]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 1/2/2025 10:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[PostID] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friend]    Script Date: 1/2/2025 10:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[FriendID] [int] NULL,
	[AcceptedTime] [datetime] NULL,
	[RequestedTime] [datetime] NULL,
	[UserName] [nvarchar](255) NULL,
	[FriendName] [nvarchar](255) NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FriendRequest]    Script Date: 1/2/2025 10:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FriendRequest](
	[ID] [int] NOT NULL,
	[FromUserID] [int] NULL,
	[ToUserID] [int] NULL,
	[RequestedTime] [datetime] NULL,
	[IsAccepted] [bit] NULL,
	[FromUserName] [nvarchar](255) NULL,
	[ToUserName] [nvarchar](255) NULL,
 CONSTRAINT [PK_FriendRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Like]    Script Date: 1/2/2025 10:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PostID] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 1/2/2025 10:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[PhotoDatas] [nvarchar](max) NULL,
	[LikeCount] [int] NULL,
	[CommentCount] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedTime] [datetime] NULL,
	[UploadedById] [int] NULL,
	[Tags] [nvarchar](255) NULL,
	[UploadedUserName] [nvarchar](255) NULL,
	[UploadedUserPhoto] [nvarchar](255) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 1/2/2025 10:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[PostCount] [int] NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/2/2025 10:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Friend] ON 

INSERT [dbo].[Friend] ([ID], [UserID], [FriendID], [AcceptedTime], [RequestedTime], [UserName], [FriendName]) VALUES (1, 1, 2, CAST(N'2020-12-29T00:00:00.000' AS DateTime), CAST(N'2020-12-25T00:00:00.000' AS DateTime), N'Su', N'Bb')
INSERT [dbo].[Friend] ([ID], [UserID], [FriendID], [AcceptedTime], [RequestedTime], [UserName], [FriendName]) VALUES (2, 2, 1, CAST(N'2020-12-29T00:00:00.000' AS DateTime), CAST(N'2020-12-29T00:00:00.000' AS DateTime), N'Bb', N'Su')
SET IDENTITY_INSERT [dbo].[Friend] OFF
GO
INSERT [dbo].[FriendRequest] ([ID], [FromUserID], [ToUserID], [RequestedTime], [IsAccepted], [FromUserName], [ToUserName]) VALUES (1, 3, 1, CAST(N'2010-12-29T00:00:00.000' AS DateTime), NULL, N'Mew', N'Su')
INSERT [dbo].[FriendRequest] ([ID], [FromUserID], [ToUserID], [RequestedTime], [IsAccepted], [FromUserName], [ToUserName]) VALUES (2, 4, 1, CAST(N'2010-12-29T00:00:00.000' AS DateTime), NULL, N'CiCi', N'Su')
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([ID], [Title], [Description], [PhotoDatas], [LikeCount], [CommentCount], [CreatedTime], [ModifiedTime], [UploadedById], [Tags], [UploadedUserName], [UploadedUserPhoto]) VALUES (1, N'First post', N'this is my first post.', NULL, 0, 0, CAST(N'2024-12-25T13:45:49.487' AS DateTime), CAST(N'2024-12-25T06:45:19.390' AS DateTime), 1, N'Travel,Vlog', NULL, NULL)
INSERT [dbo].[Post] ([ID], [Title], [Description], [PhotoDatas], [LikeCount], [CommentCount], [CreatedTime], [ModifiedTime], [UploadedById], [Tags], [UploadedUserName], [UploadedUserPhoto]) VALUES (2, N'Test photo', N'test', N'206e0e62-98ec-4f49-b364-5aff1787abc5', 0, 0, CAST(N'2024-12-25T14:56:47.550' AS DateTime), CAST(N'2024-12-25T07:53:32.870' AS DateTime), 0, N'Education', N'string', N'string')
INSERT [dbo].[Post] ([ID], [Title], [Description], [PhotoDatas], [LikeCount], [CommentCount], [CreatedTime], [ModifiedTime], [UploadedById], [Tags], [UploadedUserName], [UploadedUserPhoto]) VALUES (3, N'Test photo', N'test', N'95412fff-7f3a-4f34-9761-06b6c3d8b300.jpg', 0, 0, CAST(N'2024-12-25T15:02:48.987' AS DateTime), CAST(N'2024-12-25T07:53:32.870' AS DateTime), 0, N'Education', N'string', N'string')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([ID], [Text], [CreatedAt], [PostCount]) VALUES (1, N'Travel', CAST(N'2024-12-25T13:45:49.487' AS DateTime), 2)
INSERT [dbo].[Tag] ([ID], [Text], [CreatedAt], [PostCount]) VALUES (2, N'Vlog', CAST(N'2024-12-25T13:45:49.487' AS DateTime), 2)
INSERT [dbo].[Tag] ([ID], [Text], [CreatedAt], [PostCount]) VALUES (3, N'Education', CAST(N'2024-12-25T14:16:51.443' AS DateTime), 7)
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [CreatedTime], [ModifiedTime]) VALUES (1, N'Su', N'123', CAST(N'2010-12-29T00:00:00.000' AS DateTime), CAST(N'2010-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([ID], [UserName], [Password], [CreatedTime], [ModifiedTime]) VALUES (2, N'Bb', N'111', CAST(N'2010-12-29T00:00:00.000' AS DateTime), CAST(N'2010-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([ID], [UserName], [Password], [CreatedTime], [ModifiedTime]) VALUES (3, N'Mew', N'123', CAST(N'2010-12-29T00:00:00.000' AS DateTime), CAST(N'2010-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[User] ([ID], [UserName], [Password], [CreatedTime], [ModifiedTime]) VALUES (4, N'CiCi', N'123', CAST(N'2010-12-29T00:00:00.000' AS DateTime), CAST(N'2010-12-29T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [SocialDb] SET  READ_WRITE 
GO
