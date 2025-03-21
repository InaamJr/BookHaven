USE [master]
GO
/****** Object:  Database [BookHaven]    Script Date: 3/15/2025 5:17:33 PM ******/
CREATE DATABASE [BookHaven]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookHaven', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\BookHaven.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookHaven_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\BookHaven_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookHaven] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookHaven].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookHaven] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookHaven] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookHaven] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookHaven] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookHaven] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookHaven] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookHaven] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookHaven] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookHaven] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookHaven] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookHaven] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookHaven] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookHaven] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookHaven] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookHaven] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookHaven] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookHaven] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookHaven] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookHaven] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookHaven] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookHaven] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookHaven] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookHaven] SET RECOVERY FULL 
GO
ALTER DATABASE [BookHaven] SET  MULTI_USER 
GO
ALTER DATABASE [BookHaven] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookHaven] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookHaven] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookHaven] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookHaven] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookHaven] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookHaven', N'ON'
GO
ALTER DATABASE [BookHaven] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookHaven] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookHaven]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
	[Genre] [nvarchar](50) NULL,
	[ISBN] [nvarchar](20) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[SupplierID] [uniqueidentifier] NULL,
	[UserID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessSettings]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessSettings](
	[BusinessID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BusinessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](255) NULL,
	[JoinDate] [datetime] NULL,
	[UserID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[OrderStatus] [nvarchar](20) NOT NULL,
	[PaymentStatus] [nvarchar](20) NOT NULL,
	[DeliveryType] [nvarchar](20) NOT NULL,
	[ExpectedDeliveryDate] [datetime] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[BookID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PricePerUnit] [decimal](10, 2) NOT NULL,
	[SubTotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[ReportType] [nvarchar](20) NOT NULL,
	[GeneratedDate] [datetime] NULL,
	[TotalSales] [decimal](10, 2) NOT NULL,
	[BestSellingBookID] [uniqueidentifier] NULL,
	[InventoryStatus] [nvarchar](255) NULL,
	[GeneratedBy] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDetails](
	[SalesDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [int] NOT NULL,
	[BookID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PricePerUnit] [decimal](10, 2) NOT NULL,
	[SubTotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SalesDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesTransaction]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesTransaction](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
	[TransactionDate] [datetime] NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[Discount] [decimal](10, 2) NULL,
	[PaymentMethod] [nvarchar](20) NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[FinalAmount] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ContactPerson] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](255) NULL,
	[UserID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/15/2025 5:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [nvarchar](10) NOT NULL,
	[FailedAttempts] [int] NULL,
	[IsLocked] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IDX_BookID]    Script Date: 3/15/2025 5:17:34 PM ******/
CREATE NONCLUSTERED INDEX [IDX_BookID] ON [dbo].[Book]
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT (newid()) FOR [BookID]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT (newid()) FOR [CustomerID]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT (getdate()) FOR [JoinDate]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Report] ADD  DEFAULT (getdate()) FOR [GeneratedDate]
GO
ALTER TABLE [dbo].[SalesTransaction] ADD  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[SalesTransaction] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[SalesTransaction] ADD  DEFAULT ((0)) FOR [FinalAmount]
GO
ALTER TABLE [dbo].[Supplier] ADD  DEFAULT (newid()) FOR [SupplierID]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (newid()) FOR [UserID]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ('active') FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [FailedAttempts]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD FOREIGN KEY([BestSellingBookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD FOREIGN KEY([GeneratedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD FOREIGN KEY([TransactionID])
REFERENCES [dbo].[SalesTransaction] ([TransactionID])
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD CHECK  (([StockQuantity]>=(0)))
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD CHECK  (([DeliveryType]='Delivery' OR [DeliveryType]='Pickup'))
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD CHECK  (([OrderStatus]='Cancelled' OR [OrderStatus]='Completed' OR [OrderStatus]='Pending'))
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD CHECK  (([PaymentStatus]='Cancelled' OR [PaymentStatus]='Completed' OR [PaymentStatus]='Pending'))
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD CHECK  (([TotalAmount]>=(0)))
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD CHECK  (([PricePerUnit]>=(0)))
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD CHECK  (([ReportType]='Monthly' OR [ReportType]='Weekly' OR [ReportType]='Daily'))
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD CHECK  (([TotalSales]>=(0)))
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD CHECK  (([PricePerUnit]>=(0)))
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD CHECK  (([Discount]>=(0)))
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD CHECK  (([PaymentMethod]='Online' OR [PaymentMethod]='Card' OR [PaymentMethod]='Cash'))
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD CHECK  (([TotalAmount]>=(0)))
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD CHECK  (([IsActive]='inactive' OR [IsActive]='active'))
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD CHECK  (([Role]='Salesclerk' OR [Role]='Admin'))
GO
USE [master]
GO
ALTER DATABASE [BookHaven] SET  READ_WRITE 
GO
