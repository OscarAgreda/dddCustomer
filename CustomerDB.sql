USE [master]
GO
/****** Object:  Database [DDDCustomer]    Script Date: 3/11/2023 10:44:28 AM ******/
CREATE DATABASE [DDDCustomer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DDDCustomer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DDDCustomer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DDDCustomer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DDDCustomer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DDDCustomer] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DDDCustomer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DDDCustomer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DDDCustomer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DDDCustomer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DDDCustomer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DDDCustomer] SET ARITHABORT OFF 
GO
ALTER DATABASE [DDDCustomer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DDDCustomer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DDDCustomer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DDDCustomer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DDDCustomer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DDDCustomer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DDDCustomer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DDDCustomer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DDDCustomer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DDDCustomer] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DDDCustomer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DDDCustomer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DDDCustomer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DDDCustomer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DDDCustomer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DDDCustomer] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DDDCustomer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DDDCustomer] SET RECOVERY FULL 
GO
ALTER DATABASE [DDDCustomer] SET  MULTI_USER 
GO
ALTER DATABASE [DDDCustomer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DDDCustomer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DDDCustomer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DDDCustomer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DDDCustomer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DDDCustomer] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DDDCustomer', N'ON'
GO
ALTER DATABASE [DDDCustomer] SET QUERY_STORE = OFF
GO
USE [DDDCustomer]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/11/2023 10:44:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[CustomerNumber] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[CreditLimit] [decimal](18, 2) NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'85ad4bca-f986-2955-93c7-051c58112f1a', 19000, N'Luz', N'Moody', CAST(1952.78 AS Decimal(18, 2)), N'440807-3413', CAST(N'2023-02-13T00:08:43.1343987' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'9db6143c-0bba-3341-f0e9-07a88406044c', 78000, N'Linda', N'Bell', CAST(1106.86 AS Decimal(18, 2)), N'5973813405', CAST(N'2022-06-21T02:08:48.5602561' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'e32e9e54-6934-86a9-e2a7-0b012ce42332', 57000, N'Karl', N'Phelps', CAST(1886.04 AS Decimal(18, 2)), N'964-465-3048', CAST(N'2023-12-10T04:17:25.3260077' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'd4c60784-6dd3-f761-fd69-0bdeb41f1216', 26000, N'Kisha', N'Wood', CAST(3880.51 AS Decimal(18, 2)), N'1078139778', CAST(N'2022-01-04T11:43:01.1025488' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'e92a284a-9700-e8c4-6531-0d05de71bb63', 62000, N'Chad', N'Scott', CAST(2266.11 AS Decimal(18, 2)), N'925-411-4842', CAST(N'2023-01-15T12:32:12.4094953' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'4b3d1935-0498-9717-6b48-12d171967e7f', 60000, N'Tia', N'Hurley', CAST(2278.02 AS Decimal(18, 2)), N'4744530508', CAST(N'2022-06-18T19:22:37.6111626' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'e58f9f67-6bf3-8261-9c47-132b022fab13', 7000, N'Anne', N'Cook', CAST(3182.38 AS Decimal(18, 2)), N'801-6301779', CAST(N'2022-10-22T19:49:47.9442637' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'26a8f436-b996-44d7-1061-188cc7e4a685', 6000, N'Terence', N'Collins', CAST(2954.82 AS Decimal(18, 2)), N'4100550959', CAST(N'2023-05-07T01:45:17.4835801' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'c8159790-180a-1bb7-da5b-1b743870155e', 71000, N'Angelina', N'Ware', CAST(3013.78 AS Decimal(18, 2)), N'092-095-3893', CAST(N'2022-02-11T08:12:26.5592849' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'4be24a1c-b1e3-dac4-5f66-2022ae657766', 76000, N'James', N'Jacobs', CAST(2646.12 AS Decimal(18, 2)), N'1252977625', CAST(N'2023-08-06T11:57:06.9834168' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'6a56c0d0-dcd3-bb4e-6005-203ba7540905', 70000, N'Rhonda', N'Kirk', CAST(4768.26 AS Decimal(18, 2)), N'663-3114482', CAST(N'2023-02-07T10:42:21.1662252' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'46d31644-4347-8ecb-2555-2a63c4392e12', 3000, N'Carey', N'Cline', CAST(1649.78 AS Decimal(18, 2)), N'407465-5874', CAST(N'2023-06-14T00:01:22.1206973' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'6de9e12c-7b6b-4df3-d161-2b336814449d', 34000, N'Dana', N'Buck', CAST(1625.36 AS Decimal(18, 2)), N'954-9897595', CAST(N'2023-08-15T10:15:34.8938265' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'c65773e0-4208-e871-46ef-34bf19b0cde2', 46000, N'Brandy', N'Carpenter', CAST(177.23 AS Decimal(18, 2)), N'5228562159', CAST(N'2023-09-15T11:49:59.7580533' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'5ff3c89c-8f70-7cd9-256b-3645dc186b59', 47000, N'Roy', N'Rocha', CAST(4831.05 AS Decimal(18, 2)), N'278-2113425', CAST(N'2023-07-12T18:47:53.1170165' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'2f7e28c5-ce9c-b843-2db2-36f8f4ee6d8e', 44000, N'James', N'Lloyd', CAST(1546.26 AS Decimal(18, 2)), N'350011-1622', CAST(N'2023-08-30T19:11:04.7656748' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'639e7c75-0d29-422c-8368-3970ec1262d9', 31000, N'Candy', N'Benson', CAST(3364.24 AS Decimal(18, 2)), N'118349-5176', CAST(N'2022-11-17T21:42:44.0844992' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'191f4642-9429-44d7-2f5d-3a8a09b10408', 63000, N'Marianne', N'Waters', CAST(1436.11 AS Decimal(18, 2)), N'719493-4073', CAST(N'2022-04-06T10:25:36.7213811' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'c1277445-9587-2191-7e75-3ba53b8c581b', 39000, N'Clarence', N'Chapman', CAST(2012.95 AS Decimal(18, 2)), N'5253328931', CAST(N'2023-06-19T01:42:38.7955653' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'a7fc18b1-46af-0843-7185-407a6cfb0ec1', 64000, N'Forrest', N'Cisneros', CAST(2254.47 AS Decimal(18, 2)), N'715899-8360', CAST(N'2023-08-10T07:22:55.0482236' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'15794079-ef21-1778-79ab-436426e086b0', 33000, N'Judy', N'Banks', CAST(342.53 AS Decimal(18, 2)), N'643-588-0897', CAST(N'2022-12-20T11:03:47.9877714' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'20957b8e-d347-4d87-94f5-4391f380a928', 11000, N'Carlos', N'Dickson', CAST(2873.58 AS Decimal(18, 2)), N'3705738930', CAST(N'2022-04-01T15:37:43.4220683' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'83d3b6da-ce6a-f63b-c46c-46c435d4bcc0', 49000, N'Joseph', N'Gibbs', CAST(2745.50 AS Decimal(18, 2)), N'542-727-3036', CAST(N'2023-07-17T07:27:42.5142566' AS DateTime2), 1, 0)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'2ce5a125-3928-4d58-7d92-484d11cfea8f', 10000, N'Anne', N'Vang', CAST(3421.03 AS Decimal(18, 2)), N'385812-4969', CAST(N'2022-03-05T16:00:49.2146730' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'635f055b-1521-b5fe-c08a-4fdf65cfe012', 2000, N'Keisha', N'Palmer', CAST(1542.93 AS Decimal(18, 2)), N'4952856277', CAST(N'2022-01-29T01:37:18.6519384' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'6deb0ecf-1f18-e198-1a19-507bb09ac25f', 17000, N'Alfred', N'Franco', CAST(2268.27 AS Decimal(18, 2)), N'660-2533317', CAST(N'2023-08-30T16:23:17.4050678' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'02dfed1f-ed66-4ba4-bbaf-51079fe9ad65', 17000, N'Alfred', N'Franco', CAST(2268.27 AS Decimal(18, 2)), N'660-2533317', CAST(N'2023-08-30T16:23:17.4050678' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'1020a229-15ad-6a87-7d2b-524a136d1a80', 9000, N'Deanna', N'King', CAST(2291.40 AS Decimal(18, 2)), N'769-7220153', CAST(N'2022-10-23T19:01:21.4995161' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'4d6dfdf9-c0f2-fb7b-f4fa-52890a9ef8f1', 73000, N'Jeanine', N'Cain', CAST(3407.87 AS Decimal(18, 2)), N'163-7686120', CAST(N'2023-09-21T10:21:16.8542732' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'c4ac4b5b-d4e3-584e-2f5b-57a946454cfb', 68000, N'Rachel', N'Compton', CAST(3311.00 AS Decimal(18, 2)), N'949569-9860', CAST(N'2023-10-16T03:46:51.2797488' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'fe6fc95a-b5d3-0adc-e5f8-5ae82be0e651', 74000, N'Jerry', N'Quinn', CAST(1653.21 AS Decimal(18, 2)), N'527030-5367', CAST(N'2023-07-12T17:22:00.2544385' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'3838a823-8b1b-1740-b097-5d07817a99d7', 14000, N'Arturo', N'Buckley', CAST(1853.09 AS Decimal(18, 2)), N'972529-5747', CAST(N'2022-08-31T08:21:23.4545022' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'027828a7-3b3c-e0fd-ff16-5fb87a49e61e', 37000, N'Billy', N'Herman', CAST(1208.08 AS Decimal(18, 2)), N'993-9040862', CAST(N'2022-06-17T19:13:23.1211504' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'c8a16271-2bc4-df6d-20da-60a672db463a', 50000, N'Erik', N'Travis', CAST(4077.67 AS Decimal(18, 2)), N'4319588211', CAST(N'2022-09-17T08:29:54.0648087' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'17a43da5-6238-074d-262b-63e6cfb667e2', 30000, N'Joseph', N'Dunn', CAST(4846.75 AS Decimal(18, 2)), N'4741314643', CAST(N'2023-03-15T11:38:26.4512925' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'9d4ef976-83ec-3093-afc5-6416bc66348f', 20000, N'Roderick', N'Riddle', CAST(1408.68 AS Decimal(18, 2)), N'508-2316021', CAST(N'2022-04-09T20:49:09.1837701' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'385f924c-2bef-5456-685e-64c6338d6cff', 40000, N'Shad', N'Powell', CAST(4159.31 AS Decimal(18, 2)), N'209415-3902', CAST(N'2023-08-03T06:46:42.8799603' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'e9f4c039-30fe-43b3-9e58-688b16ec8d0c', 13000, N'Keri', N'Marks', CAST(946.11 AS Decimal(18, 2)), N'8633185492', CAST(N'2023-05-31T14:02:26.1735752' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'31ae38b6-c72a-081f-1f87-6eb72aa9dfb4', 1000, N'Angie', N'Fuller', CAST(4931.57 AS Decimal(18, 2)), N'7019628082', CAST(N'2023-08-24T22:14:53.5776756' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'a29bda35-3534-f9b0-00d1-6ec80daf3d18', 28000, N'Timmy', N'Clark', CAST(701.80 AS Decimal(18, 2)), N'4838094823', CAST(N'2023-10-07T07:17:35.5347685' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'f30d46f9-e55c-709a-b28a-76cce2b65aab', 66000, N'Lana', N'Mcgrath', CAST(4171.57 AS Decimal(18, 2)), N'4373278187', CAST(N'2022-09-21T21:29:01.6140052' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'aaddfb45-eeb1-0f92-c95d-7b25ec07b5e6', 35000, N'Kristy', N'Oliver', CAST(4020.11 AS Decimal(18, 2)), N'2081872655', CAST(N'2022-08-05T06:42:32.1049776' AS DateTime2), 1, 0)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'76e2dcec-5821-cfac-10e0-7e663817ce52', 15000, N'Molly', N'Finley', CAST(171.87 AS Decimal(18, 2)), N'128164-4085', CAST(N'2023-11-26T20:42:50.0161626' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'1bb9508d-038e-c96f-46c9-829dda229b86', 58000, N'Darla', N'Mc Mahon', CAST(2303.90 AS Decimal(18, 2)), N'050-781-1506', CAST(N'2023-09-24T21:02:33.0261616' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'ed79c8bd-a599-d44b-f81b-86c9e37c6d99', 80000, N'Mandy', N'Freeman', CAST(1438.51 AS Decimal(18, 2)), N'610786-5933', CAST(N'2023-08-01T07:33:12.7016028' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'e28be90e-138d-6b92-4e47-870cb0b3753e', 18000, N'Ruth', N'Bartlett', CAST(3901.00 AS Decimal(18, 2)), N'4347959652', CAST(N'2023-03-10T12:03:55.6498384' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'b8909046-683b-fcd8-1578-87843ac0f18e', 43000, N'Donnell', N'Leach', CAST(4141.83 AS Decimal(18, 2)), N'4208910071', CAST(N'2022-11-10T12:16:58.4233842' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'f5486434-21f5-1876-a65b-87b85d083930', 48000, N'Philip', N'Wilcox', CAST(160.11 AS Decimal(18, 2)), N'9358445128', CAST(N'2023-03-09T08:32:09.9058744' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'8a394536-44c8-2215-ddc0-87c46304bf55', 67000, N'Javier', N'Cooley', CAST(2418.63 AS Decimal(18, 2)), N'033863-9653', CAST(N'2022-03-28T06:24:19.8597648' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'fd0ff782-92f7-6812-7185-88759441b12f', 22000, N'Edwin', N'Mc Millan', CAST(3807.26 AS Decimal(18, 2)), N'382-871-1301', CAST(N'2023-02-02T04:42:00.5827822' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'53ee24a7-ac62-d30b-ebef-8e2c87eb8152', 36000, N'Ericka', N'May', CAST(4520.96 AS Decimal(18, 2)), N'8480618561', CAST(N'2022-10-20T10:00:28.8499374' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'5af6c1df-11ef-394b-7f2f-90603cd11a3a', 5000, N'Faith', N'Stuart', CAST(1255.85 AS Decimal(18, 2)), N'6947287432', CAST(N'2022-06-22T07:05:38.7137114' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'9d57fc38-c478-db1c-93e5-946dd80056ff', 29000, N'Rebekah', N'Matthews', CAST(2658.29 AS Decimal(18, 2)), N'920-3966760', CAST(N'2022-02-03T16:20:17.5333818' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'63e91d52-d258-47f4-929e-9b3dedc5378b', 17000, N'Oscar', N'Franco', CAST(2268.27 AS Decimal(18, 2)), N'660-2533317', CAST(N'2023-08-30T16:23:17.4050678' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'4ddec17c-d0ac-0852-c101-9d8a0a9b2e4b', 56000, N'Mickey', N'Mejia', CAST(4249.35 AS Decimal(18, 2)), N'536-5129583', CAST(N'2022-07-23T17:32:52.9948934' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'cbaed4d4-e065-08fb-e408-a3a15cb90925', 21000, N'Donnell', N'Brewer', CAST(2925.69 AS Decimal(18, 2)), N'690923-4600', CAST(N'2023-05-07T00:38:44.1807964' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'b17185da-964e-20e1-287b-a6771b8afbb9', 27000, N'Quentin', N'Beltran', CAST(1949.48 AS Decimal(18, 2)), N'564-042-6438', CAST(N'2022-12-25T14:49:51.9550429' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'cb847727-e94d-d0ac-c305-ac469eeb8dd3', 41000, N'Jesus', N'Irwin', CAST(4305.37 AS Decimal(18, 2)), N'099-829-9064', CAST(N'2022-06-19T02:15:08.9260467' AS DateTime2), 0, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'44edefe5-be29-6cb1-473b-ad57b7965de9', 53000, N'Stephan', N'Cooke', CAST(664.21 AS Decimal(18, 2)), N'4054842667', CAST(N'2022-05-12T06:45:45.4224968' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'371f8606-b39c-a41e-423c-b463a035ff27', 4000, N'Shari', N'Nielsen', CAST(860.83 AS Decimal(18, 2)), N'456-441-8564', CAST(N'2022-10-22T19:01:37.6824498' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'3fa4679a-d367-a2e6-80d2-b503a0195767', 69000, N'Latonya', N'Briggs', CAST(2218.61 AS Decimal(18, 2)), N'686-555-7928', CAST(N'2022-01-27T01:38:51.3495246' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'c9138896-b778-ceae-ba3f-b50f6063a6fe', 72000, N'Tyler', N'Keller', CAST(2877.09 AS Decimal(18, 2)), N'5303454776', CAST(N'2023-01-05T21:54:53.5507501' AS DateTime2), 1, 0)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'97bf6d5d-87d1-4b52-8c66-b6af7dbe943d', 17000, N'Oscar', N'Franco', CAST(2268.27 AS Decimal(18, 2)), N'660-2533317', CAST(N'2023-08-30T16:23:17.4050678' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'3c259a7a-2342-804b-712a-badc73c263a3', 55000, N'Marissa', N'Potts', CAST(847.39 AS Decimal(18, 2)), N'380-503-9694', CAST(N'2022-11-11T12:56:07.3787393' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'fc99563e-2f8b-98da-2f5a-bcb47738c517', 77000, N'Jon', N'Jenkins', CAST(936.84 AS Decimal(18, 2)), N'400339-9586', CAST(N'2022-03-25T16:25:02.1593980' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'6b394d29-919a-67a5-9e98-c2a79af70f0a', 23000, N'Erich', N'Flowers', CAST(878.16 AS Decimal(18, 2)), N'775-334-2664', CAST(N'2022-02-18T21:19:53.3259308' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'ac8d7dc8-df21-2e6e-afa6-c9fe18e3969c', 52000, N'Lloyd', N'Abbott', CAST(1422.84 AS Decimal(18, 2)), N'708103-9637', CAST(N'2023-11-17T09:38:41.9803808' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'dd4581a3-745b-84c3-77ba-d4076dc00bb0', 61000, N'Krystal', N'Tucker', CAST(1699.07 AS Decimal(18, 2)), N'958-1068747', CAST(N'2022-05-13T10:55:25.5285371' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'ecdef0ba-28f0-467b-ad49-d8376152c4a9', 51000, N'Garrett', N'Solomon', CAST(2326.73 AS Decimal(18, 2)), N'192927-6513', CAST(N'2022-02-24T13:04:01.1208491' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'6d1241c9-edf4-1d9b-c753-de8d47d2f2de', 25000, N'Sophia', N'Erickson', CAST(4200.17 AS Decimal(18, 2)), N'622-7089396', CAST(N'2023-04-16T19:23:12.4596560' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'a60328f2-4839-83d6-114a-e08697f4a55f', 75000, N'Kirk', N'Roberts', CAST(769.25 AS Decimal(18, 2)), N'328-7578532', CAST(N'2023-10-21T18:34:00.2577235' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'11ddc04a-6c88-8017-02e2-e0c36cb80dc4', 65000, N'Lorena', N'Golden', CAST(4758.68 AS Decimal(18, 2)), N'253-7749859', CAST(N'2023-04-17T18:18:05.1301739' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'2c82fa87-825f-a8c7-e9e1-e5e900f47efb', 38000, N'Shannon', N'Santos', CAST(2701.44 AS Decimal(18, 2)), N'233-369-5804', CAST(N'2022-08-25T18:28:23.8543176' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'8b0ee737-fdac-ecb4-b2c9-e7d8b71c3df8', 12000, N'Hector', N'Chen', CAST(3990.81 AS Decimal(18, 2)), N'5972706455', CAST(N'2023-03-16T17:28:07.8475363' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'4a9663d3-e577-cb75-5e98-e97cd50d5ac6', 42000, N'Randolph', N'Hill', CAST(3906.62 AS Decimal(18, 2)), N'4275934640', CAST(N'2023-09-30T12:41:37.1973796' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'8d03860a-6dea-9c89-d057-eb29686abc9b', 16000, N'Kristie', N'Walton', CAST(1045.08 AS Decimal(18, 2)), N'877816-6714', CAST(N'2022-07-29T03:25:49.6804354' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'0a944b78-968e-d8f8-8a99-f4c8093181da', 79000, N'Garrett', N'Gallagher', CAST(374.15 AS Decimal(18, 2)), N'031-854-8342', CAST(N'2023-10-18T04:06:38.1894652' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'6ccd71d7-82cd-4af8-9022-f9761b865ab1', 17000, N'Alfred', N'Franco', CAST(2268.27 AS Decimal(18, 2)), N'660-2533317', CAST(N'2023-08-30T16:23:17.4050678' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'a5a76dff-1de4-fc9e-76fd-fb4e7368cecd', 59000, N'Justin', N'Potter', CAST(60.21 AS Decimal(18, 2)), N'9202289865', CAST(N'2023-07-07T23:38:25.2227938' AS DateTime2), 1, 0)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'12f73c6b-7750-fcdc-6cd5-fbd364fd5cf7', 8000, N'Mickey', N'Dyer', CAST(378.28 AS Decimal(18, 2)), N'018-640-1360', CAST(N'2022-05-10T02:45:54.2547630' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'19a82a33-c731-c8f0-0ae2-fd78b7b57511', 24000, N'Irma', N'Ayers', CAST(4936.26 AS Decimal(18, 2)), N'6218809870', CAST(N'2023-09-19T02:58:49.0945357' AS DateTime2), 1, 1)
INSERT [dbo].[Customer] ([CustomerId], [CustomerNumber], [FirstName], [LastName], [CreditLimit], [PhoneNumber], [DateCreated], [IsActive], [IsDeleted]) VALUES (N'fcb868b9-27c5-4d4a-febe-fdebfe726afb', 54000, N'Grace', N'Orr', CAST(2805.79 AS Decimal(18, 2)), N'344-7450519', CAST(N'2022-08-27T03:43:23.4799504' AS DateTime2), 1, 1)
GO
USE [master]
GO
ALTER DATABASE [DDDCustomer] SET  READ_WRITE 
GO
