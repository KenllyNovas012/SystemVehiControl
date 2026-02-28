create database [VehixControlDB]
go
USE [VehixControlDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SalePrice] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[IdentificationNumber] [nvarchar](max) NOT NULL,
	[MobileNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[DocumentType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceCaseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Engines]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Engines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExteriorInspections]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExteriorInspections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RadioAntennaOk] [bit] NOT NULL,
	[BeepersOk] [bit] NOT NULL,
	[SpareTirePresent] [bit] NOT NULL,
	[JackAndWrenchPresent] [bit] NOT NULL,
	[AlarmWorking] [bit] NOT NULL,
	[MirrorCondition] [nvarchar](50) NULL,
	[HoopGame] [nvarchar](50) NULL,
 CONSTRAINT [PK_ExteriorInspections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InteriorInspections]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InteriorInspections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UpholsteryOk] [nvarchar](50) NOT NULL,
	[LighterOk] [bit] NOT NULL,
	[ACFunctionality] [nvarchar](max) NOT NULL,
	[RadioOk] [bit] NOT NULL,
	[RadioSpeakersOk] [bit] NOT NULL,
	[Doorwindows] [nvarchar](50) NOT NULL,
	[Doorlocks] [nvarchar](50) NOT NULL,
	[Carhorn] [nvarchar](50) NOT NULL,
	[RearRightDoorOk] [bit] NOT NULL,
	[ExternalHornOk] [bit] NOT NULL,
	[FloorMatCount] [int] NOT NULL,
	[EmergencyKitOk] [bit] NOT NULL,
 CONSTRAINT [PK_InteriorInspections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCFs]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCFs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NCFType] [nvarchar](max) NOT NULL,
	[StartRange] [int] NOT NULL,
	[EndRange] [int] NOT NULL,
	[CurrentSequence] [int] NOT NULL,
	[VerificationCode] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_NCFs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[PersonType] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DocumentType] [nvarchar](max) NOT NULL,
	[DocumentNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[PhotoId] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[TakenAt] [datetime2](7) NOT NULL,
	[ExteriorInspectionId] [int] NULL,
	[InteriorInspectionId] [int] NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priorities]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priorities](
	[PriorityId] [int] IDENTITY(1,1) NOT NULL,
	[Level] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Priorities] PRIMARY KEY CLUSTERED 
