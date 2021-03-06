USE [master]
GO
/****** Object:  Database [ComprehensiveFinal]    Script Date: 9/5/2017 7:52:02 PM ******/
CREATE DATABASE [ComprehensiveFinal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComprehensiveFinal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ComprehensiveFinal.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComprehensiveFinal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ComprehensiveFinal_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComprehensiveFinal] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComprehensiveFinal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComprehensiveFinal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComprehensiveFinal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComprehensiveFinal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComprehensiveFinal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComprehensiveFinal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComprehensiveFinal] SET  MULTI_USER 
GO
ALTER DATABASE [ComprehensiveFinal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComprehensiveFinal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComprehensiveFinal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComprehensiveFinal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ComprehensiveFinal] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ComprehensiveFinal]
GO
/****** Object:  UserDefinedTableType [dbo].[LineItemTableType]    Script Date: 9/5/2017 7:52:02 PM ******/
CREATE TYPE [dbo].[LineItemTableType] AS TABLE(
	[Name] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[Price] [money] NULL,
	[PurchaseLocation] [varchar](100) NULL,
	[Quantity] [int] NULL,
	[Justification] [varchar](200) NULL,
	[Status] [varchar](50) NULL,
	[Subtotal] [money] NULL
)
GO
/****** Object:  Table [dbo].[department]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[supervisor] [int] NOT NULL,
	[supervisorName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[employee]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] IDENTITY(10000000,1) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[middleName] [char](1) NULL,
	[dob] [date] NOT NULL,
	[street] [nvarchar](100) NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[postalCode] [nchar](6) NOT NULL,
	[sin] [int] NOT NULL,
	[seniority] [date] NOT NULL,
	[jobStart] [date] NOT NULL,
	[payrate] [money] NOT NULL,
	[previousPayrate] [money] NULL,
	[payrateApplied] [date] NULL,
	[workPhone] [char](10) NOT NULL,
	[cellPhone] [char](10) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[payrollNotifyEmail] [nvarchar](50) NULL,
	[job] [int] NOT NULL,
	[department] [int] NOT NULL,
	[accessLevel] [nchar](1) NULL,
	[status] [nvarchar](10) NOT NULL CONSTRAINT [DF_employee_status]  DEFAULT (N'Active'),
	[statusApplied] [date] NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[item]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[item](
	[itemId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [varchar](200) NOT NULL,
	[price] [money] NOT NULL,
	[purchaseLocation] [varchar](100) NOT NULL,
	[quantity] [int] NOT NULL,
	[justification] [varchar](300) NOT NULL,
	[modificationReason] [varchar](200) NULL,
	[orderNumber] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[subtotal] [money] NOT NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_item] PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[job]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[maxPayrate] [money] NOT NULL,
	[affectDate] [date] NULL,
	[oldMaxPay] [money] NULL,
 CONSTRAINT [PK_job] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[payPeriod]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payPeriod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payDate] [date] NOT NULL,
	[passcode] [nvarchar](50) NOT NULL,
	[processed] [bit] NOT NULL,
 CONSTRAINT [PK_payPeriod] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[payroll]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payroll](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[payrate] [money] NOT NULL,
	[gross] [money] NOT NULL,
	[tax] [money] NOT NULL,
	[cpp] [money] NOT NULL,
	[ei] [money] NOT NULL,
	[pension] [money] NOT NULL,
	[pay] [money] NULL,
	[payPeriod] [int] NULL,
 CONSTRAINT [PK_payroll] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[purchaseOrder]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[purchaseOrder](
	[orderNumber] [int] IDENTITY(1,1) NOT NULL,
	[orderDate] [datetime] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[subtotal] [money] NOT NULL,
	[taxes] [money] NOT NULL,
	[total] [money] NOT NULL,
	[employeeId] [int] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_purchaseOrder] PRIMARY KEY CLUSTERED 
(
	[orderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SickDay]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SickDay](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[fullDay] [bit] NOT NULL,
	[description] [nvarchar](200) NOT NULL,
	[empId] [int] NOT NULL,
 CONSTRAINT [PK_SickDay] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[department] ON 

INSERT [dbo].[department] ([id], [title], [supervisor], [supervisorName]) VALUES (1, N'Development', 10000002, N'Steve Hamm')
INSERT [dbo].[department] ([id], [title], [supervisor], [supervisorName]) VALUES (2, N'Design', 10000007, N'Tim Fisher')
INSERT [dbo].[department] ([id], [title], [supervisor], [supervisorName]) VALUES (4, N'Management', 10000009, N'Thomas Donovan')
SET IDENTITY_INSERT [dbo].[department] OFF
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([id], [lastName], [firstName], [middleName], [dob], [street], [city], [postalCode], [sin], [seniority], [jobStart], [payrate], [previousPayrate], [payrateApplied], [workPhone], [cellPhone], [email], [payrollNotifyEmail], [job], [department], [accessLevel], [status], [statusApplied]) VALUES (10000002, N'Hamm', N'Steve', N'M', CAST(N'1989-12-29' AS Date), N'200 Main Street', N'Moncton', N'E1A8E8', 129416745, CAST(N'2016-01-12' AS Date), CAST(N'2014-06-14' AS Date), 27.1973, 26.6640, CAST(N'2017-05-08' AS Date), N'5067841234', N'5069885432', N'aesteve@live.com', N'aesteve@live.com', 1, 1, N'S', N'Active', NULL)
INSERT [dbo].[employee] ([id], [lastName], [firstName], [middleName], [dob], [street], [city], [postalCode], [sin], [seniority], [jobStart], [payrate], [previousPayrate], [payrateApplied], [workPhone], [cellPhone], [email], [payrollNotifyEmail], [job], [department], [accessLevel], [status], [statusApplied]) VALUES (10000005, N'Romkey', N'Dylan', N'J', CAST(N'1990-01-01' AS Date), N'103 Duffrin Lane', N'Saint Paul', N'E1Z1Z2', 129546134, CAST(N'2010-03-02' AS Date), CAST(N'2013-05-09' AS Date), 23.1199, 23.1199, CAST(N'2017-05-08' AS Date), N'5063332156', N'5066741019', N'dylan@dylanromkey.com', N'dylan@dylanromkey.com', 1, 2, N'H', N'Active', NULL)
INSERT [dbo].[employee] ([id], [lastName], [firstName], [middleName], [dob], [street], [city], [postalCode], [sin], [seniority], [jobStart], [payrate], [previousPayrate], [payrateApplied], [workPhone], [cellPhone], [email], [payrollNotifyEmail], [job], [department], [accessLevel], [status], [statusApplied]) VALUES (10000006, N'Blais', N'Ashley', N'L', CAST(N'1992-09-11' AS Date), N'7 Fergusson Lane', N'Moncton', N'E1Z6F4', 129478223, CAST(N'2016-02-14' AS Date), CAST(N'2015-07-11' AS Date), 24.2759, 23.7999, CAST(N'2017-05-08' AS Date), N'5066345578', N'5063336890', N'ashleylynnblais@live.com', N'ashleylynnblais@live.com', 1, 1, N'E', N'Active', NULL)
INSERT [dbo].[employee] ([id], [lastName], [firstName], [middleName], [dob], [street], [city], [postalCode], [sin], [seniority], [jobStart], [payrate], [previousPayrate], [payrateApplied], [workPhone], [cellPhone], [email], [payrollNotifyEmail], [job], [department], [accessLevel], [status], [statusApplied]) VALUES (10000007, N'Fisher', N'Tim', N'A', CAST(N'2017-05-11' AS Date), N'7 Fergusson Lane', N'Moncton', N'E1Z6F4', 324234234, CAST(N'2016-02-14' AS Date), CAST(N'2017-05-08' AS Date), 24.0130, 24.0100, CAST(N'2017-05-09' AS Date), N'3423423423', N'2342342342', N'timfisher@live.com', N'timfisher@live.com', 1, 2, N'S', N'Terminated', CAST(N'2017-02-02' AS Date))
INSERT [dbo].[employee] ([id], [lastName], [firstName], [middleName], [dob], [street], [city], [postalCode], [sin], [seniority], [jobStart], [payrate], [previousPayrate], [payrateApplied], [workPhone], [cellPhone], [email], [payrollNotifyEmail], [job], [department], [accessLevel], [status], [statusApplied]) VALUES (10000008, N'Boilly', N'Billy', N'l', CAST(N'1997-05-02' AS Date), N'55 Main Street', N'Moncton', N'E1G2W3', 345345345, CAST(N'2010-05-02' AS Date), CAST(N'2017-05-09' AS Date), 14.0000, 14.9338, CAST(N'2017-05-09' AS Date), N'9787697897', N'9870798707', N'billyb@live.com', N'billyb@live.com', 1, 4, N'E', N'Active', CAST(N'2017-05-23' AS Date))
INSERT [dbo].[employee] ([id], [lastName], [firstName], [middleName], [dob], [street], [city], [postalCode], [sin], [seniority], [jobStart], [payrate], [previousPayrate], [payrateApplied], [workPhone], [cellPhone], [email], [payrollNotifyEmail], [job], [department], [accessLevel], [status], [statusApplied]) VALUES (10000009, N'Donovan', N'Thomas', N'E', CAST(N'1927-12-13' AS Date), N'7 Greenhead Road', N'Saint John', N'E1A4A2', 129445213, CAST(N'2015-06-11' AS Date), CAST(N'2014-05-12' AS Date), 61.2000, 60.0000, CAST(N'2017-05-08' AS Date), N'5066724582', N'5063334690', N'thomas@donovan.com', N'thomas@donovan.com', 4, 4, N'C', N'Active', NULL)
INSERT [dbo].[employee] ([id], [lastName], [firstName], [middleName], [dob], [street], [city], [postalCode], [sin], [seniority], [jobStart], [payrate], [previousPayrate], [payrateApplied], [workPhone], [cellPhone], [email], [payrollNotifyEmail], [job], [department], [accessLevel], [status], [statusApplied]) VALUES (10000010, N'McOld', N'Frank', N'E', CAST(N'1959-12-13' AS Date), N'5 Somerset Street', N'Saint Paul', N'E1G2W1', 213423421, CAST(N'1927-12-13' AS Date), CAST(N'2017-05-08' AS Date), 12.2400, 12.0000, CAST(N'2017-05-08' AS Date), N'4234324234', N'2342342342', N'McOld@Hotmail', N'McOld@Hotmail.com', 2, 2, N'H', N'Active', NULL)
SET IDENTITY_INSERT [dbo].[employee] OFF
SET IDENTITY_INSERT [dbo].[item] ON 

INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (128, N'Pencils', N'Writing utensils', 10.0000, N'Walmart', 2, N'I need something to write with', NULL, 55, N'Pending', 20.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (129, N'Stapler', N'Paper binding device', 8.0000, N'Staples', 1, N'I need to bind papers together', NULL, 55, N'Pending', 8.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (130, N'Binder', N'Three ring binder', 12.0000, N'Walmart', 2, N'I need something to hold papers', NULL, 55, N'Pending', 24.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (131, N'USB drive', N'Data storage device', 29.0000, N'Best Buy', 1, N'I need something to store my files on', NULL, 56, N'Pending', 29.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (132, N'Pens', N'Ink writing utensils', 9.0000, N'Walmart', 2, N'I need something to write with in ink', NULL, 56, N'Pending', 18.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (133, N'Wireless keyboard', N'Computer input device', 40.0000, N'Staples', 1, N'I need a new keyboard for my computer', NULL, 56, N'Pending', 40.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (134, N'Mouse pad', N'Pad for computer input device', 12.0000, N'Staples', 1, N'I need a new tracking surface for my mouse', NULL, 57, N'Approved', 12.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (135, N'Laptop bag', N'Computer carrying case', 50.0000, N'Best Buy', 1, N'I need something to carry my laptop in', NULL, 57, N'Pending', 50.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (136, N'Laptop charger', N'computer charging device', 49.0000, N'Walmart', 1, N'I need a new charger for my laptop', NULL, 58, N'Approved', 49.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (137, N'USB card reader', N'Data storage device reader', 39.0000, N'Best Buy', 1, N'I need a device to read memory cards', NULL, 58, N'Approved', 39.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (138, N'Phone screen protector', N'Glass screen protector for phone', 15.0000, N'Zellers', 1, N'I need something to protect my phone screen', N'Unnecessary for work', 58, N'Denied', 15.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (139, N'Solid state hard drive', N'Computer mass storage device', 449.0000, N'Best Buy', 1, N'I need a faster computer hard drive', NULL, 59, N'Pending', 449.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (140, N'Calculator', N'Digital calculating device', 17.0000, N'Walmart', 1, N'I need help with calculations', NULL, 59, N'Pending', 17.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (141, N'Page dividers', N'Paper dividing sheets', 8.0000, N'Staples', 2, N'I need to separate pages', NULL, 59, N'Pending', 16.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (142, N'Laptop case', N'computer protecting device', 29.0000, N'Best Buy', 1, N'I need something to protect my laptop', NULL, 60, N'Pending', 29.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (143, N'HDMI cord', N'Visual output device', 49.0000, N'The Source', 1, N'I need to output my computer to HDMI', NULL, 60, N'Pending', 49.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (144, N'Webcam', N'Peripheral device', 59.0000, N'Best Buy', 1, N'I need a camera for Skype calls', NULL, 60, N'Pending', 59.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (145, N'Apple remote', N'Computer input device', 79.0000, N'Walmart', 1, N'I need a remote for my Macbook', NULL, 61, N'Pending', 79.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (146, N'Lightning adapter', N'Computer output device', 85.0000, N'Best Buy', 1, N'I need to output my Macbook to a screen', NULL, 61, N'Pending', 85.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (147, N'USB drive', N'Computer storage device', 29.0000, N'Walmart', 1, N'I need to store files from my computer', NULL, 62, N'Pending', 29.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (148, N'iPad case', N'Computer protective accessory', 65.0000, N'Best Buy', 1, N'I need to protect my iPad', N'Too expensive', 62, N'Denied', 65.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (149, N'Mouse', N'Computer input device', 29.0000, N'Walmart', 1, N'I need a new mouse for my computer', NULL, 62, N'Pending', 29.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (150, N'Binder', N'Three ring binder', 10.0000, N'Walmart', 2, N'I need to store my work papers', NULL, 63, N'Pending', 20.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (151, N'Pens', N'Writing utensils', 8.0000, N'Dollorama', 3, N'I need something to write with', NULL, 63, N'Pending', 24.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (152, N'iPhone case', N'Phone protection accessory', 29.0000, N'Best Buy', 1, N'I need to protect my work phone', NULL, 64, N'Pending', 29.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (153, N'Stylus pen', N'Tablet input device', 19.0000, N'Zellers', 1, N'I need a new stylus for my tablet', NULL, 64, N'Pending', 19.0000)
INSERT [dbo].[item] ([itemId], [name], [description], [price], [purchaseLocation], [quantity], [justification], [modificationReason], [orderNumber], [status], [subtotal]) VALUES (154, N'iPhone charger', N'Phone charging accessory', 49.0000, N'Walmart', 1, N'I need a new charger for my work phone', NULL, 64, N'Pending', 49.0000)
SET IDENTITY_INSERT [dbo].[item] OFF
SET IDENTITY_INSERT [dbo].[job] ON 

INSERT [dbo].[job] ([id], [title], [maxPayrate], [affectDate], [oldMaxPay]) VALUES (1, N'BackEnd', 50.9949, CAST(N'2017-05-08' AS Date), 49.9950)
INSERT [dbo].[job] ([id], [title], [maxPayrate], [affectDate], [oldMaxPay]) VALUES (2, N'Frontend', 33.9966, CAST(N'2017-05-08' AS Date), 33.3300)
INSERT [dbo].[job] ([id], [title], [maxPayrate], [affectDate], [oldMaxPay]) VALUES (3, N'BOL', 39.6627, CAST(N'2017-05-08' AS Date), 38.8850)
INSERT [dbo].[job] ([id], [title], [maxPayrate], [affectDate], [oldMaxPay]) VALUES (4, N'CEO', 61.2000, CAST(N'2017-05-08' AS Date), 60.0000)
SET IDENTITY_INSERT [dbo].[job] OFF
SET IDENTITY_INSERT [dbo].[payPeriod] ON 

INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (10, CAST(N'2014-03-24' AS Date), N'pass0', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (11, CAST(N'2010-04-07' AS Date), N'pass1', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (12, CAST(N'2011-04-21' AS Date), N'pass2', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (13, CAST(N'2012-05-05' AS Date), N'pass3', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (14, CAST(N'2013-05-19' AS Date), N'pass4', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (15, CAST(N'2014-06-02' AS Date), N'pass5', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (16, CAST(N'2015-06-16' AS Date), N'pass6', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (17, CAST(N'2016-06-30' AS Date), N'pass7', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (18, CAST(N'2016-07-14' AS Date), N'pass8', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (19, CAST(N'2016-07-28' AS Date), N'pass9', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (20, CAST(N'2016-08-11' AS Date), N'pass10', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (21, CAST(N'2016-08-25' AS Date), N'pass11', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (22, CAST(N'2016-09-08' AS Date), N'pass12', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (23, CAST(N'2016-09-22' AS Date), N'pass13', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (24, CAST(N'2016-10-06' AS Date), N'pass14', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (25, CAST(N'2016-10-20' AS Date), N'pass15', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (26, CAST(N'2016-11-03' AS Date), N'pass16', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (27, CAST(N'2016-11-17' AS Date), N'pass17', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (28, CAST(N'2016-12-01' AS Date), N'pass18', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (29, CAST(N'2016-12-16' AS Date), N'pass19', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (30, CAST(N'2017-01-06' AS Date), N'pass20', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (31, CAST(N'2017-01-20' AS Date), N'pass21', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (32, CAST(N'2017-02-03' AS Date), N'pass22', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (33, CAST(N'2017-02-17' AS Date), N'pass23', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (34, CAST(N'2017-03-03' AS Date), N'pass24', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (35, CAST(N'2017-03-17' AS Date), N'pass25', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (36, CAST(N'2017-03-31' AS Date), N'pass26', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (37, CAST(N'2017-04-14' AS Date), N'pass27', 1)
INSERT [dbo].[payPeriod] ([id], [payDate], [passcode], [processed]) VALUES (38, CAST(N'2017-04-28' AS Date), N'pass28', 0)
SET IDENTITY_INSERT [dbo].[payPeriod] OFF
SET IDENTITY_INSERT [dbo].[payroll] ON 

INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (97, 10000010, 24.0000, 30960.0000, 364.8000, 95.0400, 34.5600, 111.3600, 354.2400, 11)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (98, 10000005, 20.0000, 800.0000, 304.0000, 79.2000, 28.8000, 92.8000, 295.2000, 11)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (99, 10000008, 21.4221, 30969.6000, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 11)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (100, 10000007, 21.0000, 840.0000, 319.2000, 83.1600, 30.2400, 97.4400, 309.9600, 11)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (101, 10000010, 24.2400, 30969.6000, 368.4480, 95.9904, 34.9056, 112.4736, 357.7824, 12)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (102, 10000005, 25.3389, 1013.5560, 385.1513, 100.3420, 36.4880, 117.5725, 374.0022, 12)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (103, 10000008, 21.6363, 865.4520, 328.8718, 85.6797, 31.1563, 100.3924, 319.3518, 12)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (104, 10000007, 21.2100, 848.4000, 322.3920, 83.9916, 30.5424, 98.4144, 313.0596, 12)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (105, 10000010, 24.2400, 30969.6000, 368.4480, 95.9904, 34.9056, 112.4736, 357.7824, 13)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (106, 10000005, 25.3389, 1013.5560, 385.1513, 100.3420, 36.4880, 117.5725, 374.0022, 13)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (107, 10000008, 21.6363, 865.4520, 328.8718, 85.6797, 31.1563, 100.3924, 319.3518, 13)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (108, 10000007, 21.2100, 848.4000, 322.3920, 83.9916, 30.5424, 98.4144, 313.0596, 13)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (109, 10000010, 24.2400, 30969.6000, 368.4480, 95.9904, 34.9056, 112.4736, 357.7824, 14)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (110, 10000005, 25.3389, 1050.5560, 385.1513, 100.3420, 36.4880, 117.5725, 374.0022, 14)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (111, 10000008, 21.6363, 865.4520, 328.8718, 85.6797, 31.1563, 100.3924, 319.3518, 14)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (112, 10000007, 21.2100, 848.4000, 322.3920, 83.9916, 30.5424, 98.4144, 313.0596, 14)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (113, 10000010, 24.4824, 30979.2960, 372.1325, 96.9503, 35.2547, 113.5983, 361.3602, 15)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (114, 10000005, 25.5923, 1023.6920, 389.0030, 101.3455, 36.8529, 118.7483, 377.7423, 15)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (115, 10000008, 22.2897, 891.5880, 338.8034, 88.2672, 32.0972, 103.4242, 328.9960, 15)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (116, 10000007, 21.4221, 856.8840, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 15)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (117, 10000010, 24.4824, 30979.2960, 372.1325, 96.9503, 35.2547, 113.5983, 361.3602, 16)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (118, 10000005, 26.1041, 1044.1640, 396.7823, 103.3722, 37.5899, 121.1230, 385.2966, 16)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (119, 10000008, 22.2897, 891.5880, 338.8034, 88.2672, 32.0972, 103.4242, 328.9960, 16)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (120, 10000007, 21.4221, 856.8840, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 16)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (121, 10000008, 12.0000, 480.0000, 182.4000, 47.5200, 17.2800, 55.6800, 177.1200, 16)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (122, 10000010, 24.4824, 30979.2960, 372.1325, 96.9503, 35.2547, 113.5983, 361.3602, 17)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (123, 10000005, 26.1041, 1044.1640, 396.7823, 103.3722, 37.5899, 121.1230, 385.2966, 17)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (124, 10000008, 22.2897, 891.5880, 338.8034, 88.2672, 32.0972, 103.4242, 328.9960, 17)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (125, 10000007, 21.4221, 856.8840, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 17)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (126, 10000008, 12.0000, 480.0000, 182.4000, 47.5200, 17.2800, 55.6800, 177.1200, 17)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (127, 10000002, 24.4824, 979.2960, 372.1325, 96.9503, 35.2547, 113.5983, 361.3602, 18)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (128, 10000005, 26.1041, 1044.1640, 396.7823, 103.3722, 37.5899, 121.1230, 385.2966, 18)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (129, 10000006, 22.2897, 891.5880, 338.8034, 88.2672, 32.0972, 103.4242, 328.9960, 18)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (130, 10000007, 21.4221, 856.8840, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 18)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (131, 10000008, 12.0000, 480.0000, 182.4000, 47.5200, 17.2800, 55.6800, 177.1200, 18)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (132, 10000002, 24.4824, 979.2960, 372.1325, 96.9503, 35.2547, 113.5983, 361.3602, 19)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (133, 10000005, 26.1041, 1044.1640, 396.7823, 103.3722, 37.5899, 121.1230, 385.2966, 19)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (134, 10000006, 22.2897, 891.5880, 338.8034, 88.2672, 32.0972, 103.4242, 328.9960, 19)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (135, 10000007, 21.4221, 856.8840, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 19)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (136, 10000008, 12.0000, 480.0000, 182.4000, 47.5200, 17.2800, 55.6800, 177.1200, 19)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (137, 10000002, 24.4824, 979.2960, 372.1325, 96.9503, 35.2547, 113.5983, 361.3602, 20)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (138, 10000005, 26.1041, 1044.1640, 396.7823, 103.3722, 37.5899, 121.1230, 385.2966, 20)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (139, 10000006, 22.2897, 891.5880, 338.8034, 88.2672, 32.0972, 103.4242, 328.9960, 20)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (140, 10000007, 21.4221, 856.8840, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 20)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (141, 10000008, 12.0000, 480.0000, 182.4000, 47.5200, 17.2800, 55.6800, 177.1200, 20)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (142, 10000002, 24.4824, 979.2960, 372.1325, 96.9503, 35.2547, 113.5983, 361.3602, 21)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (143, 10000005, 26.1041, 1044.1640, 396.7823, 103.3722, 37.5899, 121.1230, 385.2966, 21)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (144, 10000006, 22.2897, 891.5880, 338.8034, 88.2672, 32.0972, 103.4242, 328.9960, 21)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (145, 10000007, 21.4221, 856.8840, 325.6159, 84.8315, 30.8478, 99.3985, 316.1903, 21)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (146, 10000008, 20.2300, 809.2000, 307.4960, 80.1108, 29.1312, 93.8672, 298.5948, 21)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (156, 10000002, 26.6640, 1066.5600, 405.2928, 105.5894, 38.3962, 123.7210, 393.5606, 25)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (157, 10000005, 22.4422, 897.6880, 341.1214, 88.8711, 32.3168, 104.1318, 331.2469, 25)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (158, 10000006, 23.7999, 951.9960, 361.7585, 94.2476, 34.2719, 110.4315, 351.2865, 25)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (159, 10000007, 23.3310, 933.2400, 354.6312, 92.3908, 33.5966, 108.2558, 344.3656, 25)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (160, 10000008, 14.6410, 585.6400, 222.5432, 57.9784, 21.0830, 67.9342, 216.1012, 25)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (161, 10000009, 60.0000, 2400.0000, 912.0000, 237.6000, 86.4000, 278.4000, 885.6000, 25)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (162, 10000010, 12.0000, 30480.0000, 182.4000, 47.5200, 17.2800, 55.6800, 177.1200, 25)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (163, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 26)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (164, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 26)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (165, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 26)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (166, 10000007, 24.2736, 970.9440, 368.9587, 96.1235, 34.9540, 112.6295, 358.2783, 26)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (167, 10000008, 14.9338, 597.3520, 226.9938, 59.1378, 21.5047, 69.2928, 220.4229, 26)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (168, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 26)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (169, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 26)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (170, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 27)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (171, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 27)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (172, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 27)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (173, 10000007, 24.2736, 970.9440, 368.9587, 96.1235, 34.9540, 112.6295, 358.2783, 27)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (174, 10000008, 14.9338, 597.3520, 226.9938, 59.1378, 21.5047, 69.2928, 220.4229, 27)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (175, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 27)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (176, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 27)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (177, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 28)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (178, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 28)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (179, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 28)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (180, 10000007, 24.2736, 970.9440, 368.9587, 96.1235, 34.9540, 112.6295, 358.2783, 28)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (181, 10000008, 14.9338, 597.3520, 226.9938, 59.1378, 21.5047, 69.2928, 220.4229, 28)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (182, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 28)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (183, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 28)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (184, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 29)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (185, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 29)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (186, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 29)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (187, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 29)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (188, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 29)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (189, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 29)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (190, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 29)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (191, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 30)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (192, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 30)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (193, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 30)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (194, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 30)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (195, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 30)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (196, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 30)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (197, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 30)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (198, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 31)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (199, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 31)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (200, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 31)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (201, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 31)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (202, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 31)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (203, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 31)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (204, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 31)
GO
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (205, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 32)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (206, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 32)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (207, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 32)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (208, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 32)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (209, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 32)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (210, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 32)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (211, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 32)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (212, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 33)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (213, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 33)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (214, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 33)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (215, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 33)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (216, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 33)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (217, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 33)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (218, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 33)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (219, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 34)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (220, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 34)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (221, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 34)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (222, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 34)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (223, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 34)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (224, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 34)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (225, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 34)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (226, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 35)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (227, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 35)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (228, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 35)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (229, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 35)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (230, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 35)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (231, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 35)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (232, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 35)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (233, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 36)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (234, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 36)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (235, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 36)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (236, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 36)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (237, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 36)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (238, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 36)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (239, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 36)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (240, 10000002, 27.1973, 1087.8920, 413.3990, 107.7013, 39.1641, 126.1955, 401.4321, 37)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (241, 10000005, 23.1199, 924.7960, 351.4225, 91.5548, 33.2927, 107.2763, 341.2497, 37)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (242, 10000006, 24.2759, 971.0360, 368.9937, 96.1326, 34.9573, 112.6402, 358.3122, 37)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (243, 10000007, 24.0130, 960.5200, 364.9976, 95.0915, 34.5787, 111.4203, 354.4319, 37)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (244, 10000008, 14.0000, 560.0000, 212.8000, 55.4400, 20.1600, 64.9600, 206.6400, 37)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (245, 10000009, 61.2000, 2448.0000, 930.2400, 242.3520, 88.1280, 283.9680, 903.3120, 37)
INSERT [dbo].[payroll] ([id], [empId], [payrate], [gross], [tax], [cpp], [ei], [pension], [pay], [payPeriod]) VALUES (246, 10000010, 12.2400, 489.6000, 186.0480, 48.4704, 17.6256, 56.7936, 180.6624, 37)
SET IDENTITY_INSERT [dbo].[payroll] OFF
SET IDENTITY_INSERT [dbo].[purchaseOrder] ON 

INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (55, CAST(N'2017-05-09 15:31:04.420' AS DateTime), N'Pending', 52.0000, 7.8000, 59.8000, 10000006)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (56, CAST(N'2017-05-09 15:32:40.733' AS DateTime), N'Pending', 87.0000, 13.0500, 100.0500, 10000006)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (57, CAST(N'2017-05-09 15:34:18.323' AS DateTime), N'Under Review', 62.0000, 9.3000, 71.3000, 10000006)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (58, CAST(N'2017-05-09 15:38:33.637' AS DateTime), N'Closed', 103.0000, 15.4500, 118.4500, 10000006)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (59, CAST(N'2017-05-09 15:52:03.383' AS DateTime), N'Pending', 482.0000, 72.3000, 554.3000, 10000002)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (60, CAST(N'2017-05-09 15:55:31.593' AS DateTime), N'Pending', 137.0000, 20.5500, 157.5500, 10000002)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (61, CAST(N'2017-05-09 15:59:01.963' AS DateTime), N'Pending', 164.0000, 24.6000, 188.6000, 10000002)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (62, CAST(N'2017-05-09 16:01:23.437' AS DateTime), N'Under Review', 123.0000, 18.4500, 141.4500, 10000007)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (63, CAST(N'2017-05-09 16:02:08.923' AS DateTime), N'Pending', 44.0000, 6.6000, 50.6000, 10000007)
INSERT [dbo].[purchaseOrder] ([orderNumber], [orderDate], [status], [subtotal], [taxes], [total], [employeeId]) VALUES (64, CAST(N'2017-05-09 16:04:46.277' AS DateTime), N'Pending', 97.0000, 14.5500, 111.5500, 10000007)
SET IDENTITY_INSERT [dbo].[purchaseOrder] OFF
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_department] FOREIGN KEY([department])
REFERENCES [dbo].[department] ([id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_department]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_job] FOREIGN KEY([job])
REFERENCES [dbo].[job] ([id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_job]
GO
ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_purchaseOrder] FOREIGN KEY([orderNumber])
REFERENCES [dbo].[purchaseOrder] ([orderNumber])
GO
ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_purchaseOrder]
GO
ALTER TABLE [dbo].[payroll]  WITH CHECK ADD  CONSTRAINT [FK_payroll_employee] FOREIGN KEY([empId])
REFERENCES [dbo].[employee] ([id])
GO
ALTER TABLE [dbo].[payroll] CHECK CONSTRAINT [FK_payroll_employee]
GO
ALTER TABLE [dbo].[payroll]  WITH CHECK ADD  CONSTRAINT [FK_payroll_payPeriod] FOREIGN KEY([payPeriod])
REFERENCES [dbo].[payPeriod] ([id])
GO
ALTER TABLE [dbo].[payroll] CHECK CONSTRAINT [FK_payroll_payPeriod]
GO
ALTER TABLE [dbo].[purchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_purchaseOrder_employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[employee] ([id])
GO
ALTER TABLE [dbo].[purchaseOrder] CHECK CONSTRAINT [FK_purchaseOrder_employee]
GO
ALTER TABLE [dbo].[SickDay]  WITH CHECK ADD  CONSTRAINT [FK_SickDay_employee] FOREIGN KEY([empId])
REFERENCES [dbo].[employee] ([id])
GO
ALTER TABLE [dbo].[SickDay] CHECK CONSTRAINT [FK_SickDay_employee]
GO
/****** Object:  StoredProcedure [dbo].[CreateLog]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateLog]
(@LogName varchar(100),
@Msg varchar(500))
AS
BEGIN
	DECLARE @filename varchar(100)
	SET @filename = 'C:\Users\Steve\NBCC\Final\Logs\' + @LogName + '.txt'

	DECLARE @cmd varchar(2000)
	SET @cmd = 'echo ' + @Msg + ' >> ' + @filename
	EXEC master..xp_cmdshell @cmd
END







GO
/****** Object:  StoredProcedure [dbo].[DepartmentByEmployeeId]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DepartmentByEmployeeId]
	(@EmployeeId int)
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM employee WHERE id = @EmployeeId)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Employee not on file.';
				THROW 50015, @Error, 1
			END;	
		
		SELECT department.id, department.title, department.supervisor, department.supervisorName FROM department INNER JOIN employee ON employee.department = department.id
		WHERE employee.id = @EmployeeId
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[DepartmentLookup]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[DepartmentLookup]

AS	
set nocount on


SELECT id, title FROM department








GO
/****** Object:  StoredProcedure [dbo].[DepartmentRetrieve]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DepartmentRetrieve]
	(@id int)
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM department WHERE id = @id)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Department not on file.';
				THROW 50015, @Error, 1
			END;	
		
		SELECT * from department WHERE id = @id

    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessLevel]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeAccessLevel]
	(@FirstName varchar(50),
	@LastName varchar(50))
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM employee WHERE firstName = @FirstName AND lastName = @LastName)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Employee not on file.';
				THROW 50015, @Error, 1
			END;	
		
		SELECT accessLevel FROM employee WHERE firstName = @FirstName AND lastName = @LastName
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[EmployeeById]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeById]
		@id int

AS	
set nocount on
IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Employee not on file.';
				THROW 50015, @Error, 1
			END;

SELECT * FROM employee WHERE id = @id







GO
/****** Object:  StoredProcedure [dbo].[EmployeeByName]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeByName]
	(@FirstName varchar(50),
	@LastName varchar(50))
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM employee WHERE firstName = @FirstName AND lastName = @LastName)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Employee not on file.';
				THROW 50015, @Error, 1
			END;	
		
		SELECT * FROM employee WHERE firstName = @FirstName AND lastName = @LastName
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[EmployeeByOrderNumber]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeByOrderNumber]
	(@OrderNumber int)
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM employee INNER JOIN purchaseOrder ON employee.id = purchaseOrder.employeeId WHERE purchaseOrder.orderNumber = @OrderNumber)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Employee not on file.';
				THROW 50009, @Error, 1
			END;

		SELECT * FROM employee INNER JOIN purchaseOrder ON employee.id = purchaseOrder.employeeId WHERE purchaseOrder.orderNumber = @OrderNumber
		
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[EmployeeInsert]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeInsert]
	@id			int output,
 	@Lname		varchar(50),
	@Fname		varchar(50),
	@Mname		char(1) = null, --optional (biz 201)
	@bod		date,
	@street		varchar(100),
	@city		varchar(50),
	@PO			char(6),
	@SIN		int,
	@seniority	date,
	@jobStart	date,
	@payrate	money,
	@previousPayrate money,
	@payrateApplied  date,
	@workPhone	char(10),
	@cellPhone	char(10),
	@email		varchar(50),
	@payrollNotifyEmail	varchar(50) NULL,
	@job		int,
	@department int

AS	
set nocount on

begin try

	SET NOCOUNT ON;

	--payrate cant be higher than job max (biz 202)
	if (@payrate > (SELECT maxPayrate from job where id = @job))
	begin;
		THROW 50001, 'The payrate is too high for that job', 1
	end;

	--job start date cant be earlier than seniority date (biz 207)
	if (@jobStart < @seniority)
	begin;
		THROW 50002, 'Job can not be started before seniority date', 1
	end;



    INSERT employee (lastName,firstName,middleName,dob,street,city,postalCode,[sin],seniority,jobStart,job,department,payrate,previousPayrate,payrateApplied,workPhone,cellPhone,email,payrollNotifyEmail)
	 values (@Lname, @Fname, @Mname, @bod, @street, @city, @PO, @SIN, @seniority, @jobStart,@job,@department,@payrate,@previousPayrate,@payrateApplied,@workPhone,@cellPhone,@email,@payrollNotifyEmail);
	set @id = SCOPE_IDENTITY();
end try
begin catch
	throw 
end catch









GO
/****** Object:  StoredProcedure [dbo].[EmployeeList]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeList]
AS	
set nocount on


SELECT * FROM employee 







GO
/****** Object:  StoredProcedure [dbo].[EmployeeLookup]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeLookup]
		@id int = NULL,
		@search Varchar(50) = NULL

AS	
set nocount on


SELECT id, firstName + ' ' + lastName as title FROM employee 
WHERE (@id is null or id = @id) and (@search is null or lastName like @search)








GO
/****** Object:  StoredProcedure [dbo].[EmployeePensionInfo]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeePensionInfo]
		@id int 

AS	
set nocount on
begin try

IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
	BEGIN;
		THROW 50001, 'Can not find you on file', 1
	END;

DECLARE @today date, @5years bit = 1, @55age bit = 1, @bestPays money, @bestPay money, @pension money, @retireDate date, @55 money,@56 money,@57 money,@58 money,@59 money

IF ((SELECT DATEADD(YEAR,55,dob) FROM employee WHERE id = @id) > GETDATE()) -- cannot retire till 55 (biz 300)
	BEGIN;
		SET @55age = 0;
		--THROW 50300, 'Must be 55 to be eligible for retirement', 1
	END;
IF ((SELECT DATEADD(YEAR, 5, seniority) FROM employee WHERE id = @id) > GETDATE()) -- cannot retire unless you have worked for 5 years (biz 305)
	BEGIN;
		SET @5years = 0;
		THROW 50305, 'You must have been with the company for 5 years to be eligible for retirement', 1
	END;

SET @bestPays= (SELECT SUM(YTDGross) FROM (SELECT TOP 5 SUM(payroll.gross) AS 'YTDGross', DATEPART(year,payPeriod.payDate) AS 'Year' FROM payroll INNER JOIN payPeriod ON payPeriod.id = payroll.payPeriod WHERE payroll.empId = @id GROUP BY DATEPART(year,payDate) ORDER BY YTDGross DESC) as t) --5 highest pays (biz 302)
SET @bestPay = @bestPays / 5
SET @pension = @bestPay * .7 --pension is 70% of highest pays (biz 301)
 
 -- Apply early pension penalties (biz 303)
SET @55 = @pension - (@pension * .15) 
SET @56 = @pension - (@pension * .12) 
SET @57 = @pension - (@pension * .09)	
SET @58 = @pension - (@pension * .06)
SET @59 = @pension - (@pension * .03)


SELECT id, @pension as 'fullPensionPay', DATEADD(YEAR,60,dob) as 'fullRetireDate', @55 as 'at55',@56 as 'at56',@57 as 'at57',@58 as 'at58',@59 as 'at59',@55age as 'is55',@5years as 'is5YearsIn' FROM employee WHERE id = @id


end try
begin catch
	throw 
end catch









GO
/****** Object:  StoredProcedure [dbo].[EmployeeTop5Gross]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeTop5Gross]
		@id int

AS	
set nocount on
begin try

IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
	BEGIN;
		THROW 50001, 'Can not find you on file', 1
	END;
--IF ((SELECT DATEADD(YEAR,55,dob) FROM employee WHERE id = @id) > GETDATE()) -- cannot retire till 55 (biz 300)
--	BEGIN;
--		THROW 50300, 'Must be 55 to be eligible for retirement', 1
--	END;
IF ((SELECT DATEADD(YEAR, 5, seniority) FROM employee WHERE id = @id) > GETDATE()) -- cannot retire unless you have worked for 5 years (biz 305)
	BEGIN;
		THROW 50305, 'You must have been with the company for 5 years before you can retire', 1
	END;


SELECT TOP 5 SUM(payroll.gross) AS 'gross', DATEPART(year,payPeriod.payDate) AS 'year' FROM payroll INNER JOIN payPeriod ON payPeriod.id = payroll.payPeriod WHERE payroll.empId = @id GROUP BY DATEPART(year,payDate) ORDER BY gross DESC

end try
begin catch
	throw 
end catch




GO
/****** Object:  StoredProcedure [dbo].[EmployeeUpdateJob]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[EmployeeUpdateJob]
	@id			int,
	@startDate	date,
	@job		int,
	@dep		int,
	@pay		money

AS	
set nocount on

begin try

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
	BEGIN;
		THROW 50001, 'Can not find you on file', 1
	END;

	--payrate cant be higher than job max (biz 202)
	if (@pay > (SELECT maxPayrate FROM job INNER JOIN employee on job.id = employee.job WHERE employee.id = @id))
	begin;
		THROW 50202, 'Can not be more than department max', 1
	end;

	if (@startDate < (SELECT seniority FROM employee WHERE id=@id))
	begin;
		THROW 50207, 'Job start date cannot be before seniority date', 1
	end;

    UPDATE employee SET department=@dep,job=@job, previousPayrate=payrate,payrateApplied=GETDATE(), payrate=@pay,jobStart=@startDate
	 WHERE id = @id
end try
begin catch
	THROW
end catch









GO
/****** Object:  StoredProcedure [dbo].[EmployeeUpdatePersonal]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeUpdatePersonal]
	@id			int,
	@street		varchar(100),
	@city		varchar(50),
	@PO			char(6),
	@workPhone	char(10),
	@cellPhone	char(10)

AS	
set nocount on

begin try

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
	BEGIN;
		THROW 50001, 'Can not find you on file', 1
	END;




    UPDATE employee SET street=@street,city=@city,postalCode=@PO,workPhone=@workPhone,cellPhone=@cellPhone
	 WHERE id = @id
end try
begin catch
	THROW
end catch









GO
/****** Object:  StoredProcedure [dbo].[EmployeeUpdatePersonal2]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeUpdatePersonal2]
	@id			int,
	@street		varchar(100),
	@city		varchar(50),
	@PO			char(6),
	@fname		varchar(50),
	@lname		varchar(50),
	@mname		char(1) = null,
	@date		date

AS	
set nocount on

begin try

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
	BEGIN;
		THROW 50001, 'Can not find you on file', 1
	END;



    UPDATE employee SET street=@street,city=@city,postalCode=@PO,lastName=@lname, firstName=@fname, middleName=@mname, dob=@date
	 WHERE id = @id
end try
begin catch
	THROW
end catch









GO
/****** Object:  StoredProcedure [dbo].[EmployeeUpdateStatus]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeUpdateStatus]
			@id int,
			@status varchar(10),
			@date date

AS	
set nocount on

begin try

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
	BEGIN;
		THROW 50001, 'Can not find you on file', 1
	END;

	IF(@status = 'Terminated' and @date > (SELECT TOP 1 payDate FROM payPeriod ORDER BY payDate DESC))
	BEGIN;
		THROW 50306, 'Termination date must be within this pay period', 1
	END;

	IF(@status = 'Retired' and DATEDIFF(YEAR, (SELECT dob FROM employee WHERE id = @id), GETDATE()) < 55)
	BEGIN;
		THROW 50300, 'Must be 55 to retire', 1
	END;

UPDATE employee SET [status]=@status, statusApplied=@date WHERE id=@id

end try
begin catch
	THROW
end catch









GO
/****** Object:  StoredProcedure [dbo].[JobLookup]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[JobLookup]

AS	
set nocount on


SELECT id, title FROM job








GO
/****** Object:  StoredProcedure [dbo].[PayPeriodNextPay]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[PayPeriodNextPay]

AS	
set nocount on

begin try

	SET NOCOUNT ON;

SELECT payDate FROM payPeriod ORDER BY payDate DESC

end try
begin catch
	THROW
end catch









GO
/****** Object:  StoredProcedure [dbo].[PayraiseLiving]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PayraiseLiving]
			@payIn DECIMAL, 
			@affDate date
AS	
set nocount on
begin try

Update job SET oldMaxPay = maxPayrate, maxPayrate = (maxPayrate * (@payIn/100)) + maxPayrate, affectDate = @affDate
Update employee SET previousPayrate = payrate, payrate = (payrate * (@payIn/100)) + payrate, payrateApplied = @affDate


end try
begin catch
	THROW
end catch





GO
/****** Object:  StoredProcedure [dbo].[PayraisePersonal]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PayraisePersonal]
			@empId int,
			@payIn DECIMAL, 
			@affDate date,

			@payrate money OUTPUT,
			@oldRate money OUTPUT,
			@oldAffDate date OUTPUT
AS	
set nocount on
begin try

if not exists(SELECT * FROM employee WHERE id = @empId)
begin;
	THROW 50000, 'Could not find that employee on record', 1
end;

SELECT @oldRate = payrate, @oldAffDate = payrateApplied FROM employee WHERE id = @empId
set @payrate = (@oldRate * (@payIn/100)) + @oldRate

--Payrate can not be greater than jobs max(biz 211)
if @payrate > (SELECT maxPayrate FROM job WHERE id = (SELECT job FROM employee WHERE id = @empId) )
begin;
	THROW 50001, 'This payrate is too much for the current job', 1
end;

--Payrate can not be increased twice in one pay period(biz 211)
if @oldAffDate > (SELECT TOP 1 DATEADD(DAY, -14, payDate) FROM payPeriod ORDER BY payDate DESC)
begin;
	THROW 50002, 'This payrate has already been increased this pay', 1
end;


Update employee SET payrate = @payrate, previousPayrate = @oldRate, payrateApplied = @affDate WHERE id = @empId 


end try
begin catch
	THROW
end catch





GO
/****** Object:  StoredProcedure [dbo].[PayrollCode]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PayrollCode]

AS	
set nocount on

--payroll can only be processed every seconed friday(biz 217)
if not exists(SELECT TOP 1 payDate FROM payPeriod WHERE payDate = CAST(CURRENT_TIMESTAMP as DATE) ORDER BY payDate DESC )
begin;
	THROW 50001, 'Incorrect date to process pay', 1
end;

--payroll can only be processed once(biz 208)
if ((SELECT processed FROM payPeriod WHERE payDate = CAST(CURRENT_TIMESTAMP as DATE)) = 1)
begin;
	THROW 50002, 'This pay period has already been processed', 1
end;

if not exists(SELECT TOP 1 passcode from payPeriod ORDER BY payDate DESC)
begin;
	THROW 50000, 'An error occured retrieving the passcode', 1
end;

select TOP 1 passcode from payPeriod ORDER BY payDate DESC






GO
/****** Object:  StoredProcedure [dbo].[PayrollExc]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PayrollExc]

AS	
set nocount on

DECLARE @periodId int
DECLARE @periodDate date

begin try
 BEGIN TRANSACTION 

--get paydate info
SELECT TOP 1 @periodId = id, @periodDate = payDate FROM payPeriod ORDER BY payDate DESC

--insert pay recored for all employees
INSERT payroll (empId, payrate, gross, tax, cpp, ei, pension, payPeriod) 
SELECT id, payrate, payrate*40,
(payrate*80)*.19, --TAX(Biz 213)
IIF((payrate*80)*.0495>2100, 2100, (payrate*80)*.0495), --CPP(Biz 214)
IIF((payrate*80)*.018>720, 720, (payrate*80)*.018), --EI(Biz 215)
IIF((payrate*80)*.058>42000,((payrate*80)-42000)*.075,(payrate*80)*.058), --Pension(Biz 216)
@periodId FROM employee
UPDATE payroll SET pay = (gross - tax - cpp - ei - pension) WHERE payPeriod = @periodId

--set up payperiod
UPDATE payPeriod SET processed = 1 WHERE id = @periodId
INSERT payPeriod (payDate, passcode, processed) VALUES (DATEADD(DAY, 14,@periodDate),'pass'+CAST((SELECT COUNT(*) FROM payPeriod) AS VARCHAR(32)),0)


--select paystubs
SELECT employee.id as 'Employee ID', employee.firstName +' '+employee.middleName+' '+ employee.lastName as 'Name' , 
employee.dob as 'Birthday', employee.street+', '+employee.city as 'Address', payroll.payrate as 'Payrate',
payroll.gross as 'Gross pay', payroll.tax as 'Tax', payroll.cpp as 'CPP', payroll.ei as 'EI', payroll.pension as 'Pension',
payroll.pay as 'Net pay', YTD.* 
 FROM payroll
 INNER JOIN employee ON payroll.empId = employee.id 
 INNER JOIN (SELECT empId, SUM(payroll.gross) AS 'YTD Gross Pay',SUM(payroll.tax) AS 'YTD Tax',SUM(payroll.cpp) AS 'YTD CPP',
 SUM(payroll.ei) AS 'YTD EI',SUM(payroll.pension) AS 'YTD Pension',SUM(payroll.pay) AS 'YTD Pay' FROM payroll  
WHERE payPeriod IN (SELECT id FROM payPeriod WHERE DATEPART(year,payDate)=YEAR(getdate())) GROUP BY payroll.empId) 
 AS YTD ON YTD.empId = employee.id
 WHERE payroll.payPeriod = @periodId
 ORDER BY employee.lastName

   COMMIT
end try

begin catch
	IF @@TRANCOUNT > 0
        ROLLBACK
end catch




GO
/****** Object:  StoredProcedure [dbo].[PayrollNotifyEmails]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PayrollNotifyEmails]

AS	
set nocount on


SELECT payrollNotifyEmail 
FROM employee WHERE payrollNotifyEmail is not null






GO
/****** Object:  StoredProcedure [dbo].[SickdayInsert]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SickdayInsert]
	@total		int OUTPUT,
	@id			int,
	@date		date,
	@fullDay	bit,
	@description varchar(200)

AS	
set nocount on

begin try

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT * FROM employee WHERE id = @id)
	BEGIN;
		THROW 50001, 'Can not find you on file', 1
	END;


    INSERT SickDay ([date], fullDay, [description], empId)
	 values (@date, @fullDay, @description, @id);

	 SET @total = (SELECT COUNT(*) FROM SickDay WHERE empId = @id)

end try
begin catch
	throw 
end catch











GO
/****** Object:  StoredProcedure [dbo].[spApproveItem]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spApproveItem]
(@ItemId int,
@employeeId int,
 @Timestamp timestamp OUTPUT)
	AS	
	SET NOCOUNT ON
	Begin Try
		IF Not EXISTS (SELECT * FROM item WHERE ItemId = @ItemId)  
			BEGIN;
				DECLARE @Error char(50)
				SET @Error = 'Item not on file.';
				THROW 50011, @Error, 1
			END;				
			
		IF (SELECT [timestamp] FROM item WHERE itemId = @ItemId) <> @timestamp
			BEGIN;
				DECLARE @Error2 char(200)
				SET @Error2 = 'The item has been updated since you last retrieved it. Please retrieve it again and resubmit the update.';
				THROW 50017, @Error2, 1	
			END;	

		DECLARE @OrderNumber int
		SET @OrderNumber = (SELECT orderNumber FROM item WHERE itemId = @ItemId)

		DECLARE @Status varchar(50)
		SET @Status = (SELECT [status] FROM purchaseOrder WHERE orderNumber = @OrderNumber)

		DECLARE @OrderEmployeeId int
		SET @OrderEmployeeId = (SELECT employeeId FROM purchaseOrder INNER JOIN item 
		ON purchaseOrder.orderNumber = item.orderNumber WHERE itemId = @ItemId)

		--Supervisor is unable to process their own Purchase Order item
		IF @employeeId <> @OrderEmployeeId
			BEGIN;
				--Updates the Item and Purchase Order as long as the Purchase Order status is not already set to Closed
				--and the Supervisor is not the created of the Purchase Order item
				IF @Status <> 'Closed'
					BEGIN;
						UPDATE item SET [status] = 'Approved' WHERE ItemId = @ItemId	
						UPDATE purchaseOrder SET [status] = 'Under Review' WHERE orderNumber = @OrderNumber 
						SELECT @Timestamp = [timestamp] FROM item WHERE ItemId = @ItemId
					END;
				ELSE
					BEGIN;
						DECLARE @Error3 char(100)
						SET @Error3 = 'Purchase order is closed. Unable to process item.';
						THROW 50023, @Error3, 1	
					END;
			END;
		ELSE
			BEGIN;
				DECLARE @Error4 char(200)
				SET @Error4 = 'Supervisors are unable to process their own purchase orders. Please contact your ' +
					'superior to process the order for you. You are able to view the items that you have requested.';
				THROW 50024, @Error4, 1	
			END;
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spClosePurchaseOrder]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spClosePurchaseOrder]
(@OrderNumber int)
	AS	
	SET NOCOUNT ON
	Begin Try
		IF Not EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber)  
			BEGIN;
				DECLARE @Error char(50)
				SET @Error = 'Purchase order not on file.';
				THROW 50019, @Error, 1
			END;	
			
		--Checks total number of processed items on Purchase Order
		DECLARE @processedCount int
		SET @processedCount = (SELECT count(itemId) FROM item WHERE ([status] = 'Approved' 
		OR [status] = 'Denied') AND orderNumber = @OrderNumber)

		--Checks total number of items on Purchase Order
		DECLARE @totalItemCount int
		SET @totalItemCount = (SELECT count(itemId) FROM item WHERE orderNumber = @OrderNumber)			
			
		IF @processedCount = @totalItemCount
			BEGIN;
				UPDATE purchaseOrder SET [status] = 'Closed' WHERE orderNumber = @OrderNumber
			END;
		ELSE
			BEGIN;
				DECLARE @Error1 char(100)
				SET @Error1 = 'All items have not yet been processed. Unable to close purchase order.';
				THROW 50022, @Error1, 1
			END;
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spCreateLineItem]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateLineItem]
	(@Name varchar(50),
	@Description varchar(200),
	@Price money,
	@PurchaseLocation varchar(100),
	@Quantity int,
	@Justification varchar(200),
	@OrderNumber int,
	@Status varchar(50),
	@Subtotal money)
	AS
	SAVE TRANSACTION tmpTransaction
		DECLARE @Temp varchar(300)
		DECLARE @ItemId int

		INSERT INTO item (name, [description], price, purchaseLocation, quantity, justification, modificationReason, orderNumber, [status], subtotal) 
		VALUES (@Name, @Description, @Price, @PurchaseLocation, @Quantity, @Justification, null, @OrderNumber, @Status, @Subtotal)

		SET @ItemId = SCOPE_IDENTITY()

		IF @@ERROR <> 0 
			BEGIN;		
				ROLLBACK TRANSACTION tmpTransaction
				SET @Temp = 'Insert unsuccessful. Item rolled back.';
				EXEC [CreateLog] @OrderNumber, @Temp	
				RETURN 0 							
			END;

	
		SET @Temp = 'Order detail accepted. Product ' + CONVERT(varchar(15), @ItemId) + ' has been added successfully';
		EXEC [CreateLog] @OrderNumber, @Temp	
		RETURN 1		





GO
/****** Object:  StoredProcedure [dbo].[spDenyItem]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDenyItem]
(@ItemId int,
@EmployeeId int,
 @Reason varchar(200),
 @Timestamp timestamp OUTPUT)
	AS	
	SET NOCOUNT ON
	Begin Try
		IF Not EXISTS (SELECT * FROM item WHERE ItemId = @ItemId)  
			BEGIN;
				DECLARE @Error char(50)
				SET @Error = 'Item not on file.';
				THROW 50011, @Error, 1
			END;				
			
		IF (SELECT [timestamp] FROM item WHERE itemId = @ItemId) <> @timestamp
			BEGIN;
				DECLARE @Error2 char(200)
				SET @Error2 = 'The item has been updated since you last retrieved it. Please retrieve it again and resubmit the update.';
				THROW 50017, @Error2, 1	
			END;	

		DECLARE @OrderNumber int
		SET @OrderNumber = (SELECT orderNumber FROM item WHERE itemId = @ItemId)

		DECLARE @Status varchar(50)
		SET @Status = (SELECT [status] FROM purchaseOrder WHERE orderNumber = @OrderNumber)

		DECLARE @OrderEmployeeId int
		SET @OrderEmployeeId = (SELECT employeeId FROM purchaseOrder INNER JOIN item 
		ON purchaseOrder.orderNumber = item.orderNumber WHERE itemId = @ItemId)

		--Supervisor is unable to process their own Purchase Order item
		IF @employeeId <> @OrderEmployeeId
			BEGIN;
				--Updates the Item and Purchase Order as long as the Purchase Order status is not already set to Closed
				--and the Supervisor is not the creator of the Purchase Order item
				IF @Status <> 'Closed'
					BEGIN;
						UPDATE item SET [status] = 'Denied', modificationReason = @Reason WHERE ItemId = @ItemId	 	
						UPDATE purchaseOrder SET [status] = 'Under Review' WHERE orderNumber = @OrderNumber
						SELECT @Timestamp = [timestamp] FROM item WHERE ItemId = @ItemId
					END;
				ELSE
					BEGIN;
						DECLARE @Error3 char(100)
						SET @Error3 = 'Purchase order is closed. Unable to process item.';
						THROW 50023, @Error3, 1	
					END;
			END;
		ELSE
			BEGIN;
				DECLARE @Error4 char(200)
				SET @Error4 = 'Supervisors are unable to process their own purchase orders. Please contact your ' +
					'superior to process the order for you. You are able to view the items that you have requested.';
				THROW 50024, @Error4, 1	
			END;	
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spEmployeeAddItem]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployeeAddItem]
(@ItemId int OUTPUT,
 @Name varchar(100),
 @Description varchar(200),
 @Price money,
 @PurchaseLocation varchar(100),
 @Quantity int,
 @Justification varchar(300),
 @Subtotal money,
 @OrderNumber int)
	AS	
	SET NOCOUNT ON
	Begin Try					
		IF Not EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber)  
			BEGIN;
				DECLARE @Error1 char(50)
				SET @Error1 = 'Purchase order not on file.';
				THROW 50012, @Error1, 1
			END;		

		IF (@Quantity < 1 OR @Price <= 0)  
			BEGIN;
				DECLARE @Error2 char(75)
				SET @Error2 = 'Item price and quantity cannot be less than or equal to zero.';
				THROW 50013, @Error2, 1
			END;	

		DECLARE @Status varchar(50)
		SET @Status = (SELECT [status] FROM purchaseOrder WHERE orderNumber = @OrderNumber)

		--Employee cannot add new Items to a Purchase Order if the order's status is set to Closed
		IF @Status = 'Closed'
			BEGIN;
				DECLARE @Error3 char(75)
				SET @Error3 = 'Cannot add items to a Purchase Order with a status of Closed.';
				THROW 50026, @Error3, 1
			END;

		INSERT INTO item (name, [description], price, purchaseLocation, quantity, justification, orderNumber, status, subtotal) VALUES (@Name, @Description, @Price, @PurchaseLocation,
		@Quantity, @Justification, @OrderNumber, 'Pending', @Subtotal)

		SET @ItemID = SCOPE_IDENTITY()			
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spEmployeeModifyItem]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployeeModifyItem]
(@ItemId int,
 @Name varchar(100),
 @Description varchar(200),
 @Price money,
 @PurchaseLocation varchar(100),
 @Quantity int,
 @Justification varchar(300),
 @Subtotal money,
 @ModificationReason varchar(200) NULL,
 @Timestamp timestamp OUTPUT)
	AS	
	SET NOCOUNT ON
	Begin Try
		IF Not EXISTS (SELECT * FROM item WHERE ItemId = @ItemId)  
			BEGIN;
				DECLARE @Error char(50)
				SET @Error = 'Item not on file.';
				THROW 50011, @Error, 1
			END;				
			
		IF (SELECT [timestamp] FROM item WHERE itemId = @ItemId) <> @timestamp
			BEGIN;
				DECLARE @Error1 char(200)
				SET @Error1 = 'The item has been updated since you last retrieved it. Please retrieve it again and resubmit the update.';
				THROW 50017, @Error1, 1	
			END;	

		IF (@Quantity < 1 OR @Price <= 0)  
			BEGIN;
				DECLARE @Error2 char(75)
				SET @Error2 = 'Item price and quantity cannot be less than or equal to zero.';
				THROW 50013, @Error2, 1
			END;	

		DECLARE @Status varchar(50)
		SET @Status = (SELECT [status] FROM item WHERE itemId = @ItemId)

		--Will not allow an Employee to modify an item if its status is not set to Pending
		IF @Status = 'Denied' OR @Status = 'Approved'
			BEGIN;
				DECLARE @Error3 char(75)
				SET @Error3 = 'Cannot modify item if its status is not set to Pending.';
				THROW 50026, @Error3, 1
			END;
			
		--Modification reason will be null when an employee is modifying an Item. It is supplied when a Supervisor is modifying an item
		IF @ModificationReason = null
			BEGIN;
				UPDATE item SET name = @Name, description = @Description, price = @Price, purchaseLocation = @PurchaseLocation, quantity = @Quantity, justification = @Justification,
				subtotal = @Subtotal WHERE ItemId = @ItemId	 
			END;
		ELSE
			BEGIN;
				UPDATE item SET name = @Name, description = @Description, price = @Price, purchaseLocation = @PurchaseLocation, quantity = @Quantity, justification = @Justification,
				modificationReason = @ModificationReason, subtotal = @Subtotal WHERE ItemId = @ItemId	 
			END;
		  
		SELECT @Timestamp = [timestamp] FROM item WHERE ItemId = @ItemId
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spEmployeeRemoveItem]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployeeRemoveItem]
(@ItemId int,
 @OrderNumber int,
 @OrderSubtotal money,
 @OrderTaxes money,
 @OrderTotal money)
	AS	
	SET NOCOUNT ON
	Begin Try					
		IF Not EXISTS (SELECT * FROM item WHERE itemId = @ItemId)  
			BEGIN;
				DECLARE @Error char(50)
				SET @Error = 'Item not on file.';
				THROW 50014, @Error, 1
			END;	
			
		DECLARE @Status varchar(50)
		SET @Status = (SELECT [status] FROM item WHERE itemId = @ItemId)

		IF @Status = 'Pending'
			BEGIN;
				UPDATE item SET quantity = 0, price = 0, subtotal = 0, [description] = 'No longer needed', [status] = 'Denied' WHERE itemId = @ItemId
				UPDATE purchaseOrder SET subtotal = @OrderSubtotal, taxes = @OrderTaxes, total = @OrderTotal WHERE orderNumber = @OrderNumber
			END;
		ELSE
			BEGIN;
				DECLARE @Error1 char(60)
				SET @Error1 = 'Cannot remove item if its status is not set to Pending.';
				THROW 50025, @Error1, 1
			END;
	End Try	
Begin Catch
	Throw
End Catch








GO
/****** Object:  StoredProcedure [dbo].[spEmployeeRemoveOrder]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployeeRemoveOrder]
( @OrderNumber int)
	AS	
	SET NOCOUNT ON
	Begin Try					
		IF Not EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber)  
			BEGIN;
				DECLARE @Error1 char(50)
				SET @Error1 = 'Purchase order not on file.';
				THROW 50013, @Error1, 1
			END;		


		DELETE FROM purchaseOrder WHERE orderNumber = @OrderNumber
		
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spEmployeeUpdateTotals]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployeeUpdateTotals]
(@OrderNumber int,
 @OrderSubtotal money,
 @OrderTaxes money,
 @OrderTotal money)
	AS	
	SET NOCOUNT ON
	Begin Try					
		IF Not EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber)  
			BEGIN;
				DECLARE @Error1 char(50)
				SET @Error1 = 'Purchase order not on file.';
				THROW 50012, @Error1, 1
			END;		

		IF (@OrderSubtotal <= 0 OR @OrderTaxes <= 0 OR @OrderTotal <= 0)  
			BEGIN;
				DECLARE @Error4 char(75)
				SET @Error4 = 'Purchase order subtotal, tax, and total cannot be less than or equal to zero.';
				THROW 50014, @Error4, 1
			END;	

		UPDATE purchaseOrder SET subtotal = @OrderSubtotal, taxes = @OrderTaxes, total = @OrderTotal WHERE orderNumber = @OrderNumber
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spPendingItem]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPendingItem]
(@ItemId int,
@EmployeeId int,
 @Timestamp timestamp OUTPUT)
	AS	
	SET NOCOUNT ON
	Begin Try
		IF Not EXISTS (SELECT * FROM item WHERE ItemId = @ItemId)  
			BEGIN;
				DECLARE @Error char(50)
				SET @Error = 'Item not on file.';
				THROW 50011, @Error, 1
			END;				
			
		IF (SELECT [timestamp] FROM item WHERE itemId = @ItemId) <> @timestamp
			BEGIN;
				DECLARE @Error2 char(200)
				SET @Error2 = 'The item has been updated since you last retrieved it. Please retrieve it again and resubmit the update.';
				THROW 50017, @Error2, 1	
			END;	

		DECLARE @OrderNumber int
		SET @OrderNumber = (SELECT orderNumber FROM item WHERE itemId = @ItemId)

		DECLARE @Status varchar(50)
		SET @Status = (SELECT [status] FROM purchaseOrder WHERE orderNumber = @OrderNumber)

		DECLARE @OrderEmployeeId int
		SET @OrderEmployeeId = (SELECT employeeId FROM purchaseOrder INNER JOIN item 
		ON purchaseOrder.orderNumber = item.orderNumber WHERE itemId = @ItemId)

		--Supervisor is unable to process their own Purchase Order item
		IF @employeeId <> @OrderEmployeeId
			BEGIN;
				--Updates the Item and Purchase Order as long as the Purchase Order status is not already set to Closed
				--and the Supervisor is not the creator of the Purchase Order item
				IF @Status <> 'Closed'
					BEGIN;
						UPDATE item SET [status] = 'Pending' WHERE ItemId = @ItemId	 

						--Checks total number of Pending items on Purchase Order
						DECLARE @pendingCount int
						SET @pendingCount = (SELECT count(itemId) FROM item WHERE [status] = 'Pending' AND orderNumber = @OrderNumber)

						--Checks total number of items on Purchase Order
						DECLARE @totalItemCount int
						SET @totalItemCount = (SELECT count(itemId) FROM item WHERE orderNumber = @OrderNumber)

						IF @pendingCount = @totalItemCount
							BEGIN;
								UPDATE purchaseOrder SET [status] = 'Pending' WHERE orderNumber = @OrderNumber
							END;
						ELSE
							BEGIN;
								UPDATE purchaseOrder SET [status] = 'Under Review' WHERE orderNumber = @OrderNumber
							END;	
	  
						SELECT @Timestamp = [timestamp] FROM item WHERE ItemId = @ItemId
					END;
				ELSE
					BEGIN;
						DECLARE @Error3 char(100)
						SET @Error3 = 'Purchase order is closed. Unable to process item.';
						THROW 50023, @Error3, 1	
					END;
			END;
		ELSE
			BEGIN;
				DECLARE @Error4 char(200)
				SET @Error4 = 'Supervisors are unable to process their own purchase orders. Please contact your ' +
					'superior to process the order for you. You are able to view the items that you have requested.';
				THROW 50024, @Error4, 1	
			END;
	End Try	
Begin Catch
	Throw
End Catch







GO
/****** Object:  StoredProcedure [dbo].[spRetrieveItemById]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveItemById]
	(@ItemId int)
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM item WHERE itemId = @ItemId)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Item not found.';
				THROW 50010, @Error, 1
			END;	
		
		SELECT * FROM item WHERE itemId = @ItemId
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spRetrieveOrderByNumber]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveOrderByNumber]
	(@OrderNumber int,
	@EmployeeId int)
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Purchase order does not exist.';
				THROW 50001, @Error, 1
			END;
		
		IF NOT EXISTS (SELECT * FROM purchaseOrder WHERE employeeId = @EmployeeId)
			BEGIN;
				DECLARE @Error1 char(60)
				SET @Error1 = 'Employee does not have any purchase orders on file.';
				THROW 50002, @Error1, 1
			END;

		IF NOT EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber AND employeeId = @EmployeeId)
			BEGIN;
				DECLARE @Error2 char(60)
				SET @Error2 = 'Employee does not have access to specified purchase order.';
				THROW 50002, @Error2, 1
			END;
		
		--Only retrieves the purchase order if the employee requesting it is the employee that created it
		SELECT orderNumber, orderDate, [status], subtotal, taxes, total, employeeId FROM purchaseOrder 
		WHERE orderNumber = @OrderNumber AND employeeId = @EmployeeId ORDER BY orderDate DESC
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spRetrieveOrderByNumberSupervisor]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveOrderByNumberSupervisor]
	(@OrderNumber int,
	@EmployeeId int)
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Purchase order does not exist.';
				THROW 50001, @Error, 1
			END;

		DECLARE @Supervisor bit
		DECLARE @Department int
		SET @Department = (SELECT department FROM employee WHERE employee.id = @EmployeeId)	

		IF EXISTS (SELECT * FROM department WHERE supervisor = @EmployeeId AND id = @Department)
			BEGIN;
				SET @Supervisor = 1
			END;

		IF @Supervisor = 1
			BEGIN;
				SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder 
				INNER JOIN employee ON purchaseOrder.employeeId = employee.id
				WHERE orderNumber = @OrderNumber AND department = @Department ORDER BY orderDate DESC
			END;	
		ELSE
			BEGIN;
				SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder 
				INNER JOIN employee ON purchaseOrder.employeeId = employee.id
				WHERE orderNumber = @OrderNumber AND employeeId = @EmployeeId AND department = @Department ORDER BY orderDate DESC
			END;
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spRetrieveOrderByOther]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveOrderByOther]
	(@StartDate datetime NULL,
	@EndDate datetime NULL,
	@EmployeeId int,
	@Filter char(1))
	AS
	BEGIN TRY
		IF NOT EXISTS(SELECT * FROM purchaseOrder WHERE employeeId = @EmployeeId)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Employee has no purchase orders on file.';
				THROW 50002, @Error, 1
			END;

		IF @Filter = 'A'
			BEGIN;
				SELECT orderNumber, orderDate, [status], subtotal, taxes, total, employeeId FROM purchaseOrder 
				WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
				AND EmployeeId = @EmployeeId ORDER BY orderDate DESC
			END;
		ELSE IF @Filter = 'P'
			BEGIN;
				SELECT orderNumber, orderDate, [status], subtotal, taxes, total, employeeId FROM purchaseOrder 
				WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
				AND ([status] = 'Pending' OR [status] = 'Under Review') AND EmployeeId = @EmployeeId ORDER BY orderDate DESC
			END;
		ELSE IF @Filter = 'C'
			BEGIN;
				SELECT orderNumber, orderDate, [status], subtotal, taxes, total, employeeId FROM purchaseOrder 
				WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
				AND ([status] = 'Closed') AND EmployeeId = @EmployeeId ORDER BY orderDate DESC
			END;			

    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spRetrieveOrderByOtherSupervisor]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveOrderByOtherSupervisor]
	(@StartDate datetime NULL,
	@EndDate datetime NULL,
	@EmployeeId int,
	@Filter char(1),
	@Name varchar(100) NULL)
	AS
	BEGIN TRY

		DECLARE @Supervisor bit

		DECLARE @Department int
		SET @Department = (SELECT department FROM employee WHERE employee.id = @EmployeeId)		

		IF EXISTS (SELECT * FROM department WHERE supervisor = @EmployeeId AND id = @Department)
			BEGIN;
				SET @Supervisor = 1
			END;

		IF @Supervisor = 1
			BEGIN;
				IF @Filter = 'A'
					BEGIN;
						SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (employee.department = @Department) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						ORDER BY orderDate DESC
					END;
				ELSE IF @Filter = 'P'
					BEGIN;
						SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Pending' OR purchaseOrder.[status] = 'Under Review') AND (employee.department = @Department) AND
						(@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%')) 
						ORDER BY orderDate DESC
					END;
				ELSE IF @Filter = 'C'
					BEGIN;
						SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Closed') AND (employee.department = @Department) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						ORDER BY orderDate DESC
					END;	
			END;
		ELSE
			BEGIN;
				IF @Filter = 'A'
					BEGIN;
						SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (EmployeeId = @EmployeeId) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%')) ORDER BY orderDate DESC
					END;
				ELSE IF @Filter = 'P'
					BEGIN;
						SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Pending' OR purchaseOrder.[status] = 'Under Review') AND (EmployeeId = @EmployeeId)
						AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
					    ORDER BY orderDate DESC
					END;
				ELSE IF @Filter = 'C'
					BEGIN;
						SELECT orderNumber, orderDate, purchaseOrder.[status], subtotal, taxes, total, employeeId FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Closed') AND (EmployeeId = @EmployeeId) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						ORDER BY orderDate DESC
					END;	
			END;
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spRetrieveOrderItems]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveOrderItems]
	(@OrderNumber int)
	AS
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM item WHERE orderNumber = @OrderNumber)
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'No items on file for the selected purchase order.';
				THROW 50006, @Error, 1
			END;
		
		SELECT itemId, name, [description], purchaseLocation, justification, price, quantity, subtotal, [status], [timestamp], orderNumber, modificationReason FROM item WHERE orderNumber = @OrderNumber
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spRetrieveOrdersForProcessing]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveOrdersForProcessing]
	(@StartDate datetime NULL,
	@EndDate datetime NULL,
	@EmployeeId int,
	@Filter char(1),
	@Name varchar(100) NULL)
	AS
	BEGIN TRY
		DECLARE @Supervisor bit

		DECLARE @Department int
		SET @Department = (SELECT department FROM employee WHERE employee.id = @EmployeeId)		

		IF EXISTS (SELECT * FROM department WHERE supervisor = @EmployeeId AND id = @Department)
			BEGIN;
				SET @Supervisor = 1
			END;

		IF @Supervisor = 1
			BEGIN;
				IF @Filter = 'A'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (employee.department = @Department) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						ORDER BY orderDate ASC
					END;
				ELSE IF @Filter = 'P'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Pending' OR purchaseOrder.[status] = 'Under Review') AND (employee.department = @Department) AND
						(@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%')) 
						ORDER BY orderDate ASC
					END;
				ELSE IF @Filter = 'C'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Closed') AND (employee.department = @Department) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						ORDER BY orderDate ASC
					END;	
			END;
		ELSE
			BEGIN;
				IF @Filter = 'A'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (EmployeeId = @EmployeeId) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%')) 
						ORDER BY orderDate ASC
					END;
				ELSE IF @Filter = 'P'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Pending' OR purchaseOrder.[status] = 'Under Review') AND (EmployeeId = @EmployeeId) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						ORDER BY orderDate ASC
					END;
				ELSE IF @Filter = 'C'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Closed') AND (EmployeeId = @EmployeeId) AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						ORDER BY orderDate ASC
					END;	
			END;
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spRetrieveOrdersForProcessingCEO]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRetrieveOrdersForProcessingCEO]
	(@StartDate datetime NULL,
	@EndDate datetime NULL,
	@EmployeeId int,
	@Filter char(1),
	@Name varchar(100) NULL)
	AS
	BEGIN TRY
		DECLARE @CEO bit

		IF @EmployeeId = (SELECT supervisor FROM department WHERE department.id = 4)
			BEGIN;
				SET @CEO = 1
			END;

		IF @CEO = 1
			BEGIN;
				IF @Filter = 'A'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						AND (EXISTS(SELECT supervisor FROM department WHERE supervisor = employee.id))
						ORDER BY orderDate ASC
					END;
				ELSE IF @Filter = 'P'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder 
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Pending' OR purchaseOrder.[status] = 'Under Review') AND
						(@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%')) 
						AND (EXISTS(SELECT supervisor FROM department WHERE supervisor = employee.id))
						ORDER BY orderDate ASC
					END;
				ELSE IF @Filter = 'C'
					BEGIN;
						SELECT orderNumber, employee.firstName + ' ' + employee.lastName AS employeeName, orderDate, total, purchaseOrder.[status] FROM purchaseOrder
						INNER JOIN employee ON purchaseOrder.employeeId = employee.id 
						WHERE (@StartDate IS NULL OR (orderDate >= @StartDate)) AND (@EndDate IS NULL OR (orderDate <= @EndDate))
						AND (purchaseOrder.[status] = 'Closed') AND (@Name IS NULL OR ((employee.firstName + employee.lastName) LIKE '%' + @Name + '%'))
						AND (EXISTS(SELECT supervisor FROM department WHERE supervisor = employee.id))
						ORDER BY orderDate ASC
					END;	
			END;
		ELSE
			BEGIN;
				DECLARE @Error char(60)
				SET @Error = 'Employee is not CEO of the company.';
				THROW 50021, @Error, 1
			END;
    END TRY
BEGIN CATCH
	THROW
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[spSubmitPurchaseOrder]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLTableParms.sql|25|0|C:\Users\Steve\NBCC\N-tier Development\SQLTableParms.sql

CREATE PROCEDURE [dbo].[spSubmitPurchaseOrder]
	(@OrderDetail LineItemTableType READONLY,
	@OrderNumber int OUTPUT,
	@OrderDate datetime,
	@Status varchar(50),
	@Subtotal money,
	@Taxes money,
	@Total money,
	@EmployeeId int)
	AS 
	SET NOCOUNT ON
	BEGIN TRY

	BEGIN TRANSACTION

		INSERT INTO purchaseOrder (orderDate, [status], subtotal, taxes, total, employeeId)		
		VALUES(@OrderDate, @Status, @Subtotal, @Taxes, @Total, @EmployeeId) 
		SET @OrderNumber = SCOPE_IDENTITY()

		DECLARE @Temp varchar(400) = ''
		DECLARE @totalItems int = 0
		SET @totalItems = 0
		DECLARE @totAccepted int
		SET @totAccepted = 0

		SELECT * INTO #mytemp FROM @OrderDetail		

		WHILE EXISTS(SELECT TOP 1 * FROM #mytemp)
		BEGIN
		   DECLARE @name varchar(50)
		   DECLARE @description varchar(200)
		   DECLARE @price money
		   DECLARE @purchaseLocation varchar(100)
		   DECLARE @quantity int
		   DECLARE @justification varchar(200)
		   DECLARE @itemStatus varchar(50)
		   DECLARE @itemSubtotal money

		   SELECT TOP 1 @name = Name FROM #mytemp
		   SELECT TOP 1 @description = [Description] FROM #mytemp
		   SELECT TOP 1 @price = Price FROM #mytemp
		   SELECT TOP 1 @purchaseLocation = PurchaseLocation FROM #mytemp
		   SELECT TOP 1 @quantity = Quantity FROM #mytemp
		   SELECT TOP 1 @justification = Justification FROM #mytemp
		   SELECT TOP 1 @itemStatus = [Status] FROM #mytemp
		   SELECT TOP 1 @itemSubtotal = Subtotal FROM #mytemp

		   DECLARE @return int
		   EXEC @return = spCreateLineItem @name, @description, @price, @purchaseLocation, @quantity, @justification, @OrderNumber, @itemStatus, @itemSubtotal
	   
		   SET @totalItems = @totalItems + 1
		   SET @totAccepted = @totAccepted + (SELECT @return)
		   DELETE Top (1) FROM #mytemp
		END
	
	IF @totAccepted = 0
	BEGIN
		SET @Temp = 'Order rejected - One or more items have been processed or changed since you retrieved the list of items. Please ' +
			'cancel agreement and retrieve the list of items again.';		
		EXEC [CreateLog] @OrderNumber, @Temp;
		THROW 50006, @Temp, 1
	END

	IF @totAccepted = @TotalItems
		BEGIN
			COMMIT TRANSACTION
			SET @Temp = CONVERT(varchar(10), @totAccepted) + ' out of ' + CONVERT(varchar(10), @totalItems) + ' transactions were successful'
			EXEC [CreateLog] @OrderNumber, @Temp
		END
	ELSE
		BEGIN;
			SET @Temp = 'Order rejected - One or more items have been processed or changed since you retrieved the list of items. Please ' +
			'cancel agreement and retrieve the list of items again.';		
			EXEC [CreateLog] @OrderNumber, @Temp;
			THROW 50007, @Temp, 1
		END;

END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
		ROLLBACK TRANSACTION
	END;
	THROW
END CATCH  





GO
/****** Object:  StoredProcedure [dbo].[spUpdateOrderStatusToPending]    Script Date: 9/5/2017 7:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateOrderStatusToPending]
(@OrderNumber int)
	AS	
	SET NOCOUNT ON
	Begin Try
		IF Not EXISTS (SELECT * FROM purchaseOrder WHERE orderNumber = @OrderNumber)  
			BEGIN;
				DECLARE @Error char(50)
				SET @Error = 'Purchase order not on file.';
				THROW 50019, @Error, 1
			END;				
			
		UPDATE purchaseOrder SET [status] = 'Pending' WHERE orderNumber = @OrderNumber
	End Try	
Begin Catch
	Throw
End Catch







GO
USE [master]
GO
ALTER DATABASE [ComprehensiveFinal] SET  READ_WRITE 
GO
