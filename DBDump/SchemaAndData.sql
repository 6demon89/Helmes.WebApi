USE [master]
GO
/****** Object:  Database [HelmesTask]    Script Date: 2/20/2022 9:40:43 PM ******/
CREATE DATABASE [HelmesTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HelmesTask', FILENAME = N'C:\Users\Demon\HelmesTask.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HelmesTask_log', FILENAME = N'C:\Users\Demon\HelmesTask_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HelmesTask] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HelmesTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HelmesTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HelmesTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HelmesTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HelmesTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HelmesTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [HelmesTask] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HelmesTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HelmesTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HelmesTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HelmesTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HelmesTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HelmesTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HelmesTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HelmesTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HelmesTask] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HelmesTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HelmesTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HelmesTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HelmesTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HelmesTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HelmesTask] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HelmesTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HelmesTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HelmesTask] SET  MULTI_USER 
GO
ALTER DATABASE [HelmesTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HelmesTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HelmesTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HelmesTask] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HelmesTask] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HelmesTask] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HelmesTask] SET QUERY_STORE = OFF
GO
USE [HelmesTask]
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 2/20/2022 9:40:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sectors](
	[SectorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ParentSectorID] [int] NULL,
 CONSTRAINT [PK_Sectors] PRIMARY KEY CLUSTERED 
(
	[SectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SectorsUser]    Script Date: 2/20/2022 9:40:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SectorsUser](
	[SectorsSectorID] [int] NOT NULL,
	[UsersID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SectorsUser] PRIMARY KEY CLUSTERED 
(
	[SectorsSectorID] ASC,
	[UsersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/20/2022 9:40:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[AgreedToTerms] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sectors] ON 

INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (1, N'Manufacturing', NULL)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (2, N'Service', NULL)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (3, N'Other', NULL)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (5, N'Printing ', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (6, N'Food and Beverage', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (7, N'Textile and Clothing', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (8, N'Wood', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (9, N'Plastic and Rubber', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (11, N'Metalworking', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (12, N'Machinery', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (13, N'Furniture', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (18, N'Electronics and Optics', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (19, N'Construction materials', 1)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (21, N'Transport and Logistics', 2)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (22, N'Tourism', 2)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (25, N'Business services', 2)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (28, N'Information Technology and Telecommunications', 2)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (29, N'Energy technology', 3)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (33, N'Environment', 3)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (35, N'Engineering', 2)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (37, N'Creative industries', 3)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (39, N'Milk & dairy products ', 6)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (40, N'Meat & meat products', 6)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (42, N'Fish & fish products ', 6)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (43, N'Beverages', 6)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (44, N'Clothing', 7)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (45, N'Textile', 7)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (47, N'Wooden houses', 8)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (51, N'Wooden building materials', 8)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (53, N'Plastics welding and processing', 559)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (54, N'Packaging', 9)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (55, N'Blowing', 559)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (57, N'Moulding', 559)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (62, N'Forgings, Fasteners ', 542)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (66, N'MIG, TIG, Aluminum welding', 542)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (67, N'Construction of metal structures', 11)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (69, N'Gas, Plasma, Laser cutting', 542)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (75, N'CNC-machining', 542)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (91, N'Machinery equipment/tools', 12)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (93, N'Metal structures', 12)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (94, N'Machinery components', 12)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (97, N'Maritime', 12)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (98, N'Kitchen ', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (99, N'Project furniture', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (101, N'Living room ', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (111, N'Air', 21)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (112, N'Road', 21)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (113, N'Water', 21)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (114, N'Rail', 21)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (121, N'Software, Hardware', 28)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (122, N'Telecommunications', 28)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (141, N'Translation services', 2)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (145, N'Labelling and packaging printing', 5)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (148, N'Advertising', 5)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (150, N'Book/Periodicals printing', 5)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (224, N'Manufacture of machinery ', 12)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (227, N'Repair and maintenance service', 12)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (230, N'Ship repair and conversion', 97)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (263, N'Houses and buildings', 11)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (267, N'Metal products', 11)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (269, N'Boat/Yacht building', 97)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (271, N'Aluminium and steel workboats ', 97)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (337, N'Other (Wood)', 8)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (341, N'Outdoor ', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (342, N'Bakery &  confectionery products', 6)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (378, N'Sweets & snack food', 6)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (385, N'Bedroom', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (389, N'Bathroom/sauna ', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (390, N'Children’s room ', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (392, N'Office', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (394, N'Other (Furniture)', 13)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (437, N'Other', 6)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (508, N'Other', 12)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (542, N'Metal works', 11)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (556, N'Plastic goods', 9)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (559, N'Plastic processing technology', 9)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (560, N'Plastic profiles', 9)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (576, N'Programming, Consultancy', 28)
INSERT [dbo].[Sectors] ([SectorID], [Name], [ParentSectorID]) VALUES (581, N'Data processing, Web portals, E-marketing', 28)
SET IDENTITY_INSERT [dbo].[Sectors] OFF
GO
/****** Object:  Index [IX_Sectors_ParentSectorID]    Script Date: 2/20/2022 9:40:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_Sectors_ParentSectorID] ON [dbo].[Sectors]
(
	[ParentSectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SectorsUser_UsersID]    Script Date: 2/20/2022 9:40:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_SectorsUser_UsersID] ON [dbo].[SectorsUser]
(
	[UsersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Sectors]  WITH CHECK ADD  CONSTRAINT [FK_Sectors_Sectors_ParentSectorID] FOREIGN KEY([ParentSectorID])
REFERENCES [dbo].[Sectors] ([SectorID])
GO
ALTER TABLE [dbo].[Sectors] CHECK CONSTRAINT [FK_Sectors_Sectors_ParentSectorID]
GO
ALTER TABLE [dbo].[SectorsUser]  WITH CHECK ADD  CONSTRAINT [FK_SectorsUser_Sectors_SectorsSectorID] FOREIGN KEY([SectorsSectorID])
REFERENCES [dbo].[Sectors] ([SectorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SectorsUser] CHECK CONSTRAINT [FK_SectorsUser_Sectors_SectorsSectorID]
GO
ALTER TABLE [dbo].[SectorsUser]  WITH CHECK ADD  CONSTRAINT [FK_SectorsUser_Users_UsersID] FOREIGN KEY([UsersID])
REFERENCES [dbo].[Users] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SectorsUser] CHECK CONSTRAINT [FK_SectorsUser_Users_UsersID]
GO
USE [master]
GO
ALTER DATABASE [HelmesTask] SET  READ_WRITE 
GO