(
	[PriorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotationDetails]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotationDetails](
	[QuotationDetailId] [int] IDENTITY(1,1) NOT NULL,
	[QuotationId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_QuotationDetails] PRIMARY KEY CLUSTERED 
(
	[QuotationDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotations]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotations](
	[QuotationId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReceiptType] [nvarchar](max) NOT NULL,
	[ReceiptSeries] [nvarchar](max) NOT NULL,
	[ReceiptNumber] [nvarchar](max) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_Quotations] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDetails]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetails](
	[SaleDetailId] [int] IDENTITY(1,1) NOT NULL,
	[SaleId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SaleDetails] PRIMARY KEY CLUSTERED 
(
	[SaleDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReceiptType] [nvarchar](max) NOT NULL,
	[ReceiptSeries] [nvarchar](max) NOT NULL,
	[ReceiptNumber] [nvarchar](max) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCases]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleReceptionId] [int] NOT NULL,
	[ServiceTypeId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[EntryDate] [datetime2](7) NOT NULL,
	[EstimatedDeliveryDate] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](50) NULL,
	[CloseDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ServiceCases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceTypes]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTypes](
	[ServiceTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ServiceTypes] PRIMARY KEY CLUSTERED 
(
	[ServiceTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockEntries]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockEntries](
	[StockEntryId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReceiptType] [nvarchar](max) NOT NULL,
	[ReceiptSeries] [nvarchar](max) NOT NULL,
	[ReceiptNumber] [nvarchar](max) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StockEntries] PRIMARY KEY CLUSTERED 
(
	[StockEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockEntryDetails]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockEntryDetails](
	[StockEntryDetailId] [int] IDENTITY(1,1) NOT NULL,
	[StockEntryId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_StockEntryDetails] PRIMARY KEY CLUSTERED 
(
	[StockEntryDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DocumentType] [nvarchar](max) NOT NULL,
	[DocumentNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleReceptions]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleReceptions](
	[VehicleReceptionId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nvarchar](max) NOT NULL,
	[ReceptionDate] [datetime2](7) NOT NULL,
	[ReceptionTime] [time](7) NOT NULL,
	[ClientId] [int] NOT NULL,
	[VehicleId] [int] NOT NULL,
	[InteriorInspectionId] [int] NULL,
	[ExteriorInspectionId] [int] NOT NULL,
	[PersonalItems] [nvarchar](max) NOT NULL,
	[Observations] [nvarchar](max) NOT NULL,
	[VisitReason] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VehicleReceptions] PRIMARY KEY CLUSTERED 
(
	[VehicleReceptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 31/7/2025 5:04:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[ChassisNumber] [nvarchar](max) NOT NULL,
	[BrandId] [int] NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Year] [int] NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[LicensePlate] [nvarchar](max) NOT NULL,
	[Mileage] [nvarchar](max) NOT NULL,
	[FuelType] [nvarchar](max) NOT NULL,
	[EngineId] [int] NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250505231047_InitialCreate', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (4, 3, N'A001', N'Aceite de motor 5W30', CAST(450.00 AS Decimal(18, 2)), 100, N'Aceite sintético para motor', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (5, 3, N'A002', N'Aceite de transmisión ATF', CAST(500.00 AS Decimal(18, 2)), 70, N'Aceite para transmisión automática', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (6, 6, N'B001', N'Batería 12V 70Ah', CAST(2800.00 AS Decimal(18, 2)), 40, N'Batería para vehículo mediano', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (7, 2, N'R001', N'Filtro de aire', CAST(300.00 AS Decimal(18, 2)), 80, N'Filtro de aire para motor de gasolina', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (8, 2, N'R002', N'Bombilla H4 12V', CAST(150.00 AS Decimal(18, 2)), 200, N'Luz para faro delantero', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (9, 5, N'N001', N'Neumático 195/65R15', CAST(4200.00 AS Decimal(18, 2)), 50, N'Neumático radial de alta durabilidad', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (10, 5, N'N002', N'Aro 15" aluminio', CAST(3200.00 AS Decimal(18, 2)), 20, N'Aro deportivo de aleación', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (11, 7, N'F001', N'Pastillas de freno delanteras', CAST(850.00 AS Decimal(18, 2)), 60, N'Juego de pastillas de freno', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (12, 7, N'F002', N'Disco de freno trasero', CAST(1200.00 AS Decimal(18, 2)), 30, N'Disco ventilado para freno trasero', 1)
GO
INSERT [dbo].[Articles] ([ArticleId], [CategoryId], [Code], [Name], [SalePrice], [Stock], [Description], [IsActive]) VALUES (13, 4, N'M001', N'Cambio de aceite', CAST(600.00 AS Decimal(18, 2)), 0, N'Servicio de cambio de aceite y filtro', 1)
GO
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (1, N'Toyota')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (2, N'Honda')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (3, N'Ford')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (4, N'Chevrolet')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (5, N'Nissan')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (6, N'Hyundai')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (7, N'Kia')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (8, N'Volkswagen')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (9, N'Mazda')
GO
INSERT [dbo].[Brands] ([BrandId], [Name]) VALUES (10, N'BMW')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive]) VALUES (2, N'Repuestos', N'Componentes y piezas utilizadas para el reemplazo o reparación de partes del vehículo.', 0)
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive]) VALUES (3, N'Lubricantes', N'Productos diseñados para reducir la fricción, proteger y mejorar el rendimiento del motor y otros sistemas mecánicos.', 0)
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive]) VALUES (4, N'Mano de Obra', N'Servicios técnicos realizados por el personal del taller, como cambios de aceite, instalación de piezas', 0)
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive]) VALUES (5, N'Neumáticos y Aros', N'Artículos relacionados con el sistema de rodamiento del vehículo, incluyendo gomas, aros de diferentes medidas y servicios como alineación o balanceo.', 0)
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive]) VALUES (6, N'Baterías', N'Suministro e instalación de baterías automotrices, necesarias para el encendido y funcionamiento del sistema eléctrico del vehículo.', 0)
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive]) VALUES (7, N'Sistema de Frenos', N'Elementos y servicios vinculados al sistema de frenado, como discos, pastillas, tambores y demás componentes que garantizan la seguridad al conducir.', 0)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (1, N'Juan Pérez', N'001-1234567-8', N'8291234567', N'juan.perez@example.com', N'Calle 1, Santo Domingo', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (2, N'María Gómez', N'002-2345678-9', N'8292345678', N'maria.gomez@example.com', N'Avenida 2, Santiago', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (3, N'Carlos Rodríguez', N'003-3456789-0', N'8293456789', N'carlos.rodriguez@example.com', N'Calle 3, La Vega', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (4, N'Ana Martínez', N'004-4567890-1', N'8294567890', N'ana.martinez@example.com', N'Avenida 4, Santo domingo', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (5, N'Luis Fernández', N'005-5678901-2', N'8295678901', N'luis.fernandez@example.com', N'Calle 5, Barahona', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (8, N'Laura Jiménez', N'008-8901234-5', N'8298901234', N'laura.jimenez@example.com', N'Avenida 8, Higüey', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (9, N'José Castillo', N'009-9012345-6', N'8299012345', N'jose.castillo@example.com', N'Calle 9, Moca', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (10, N'Marta Ruiz', N'010-0123456-7', N'8290123456', N'marta.ruiz@example.com', N'Avenida 10, Baní', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (11, N'Kenlly Novas', N'22900100938', N'8298477090', N'knovas@jeturing.com', N'Calle m 35 santo domingo rd', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (12, N'Dalton Novas Contreras', N'00445678901', N'8298477090', N'dalton@meamedica.com', N'Calle M # El tamarindo santo domingo este', N'Cédula')
GO
INSERT [dbo].[Clients] ([Id], [FullName], [IdentificationNumber], [MobileNumber], [Email], [Address], [DocumentType]) VALUES (13, N'Maritza Perez Roa', N'004-4567890-1', N'829-847-7090', N'maritza@meamedica.com', N'Calle M # El tamarindo santo domingo este', N'Cédula')
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 
GO
INSERT [dbo].[Comments] ([Id], [ServiceCaseId], [UserId], [Text], [CreatedAt]) VALUES (4, 16, 12, N'Agregar Comentario', CAST(N'2025-06-12T21:18:01.610' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Engines] ON 
GO
INSERT [dbo].[Engines] ([Id], [Name]) VALUES (1, N'Gasoline')
GO
INSERT [dbo].[Engines] ([Id], [Name]) VALUES (2, N'Diesel')
GO
INSERT [dbo].[Engines] ([Id], [Name]) VALUES (3, N'Electric')
GO
INSERT [dbo].[Engines] ([Id], [Name]) VALUES (4, N'Hybrid')
GO
INSERT [dbo].[Engines] ([Id], [Name]) VALUES (5, N'Natural Gas')
GO
SET IDENTITY_INSERT [dbo].[Engines] OFF
GO
SET IDENTITY_INSERT [dbo].[ExteriorInspections] ON 
GO
INSERT [dbo].[ExteriorInspections] ([Id], [RadioAntennaOk], [BeepersOk], [SpareTirePresent], [JackAndWrenchPresent], [AlarmWorking], [MirrorCondition], [HoopGame]) VALUES (17, 1, 1, 1, 1, 1, N'No funcionan', N'Incompleta')
GO
SET IDENTITY_INSERT [dbo].[ExteriorInspections] OFF
GO
SET IDENTITY_INSERT [dbo].[InteriorInspections] ON 
GO
INSERT [dbo].[InteriorInspections] ([Id], [UpholsteryOk], [LighterOk], [ACFunctionality], [RadioOk], [RadioSpeakersOk], [Doorwindows], [Doorlocks], [Carhorn], [RearRightDoorOk], [ExternalHornOk], [FloorMatCount], [EmergencyKitOk]) VALUES (16, N'Malo', 1, N'Hot', 1, 0, N'No funcionan', N'No funcionan', N'Mal', 0, 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[InteriorInspections] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (1, N'Cliente', N'Kenlly Novas', N'22900100938', N'Cedula', N'Calle prolognacion duarte ', N'8298477090', N'kenllynovas012@gmail.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (2, N'Cliente', N'Juan Perez', N'Cedula', N'00123456789', N'Calle 1', N'8091234567', N'juan.perez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (3, N'Cliente', N'Maria Lopez', N'Cedula', N'00123456790', N'Calle 2', N'8091234568', N'maria.lopez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (4, N'Cliente', N'Carlos Ramirez', N'Cedula', N'00123456791', N'Calle 3', N'8091234569', N'carlos.ramirez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (5, N'Cliente', N'Ana Gomez', N'Cedula', N'00123456792', N'Calle 4', N'8091234570', N'ana.gomez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (6, N'Cliente', N'Luis Torres', N'Cedula', N'00123456793', N'Calle 5', N'8091234571', N'luis.torres@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (7, N'Cliente', N'Sofia Fernandez', N'Cedula', N'00123456794', N'Calle 6', N'8091234572', N'sofia.fernandez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (8, N'Cliente', N'Pedro Martinez', N'Cedula', N'00123456795', N'Calle 7', N'8091234573', N'pedro.martinez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (9, N'Cliente', N'Lucia Rodriguez', N'Cedula', N'00123456796', N'Calle 8', N'8091234574', N'lucia.rodriguez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (10, N'Cliente', N'Jorge Sanchez', N'Cedula', N'00123456797', N'Calle 9', N'8091234575', N'jorge.sanchez@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (11, N'Cliente', N'Elena Diaz', N'Cedula', N'00123456798', N'Calle 10', N'8091234576', N'elena.diaz@example.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (12, N'Supplier', N'Autopartes Santo Domingo', N'RNC', N'10123456789', N'Av. 27 de Febrero #123', N'8098000001', N'contacto@autopartessd.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (13, N'Supplier', N'Lubricantes El Sol', N'RNC', N'10123456790', N'Calle Mella #45', N'8098000002', N'ventas@lubelsol.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (14, N'Supplier', N'Neumáticos del Caribe', N'RNC', N'10123456791', N'Carretera Duarte Km 10', N'8098000003', N'info@neucaribe.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (15, N'Supplier', N'Frenos y Más SRL', N'RNC', N'10123456792', N'Calle Paseo de los Locutores', N'8098000004', N'frenosymas@proveedor.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (16, N'Supplier', N'Baterías Energy Plus', N'RNC', N'10123456793', N'Av. Churchill #101', N'8098000005', N'baterias@energyplus.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (17, N'Supplier', N'Servicios Mecánicos Tony', N'RNC', N'10123456794', N'Calle Sánchez #33', N'8098000006', N'servicios@tonymecanica.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (18, N'Supplier', N'Importadora AutoLux', N'RNC', N'10123456795', N'Zona Franca San Isidro', N'8098000007', N'ventas@autolux.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (19, N'Supplier', N'MotoRepuestos JJ', N'RNC', N'10123456796', N'Av. Venezuela #98', N'8098000008', N'contacto@motorepjj.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (20, N'Supplier', N'Repuestos Rápidos SRL', N'RNC', N'10123456797', N'Calle Luperón #5', N'8098000009', N'rapidos@repuestosrd.com')
GO
INSERT [dbo].[People] ([PersonId], [PersonType], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email]) VALUES (21, N'Supplier', N'Distribuidora AutoPartes MX', N'RNC', N'10123456798', N'Av. Independencia #55', N'8098000010', N'autopartesmx@proveedor.com')
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Photos] ON 
GO
INSERT [dbo].[Photos] ([PhotoId], [FileName], [Url], [Description], [TakenAt], [ExteriorInspectionId], [InteriorInspectionId]) VALUES (1, N'fb036294-a5a4-422a-be99-9b25e0847851_partes-de-un-coche-interior.jpg', N'/uploads/exterior/fb036294-a5a4-422a-be99-9b25e0847851_partes-de-un-coche-interior.jpg', N'Imagen de vehiculo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 17, NULL)
GO
INSERT [dbo].[Photos] ([PhotoId], [FileName], [Url], [Description], [TakenAt], [ExteriorInspectionId], [InteriorInspectionId]) VALUES (2, N'9edf5760-de61-4015-ba31-c9754b28340e_partes-de-un-coche-interior.jpg', N'/uploads/exterior/9edf5760-de61-4015-ba31-c9754b28340e_partes-de-un-coche-interior.jpg', N'Imagen de vehiculo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 17, NULL)
GO
INSERT [dbo].[Photos] ([PhotoId], [FileName], [Url], [Description], [TakenAt], [ExteriorInspectionId], [InteriorInspectionId]) VALUES (6, N'47bb1326-4382-4c76-bc21-b90d6d925885_partes-de-un-coche-interior.jpg', N'/uploads/interior/47bb1326-4382-4c76-bc21-b90d6d925885_partes-de-un-coche-interior.jpg', N'Imagen de vehiculo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 16)
GO
INSERT [dbo].[Photos] ([PhotoId], [FileName], [Url], [Description], [TakenAt], [ExteriorInspectionId], [InteriorInspectionId]) VALUES (10, N'0a591c2b-9f8b-47ae-b83a-b9f836ba2062_partes-de-un-coche-interior.jpg', N'/uploads/exterior/0a591c2b-9f8b-47ae-b83a-b9f836ba2062_partes-de-un-coche-interior.jpg', N'Imagen exterior', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 17, NULL)
GO
INSERT [dbo].[Photos] ([PhotoId], [FileName], [Url], [Description], [TakenAt], [ExteriorInspectionId], [InteriorInspectionId]) VALUES (11, N'2a6ee604-f26c-407c-87f2-57867d8e6b14_partes-de-un-coche-interior.jpg', N'/uploads/interior/2a6ee604-f26c-407c-87f2-57867d8e6b14_partes-de-un-coche-interior.jpg', N'Imagen interior', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 16)
GO
INSERT [dbo].[Photos] ([PhotoId], [FileName], [Url], [Description], [TakenAt], [ExteriorInspectionId], [InteriorInspectionId]) VALUES (12, N'b62b2d2a-e954-4473-9698-d352487fb613_partes-de-un-coche-interior.jpg', N'/uploads/interior/b62b2d2a-e954-4473-9698-d352487fb613_partes-de-un-coche-interior.jpg', N'Imagen interior', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 16)
GO
SET IDENTITY_INSERT [dbo].[Photos] OFF
GO
SET IDENTITY_INSERT [dbo].[Priorities] ON 
GO
INSERT [dbo].[Priorities] ([PriorityId], [Level], [Description]) VALUES (1, N'Baja', N'No requiere atención inmediata')
GO
INSERT [dbo].[Priorities] ([PriorityId], [Level], [Description]) VALUES (2, N'Media', N'Importancia moderada, revisar pronto')
GO
INSERT [dbo].[Priorities] ([PriorityId], [Level], [Description]) VALUES (3, N'Alta', N'Requiere atención urgente')
GO
INSERT [dbo].[Priorities] ([PriorityId], [Level], [Description]) VALUES (4, N'Crítica', N'Situación crítica que requiere acción inmediata')
GO
INSERT [dbo].[Priorities] ([PriorityId], [Level], [Description]) VALUES (5, N'Normal', N'Prioridad estándar para tareas regulares')
GO
SET IDENTITY_INSERT [dbo].[Priorities] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (1, N'Ventas', N'Acceso completo a todas las funcionalidades', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (2, N'Mecánico', N'Responsable del mantenimiento de vehículos', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (3, N'Ventas', N'Encargado del proceso de venta y clientes', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (4, N'Cajero', N'Maneja los cobros y pagos', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (5, N'Supervisor', N'Supervisa las operaciones y al personal', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (6, N'Recepcionista', N'Registra visitas y recibe vehículos', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (7, N'Técnico', N'Especialista en diagnóstico y reparación', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (8, N'Inventario', N'Controla y gestiona repuestos y materiales', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (9, N'Limpieza', N'Personal de limpieza de vehículos', 1)
GO
INSERT [dbo].[Roles] ([RoleId], [Name], [Description], [IsActive]) VALUES (10, N'Soporte', N'Atención a usuarios y soporte técnico', 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceCases] ON 
GO
INSERT [dbo].[ServiceCases] ([Id], [VehicleReceptionId], [ServiceTypeId], [PriorityId], [EntryDate], [EstimatedDeliveryDate], [UserId], [Description], [Status], [CloseDate]) VALUES (16, 14, 10, 5, CAST(N'2025-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2025-07-03T00:00:00.0000000' AS DateTime2), 8, N'Descripción', N'En proceso', CAST(N'2025-06-26T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[ServiceCases] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceTypes] ON 
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (1, N'Cambio de Aceite', N'Sustitución del aceite del motor y filtro')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (2, N'Alineación', N'Alineación de las ruedas del vehículo')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (3, N'Balanceo', N'Balanceo de los neumáticos')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (4, N'Revisión General', N'Inspección completa del vehículo')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (5, N'Cambio de Filtro de Aire', N'Sustitución del filtro de aire del motor')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (6, N'Servicio de Frenos', N'Revisión y cambio de pastillas o discos')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (7, N'Cambio de Batería', N'Sustitución de batería del vehículo')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (8, N'Rotación de Neumáticos', N'Cambio de posición de los neumáticos')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (9, N'Inspección Técnica', N'Chequeo técnico para cumplimiento legal')
GO
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [Name], [Description]) VALUES (10, N'Revisión de Suspensión', N'Chequeo y mantenimiento del sistema de suspensión')
GO
SET IDENTITY_INSERT [dbo].[ServiceTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[StockEntries] ON 
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (23, 1, 1, N'Factura', N'A001', N'0001', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(18.00 AS Decimal(18, 2)), CAST(118.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (24, 2, 1, N'Factura', N'A001', N'0002', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (25, 3, 2, N'Nota Crédito', N'B002', N'0003', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), N'Anulado')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (26, 1, 3, N'Factura', N'A001', N'0004', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(16.00 AS Decimal(18, 2)), CAST(116.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (27, 4, 2, N'Factura', N'A002', N'0005', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(12.00 AS Decimal(18, 2)), CAST(112.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (28, 5, 3, N'Factura', N'A003', N'0006', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(15.00 AS Decimal(18, 2)), CAST(115.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (29, 2, 4, N'Factura', N'A001', N'0007', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(20.00 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (30, 3, 1, N'Factura', N'A001', N'0008', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), CAST(108.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (31, 1, 2, N'Factura', N'A004', N'0009', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(17.00 AS Decimal(18, 2)), CAST(117.00 AS Decimal(18, 2)), N'Activo')
GO
INSERT [dbo].[StockEntries] ([StockEntryId], [SupplierId], [UserId], [ReceiptType], [ReceiptSeries], [ReceiptNumber], [DateTime], [Tax], [Total], [Status]) VALUES (32, 4, 3, N'Nota Crédito', N'B005', N'0010', CAST(N'2025-07-25T21:58:08.7366667' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), CAST(85.00 AS Decimal(18, 2)), N'Anulado')
GO
SET IDENTITY_INSERT [dbo].[StockEntries] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (1, 1, N'Juan Pérez', N'DNI', N'12345678', N'Calle 123', N'555-1234', N'juan.perez@email.com', 0x1234ABCD, 0x5678EF90, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (2, 2, N'María Gómez', N'Passport', N'AA1234567', N'Avenida 456', N'555-5678', N'maria.gomez@email.com', 0x2345BCDE, 0x6789F012, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (3, 3, N'Carlos López', N'DNI', N'87654321', N'Calle 789', N'555-8765', N'carlos.lopez@email.com', 0x3456CDEF, 0x7890A123, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (4, 4, N'Ana Martínez', N'Passport', N'BB7654321', N'Avenida 321', N'555-4321', N'ana.martinez@email.com', 0x4567DEFA, 0x8901B234, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (5, 2, N'Luis Fernández', N'DNI', N'11223344', N'Calle 246', N'555-2468', N'luis.fernandez@email.com', 0x5678EFAB, 0x9012C345, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (6, 1, N'Sofía Ramírez', N'DNI', N'55667788', N'Avenida 135', N'555-1357', N'sofia.ramirez@email.com', 0x6789F0BC, 0xA123D456, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (7, 3, N'Miguel Torres', N'Passport', N'CC3344556', N'Calle 864', N'555-8642', N'miguel.torres@email.com', 0x7890A1CD, 0xB234E567, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (8, 2, N'Laura Sánchez', N'DNI', N'99887766', N'Avenida 975', N'555-9753', N'laura.sanchez@email.com', 0x8901B2DE, 0xC345F678, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (9, 1, N'Jorge Herrera', N'DNI', N'44332211', N'Calle 357', N'555-3579', N'jorge.herrera@email.com', 0x9012C3EF, 0xD4560789, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (10, 3, N'Elena Castillo', N'Passport', N'DD9988776', N'Avenida 468', N'555-4680', N'elena.castillo@email.com', 0xA123D4F0, 0xE5671890, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (12, 5, N'Kenlly Starlin Novas Contreras', N'Cedula', N'22900100938', N'Avenida 4, Santo domingo', N'(829) 847-7090', N'kenllynovas012@gmail.com', 0xBA03DC4A4998A1634558B325FE3023D70B56DB114D580BE02BBB4B60C4C08C48697EBE663DD7B03D01D38BF934E9BE7462673AE4AE1BC78BECCA985DB10E923A, 0x414BDF74E55CB1699C6D71699C35986F819BFA08908D257A378D23179739754F89FF70290EBC91B2426719B07825AEC0C0DE3C8C628A233BB65934D41365B5D3B53CEC70B18CFFDEF06A8491C7EDBE69D21A84901828C331E554684C57A69235732AFF1EE8A1D82835132FE5DA0581AD54E97CFA58FC01278084CD3A33B10929, 1)
GO
INSERT [dbo].[Users] ([UserId], [RoleId], [Name], [DocumentType], [DocumentNumber], [Address], [Phone], [Email], [PasswordHash], [PasswordSalt], [IsActive]) VALUES (13, 1, N'warli', N'Cedula', N'22900100938', N'Calle M # El tamarindo santo domingo este', N'(829) 847-7090', N'warli@gmail.com', 0x551DFE739CC65000362682E59334C412025FCB2BC68BC231DE58F4452EE3E9CF3B12E774E5FA62B1BF3A9EE1734853943E90E1EC58251CC6C5C51D7856B2287A, 0x173E9CCA96D2264DF299CC31523F7447609827F78A3D08F4C6733611CA7FFE8A253ECF70D9E476DB0C809FDE3CD4EE0D6E027EF079EF37F46C2F1E688720B814D118938D2EDA10B41BC1D0DD40B6769CBAD1D3DEB6A111B63C34571381C3E38A5A9443E36AE96628B795B1C3B9BA14868CEEB920A37818EB17A083AA919829EA, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleReceptions] ON 
GO
INSERT [dbo].[VehicleReceptions] ([VehicleReceptionId], [OrderNumber], [ReceptionDate], [ReceptionTime], [ClientId], [VehicleId], [InteriorInspectionId], [ExteriorInspectionId], [PersonalItems], [Observations], [VisitReason]) VALUES (14, N'ORD1001', CAST(N'2025-06-11T00:00:00.0000000' AS DateTime2), CAST(N'21:32:00' AS Time), 1, 4, 16, 17, N'Objetos Personales
', N'Observaciones', N'Motivo de Visita
')
GO
SET IDENTITY_INSERT [dbo].[VehicleReceptions] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (1, N'CHS001', 1, N'Model X', 2020, N'Rojo', N'PL1234', N'15000', N'Gasolina', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (2, N'CHS002', 2, N'Model Y', 2019, N'Azul', N'PL5678', N'23000', N'Diesel', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (3, N'CHS003', 1, N'Model Z', 2021, N'Blanco', N'PL9101', N'10000', N'Gasolina', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (4, N'CHS004', 3, N'Model A', 2018, N'Negro', N'PL1121', N'45000', N'Gasolina', 3)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (5, N'CHS005', 2, N'Model B', 2022, N'Gris', N'PL3141', N'5000', N'Híbrido', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (7, N'CHS007', 3, N'Model D', 2017, N'Azul', N'PL7181', N'60000', N'Gasolina', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (8, N'CHS008', 2, N'Model E', 2019, N'Blanco', N'PL9202', N'22000', N'Gasolina', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (9, N'CHS009', 1, N'Model F', 2021, N'Negro', N'PL1222', N'9000', N'Eléctrico', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (10, N'CHS010', 3, N'Model G', 2020, N'Gris', N'PL3242', N'17000', N'Gasolina', 0)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [ChassisNumber], [BrandId], [Model], [Year], [Color], [LicensePlate], [Mileage], [FuelType], [EngineId]) VALUES (12, N'CHS0050', 1, N'Model A', 2020, N'Negro', N'PL9203', N'45000', N'Diesel', 4)
GO
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT ('Cédula') FOR [DocumentType]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT ((0)) FOR [EngineId]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_ServiceCases] FOREIGN KEY([ServiceCaseId])
REFERENCES [dbo].[ServiceCases] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_ServiceCases]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_Photos_ExteriorInspections_ExteriorInspectionId] FOREIGN KEY([ExteriorInspectionId])
REFERENCES [dbo].[ExteriorInspections] ([Id])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_Photos_ExteriorInspections_ExteriorInspectionId]
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_Photos_InteriorInspections_InteriorInspectionId] FOREIGN KEY([InteriorInspectionId])
REFERENCES [dbo].[InteriorInspections] ([Id])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_Photos_InteriorInspections_InteriorInspectionId]
GO
ALTER TABLE [dbo].[QuotationDetails]  WITH CHECK ADD  CONSTRAINT [FK_QuotationDetails_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([ArticleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuotationDetails] CHECK CONSTRAINT [FK_QuotationDetails_Articles_ArticleId]
GO
ALTER TABLE [dbo].[QuotationDetails]  WITH CHECK ADD  CONSTRAINT [FK_QuotationDetails_Quotations_QuotationId] FOREIGN KEY([QuotationId])
REFERENCES [dbo].[Quotations] ([QuotationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuotationDetails] CHECK CONSTRAINT [FK_QuotationDetails_Quotations_QuotationId]
GO
ALTER TABLE [dbo].[Quotations]  WITH CHECK ADD  CONSTRAINT [FK_Quotations_People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Quotations] CHECK CONSTRAINT [FK_Quotations_People_PersonId]
GO
ALTER TABLE [dbo].[Quotations]  WITH CHECK ADD  CONSTRAINT [FK_Quotations_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Quotations] CHECK CONSTRAINT [FK_Quotations_Users_UserId]
GO
ALTER TABLE [dbo].[SaleDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleDetails_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([ArticleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SaleDetails] CHECK CONSTRAINT [FK_SaleDetails_Articles_ArticleId]
GO
ALTER TABLE [dbo].[SaleDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleDetails_Sales_SaleId] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sales] ([SaleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SaleDetails] CHECK CONSTRAINT [FK_SaleDetails_Sales_SaleId]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_People_PersonId]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Users_UserId]
GO
ALTER TABLE [dbo].[ServiceCases]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCases_Priorities_PriorityId] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[Priorities] ([PriorityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceCases] CHECK CONSTRAINT [FK_ServiceCases_Priorities_PriorityId]
GO
ALTER TABLE [dbo].[ServiceCases]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCases_ServiceTypes_ServiceTypeId] FOREIGN KEY([ServiceTypeId])
REFERENCES [dbo].[ServiceTypes] ([ServiceTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceCases] CHECK CONSTRAINT [FK_ServiceCases_ServiceTypes_ServiceTypeId]
GO
ALTER TABLE [dbo].[ServiceCases]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCases_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceCases] CHECK CONSTRAINT [FK_ServiceCases_Users_UserId]
GO
ALTER TABLE [dbo].[ServiceCases]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCases_VehicleReceptions_VehicleReceptionId] FOREIGN KEY([VehicleReceptionId])
REFERENCES [dbo].[VehicleReceptions] ([VehicleReceptionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceCases] CHECK CONSTRAINT [FK_ServiceCases_VehicleReceptions_VehicleReceptionId]
GO
ALTER TABLE [dbo].[StockEntries]  WITH CHECK ADD  CONSTRAINT [FK_StockEntries_People_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[People] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockEntries] CHECK CONSTRAINT [FK_StockEntries_People_SupplierId]
GO
ALTER TABLE [dbo].[StockEntries]  WITH CHECK ADD  CONSTRAINT [FK_StockEntries_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockEntries] CHECK CONSTRAINT [FK_StockEntries_Users_UserId]
GO
ALTER TABLE [dbo].[StockEntryDetails]  WITH CHECK ADD  CONSTRAINT [FK_StockEntryDetails_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([ArticleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockEntryDetails] CHECK CONSTRAINT [FK_StockEntryDetails_Articles_ArticleId]
GO
ALTER TABLE [dbo].[StockEntryDetails]  WITH CHECK ADD  CONSTRAINT [FK_StockEntryDetails_StockEntries_StockEntryId] FOREIGN KEY([StockEntryId])
REFERENCES [dbo].[StockEntries] ([StockEntryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockEntryDetails] CHECK CONSTRAINT [FK_StockEntryDetails_StockEntries_StockEntryId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
ALTER TABLE [dbo].[VehicleReceptions]  WITH CHECK ADD  CONSTRAINT [FK_VehicleReceptions_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleReceptions] CHECK CONSTRAINT [FK_VehicleReceptions_Clients_ClientId]
GO
ALTER TABLE [dbo].[VehicleReceptions]  WITH CHECK ADD  CONSTRAINT [FK_VehicleReceptions_ExteriorInspections] FOREIGN KEY([ExteriorInspectionId])
REFERENCES [dbo].[ExteriorInspections] ([Id])
GO
ALTER TABLE [dbo].[VehicleReceptions] CHECK CONSTRAINT [FK_VehicleReceptions_ExteriorInspections]
GO
ALTER TABLE [dbo].[VehicleReceptions]  WITH CHECK ADD  CONSTRAINT [FK_VehicleReceptions_ExteriorInspections_ExteriorInspectionId] FOREIGN KEY([ExteriorInspectionId])
REFERENCES [dbo].[ExteriorInspections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleReceptions] CHECK CONSTRAINT [FK_VehicleReceptions_ExteriorInspections_ExteriorInspectionId]
GO
ALTER TABLE [dbo].[VehicleReceptions]  WITH CHECK ADD  CONSTRAINT [FK_VehicleReceptions_InteriorInspections] FOREIGN KEY([InteriorInspectionId])
REFERENCES [dbo].[InteriorInspections] ([Id])
GO
ALTER TABLE [dbo].[VehicleReceptions] CHECK CONSTRAINT [FK_VehicleReceptions_InteriorInspections]
GO
ALTER TABLE [dbo].[VehicleReceptions]  WITH CHECK ADD  CONSTRAINT [FK_VehicleReceptions_InteriorInspections_InteriorInspectionId] FOREIGN KEY([InteriorInspectionId])
REFERENCES [dbo].[InteriorInspections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleReceptions] CHECK CONSTRAINT [FK_VehicleReceptions_InteriorInspections_InteriorInspectionId]
GO
ALTER TABLE [dbo].[VehicleReceptions]  WITH CHECK ADD  CONSTRAINT [FK_VehicleReceptions_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleReceptions] CHECK CONSTRAINT [FK_VehicleReceptions_Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Brands_BrandId]
GO
