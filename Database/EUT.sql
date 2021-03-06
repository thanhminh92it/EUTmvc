USE [master]
GO
/****** Object:  Database [EUT]    Script Date: 12/20/2014 2:50:24 PM ******/
CREATE DATABASE [EUT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EUT', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\EUT.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EUT_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\EUT_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EUT] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EUT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EUT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EUT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EUT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EUT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EUT] SET ARITHABORT OFF 
GO
ALTER DATABASE [EUT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EUT] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EUT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EUT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EUT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EUT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EUT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EUT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EUT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EUT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EUT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EUT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EUT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EUT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EUT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EUT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EUT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EUT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EUT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EUT] SET  MULTI_USER 
GO
ALTER DATABASE [EUT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EUT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EUT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EUT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EUT]
GO
/****** Object:  Table [dbo].[tblAccount]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](50) NULL,
	[EmailCode] [nvarchar](16) NULL,
	[StatusAccountId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[EndTime] [datetime] NULL,
	[NewTime] [datetime] NULL,
	[GroupAcountId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[AccumulatedPoints] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblArea]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArea](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblAuthorities]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAuthorities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblAuthorities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NOT NULL,
	[SubtestId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblChallenge]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChallenge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[RivalId] [int] NULL,
	[CategoryId] [int] NOT NULL,
	[FormId] [int] NULL,
	[AccumulatedPoints] [int] NOT NULL,
	[Status] [int] NULL,
	[ExamQuestionId] [int] NULL,
	[ResultId] [int] NULL,
	[ResultRivalId] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblChallenge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCountry]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDegree]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDegree](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_Degree] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDistrict]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDistrict](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblExamQuestion]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExamQuestion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Title] [nvarchar](200) NULL,
	[ExamStructId] [int] NOT NULL,
	[QuestionId] [nvarchar](500) NOT NULL,
	[AccumulatedPoints] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblExamQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblExamStruct]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExamStruct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[FormId] [int] NULL,
	[GradeId] [int] NULL,
	[EasyNumber] [int] NULL,
	[AverageNumber] [int] NULL,
	[HardNumber] [int] NULL,
	[CategoryNumber] [int] NULL,
	[QuestionNumber] [int] NULL,
	[Time] [int] NULL,
	[Request] [float] NULL,
	[SubtestId] [int] NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblExamStruct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblForm]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblForm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Time] [int] NULL,
	[Request] [float] NULL,
	[QuestionNumber] [int] NULL,
 CONSTRAINT [PK_tblForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblGrade]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGrade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblGrade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblGroupAcount]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGroupAcount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblGroupAcount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLevel]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Difficulty] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNews]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Image] [nvarchar](50) NULL,
	[News] [ntext] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblNews_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPerson]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[DateOfBirth] [datetime] NULL,
	[Address] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Occupation] [nvarchar](50) NULL,
	[DegreeId] [int] NULL,
	[SchoolId] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblQuestion]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuestion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[CategoryId] [int] NULL,
	[LevelId] [int] NULL,
	[Contents] [ntext] NULL,
	[Answer] [nvarchar](1) NULL,
	[AnswerA] [nvarchar](max) NULL,
	[AnswerB] [nvarchar](max) NULL,
	[AnswerC] [nvarchar](max) NULL,
	[AnswerD] [nvarchar](max) NULL,
	[AnswerDetail] [ntext] NULL,
	[SuggestionId] [int] NULL,
	[ModifiedCount] [int] NULL,
	[Description] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblResult]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[AccountId] [int] NULL,
	[ExamQuestionId] [int] NULL,
	[Seed] [int] NULL,
	[Answer] [nvarchar](100) NULL,
	[ExecutionTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Point] [float] NULL,
	[AccumulatedPoints] [int] NULL,
 CONSTRAINT [PK_tblResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSchool]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSchool](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[DistrictId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblStatusAccount]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStatusAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblStatusAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblStructContent]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStructContent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[ExamStructId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[EasyNumber] [int] NOT NULL,
	[AverageNumber] [int] NOT NULL,
	[HardNumber] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblStructContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSubtest]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubtest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_tblSubtest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSuggestion]    Script Date: 12/20/2014 2:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSuggestion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contents] [nvarchar](max) NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedCount] [int] NULL,
 CONSTRAINT [PK_Suggestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblAccount] ON 

INSERT [dbo].[tblAccount] ([Id], [Account], [PassWord], [Image], [EmailCode], [StatusAccountId], [Status], [EndTime], [NewTime], [GroupAcountId], [PersonId], [AccumulatedPoints], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'admin.png', NULL, 1, 1, CAST(0x0000A40200A425BC AS DateTime), CAST(0x0000A40200A45386 AS DateTime), 1, 1, NULL, NULL, NULL, NULL, N'admin', CAST(0x0000A3C2008BDED3 AS DateTime), NULL)
INSERT [dbo].[tblAccount] ([Id], [Account], [PassWord], [Image], [EmailCode], [StatusAccountId], [Status], [EndTime], [NewTime], [GroupAcountId], [PersonId], [AccumulatedPoints], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (3, N'vanha', N'e10adc3949ba59abbe56e057f20f883e', NULL, N'QI5Tq4EahfkTR7i1', 1, 0, CAST(0x0000A3C200D58792 AS DateTime), CAST(0x0000A3C5007C9104 AS DateTime), 2, 2, 1000, NULL, NULL, CAST(0x0000A3B6008B6180 AS DateTime), N'vanha', CAST(0x0000A3C0012BC3D0 AS DateTime), NULL)
INSERT [dbo].[tblAccount] ([Id], [Account], [PassWord], [Image], [EmailCode], [StatusAccountId], [Status], [EndTime], [NewTime], [GroupAcountId], [PersonId], [AccumulatedPoints], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (6, N'dasdas', N'e10adc3949ba59abbe56e057f20f883e', NULL, N'Hc5cKXhd1Y1CI8j2', 2, 0, NULL, NULL, 2, 1004, NULL, NULL, N'dasdas', CAST(0x0000A3FC01053EFF AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblAccount] OFF
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'1', N'Cơ chế di truyền và biến dị', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'2', N'Quy luật di truyền', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (3, N'3', N'Di truyền quần thể', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (4, N'4', N'Ứng dụng di truyền học', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (5, N'5', N'Di truyền người', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (6, N'6', N'Bằng chứng tiến hóa', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (7, N'7', N'Cơ chế tiến hóa', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (8, N'8', N'Sự phát sinh và phát triển của sự sống', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (9, N'9', N'Cá thể sinh vật', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (10, N'10', N'Quần thể sinh vật', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (11, N'11', N'Quần xã sinh vật', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (12, N'12', N'Hệ sinh thái, sinh quyển và môi trường', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (13, N'13', N'Dao động cơ', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (14, N'14', N'Sóng cơ', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (15, N'15', N'Dòng điện xoay chiều', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (16, N'16', N'Dao động và sóng điện từ', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (17, N'17', N'Sóng ánh sáng', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (18, N'18', N'Lượng tử ánh sáng', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (19, N'19', N'Hạt nhân nguyên tử', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (20, N'20', N'Từ vi mô đến vĩ mô', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (21, N'21', N'Ngữ âm', 4, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (22, N'22', N'Ngữ pháp, Từ vựng', 4, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (23, N'23', N'Chức năng giao tiếp', 4, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (25, N'24', N'Kỹ năng đọc', 4, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([Id], [Code], [Name], [SubtestId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (26, N'25', N'Kỹ năng viết', 4, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
SET IDENTITY_INSERT [dbo].[tblChallenge] ON 

INSERT [dbo].[tblChallenge] ([Id], [AccountId], [RivalId], [CategoryId], [FormId], [AccumulatedPoints], [Status], [ExamQuestionId], [ResultId], [ResultRivalId], [CreatedBy], [CreatedDate]) VALUES (1, 3, NULL, 3, NULL, 10, NULL, 1, NULL, NULL, N'vanha', CAST(0x0000A4050160A1C1 AS DateTime))
INSERT [dbo].[tblChallenge] ([Id], [AccountId], [RivalId], [CategoryId], [FormId], [AccumulatedPoints], [Status], [ExamQuestionId], [ResultId], [ResultRivalId], [CreatedBy], [CreatedDate]) VALUES (2, 3, NULL, 3, NULL, 5, NULL, 1, NULL, NULL, N'vanha', CAST(0x0000A407009AE34A AS DateTime))
SET IDENTITY_INSERT [dbo].[tblChallenge] OFF
SET IDENTITY_INSERT [dbo].[tblExamQuestion] ON 

INSERT [dbo].[tblExamQuestion] ([Id], [Code], [Name], [Title], [ExamStructId], [QuestionId], [AccumulatedPoints], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'1', NULL, NULL, 1, N'21;22;23;24;25;26;27;28;29;30', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblExamQuestion] OFF
SET IDENTITY_INSERT [dbo].[tblExamStruct] ON 

INSERT [dbo].[tblExamStruct] ([Id], [Code], [Name], [FormId], [GradeId], [EasyNumber], [AverageNumber], [HardNumber], [CategoryNumber], [QuestionNumber], [Time], [Request], [SubtestId], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'1', N'Bạn Dám Không 1', 4, NULL, 4, 3, 3, 1, 10, 15, 0.8, 3, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblExamStruct] ([Id], [Code], [Name], [FormId], [GradeId], [EasyNumber], [AverageNumber], [HardNumber], [CategoryNumber], [QuestionNumber], [Time], [Request], [SubtestId], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'2', N'Thi thử tiếng anh 1', 2, NULL, NULL, NULL, NULL, NULL, 80, 90, 0.5, 4, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblExamStruct] OFF
SET IDENTITY_INSERT [dbo].[tblForm] ON 

INSERT [dbo].[tblForm] ([Id], [Description], [Time], [Request], [QuestionNumber]) VALUES (1, N'Luyện Tập', NULL, NULL, NULL)
INSERT [dbo].[tblForm] ([Id], [Description], [Time], [Request], [QuestionNumber]) VALUES (2, N'Thi Thử', NULL, NULL, NULL)
INSERT [dbo].[tblForm] ([Id], [Description], [Time], [Request], [QuestionNumber]) VALUES (3, N'Thi Đấu', NULL, NULL, NULL)
INSERT [dbo].[tblForm] ([Id], [Description], [Time], [Request], [QuestionNumber]) VALUES (4, N'Bạn Dám Không', NULL, NULL, NULL)
INSERT [dbo].[tblForm] ([Id], [Description], [Time], [Request], [QuestionNumber]) VALUES (5, N'Thách Đấu', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblForm] OFF
SET IDENTITY_INSERT [dbo].[tblGroupAcount] ON 

INSERT [dbo].[tblGroupAcount] ([Id], [Code], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'admin', N'Admin', N'Quản trị viên', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblGroupAcount] ([Id], [Code], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'member', N'Member', N'Học viên', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblGroupAcount] OFF
SET IDENTITY_INSERT [dbo].[tblLevel] ON 

INSERT [dbo].[tblLevel] ([Id], [Code], [Difficulty], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'1', N'Dễ', N'Easy', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblLevel] ([Id], [Code], [Difficulty], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'2', N'Trung Bình', N'Average', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblLevel] ([Id], [Code], [Difficulty], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (3, N'3', N'Khó', N'Hard', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblLevel] OFF
SET IDENTITY_INSERT [dbo].[tblNews] ON 

INSERT [dbo].[tblNews] ([Id], [Title], [Image], [News], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'Kì thi THPT Quốc Gia 2015', N'461134761412989640_small.jpg', N'<div class="form-group">
	<strong>M&ocirc;n thi</strong>: Thi tối thiểu 4 m&ocirc;n, trong đ&oacute;:
	<p style="margin-left:80px">
		- 3 m&ocirc;n bắt buộc: ( To&aacute;n, Văn, Ngoại ngữ) v&agrave; 1 m&ocirc;n tự chọn:<br />
		&nbsp;&nbsp;&nbsp;&bull; Vật l&iacute;.<br />
		&nbsp;&nbsp;&nbsp;&bull; H&oacute;a học.<br />
		&nbsp;&nbsp;&nbsp;&bull; Sinh học.<br />
		&nbsp;&nbsp;&nbsp;&bull; Lịch sử.<br />
		&nbsp;&nbsp;&nbsp;&bull; Địa l&iacute;.</p>
</div>
<div class="form-group">
	<strong>Th&iacute; sinh kh&ocirc;ng học m&ocirc;n Ngoại Ngữ hoặc học trong điều kiện kh&ocirc;ng đảm bảo chất lượng được chọn m&ocirc;n thi thay thế m&ocirc;n Ngoại Ngữ trong số c&aacute;c m&ocirc;n tự chọn. Th&iacute; sinh c&oacute; chứng chỉ Ngoại Ngữ theo quy định của bộ GD-ĐT c&ocirc;ng bố sẽ được miễn thi tốt nghiệp THPT m&ocirc;n Ngoại Ngữ. </strong></div>
<div class="form-group">
	<strong>Ng&agrave;y thi: </strong>9, 10, 11, 12/6/2015.</div>
<div class="form-group">
	<strong>Th&iacute; sinh ngo&agrave;i thi 4 m&ocirc;n bắt buộc, th&iacute; sinh c&oacute; thể đăng k&yacute; c&aacute;c m&ocirc;n kh&aacute;c trong c&aacute;c m&ocirc;n tự chọn để tăng cơ hội x&eacute;t tuyển v&agrave;o ĐH-CĐ.</strong></div>
<div class="form-group">
	<strong>Th&iacute; sinh năm trước: </strong>Chỉ đăng k&yacute; thi phục vụ cho tuyển sinh ĐH-CĐ.</div>
<p>
	<strong>H&igrave;nh thức thi:</strong></p>
<table cellpadding="1" cellspacing="1" style="height:138px; width:500px">
	<tbody>
		<tr>
			<td>
				<p style="margin-left: 80px;">
					- Thi tự luận (180 ph&uacute;t):<br />
					&nbsp;&nbsp;&nbsp;&bull; To&aacute;n.<br />
					&nbsp;&nbsp;&nbsp;&bull; Văn.<br />
					&nbsp;&nbsp;&nbsp;&bull; Lịch sử.<br />
					&nbsp;&nbsp;&nbsp;&bull; Địa l&iacute;.</p>
			</td>
			<td>
				- Thi trắc nghiệm (90 ph&uacute;t):<br />
				&nbsp;&nbsp;&nbsp;&bull; Vật l&iacute;.<br />
				&nbsp;&nbsp;&nbsp;&bull; H&oacute;a học.<br />
				&nbsp;&nbsp;&nbsp;&bull; Sinh học.<br />
				&nbsp;&nbsp;&nbsp;&bull; Ngoại ngữ.</td>
		</tr>
	</tbody>
</table>
<p>
	&nbsp;</p>
', N'Admin', NULL, N'Admin', CAST(0x0000A3C5007D14AC AS DateTime), 1)
INSERT [dbo].[tblNews] ([Id], [Title], [Image], [News], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (3, N'TĂNG CƯỜNG VAI TRÒ CỦA CÁC TRƯỜNG ĐH, CĐ TRONG KÌ THI CHUNG', N'141653_thidaihoc4.jpg', N'<p style="text-align:justify">
	<strong><span style="font-size:medium">C&aacute;c trường đại học được giao chủ tr&igrave; cụm thi sẽ l&agrave; đơn vị chịu tr&aacute;ch nhiệm ch&iacute;nh c&ugrave;ng với c&aacute;c sở GDĐT tổ chức kỳ thi tốt nghiệp THPT quốc gia.</span></strong></p>
<p style="text-align:justify">
	<strong><span style="font-size:medium">Tăng cường vai tr&ograve; của c&aacute;c trường ĐH, CĐ</span></strong></p>
<p style="text-align:justify">
	&nbsp;</p>
<p style="text-align:center">
	<img alt="" src="/Uploads/images/News/141653_thidaihoc4.jpg" style="opacity:1" /></p>
<p style="text-align:center">
	<span style="font-size:medium"><em>Ảnh minh họa (Nguồn: Internet)</em></span></p>
<p style="text-align:justify">
	<span style="font-size:medium">Tin tức từ Bộ GD&amp;ĐT cho biết, trong kỳ thi tốt nghiệp THPT quốc gia, Ph&oacute; Chủ tịch UBND tỉnh/th&agrave;nh phố l&agrave;m Trưởng Ban chỉ đạo thi. L&atilde;nh đạo trường ĐH, CĐ, l&atilde;nh đạo Sở GDĐT l&agrave;m Ph&oacute; Trưởng Ban chỉ đạo thi.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">Ở cụm thi do trường ĐH chủ tr&igrave;, hiệu trưởng trường ĐH được giao l&agrave;m Chủ tịch Hội đồng thi, l&atilde;nh đạo sở GDĐT l&agrave;m Ph&oacute; chủ tịch Hội đồng thi. Ở cụm thi tại địa phương, gi&aacute;m đốc Sở GDĐT được giao l&agrave;m Chủ tịch Hội đồng thi.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">C&aacute;c trường ĐH c&oacute; đủ năng lực, điều kiện, uy t&iacute;n v&agrave; kinh nghiệm tổ chức thi sẽ được Bộ giao chủ tr&igrave;, phối hợp với c&aacute;c cơ sở gi&aacute;o dục đại học tại tỉnh/th&agrave;nh phố v&agrave; sở GDĐT tổ chức coi thi, chấm thi v&agrave; gửi kết quả chấm thi về Bộ GDĐT.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">C&aacute;c sở GDĐT tham gia Ban chỉ đạo, phối hợp với trường ĐH tổ chức coi thi, chấm thi; chịu tr&aacute;ch nhiệm tổ chức cho học sinh đăng k&iacute; dự thi, chuyển dữ liệu đăng k&iacute; dự thi về Bộ GDĐT; x&eacute;t c&ocirc;ng nhận tốt nghiệp THPT cho th&iacute; sinh của địa phương v&agrave; chủ tr&igrave; cụm thi ở địa phương (nếu được Bộ GDĐT thống nhất với Uỷ ban nh&acirc;n d&acirc;n cấp tỉnh tổ chức cụm thi) d&agrave;nh cho th&iacute; sinh chỉ đăng k&iacute; x&eacute;t tốt nghiệp THPT, kh&ocirc;ng lấy kết quả thi để tham gia tuyển sinh v&agrave;o c&aacute;c trường ĐH, CĐ sử dụng kết quả K&igrave; thi v&agrave;o tuyển sinh.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">Như vậy, vai tr&ograve; của c&aacute;c trường ĐH, CĐ, c&aacute;c sở GDĐT trong Kỳ thi THPT quốc gia l&agrave; rất lớn. C&aacute;c trường ĐH được giao chủ tr&igrave; cụm thi sẽ l&agrave; đơn vị chịu tr&aacute;ch nhiệm ch&iacute;nh c&ugrave;ng với c&aacute;c sở GDĐT tổ chức K&igrave; thi nghi&ecirc;m t&uacute;c, c&ocirc;ng bằng, kh&aacute;ch quan, kết quả thi đạt độ tin cậy để c&aacute;c trường ĐH, CĐ trong hệ thống gi&aacute;o dục đại học v&agrave; gi&aacute;o dục nghề nghiệp y&ecirc;n t&acirc;m sử dụng trong c&ocirc;ng t&aacute;c tuyển sinh.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">Uỷ ban nh&acirc;n d&acirc;n c&aacute;c tỉnh, th&agrave;nh phố chỉ đạo Sở GDĐT v&agrave; c&aacute;c ban, ng&agrave;nh của địa phương c&ugrave;ng với c&aacute;c trường ĐH, CĐ tổ chức nghi&ecirc;m t&uacute;c, đ&uacute;ng quy chế c&aacute;c kh&acirc;u của Kỳ thi; đảm bảo an ninh, an to&agrave;n c&aacute;c hội đồng coi thi, chấm thi tr&ecirc;n địa b&agrave;n; tổ chức nghi&ecirc;m t&uacute;c c&aacute;c cụm thi do Sở GDĐT chủ tr&igrave;, để kết quả thi c&oacute; độ tin cậy cao, kh&aacute;ch quan, kh&ocirc;ng xảy ra những bất thường, m&acirc;u thuẫn với kết quả thi của c&aacute;c th&iacute; sinh thi tại cụm thi do c&aacute;c trường ĐH chủ tr&igrave;.</span><br />
	<br />
	<strong><span style="font-size:medium">Tổ chức th&ecirc;m nhiều cụm thi</span></strong></p>
<p style="text-align:justify">
	<span style="font-size:medium">Bộ GD&amp;ĐT cho biết, theo kinh nghiệm tổ chức thi tuyển sinh ĐH, CĐ những năm qua, một cụm thi trung b&igrave;nh khoảng 30 &ndash; 40 ngh&igrave;n th&iacute; sinh l&agrave; ph&ugrave; hợp. Từ kinh nghiệm n&agrave;y v&agrave; dựa tr&ecirc;n nguồn lực của c&aacute;c trường ĐH, CĐ (đội ngũ c&aacute;n bộ, cơ sở vật chất, uy t&iacute;n v&agrave; kinh nghiệm tổ chức thi tuyển sinh) Bộ sẽ bố tr&iacute; c&aacute;c cụm thi theo khoảng c&aacute;ch địa l&iacute; hợp l&iacute;, đồng thời số cụm thi sẽ tăng hơn năm trước, rải ra trong cả nước nhằm tạo điều kiện thuận lợi cho th&iacute; sinh tham dự K&igrave; thi.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">C&aacute;c cụm thi sẽ được th&agrave;nh lập theo m&ocirc; h&igrave;nh c&aacute;c cụm thi ĐH, CĐ ở Hải Ph&ograve;ng, Vinh, Quy Nhơn v&agrave; Cần Thơ như những năm trước đ&acirc;y. Bộ GDĐT sẽ khảo s&aacute;t, xem x&eacute;t kĩ lưỡng c&aacute;c yếu tố để c&ugrave;ng với c&aacute;c địa phương v&agrave; c&aacute;c trường ĐH b&agrave;n bạc, thống nhất th&agrave;nh lập th&ecirc;m c&aacute;c cụm thi. C&aacute;c trường ĐH, CĐ sẽ c&ugrave;ng với c&aacute;c sở GDĐT phối hợp để tổ chức tốt K&igrave; thi.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">C&aacute;c trường ĐH được giao chủ tr&igrave; c&aacute;c cụm thi c&oacute; thể coi đ&acirc;y l&agrave; một cơ hội tốt để khẳng định uy t&iacute;n v&agrave; thương hiệu của trường. Tr&aacute;ch nhiệm của c&aacute;c trường khi đ&oacute; sẽ nặng nề hơn so với trước đ&acirc;y (chỉ tổ chức thi cho th&iacute; sinh thi v&agrave;o trường m&igrave;nh hoặc cho một số trường) v&igrave; phải tổ chức thật tốt để đ&aacute;p ứng y&ecirc;u cầu của K&igrave; thi THPT quốc gia; đảm bảo độ tin cậy của kết quả thi để c&aacute;c trường ĐH, CĐ sử dụng v&agrave;o tuyển sinh; đảm bảo chất lượng nguồn tuyển, tạo điều kiện n&acirc;ng cao chất lượng đ&agrave;o tạo của cả hệ thống.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">C&aacute;c địa phương được giao chủ tr&igrave; cụm thi cũng phải nỗ lực tổ chức Kỳ thi với y&ecirc;u cầu cao hơn k&igrave; thi tốt nghiệp THPT những năm trước; đảm bảo nghi&ecirc;m t&uacute;c, kh&aacute;ch quan, c&ocirc;ng bằng, kết quả thi c&oacute; độ tin cậy cao, phản &aacute;nh đ&uacute;ng chất lượng dạy học; đặc biệt l&agrave; kh&ocirc;ng để xảy ra t&igrave;nh trạng kết quả cao bất thường so với c&aacute;c cụm thi do c&aacute;c trường ĐH chủ tr&igrave;.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">Đ&acirc;y thực sự l&agrave; một th&aacute;ch thức lớn đối với c&aacute;c cụm thi do Sở GDĐT chủ tr&igrave;. Tổ chức nghi&ecirc;m t&uacute;c c&aacute;c cụm thi do Sở GDĐT chủ tr&igrave; ch&iacute;nh l&agrave; hướng tới đảm bảo quyền lợi của th&iacute; sinh.</span></p>
<p style="text-align:justify">
	<span style="font-size:medium">Cũng cần n&oacute;i th&ecirc;m l&agrave; Bộ sẽ tăng cường kiểm tra, thanh tra, chấm thẩm định tại c&aacute;c cụm thi, nhất l&agrave; c&aacute;c cụm thi do Sở GDĐT chủ tr&igrave; để gi&aacute;m s&aacute;t chặt chẽ, ph&aacute;t hiện v&agrave; c&oacute; giải ph&aacute;p xử l&iacute; kịp thời c&aacute;c bất cập nảy sinh, đảm bảo tổ chức K&igrave; thi THPT quốc gia đạt mục ti&ecirc;u đề ra.</span></p>
<p style="text-align:right">
	<em><span style="font-size:medium">Theo Anh Nguyễn/Doisongphapluat.vn</span></em></p>
', N'Admin', NULL, N'Admin', CAST(0x0000A3C5007D213E AS DateTime), 1)
INSERT [dbo].[tblNews] ([Id], [Title], [Image], [News], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (5, N'Vượt qua căn bệnh hồi hộp khi nói chuyện trước đám đông ', N'thumb11_442929810.jpg', N'<div>
<p><strong>C&aacute;c điểm ch&iacute;nh trong b&agrave;i học:</strong></p>

<p><strong>C&aacute;c nguy&ecirc;n khiến ch&uacute;ng ta mắc phải căn bệnh hồi hộp:</strong></p>

<p><strong>- </strong>Tự h&ugrave; dọa ch&iacute;nh bản th&acirc;n m&igrave;nh</p>

<p>- Kh&ocirc;ng c&oacute; th&oacute;i quen n&oacute;i chuyện trước đ&aacute;m đ&ocirc;ng</p>

<p>- Chuẩn bị b&agrave;i kh&ocirc;ng kỹ</p>

<p><strong>Những c&aacute;ch vượt qua sự hồi hộp:</strong></p>

<p><strong>- </strong>H&iacute;t thở s&acirc;u, đ&aacute;nh lừa n&atilde;o, lấy hơi d&agrave;i</p>

<p>- Đừng suy nghĩ ti&ecirc;u cực, h&igrave;nh dung ra những h&igrave;nh ảnh t&iacute;ch cực</p>

<p>- Chọn cho m&igrave;nh một phong c&aacute;ch thuyết tr&igrave;nh chuy&ecirc;n nghiệp</p>

<h3><strong>B&agrave;i tập thực h&agrave;nh:</strong></h3>

<div>Đứng trước gương v&agrave; tập thuyết tr&igrave;nh v&agrave; nhờ bạn b&egrave;, người th&acirc;n...đ&aacute;nh gi&aacute;</div>
</div>
', N'Admin', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblNews] ([Id], [Title], [Image], [News], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (8, N'16 trường ĐH Mỹ tìm kiếm sinh viên Việt xuất sắc', N'20141001153504-my.jpg', N'<p><strong>Triển l&atilde;m Gi&aacute;o dục Mỹ sẽ trở lại Việt Nam v&agrave;o m&ugrave;a thu n&agrave;y, tổ chức c&aacute;c sự kiện ở H&agrave; Nội (13/10/2014) v&agrave; TP.HCM (15/10/2014), đem đến cơ hội học bổng v&agrave; gặp gỡ nh&acirc;n vi&ecirc;n tuyển sinh từ 16 ĐH, CĐ danh tiếng của Mỹ. </strong></p>

<p>Tại triển l&atilde;m 2014, học sinh chưa tốt nghiệp v&agrave; đ&atilde; tốt nghiệp THPT ngo&agrave;i cơ hội t&igrave;m hiểu về c&aacute;c trường ĐH đang rộng cửa đ&oacute;n sinh vi&ecirc;n nước ngo&agrave;i, c&ograve;n dự Hội chợ Học bổng, nơi t&igrave;m hiểu cặn kẽ c&aacute;c cơ hội học bổng tại nhiều trường ĐH, CĐ Mỹ.<br />
<br />
Ban tổ chức đề nghị học sinh sinh vi&ecirc;n mang theo c&aacute;c bản sao bảng điểm, học bạ v&agrave; điểm TOEFL tới Triển l&atilde;m. C&aacute;c điểm số n&agrave;y sẽ gi&uacute;p diện c&aacute;c trường nhận định được khả năng đ&aacute;p ứng điều kiện nhập học v&agrave; mức độ tiến bộ của bạn trong học tập.</p>

<table align="center" cellpadding="0" cellspacing="0" class="center image" style="width:400px">
	<tbody>
		<tr>
			<td><img alt="ss" src="http://imgs.vietnamnet.vn/Images/vnn/2014/10/01/15/20141001153504-my.jpg" title="ss" /></td>
		</tr>
		<tr>
			<td>&nbsp;</td>
		</tr>
	</tbody>
</table>

<p>H&agrave;ng năm, Triển l&atilde;m Gi&aacute;o dục Mỹ lớn nhất đều diễn ra ở Việt Nam. Mỹ tiếp tục l&agrave; điểm đến h&agrave;ng đầu cho sinh vi&ecirc;n nước ngo&agrave;i muốn học tiếp sau trung học.<br />
<br />
Năm 2013, hơn 720.000 sinh vi&ecirc;n từ khắp nơi tr&ecirc;n thế giới đ&atilde; được tuyển v&agrave;o c&aacute;c trường ĐH v&agrave; CĐ Mỹ. Con số ổn định n&agrave;y chứng tỏ Mỹ vẫn l&agrave; nước c&oacute; nền gi&aacute;o dục đại học xứng nhất với đồng tiền bỏ ra. C&aacute;c trường ở Mỹ vẫn đủ khả năng cung cấp sự đầu tư v&ocirc; gi&aacute; n&agrave;y với c&aacute;c mức chi ph&iacute; vừa t&uacute;i tiền.<br />
<br />
<strong>Chương tr&igrave;nh Học bổng Du học ở H&agrave; Nội:</strong><br />
Thời gian: 17h30-21h thứ 2 ng&agrave;y 13/10/2014<br />
Địa điểm: Kh&aacute;ch sạn &nbsp;Sofitel&nbsp; H&agrave; Nội (01 Đường Thanh Ni&ecirc;n, H&agrave; Nội)<br />
<br />
Mọi th&ocirc;ng tin th&ecirc;m xem tại:<br />
<a href="http://studentlane.com/en_us/index.php?option=com_wrapper&amp;view=wrapper&amp;Itemid=137">http://studentlane.com/en_us/index.php?option=com_wrapper&amp;view=wrapper&amp;Itemid=137</a><br />
<br />
<strong>Chương tr&igrave;nh Học bổng du học ở TP.HCM</strong><br />
Thời gian: 17h30-21h thứ 4 ng&agrave;y 15/10/2014<br />
Địa điểm: Kh&aacute;ch sạn Rex (141 Đường Nguyễn Huệ, Q.1, TP.HCM)<br />
Hội thảo du học, Thị thực cho c&aacute;c bậc cha mẹ v&agrave; học sinh: 18h-21h<br />
Mọi th&ocirc;ng tin th&ecirc;m xem tại<br />
<a href="http://studentlane.com/en_us/index.php?option=com_wrapper&amp;view=wrapper&amp;Itemid=137">http://studentlane.com/en_us/index.php?option=com_wrapper&amp;view=wrapper&amp;Itemid=137</a></p>

<p><strong>Danh s&aacute;ch 16 trường ĐH tham gia triển l&atilde;m:</strong><br />
<br />
College of Charleston (N/A)<br />
Murray State University ($8,000)<br />
<br />
SUNY Institute of&nbsp; Technology ($20.000)<br />
<br />
University of Central Missouri (N/A)<br />
<br />
Concordia University Wisconsin ($6,000)<br />
<br />
Pennsylvania State University Harrisburg (N/A)<br />
<br />
Drexel University (Full Tuition)<br />
<br />
College for Creative Studies ($15,000)<br />
<br />
Northern Michigan University ($5,500)<br />
<br />
Saint Mary&#39;s University of Minnesota ($14,000)<br />
<br />
Oral Roberts University ($20,000)<br />
<br />
Colorado State University Pueblo ($4,000)<br />
<br />
Saint Joseph&#39;s University (Full Scholarship)<br />
<br />
University of South Florida ($15,000)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
Joliet Junior College (N/A)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
<br />
University of Wisconsin-Superior ($7,500) &nbsp; &nbsp;&nbsp;</p>
', N'Admin', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblNews] ([Id], [Title], [Image], [News], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (9, N'Thông tin mới nhất về kỳ thi THPT quốc gia 2015', N'thong-tin-moi.jpg', N'<p><strong>Bộ GD-ĐT vừa c&oacute; th&ecirc;m giải đ&aacute;p về những th&ocirc;ng tin mới về <a href="http://www.tinmoi.vn/ky-thi-quoc-gia-2015-e529.html" target="_blank">kỳ thi THPT quốc gia 2015</a> nhằm gỡ rối cho gi&aacute;o vi&ecirc;n, học sinh, phụ huynh...</strong></p>

<p>Theo dự thảo hỏi đ&aacute;p về kỳ thi THPT quốc gia được Cục Khảo th&iacute; - Kiểm định chất lượng, Bộ GD-ĐT bi&ecirc;n soạn, Quy chế tuyển sinh năm 2015 hiện đang được Cục chủ tr&igrave; khẩn trương x&acirc;y dựng. Tất cả những vấn đề kỹ thuật của việc tuyển sinh sẽ được cụ thể h&oacute;a trong quy chế mới.</p>

<p>Dự kiến quy chế kỳ thi THPT quốc gia sẽ được ban h&agrave;nh v&agrave;o đầu năm 2015.<br />
&nbsp;</p>

<table align="center" cellpadding="0" cellspacing="0" class="center image" style="width:400px">
	<tbody>
		<tr>
			<td><a class="lightbox" href="http://media.tinmoi.vn/2014/10/08/thong-tin-moi.jpg" title="Thông tin mới nhất về kỳ thi THPT quốc gia 2015 - ảnh 1"><img alt="Hình ảnh Thông tin mới nhất về kỳ thi THPT quốc gia 2015 số 1" src="http://media.tinmoi.vn/2014/10/08/thong-tin-moi.jpg" title="Thông tin mới nhất về kỳ thi THPT quốc gia 2015 - ảnh 1" /></a></td>
		</tr>
		<tr>
			<td style="text-align:center"><span style="color:#0000ff">Ảnh Văn Chung</span></td>
		</tr>
	</tbody>
</table>

<p>Th&ocirc;ng tin tuyển sinh của từng trường ĐH, CĐ sẽ được c&aacute;c trường ĐH c&ocirc;ng bố c&ocirc;ng khai tr&ecirc;n trang tin điện tử của trường, đồng thời b&aacute;o c&aacute;o về Bộ. Khi c&oacute; đầy đủ th&ocirc;ng <a href="http://www.tinmoi.vn/C/Tin-tuc">tin</a>, Bộ sẽ c&ocirc;ng bố c&ocirc;ng khai tr&ecirc;n website của Bộ.</p>

<p><strong>Đề thi kh&oacute; dễ ra sao?</strong></p>

<p><em>Đề thi được thiết kế như thế n&agrave;o để đạt được mục đ&iacute;ch của K&igrave; thi v&agrave; đ&aacute;nh gi&aacute; được to&agrave;n diện th&iacute; sinh?</em></p>

<p>Với c&aacute;ch tiếp cận mới về quan điểm gi&aacute;o dục to&agrave;n diện l&agrave; tr&ecirc;n cơ sở bảo đảm đạt chuẩn tối thiểu học vấn phổ th&ocirc;ng, phải tạo được cho học sinh m&ocirc;i trường học tập thuận lợi để ph&aacute;t huy năng lực sở trường ri&ecirc;ng của c&aacute; nh&acirc;n theo định hướng nghề nghiệp hoặc học l&ecirc;n.</p>

<div class="box-news-suggest" id="add" style="float: left;">
<div class="box-news-suggest-content" id="1320585"><img alt="Đề thi kỳ thi quốc gia 2015 sẽ ra thế nào?" class="img-130x85" src="http://media.tinmoi.vn/thumb/2014/09/10/de-thi-ky-thi-quoc-gia_thumb_140x88.jpg" /> <a class="box-news-suggest-a" href="http://www.tinmoi.vn/de-thi-ky-thi-quoc-gia-2015-se-ra-the-nao-011320585.html" target="_blank" title="Đề thi kỳ thi quốc gia 2015 sẽ ra thế nào?">Đề thi kỳ thi quốc gia 2015 sẽ ra thế n&agrave;o?</a></div>

<div class="box-news-suggest-content" id="1320889"><img alt="Bộ GD " class="img-130x85" src="http://media.tinmoi.vn/thumb/2014/09/12/bo-gd--bat-mi--them_thumb_140x88.jpg" /> <a class="box-news-suggest-a" href="http://www.tinmoi.vn/bo-gd-bat-mi-them-tin-moi-ve-ky-thi-quoc-gia-011320889.html" target="_blank" title="Bộ GD ">Bộ GD &quot;bật m&iacute;&quot; th&ecirc;m tin mới về kỳ thi quốc gia</a></div>

<div class="box-news-suggest-content" id="1321360"><img alt="Những học sinh đầu tiên thi “kỳ thi quốc gia” nói gì?" class="img-130x85" src="http://media.tinmoi.vn/thumb/2014/09/16/nhung-hoc-sinh-dau-tien_thumb_140x88.jpg" /> <a class="box-news-suggest-a" href="http://www.tinmoi.vn/nhung-hoc-sinh-dau-tien-thi-ky-thi-quoc-gia-noi-gi-011321360.html" target="_blank" title="Những học sinh đầu tiên thi “kỳ thi quốc gia” nói gì?">Những học sinh đầu ti&ecirc;n thi &ldquo;kỳ thi quốc gia&rdquo; n&oacute;i g&igrave;?</a></div>

<div class="title"><img alt="Hình ảnh Thông tin mới nhất về kỳ thi THPT quốc gia 2015 số 2" src="http://media.tinmoi.vn/block/suggest-title_15.png" title="Thông tin mới nhất về kỳ thi THPT quốc gia 2015 - ảnh 2" /> N&ecirc;n đọc</div>
</div>

<p>Hiện nay, c&aacute;c trường THPT đ&atilde; v&agrave; đang đổi mới phương ph&aacute;p dạy học, thi, kiểm tra đ&aacute;nh gi&aacute; m&ocirc;n học theo hướng đ&ograve;i hỏi học sinh phải vận dụng kiến thức tổng hợp, li&ecirc;n m&ocirc;n để l&agrave;m b&agrave;i, giải quyết c&aacute;c vấn đề li&ecirc;n quan đến thực tiễn cuộc sống.</p>

<p>Những năm gần đ&acirc;y, đề thi, nhất l&agrave; đề thi c&aacute;c m&ocirc;n Khoa học X&atilde; hội v&agrave; Nh&acirc;n văn đ&atilde; được ra theo hướng mở để tạo điều kiện cho học sinh huy động kiến thức tổng hợp, li&ecirc;n m&ocirc;n v&agrave; vốn sống của học sinh v&agrave;o việc l&agrave;m b&agrave;i (chẳng hạn, trong đề thi Ngữ văn c&oacute; kiến thức về Lịch sử, Địa l&iacute;, Gi&aacute;o dục c&ocirc;ng d&acirc;n...); khắc phục t&igrave;nh trạng bắt học sinh học thuộc l&ograve;ng một c&aacute;ch m&aacute;y m&oacute;c.</p>

<p>Đề thi trong ky thi THPT quốc gia năm 2015 sẽ c&oacute; định dạng tương tự đề thi tốt nghiệp THPT v&agrave; tuyển sinh ĐH, CĐ năm 2014. Nội dung đề thi nằm trong chương tr&igrave;nh THPT, chủ yếu lớp 12.</p>

<p>Đề thi phải đảm bảo ph&acirc;n ho&aacute; tr&igrave;nh độ th&iacute; sinh v&agrave; phải đạt được 2 mục đ&iacute;ch l&agrave; x&eacute;t c&ocirc;ng nhận tốt nghiệp THPT v&agrave; l&agrave;m căn cứ tuyển sinh v&agrave;o ĐH, CĐ. V&igrave; vậy, đề thi gồm c&aacute;c c&acirc;u hỏi từ dễ đến kh&oacute;, vừa đ&aacute;p ứng y&ecirc;u cầu cơ bản (th&iacute; sinh chỉ cần trả lời được c&aacute;c c&acirc;u hỏi n&agrave;y l&agrave; đ&atilde; đủ điều kiện để tốt nghiệp THPT) v&agrave; y&ecirc;u cầu n&acirc;ng cao (để ph&acirc;n ho&aacute; th&iacute; sinh, phục vụ c&ocirc;ng t&aacute;c tuyển sinh ĐH, CĐ). Nghĩa l&agrave;, đề thi phải đ&aacute;nh gi&aacute; được th&iacute; sinh ở cả bốn mức độ: nhận biết, th&ocirc;ng hiểu, vận dụng v&agrave; vận dụng cao.</p>

<p>Trước mắt cũng chưa y&ecirc;u cầu học sinh thay đổi nhiều trong c&aacute;ch học hay phải bổ sung kiến thức g&igrave; mới ngo&agrave;i chương tr&igrave;nh, s&aacute;ch gi&aacute;o khoa phổ th&ocirc;ng như c&aacute;c k&igrave; thi năm 2014.</p>

<p><strong>Đa số c&aacute;c trường ĐH, CĐ sử dụng kết quả k&igrave; thi</strong></p>

<p><em>C&aacute;c trường được ph&eacute;p tự chủ về tuyển sinh, tổ chức c&aacute;c k&igrave; kiểm tra bổ sung như phỏng vấn, kiểm tra năng khiếu, b&agrave;i viết luận, x&eacute;t học bạ ở bậc phổ th&ocirc;ng... Vậy c&aacute;c trường c&oacute; tổ chức thi c&aacute;c m&ocirc;n đ&atilde; tổ chức thi trong K&igrave; thi THPT quốc gia hay kh&ocirc;ng?</em></p>

<p>Để tuyển sinh v&agrave;o trường ĐH, CĐ, c&aacute;c trường phải x&acirc;y dựng phương &aacute;n tuyển sinh đ&aacute;p ứng c&aacute;c quy định tại Quy chế tuyển sinh v&agrave; c&ocirc;ng bố c&ocirc;ng khai để th&iacute; sinh tham khảo.</p>

<p>C&aacute;c trường ĐH, CĐ chủ động đề xuất c&aacute;ch sử dụng kết quả của kỳ thi THPT quốc gia để l&agrave;m căn cứ tuyển sinh với phương &aacute;n cụ thể: Lấy điểm những m&ocirc;n n&agrave;o? C&aacute;c tổ hợp m&ocirc;n thi d&ugrave;ng để x&eacute;t tuyển ra <a href="http://www.tinmoi.vn/C/sao">sao</a>? Hệ số t&iacute;nh điểm của mỗi m&ocirc;n? Tổ chức c&aacute;c kỳ kiểm tra bổ sung với h&igrave;nh thức n&agrave;o?... để x&eacute;t tuyển sinh ph&ugrave; hợp với y&ecirc;u cầu của từng ng&agrave;nh đ&agrave;o tạo.</p>

<p>Để x&acirc;y dựng phương &aacute;n tổ chức k&igrave; thi THPT quốc gia, với mục đ&iacute;ch của kỳ thi l&agrave; x&eacute;t c&ocirc;ng nh&acirc;n tốt nghiệp THPT v&agrave; l&agrave;m căn cứ để tuyển sinh v&agrave;o ĐH, CĐ, Bộ GD-ĐT đ&atilde; triển khai lấy &yacute; kiến đ&oacute;ng g&oacute;p rộng r&atilde;i của Hiệu trưởng c&aacute;c trường ĐH, CĐ; Gi&aacute;m đốc sở GD-ĐT; trường ĐH, CĐ; c&aacute;n bộ quản l&iacute;, gi&aacute;o vi&ecirc;n, học sinh trong cả nước....</p>

<p>Đa số c&aacute;c trường ĐH, CĐ đều thống nhất sử dụng kết quả kỳ thi THPT quốc gia để x&eacute;t tuyển sinh, kh&ocirc;ng tổ chức thi c&aacute;c m&ocirc;n m&agrave; th&iacute; sinh đ&atilde; c&oacute; kết quả ở kỳ thi n&agrave;y.</p>

<p>Tuy nhi&ecirc;n, t&ugrave;y thuộc v&agrave;o đặc th&ugrave; v&agrave; y&ecirc;u cầu của ng&agrave;nh đ&agrave;o tạo c&oacute; thể tổ chức thi năng khiếu, kiểm tra năng lực như: sơ tuyển, phỏng vấn, viết luận, kiểm tra IQ v&agrave; c&aacute;c h&igrave;nh thức ph&ugrave; hợp kh&aacute;c.</p>

<p>Chậm nhất ng&agrave;y 15/10/2014 c&aacute;c trường ĐH, CĐ c&ocirc;ng bố phương &aacute;n sử dụng kết quả kỳ thi để tuyển sinh, c&aacute;c th&iacute; sinh cần theo d&otilde;i th&ocirc;ng tin cụ thể để chủ động học, &ocirc;n tập v&agrave; định hướng lựa chọn ng&agrave;nh, trường để đăng k&iacute; dự thi.</p>

<p>Đối với c&aacute;c trường tổ chức thi theo Đề &aacute;n tuyển sinh ri&ecirc;ng, Bộ sẽ quy định cụ thể c&aacute;c đợt tuyển sinh ri&ecirc;ng trong Quy chế tuyển sinh. C&aacute;c trường c&ocirc;ng bố thời gian tổ chức thi trong Đề &aacute;n tuyển sinh ri&ecirc;ng của trường.</p>

<p><em>Ngo&agrave;i 8 m&ocirc;n thi của Bộ ấn định trong kỳ thi THPT quốc gia th&igrave; c&aacute;c trường ĐH, CĐ thi tuyển c&aacute;c m&ocirc;n năng khiếu như hội hoạ, m&uacute;a, h&aacute;t, diễn kịch, thể dục thể thao v&agrave;o thời điểm n&agrave;o?</em></p>

<p>Ngo&agrave;i việc sử dụng kết quả của k&igrave; thi THPT quốc gia để tuyển sinh, c&aacute;c trường ĐH, CĐ tuỳ thuộc c&aacute;c ng&agrave;nh đặc th&ugrave; của trường m&igrave;nh c&oacute; thể c&oacute; th&ecirc;m c&aacute;c h&igrave;nh thức kiểm tra năng lực kh&aacute;c.</p>

<p>Trong đ&oacute; c&aacute;c trường thuộc khối văn ho&aacute; nghệ thuật, thể dục <a href="http://www.tinmoi.vn/C/The-thao">thể thao</a>... sẽ tổ chức thi năng khiếu (việc n&agrave;y đ&atilde; được thực hiện trong những năm gần đ&acirc;y) theo phương thức được quy định r&otilde; trong Đề &aacute;n tuyển sinh ri&ecirc;ng của trường.</p>

<p>C&aacute;c trường c&oacute; c&aacute;c m&ocirc;n thi năng khiếu muốn sử dụng chung kết quả th&igrave; phải c&oacute; vă bản thỏa thuận phối hợp v&agrave; thể hiện trong Đề &aacute;n tuyển sinh ri&ecirc;ng của mỗi trường. C&aacute;c trường sẽ c&oacute; phương thức tổ chức thi tạo điều kiện thuận lợi nhất cho th&iacute; sinh v&agrave; phụ huynh. Th&iacute; sinh cần xem th&ocirc;ng tin chi tiết về Đề &aacute;n tuyển sinh ri&ecirc;ng của c&aacute;c trường được c&ocirc;ng bố rộng r&atilde;i tr&ecirc;n website của trường v&agrave; phương tiện truyền th&ocirc;ng kh&aacute;c trước 1/1 hằng năm.</p>

<p><strong>Mỗi th&iacute; sinh c&oacute; bao nhi&ecirc;u nguyện vọng?</strong></p>

<p><em>Bộ GD-ĐT c&oacute; quy định mỗi th&iacute; sinh được đăng k&yacute; bao nhi&ecirc;u nguyện vọng để dự tuyển v&agrave;o ĐH, CĐ kh&ocirc;ng?</em></p>

<p>Trước đ&acirc;y, khi chưa c&oacute; kết quả thi c&aacute;c em đ&atilde; đăng k&iacute; nguyện vọng n&ecirc;n dẫn đến t&igrave;nh trạng th&iacute; sinh ảo nhiều. Năm 2015, căn cứ v&agrave;o kết quả thi của th&iacute; sinh v&agrave; y&ecirc;u cầu x&eacute;t tuyển của c&aacute;c trường, Bộ sẽ x&acirc;y dựng phần mềm quản l&iacute; dữ liệu K&igrave; thi hỗ trợ đăng k&iacute; thi, đăng k&iacute; tuyển sinh với phương ch&acirc;m khắc phục những hạn chế ở c&aacute;c k&igrave; tuyển sinh năm trước, trong đ&oacute; c&oacute; t&igrave;nh trạng th&iacute; sinh ảo.</p>

<p>C&aacute;c trường ĐH, CĐ sử dụng kết quả K&igrave; thi để tuyển sinh sẽ tiến h&agrave;nh x&eacute;t tuyển trong 2 đến 3 đợt; trong mỗi đợt, mỗi th&iacute; sinh sẽ được đăng k&iacute; một số nguyện vọng (được quy định cụ thể trong Quy chế tuyển sinh ĐH, CĐ hệ ch&iacute;nh quy).</p>

<p>Việc x&eacute;t tuyển v&agrave;o ĐH, CĐ l&agrave; lấy điểm 4 m&ocirc;n thi tối thiểu để x&eacute;t hay tuỳ v&agrave;o trường ĐH, CĐ m&agrave; lựa chọn điểm của từng m&ocirc;n theo y&ecirc;u cầu để x&eacute;t tuyển?</p>

<p>Kết quả của 4 m&ocirc;n thi tối thiểu sẽ được sử dụng kết hợp với điểm trung b&igrave;nh học tập lớp 12 để x&eacute;t c&ocirc;ng nhận tốt nghiệp THPT cho tất cả th&iacute; sinh. Điểm c&aacute;c m&ocirc;n n&agrave;y đồng thời cũng được sử dụng để tuyển sinh v&agrave;o c&aacute;c ng&agrave;nh ph&ugrave; hợp của từng trường ĐH, CĐ.</p>

<p>C&ograve;n việc tuyển sinh v&agrave;o c&aacute;c trường ĐH, CĐ, c&aacute;c trường sẽ c&ocirc;ng bố c&ocirc;ng khai c&aacute;c m&ocirc;n thi tr&ecirc;n cơ sở c&aacute;c khối thi truyền thống. Đối với một số trường, ng&agrave;nh đặc th&ugrave; c&oacute; thể c&oacute; điều chỉnh, x&acirc;y dựng th&ecirc;m một số tổ hợp m&ocirc;n thi mới (khối thi); c&aacute;c trường sẽ c&ocirc;ng bố trước ng&agrave;y 15/10/2014 để th&iacute; sinh biết v&agrave; thực hiện.</p>

<p>Như vậy, để tham gia tuyển sinh ĐH, CĐ, ngo&agrave;i c&aacute;c m&ocirc;n đ&atilde; tr&ugrave;ng với c&aacute;c m&ocirc;n tối thiểu để x&eacute;t tốt nghiệp THPT, th&igrave; c&aacute;c em sẽ lựa chọn th&ecirc;m m&ocirc;n thi ph&ugrave; hợp để c&oacute; th&ecirc;m cơ hội v&agrave;o c&aacute;c trường ĐH, CĐ.</p>

<p><strong>Quy định về thi li&ecirc;n th&ocirc;ng, đăng k&yacute; dự thi lại</strong></p>

<p><em>Bộ GD-ĐT c&oacute; quy định g&igrave; d&agrave;nh cho th&iacute; sinh thi li&ecirc;n th&ocirc;ng (chưa đủ 36 th&aacute;ng sau khi tốt nghiệp) tham dự K&igrave; thi?</em></p>

<p>Thi li&ecirc;n th&ocirc;ng được quy định trong Th&ocirc;ng tư số 55/2012/TT-BGDĐT ng&agrave;y 25/12/2012. Những th&iacute; sinh c&oacute; bằng tốt nghiệp TCCN, CĐ chưa đủ 36 th&aacute;ng th&igrave; dự thi kỳ thi THPT quốc gia nhưng chỉ cần đăng k&yacute; thi những m&ocirc;n cần thiết để x&eacute;t v&agrave;o c&aacute;c ng&agrave;nh của trường ĐH, CĐ lựa chọn.</p>

<p>Hiện nay, chưa c&oacute; quy định n&agrave;o về vấn đề ưu ti&ecirc;n cho th&iacute; sinh thuộc nh&oacute;m n&agrave;y.</p>

<p><em>Theo th&ocirc;ng lệ, th&iacute; sinh tham dự k&igrave; thi tốt nghiệp THPT th&igrave; kh&ocirc;ng phải đ&oacute;ng lệ ph&iacute;, th&iacute; sinh thi ĐH, CĐ phải đ&oacute;ng lệ ph&iacute;; vậy c&aacute;c th&iacute; sinh tham dự K&igrave; thi THPT quốc gia từ năm 2015 c&oacute; phải đ&oacute;ng lệ ph&iacute; kh&ocirc;ng?</em></p>

<p>Những học sinh đăng k&iacute; dự thi chỉ để x&eacute;t tốt nghiệp THPT sẽ kh&ocirc;ng phải nộp lệ ph&iacute;, c&ograve;n những học sinh đăng k&iacute; dự thi để vừa x&eacute;t tốt nghiệp THPT vừa x&eacute;t tuyển v&agrave;o c&aacute;c trường ĐH, CĐ phải nộp lệ ph&iacute;. Những nội dung ch&iacute;nh về c&ocirc;ng t&aacute;c tổ chức K&igrave; thi THPT quốc gia đ&atilde; được Bộ c&ocirc;ng bố. Những vấn đề c&ograve;n lại mang t&iacute;nh kĩ thuật của kỳ thi n&agrave;y sẽ được đưa v&agrave;o quy chế v&agrave; c&aacute;c văn bản hướng dẫn m&agrave; Bộ sẽ c&ocirc;ng bố để th&iacute; sinh v&agrave; to&agrave;n x&atilde; hội biết.</p>

<p><em>Những th&iacute; sinh thi tại cụm thi do sở GD-ĐT chủ tr&igrave; v&agrave; được cấp bằng tốt nghiệp THPT năm 2015 c&oacute; được tham dự K&igrave; thi THPT quốc gia năm 2016 để x&eacute;t tuyển sinh v&agrave;o ĐH, CĐ kh&ocirc;ng? Nếu được th&igrave; sẽ phải thi những m&ocirc;n thi n&agrave;o?</em></p>

<p>Những th&iacute; sinh được cấp bằng tốt nghiệp THPT của K&igrave; thi THPT quốc gia năm 2015, được tham dự K&igrave; thi THPT quốc gia năm 2016 để x&eacute;t tuyển sinh v&agrave;o ĐH, CĐ. Những th&iacute; sinh n&agrave;y kh&ocirc;ng phải dự thi cả 4 m&ocirc;n thi tối thiểu của K&igrave; thi để x&eacute;t c&ocirc;ng nhận tốt nghiệp, m&agrave; chỉ đăng k&iacute; thi những m&ocirc;n thi ph&ugrave; hợp với ng&agrave;nh đ&agrave;o tạo của trường ĐH, CĐ phục vụ cho tuyển sinh.</p>

<p>V&iacute; dụ: th&iacute; sinh thi v&agrave;o trường ĐH, CĐ m&agrave; trường c&ocirc;ng bố phương thức tuyển sinh c&aacute;c m&ocirc;n tương ứng với khối A th&igrave; th&iacute; sinh chỉ đăng k&iacute; dự thi 3 m&ocirc;n: To&aacute;n, Vật l&iacute;, Ho&aacute; học. Như vậy, th&iacute; sinh cần theo d&otilde;i th&ocirc;ng tin cụ thể về điều kiện tuyển sinh của trường ĐH, CĐ m&agrave; m&igrave;nh c&oacute; nguyện vọng x&eacute;t tuyển để đăng k&iacute; dự thi c&aacute;c m&ocirc;n ph&ugrave; hợp.</p>

<p><strong>(Nguồn: Bộ GD-ĐT)</strong></p>
', N'Admin', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblNews] ([Id], [Title], [Image], [News], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (11, N'Hai trường ĐH đầu tiên công bố phương án tuyển sinh riêng năm 2015', N'tuyen-sinh-rieng-hoa.jpg', N'2132', N'Admin', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblNews] OFF
SET IDENTITY_INSERT [dbo].[tblPerson] ON 

INSERT [dbo].[tblPerson] ([Id], [Code], [Name], [LastName], [Sex], [DateOfBirth], [Address], [PhoneNumber], [Email], [Occupation], [DegreeId], [SchoolId], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'1', N'Hà', N'Lê Văn', 1, CAST(0x0000841200000000 AS DateTime), N'Kim Nỗ', N'01663729680', N'halvd5tin@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, N'admin', CAST(0x0000A3C2008C204B AS DateTime), NULL)
INSERT [dbo].[tblPerson] ([Id], [Code], [Name], [LastName], [Sex], [DateOfBirth], [Address], [PhoneNumber], [Email], [Occupation], [DegreeId], [SchoolId], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'vanha', N'Hà', N'Lê Văn', 1, CAST(0x0000841200000000 AS DateTime), N'Đông Anh -Hà Nội', N'01663729680', N'vanha@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, N'vanha', CAST(0x0000A3C1013E36AA AS DateTime), NULL)
INSERT [dbo].[tblPerson] ([Id], [Code], [Name], [LastName], [Sex], [DateOfBirth], [Address], [PhoneNumber], [Email], [Occupation], [DegreeId], [SchoolId], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1004, N'dasdas', NULL, NULL, NULL, NULL, NULL, NULL, N'am@yahoo.com', NULL, NULL, NULL, NULL, N'dasdas', CAST(0x0000A3FC01053EFF AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblPerson] OFF
SET IDENTITY_INSERT [dbo].[tblQuestion] ON 

INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, N'6', 13, 1, N'<p>Trong dao động điều h&ograve;a, gia tốc biến đổi</p>', N'B', N'Lực tác dụng có độ lớn cực tiểu.', N'Lực tác dụng bằng không', N'Lực tác dụng có độ lớn cực đại', N'Lực tác dụng đổi chiều', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, N'7', 13, 1, N'Trong dao động điều hòa, độ lớn gia tốc của vật', N'C', N'Tăng khi độ lớn vận tốc tăng.', N'Không thay đổi.', N'Giảm khi độ lớn vận tốc tăng.', N'Bằng 0 khi vận tốc bằng 0.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (21, N'21', 3, 1, N'<p>câu 1: Nghiên C&#7913;u M&#7897;t Qu&#7847;n Th&#7875;
&#273;&#7897;ng V&#7853;t Cho Th&#7845;y &#7903; Th&#7901;i &#273;i&#7875;m Ban
&#273;&#7847;u Có 11000 Cá Th&#7875;. Qu&#7847;n Th&#7875; Này Có T&#7881; L&#7879;
sinh Là 12% /n&#259;m, T&#7881; L&#7879; T&#7917; Vong Là 8% /n&#259;m Và T&#7881;
l&#7879; Xu&#7845;t C&#432; Là 2% /n&#259;m. Sau M&#7897;t N&#259;m, S&#7889;
l&#432;&#7907;ng Cá Th&#7875; Trong Qu&#7847;n Th&#7875; &#273;ó &#273;&#432;&#7907;c
d&#7921; &#273;oán Là:</p>', N'A', N'<p><span>a.<span>&nbsp; </span></span><span>11180.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>11020.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>11220.</span></p>', N'<p>d.<span>&nbsp; </span><span>11260.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (22, N'22', 3, 1, N'<p>câu 2: &#7902; Th&#7887;: Gen A Qui &#273;&#7883;nh Lông
&#273;en Tr&#7897;i Hoàn Toàn So V&#7899;i Gen A Qui &#273;&#7883;nh Lông Tr&#7855;ng,
trong M&#7897;t Qu&#7847;n Th&#7875; Th&#7887; &#273;ang &#7903; Tr&#7841;ng
thái Cân B&#7857;ng Có 27 Con Th&#7887; Lông Tr&#7855;ng, Chi&#7871;m 9% T&#7893;ng
s&#7889; Cá Th&#7875; C&#7911;a &#273;àn. S&#7889; Cá Th&#7875; Có Ki&#7875;u
gen &#273;&#7891;ng H&#7907;p Tr&#7897;i Lông &#273;en Trong Qu&#7847;n Th&#7875;
th&#7887; Là:</p>', N'B', N'<p><span>a.<span>&nbsp; </span></span><span>126
cá Th&#7875;.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>273
cá Th&#7875;.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>147
cá Th&#7875;.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>150
cá Th&#7875;.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (23, N'23', 3, 2, N'<p><span>câu 3: </span>&#272;i&#7873;u Ki&#7879;n Nghi&#7879;m
&#273;úng C&#7911;a &#273;&#7883;nh Lu&#7853;t Hac&#273;i - Vanbec Là:</p>', N'C', N'<p><span>a.<span>&nbsp; </span></span><span>qu&#7847;n
th&#7875; Có S&#7889; L&#432;&#7907;ng Cá Th&#7875; L&#7899;n.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>qu&#7847;n
th&#7875; Giao Ph&#7889;i Ng&#7851;u Nhiên.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>không
có Ch&#7885;n L&#7885;c Và &#273;&#7897;t Bi&#7871;n.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>qu&#7847;n
th&#7875; Có S&#7889; L&#432;&#7907;ng Cá Th&#7875; L&#7899;n.qu&#7847;n
th&#7875; Giao Ph&#7889;i Ng&#7851;u Nhiên.không Có Ch&#7885;n L&#7885;c Và
&#273;&#7897;t Bi&#7871;n.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (24, N'24', 3, 1, N'<p><span>câu 4: </span>qu&#7847;n Th&#7875; Giao Ph&#7889;i
khác Qu&#7847;n Th&#7875; T&#7921; Ph&#7889;i:</p>', N'D', N'<p><span>a.<span>&nbsp; </span></span><span>&#7903;
qu&#7847;n Th&#7875; Giao Ph&#7889;i Th&#432;&#7901;ng Nhi&#7873;u Cá Th&#7875;
h&#417;n.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>&#7903;
qu&#7847;n Th&#7875; Giao Ph&#7889;i T&#7847;n S&#7889; Các Alen Không Thay
&#273;&#7893;i.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>&#7903;
qu&#7847;n Th&#7875; Giao Ph&#7889;i Ngoài M&#7889;i Quan H&#7879; V&#7873;
dinh D&#432;&#7905;ng, N&#417;i &#7903;, Còn Có M&#7889;i Quan H&#7879;
&#273;&#7921;c Cái.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>&#7903;
qu&#7847;n Th&#7875; Giao Ph&#7889;i Các Cá Th&#7875; Khác Nhau H&#417;n.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (25, N'25', 3, 2, N'<p><span>câu 5: </span>m&#7897;t Qu&#7847;n Th&#7875; Th&#7921;c
v&#7853;t T&#7921; Th&#7909; Ph&#7845;n Có T&#7881; L&#7879; Ki&#7875;u Gen &#7903;
th&#7871; H&#7879; P Là 0,45aa : 0,30aa : 0,25aa. Cho Bi&#7871;t Các Cá Th&#7875;
có Ki&#7875;u Gen Aa Không Có Kh&#7843; N&#259;ng Sinh S&#7843;n. Tính Theo Lí
thuy&#7871;t, T&#7881; L&#7879; Các Ki&#7875;u Gen Thu &#273;&#432;&#7907;c &#7903;
f<sub>1</sub> Là:</p>', N'A', N'<p><span>a.<span>&nbsp; </span></span><span>0,525aa
: 0,150aa : 0,325aa.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>0,36aa
: 0,24aa : 0,40aa.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>0,36aa
: 0,48aa : 0,16aa.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>0,70aa
: 0,20aa : 0,10aa.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (26, N'26', 3, 3, N'<p><span>câu 6: </span>trong M&#7897;t S&#7889; Nhóm Ng&#432;&#7901;i
s&#7889;ng &#7903; Châu Phi, Có Kho&#7843;ng 4% S&#7889; Ng&#432;&#7901;i Ch&#7871;t
vì B&#7879;nh S&#7889;t Rét. Gi&#7843; S&#7917; Qu&#7847;n Th&#7875; Ng&#432;&#7901;i
&#273;&#7841;t Tr&#7841;ng Thái Cân B&#7857;ng Hac&#273;i - Vanbec, Nh&#7919;ng
ng&#432;&#7901;i Ch&#7889;ng &#273;&#432;&#7907;c B&#7879;nh S&#7889;t Rét
trong Qu&#7847;n Th&#7875; &#273;ó Có T&#7881; L&#7879; Là:</p>', N'A', N'<p><span>a.<span>&nbsp; </span></span><span>4%.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>8%.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>16%.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>32%.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (27, N'27', 3, 1, N'<p><span>câu 7: </span>trong M&#7897;t Qu&#7847;n Th&#7875;
th&#7921;c V&#7853;t, T&#7847;n S&#7889; T&#432;&#417;ng &#273;&#7889;i C&#7911;a
alen A Là 0,6; Alen A Là 0,4. Qu&#7847;n Th&#7875; &#273;ó Có C&#7845;u Trúc Di
truy&#7873;n &#7903; Tr&#7841;ng Thái Cân B&#7857;ng Là:</p>', N'B', N'<p><span>a.<span>&nbsp; </span></span><span>0,34aa
: 0,48aa : 0,18aa.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>0,36aa
: 0,48aa : 0,16aa.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>0,32aa
: 0,48aa : 0,20aa.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>0,38aa
: 0,48aa : 0,14aa.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (28, N'28', 3, 1, N'<p><span>câu 8: </span>t&#7847;n S&#7889; T&#432;&#417;ng
&#273;&#7889;i C&#7911;a M&#7897;t Ki&#7875;u Gen Nào &#273;ó Trong Qu&#7847;n
th&#7875; Là T&#7881; L&#7879; Ph&#7847;n Tr&#259;m C&#7911;a:</p>', N'D', N'<p><span>a.<span>&nbsp; </span></span><span>s&#7889;
cá Th&#7875; Có Ki&#7875;u Gen &#273;ó Trong Qu&#7847;n Th&#7875;.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>s&#7889;
ki&#7875;u Hình C&#7911;a Ki&#7875;u Gen &#273;ó Trong Qu&#7847;n Th&#7875;.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>s&#7889;
cá Th&#7875; Cùng &#273;&#7897; Tu&#7893;i Có Ki&#7875;u Gen &#273;ó Trong
qu&#7847;n Th&#7875;.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>s&#7889;
cá Th&#7875; &#273;&#7921;c Có Ki&#7875;u Gen &#273;ó Trong Qu&#7847;n
th&#7875;.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (29, N'29', 3, 2, N'<p>câu 9: <em><span>&quot;g&#7885;i
p, Q, R L&#7847;n L&#432;&#7907;t Là T&#7847;n S&#7889; Các Alen I<sup>a</sup>,
i<sup>b</sup>, I<sup>0</sup> Quy &#273;&#7883;nh Các Nhóm Máu. Khi &#273;&#7841;t
tr&#7841;ng Thái Cân B&#7857;ng Di Truy&#7873;n Thì:&quot;. </span></em>t&#7847;n
s&#7889; T&#432;&#417;ng &#273;&#7889;i Alen I<sup>0</sup> C&#7911;a Qu&#7847;n
th&#7875; Là:</p>', N'C', N'<p>a.<span>&nbsp; </span>r<sup>2</sup>
+ 2qr + Q<sup>2</sup></p>', N'<p>b.<span>&nbsp;
</span>r<sup>2</sup> + 2pr</p>', N'<p>c.<span>&nbsp;
</span>r<sup>2</sup> + 2pq</p>', N'<p>d.<span>&nbsp; </span>pr +
qr +r<sup>2</sup></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (30, N'30', 3, 3, N'<p>câu 10: &#7902; M&#7897;t Qu&#7847;n Th&#7875; Sau Khi Tr&#7843;i
qua 3 Th&#7871; H&#7879; T&#7921; Ph&#7889;i, T&#7881; L&#7879; C&#7911;a Th&#7875;
d&#7883; H&#7907;p Trong Qu&#7847;n Th&#7875; B&#7857;ng 8%. Bi&#7871;t R&#7857;ng
&#7903; Th&#7871; H&#7879; P, Qu&#7847;n Th&#7875; Có 20% S&#7889; Cá Th&#7875;
&#273;&#7891;ng H&#7907;p Tr&#7897;i Và Cánh Dài Là Tính Tr&#7897;i Hoàn Toàn
so V&#7899;i Cánh Ng&#7855;n. Hãy Cho Bi&#7871;t Tr&#432;&#7899;c Khi X&#7843;y
ra Quá Trình T&#7921; Ph&#7889;i, T&#7927; L&#7879; Ki&#7875;u Hình Nào Sau
&#273;ây Là C&#7911;a Qu&#7847;n Th&#7875; Trên?</p>', N'D', N'<p><span>a.<span>&nbsp; </span></span><span>36%
cánh Dài : 64% Cánh Ng&#7855;n.</span></p>', N'<p><span>b.<span>&nbsp; </span></span><span>64%
cánh Dài : 36% Cánh Ng&#7855;n.</span></p>', N'<p><span>c.<span>&nbsp; </span></span><span>16%
cánh Dài : 84% Cánh Ng&#7855;n.</span></p>', N'<p><span>d.<span>&nbsp; </span></span><span>84%
cánh Dài : 16% Cánh Ng&#7855;n.</span></p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (31, N'31', 21, 1, NULL, N'D', N'bush<u>es</u>', N'wish<u>es</u>', N'research<u>es</u>', N'headach<u>es</u>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (32, N'32', 21, 2, NULL, N'C', N'de<u>b</u>t', N'clim<u>b</u>ing', N' tim<u>b</u>er', N'lam<u>b</u>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (36, N'36', 21, 3, NULL, N'D', N'enou<u>gh</u>', N'cou<u>gh</u>', N'thorou<u>gh</u>', N'tou<u>gh</u>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (37, N'37', 22, 2, N'Generally, the South of England is as ______ as the North.', N'A', N'flat', N'less flat', N'flatter', N'the flattest', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblQuestion] ([Id], [Code], [CategoryId], [LevelId], [Contents], [Answer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerDetail], [SuggestionId], [ModifiedCount], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (38, N'38', 22, 2, N'Helen is traveling to Germany tomorrow on her first working trip and she is very excited ______ it.', N'C', N'for', N'against', N'about', N'with', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblQuestion] OFF
SET IDENTITY_INSERT [dbo].[tblStatusAccount] ON 

INSERT [dbo].[tblStatusAccount] ([Id], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'Bình Thường', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblStatusAccount] ([Id], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'Chưa Xác Nhận Email', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblStatusAccount] ([Id], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (3, N'Chưa Cập Nhật Thông Tin Tài Khoản', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblStatusAccount] ([Id], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (4, N'Cần Thay Đổi Mật Khẩu', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblStatusAccount] ([Id], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (5, N'Tài Khoản Bị Khóa', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblStatusAccount] OFF
SET IDENTITY_INSERT [dbo].[tblStructContent] ON 

INSERT [dbo].[tblStructContent] ([Id], [Code], [ExamStructId], [CategoryId], [EasyNumber], [AverageNumber], [HardNumber], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'1', 1, 3, 4, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblStructContent] OFF
SET IDENTITY_INSERT [dbo].[tblSubtest] ON 

INSERT [dbo].[tblSubtest] ([Id], [Code], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (1, N'1', N'Hóa Học', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblSubtest] ([Id], [Code], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (2, N'2', N'Vật Lý', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblSubtest] ([Id], [Code], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (3, N'3', N'Sinh Học', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblSubtest] ([Id], [Code], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ModifiedCount]) VALUES (4, N'4', N'Tiếng Anh', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblSubtest] OFF
ALTER TABLE [dbo].[tblAccount] ADD  CONSTRAINT [DF_tblAcount_EmailStatus]  DEFAULT ((0)) FOR [StatusAccountId]
GO
ALTER TABLE [dbo].[tblAccount] ADD  CONSTRAINT [DF_tblAcount_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblGroupAcount] FOREIGN KEY([GroupAcountId])
REFERENCES [dbo].[tblGroupAcount] ([Id])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblGroupAcount]
GO
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblPerson] FOREIGN KEY([PersonId])
REFERENCES [dbo].[tblPerson] ([Id])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblPerson]
GO
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblAccount_tblStatusAccount] FOREIGN KEY([StatusAccountId])
REFERENCES [dbo].[tblStatusAccount] ([Id])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK_tblAccount_tblStatusAccount]
GO
ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblCategory_tblSubtest] FOREIGN KEY([SubtestId])
REFERENCES [dbo].[tblSubtest] ([Id])
GO
ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK_tblCategory_tblSubtest]
GO
ALTER TABLE [dbo].[tblChallenge]  WITH CHECK ADD  CONSTRAINT [FK_tblChallenge_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tblChallenge] CHECK CONSTRAINT [FK_tblChallenge_tblCategory]
GO
ALTER TABLE [dbo].[tblChallenge]  WITH CHECK ADD  CONSTRAINT [FK_tblChallenge_tblExamQuestion] FOREIGN KEY([ExamQuestionId])
REFERENCES [dbo].[tblExamQuestion] ([Id])
GO
ALTER TABLE [dbo].[tblChallenge] CHECK CONSTRAINT [FK_tblChallenge_tblExamQuestion]
GO
ALTER TABLE [dbo].[tblChallenge]  WITH CHECK ADD  CONSTRAINT [FK_tblChallenge_tblForm] FOREIGN KEY([FormId])
REFERENCES [dbo].[tblForm] ([Id])
GO
ALTER TABLE [dbo].[tblChallenge] CHECK CONSTRAINT [FK_tblChallenge_tblForm]
GO
ALTER TABLE [dbo].[tblExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_tblExamQuestion_tblExamStruct] FOREIGN KEY([ExamStructId])
REFERENCES [dbo].[tblExamStruct] ([Id])
GO
ALTER TABLE [dbo].[tblExamQuestion] CHECK CONSTRAINT [FK_tblExamQuestion_tblExamStruct]
GO
ALTER TABLE [dbo].[tblExamStruct]  WITH CHECK ADD  CONSTRAINT [FK_tblExamStruct_tblForm] FOREIGN KEY([FormId])
REFERENCES [dbo].[tblForm] ([Id])
GO
ALTER TABLE [dbo].[tblExamStruct] CHECK CONSTRAINT [FK_tblExamStruct_tblForm]
GO
ALTER TABLE [dbo].[tblExamStruct]  WITH CHECK ADD  CONSTRAINT [FK_tblExamStruct_tblSubtest] FOREIGN KEY([SubtestId])
REFERENCES [dbo].[tblSubtest] ([Id])
GO
ALTER TABLE [dbo].[tblExamStruct] CHECK CONSTRAINT [FK_tblExamStruct_tblSubtest]
GO
ALTER TABLE [dbo].[tblPerson]  WITH CHECK ADD  CONSTRAINT [FK_Person_Degree] FOREIGN KEY([DegreeId])
REFERENCES [dbo].[tblDegree] ([Id])
GO
ALTER TABLE [dbo].[tblPerson] CHECK CONSTRAINT [FK_Person_Degree]
GO
ALTER TABLE [dbo].[tblPerson]  WITH CHECK ADD  CONSTRAINT [FK_Person_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[tblSchool] ([Id])
GO
ALTER TABLE [dbo].[tblPerson] CHECK CONSTRAINT [FK_Person_School]
GO
ALTER TABLE [dbo].[tblQuestion]  WITH CHECK ADD  CONSTRAINT [FK_tblQuestion_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tblQuestion] CHECK CONSTRAINT [FK_tblQuestion_tblCategory]
GO
ALTER TABLE [dbo].[tblQuestion]  WITH CHECK ADD  CONSTRAINT [FK_tblQuestion_tblLevel] FOREIGN KEY([LevelId])
REFERENCES [dbo].[tblLevel] ([Id])
GO
ALTER TABLE [dbo].[tblQuestion] CHECK CONSTRAINT [FK_tblQuestion_tblLevel]
GO
ALTER TABLE [dbo].[tblQuestion]  WITH CHECK ADD  CONSTRAINT [FK_tblQuestion_tblSuggestion] FOREIGN KEY([SuggestionId])
REFERENCES [dbo].[tblSuggestion] ([Id])
GO
ALTER TABLE [dbo].[tblQuestion] CHECK CONSTRAINT [FK_tblQuestion_tblSuggestion]
GO
ALTER TABLE [dbo].[tblResult]  WITH CHECK ADD  CONSTRAINT [FK_tblResult_tblAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[tblAccount] ([Id])
GO
ALTER TABLE [dbo].[tblResult] CHECK CONSTRAINT [FK_tblResult_tblAccount]
GO
ALTER TABLE [dbo].[tblResult]  WITH CHECK ADD  CONSTRAINT [FK_tblResult_tblExamQuestion] FOREIGN KEY([ExamQuestionId])
REFERENCES [dbo].[tblExamQuestion] ([Id])
GO
ALTER TABLE [dbo].[tblResult] CHECK CONSTRAINT [FK_tblResult_tblExamQuestion]
GO
ALTER TABLE [dbo].[tblSchool]  WITH CHECK ADD  CONSTRAINT [FK_School_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[tblArea] ([Id])
GO
ALTER TABLE [dbo].[tblSchool] CHECK CONSTRAINT [FK_School_Area]
GO
ALTER TABLE [dbo].[tblSchool]  WITH CHECK ADD  CONSTRAINT [FK_School_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[tblCountry] ([Id])
GO
ALTER TABLE [dbo].[tblSchool] CHECK CONSTRAINT [FK_School_Country]
GO
ALTER TABLE [dbo].[tblSchool]  WITH CHECK ADD  CONSTRAINT [FK_School_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[tblDistrict] ([Id])
GO
ALTER TABLE [dbo].[tblSchool] CHECK CONSTRAINT [FK_School_District]
GO
ALTER TABLE [dbo].[tblStructContent]  WITH CHECK ADD  CONSTRAINT [FK_tblStructContent_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tblStructContent] CHECK CONSTRAINT [FK_tblStructContent_tblCategory]
GO
ALTER TABLE [dbo].[tblStructContent]  WITH CHECK ADD  CONSTRAINT [FK_tblStructContent_tblExamStruct] FOREIGN KEY([ExamStructId])
REFERENCES [dbo].[tblExamStruct] ([Id])
GO
ALTER TABLE [dbo].[tblStructContent] CHECK CONSTRAINT [FK_tblStructContent_tblExamStruct]
GO
USE [master]
GO
ALTER DATABASE [EUT] SET  READ_WRITE 
GO
