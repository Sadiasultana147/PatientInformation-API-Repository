USE [master]
GO
/****** Object:  Database [ExcelTechnologies]    Script Date: 2/11/2024 11:41:40 PM ******/
CREATE DATABASE [ExcelTechnologies]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExcelTechnologies', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExcelTechnologies.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExcelTechnologies_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExcelTechnologies_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ExcelTechnologies] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExcelTechnologies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExcelTechnologies] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ExcelTechnologies] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExcelTechnologies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExcelTechnologies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ExcelTechnologies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExcelTechnologies] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExcelTechnologies] SET  MULTI_USER 
GO
ALTER DATABASE [ExcelTechnologies] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExcelTechnologies] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExcelTechnologies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExcelTechnologies] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExcelTechnologies] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExcelTechnologies] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ExcelTechnologies] SET QUERY_STORE = OFF
GO
USE [ExcelTechnologies]
GO
/****** Object:  Table [dbo].[Allergies]    Script Date: 2/11/2024 11:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[AllergiesID] [int] IDENTITY(1,1) NOT NULL,
	[AllergiesName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AllergiesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies_Details]    Script Date: 2/11/2024 11:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[AllergiesID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiseaseInformation]    Script Date: 2/11/2024 11:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseInformation](
	[DiseaseID] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DiseaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCD]    Script Date: 2/11/2024 11:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCD](
	[NCDID] [int] IDENTITY(1,1) NOT NULL,
	[NCDName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NCDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCD_Details]    Script Date: 2/11/2024 11:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCD_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[NCDID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientsInformation]    Script Date: 2/11/2024 11:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientsInformation](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [nvarchar](150) NOT NULL,
	[DiseaseID] [int] NOT NULL,
	[NCDID] [nvarchar](100) NULL,
	[AllergiesID] [nvarchar](100) NULL,
	[Epilepsy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 

INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (1, N'Drugs- Penicilium')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (2, N'Drug- Others')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (3, N'Animals')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (4, N'Food')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (5, N'Oinments')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (6, N'Plants')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (7, N'Sprays')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (8, N'Others')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (9, N'No Allergies')
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[Allergies_Details] ON 

INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (1, 1, 3)
INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (2, 1, 5)
INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (6, 3, 3)
INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (7, 7, 2)
SET IDENTITY_INSERT [dbo].[Allergies_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[DiseaseInformation] ON 

INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (1, N'Influenza')
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (2, N'Diabetes mellitus')
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (3, N'Hypertension')
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (4, N'Coronary artery disease')
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (5, N'Alzheimer''s disease')
SET IDENTITY_INSERT [dbo].[DiseaseInformation] OFF
GO
SET IDENTITY_INSERT [dbo].[NCD] ON 

INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (1, N'Asthma')
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (2, N'Cancer')
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (3, N'Disorder of eye')
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (4, N'Disorder of ear')
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (5, N'Mentall Illness')
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (6, N'Oral Health Problems')
SET IDENTITY_INSERT [dbo].[NCD] OFF
GO
SET IDENTITY_INSERT [dbo].[NCD_Details] ON 

INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (1, 1, 1)
INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (2, 1, 2)
INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (3, 1, 4)
INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (6, 3, 5)
INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (7, 7, 1)
SET IDENTITY_INSERT [dbo].[NCD_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientsInformation] ON 

INSERT [dbo].[PatientsInformation] ([PatientID], [PatientName], [DiseaseID], [NCDID], [AllergiesID], [Epilepsy]) VALUES (1, N'Rafiquer Rahman', 1, N'1,2,4', N'3,5', N'No')
INSERT [dbo].[PatientsInformation] ([PatientID], [PatientName], [DiseaseID], [NCDID], [AllergiesID], [Epilepsy]) VALUES (3, N'Shamim', 3, N'5', N'3', N'No')
INSERT [dbo].[PatientsInformation] ([PatientID], [PatientName], [DiseaseID], [NCDID], [AllergiesID], [Epilepsy]) VALUES (4, N'Munia Rahman', 2, N'', N'', N'Yes')
INSERT [dbo].[PatientsInformation] ([PatientID], [PatientName], [DiseaseID], [NCDID], [AllergiesID], [Epilepsy]) VALUES (6, N'Munia Rahman', 2, N'', N'', N'Yes')
INSERT [dbo].[PatientsInformation] ([PatientID], [PatientName], [DiseaseID], [NCDID], [AllergiesID], [Epilepsy]) VALUES (7, N'Munia Rahman', 2, N'1', N'2', N'Yes')
INSERT [dbo].[PatientsInformation] ([PatientID], [PatientName], [DiseaseID], [NCDID], [AllergiesID], [Epilepsy]) VALUES (8, N'Test', 2, N'', N'', N'Yes')
SET IDENTITY_INSERT [dbo].[PatientsInformation] OFF
GO
ALTER TABLE [dbo].[Allergies_Details]  WITH CHECK ADD FOREIGN KEY([AllergiesID])
REFERENCES [dbo].[Allergies] ([AllergiesID])
GO
ALTER TABLE [dbo].[Allergies_Details]  WITH CHECK ADD FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientsInformation] ([PatientID])
GO
ALTER TABLE [dbo].[NCD_Details]  WITH CHECK ADD FOREIGN KEY([NCDID])
REFERENCES [dbo].[NCD] ([NCDID])
GO
ALTER TABLE [dbo].[NCD_Details]  WITH CHECK ADD FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientsInformation] ([PatientID])
GO
ALTER TABLE [dbo].[PatientsInformation]  WITH CHECK ADD FOREIGN KEY([DiseaseID])
REFERENCES [dbo].[DiseaseInformation] ([DiseaseID])
GO
USE [master]
GO
ALTER DATABASE [ExcelTechnologies] SET  READ_WRITE 
GO
