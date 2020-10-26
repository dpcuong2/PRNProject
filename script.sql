USE [master]
GO
/****** Object:  Database [DBProject]    Script Date: 10/26/2020 3:02:46 PM ******/
CREATE DATABASE [DBProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBProject.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBProject_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBProject] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBProject] SET  MULTI_USER 
GO
ALTER DATABASE [DBProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBProject] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DBProject] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DBProject]
GO
/****** Object:  Table [dbo].[tblBrand]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBrand](
	[brandID] [char](10) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblBrand] PRIMARY KEY CLUSTERED 
(
	[brandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategory](
	[categoryID] [char](10) NOT NULL,
	[categoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[phone] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLog]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLog](
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[action] [varchar](50) NOT NULL,
	[time] [date] NOT NULL,
 CONSTRAINT [PK_tblLog] PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrder](
	[orderID] [int] IDENTITY(1,1) NOT NULL,
	[customerID] [int] NOT NULL,
	[date] [date] NOT NULL,
	[totalPrice] [float] NOT NULL,
	[status] [bit] NOT NULL,
	[discount] [int] NOT NULL,
 CONSTRAINT [PK_tblOrder] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrderDetail]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOrderDetail](
	[orderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[productID] [varchar](50) NOT NULL,
	[date] [date] NOT NULL,
	[totalPrice] [float] NOT NULL,
	[address] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblOrderDetail] PRIMARY KEY CLUSTERED 
(
	[orderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct](
	[productID] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[weight] [float] NOT NULL,
	[categoryID] [char](10) NOT NULL,
	[brandID] [char](10) NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblShipment]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblShipment](
	[shipmentID] [int] IDENTITY(1,1) NOT NULL,
	[orderID] [int] NOT NULL,
	[date] [date] NOT NULL,
	[address] [varchar](250) NOT NULL,
	[phone] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tblShipment] PRIMARY KEY CLUSTERED 
(
	[shipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 10/26/2020 3:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[role] [bit] NOT NULL,
	[status] [bit] NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_tblBrand] FOREIGN KEY([brandID])
REFERENCES [dbo].[tblBrand] ([brandID])
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_tblBrand]
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_tblCategory] FOREIGN KEY([categoryID])
REFERENCES [dbo].[tblCategory] ([categoryID])
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_tblCategory]
GO
USE [master]
GO
ALTER DATABASE [DBProject] SET  READ_WRITE 
GO
