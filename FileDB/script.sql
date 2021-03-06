USE [master]
GO
/****** Object:  Database [BTLWeb_QLDL]    Script Date: 6/20/2020 12:10:50 PM ******/
CREATE DATABASE [BTLWeb_QLDL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BTLWeb_QLDL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BTLWeb_QLDL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BTLWeb_QLDL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BTLWeb_QLDL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BTLWeb_QLDL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BTLWeb_QLDL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BTLWeb_QLDL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET ARITHABORT OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BTLWeb_QLDL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BTLWeb_QLDL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BTLWeb_QLDL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BTLWeb_QLDL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET RECOVERY FULL 
GO
ALTER DATABASE [BTLWeb_QLDL] SET  MULTI_USER 
GO
ALTER DATABASE [BTLWeb_QLDL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BTLWeb_QLDL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BTLWeb_QLDL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BTLWeb_QLDL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BTLWeb_QLDL] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BTLWeb_QLDL', N'ON'
GO
ALTER DATABASE [BTLWeb_QLDL] SET QUERY_STORE = OFF
GO
USE [BTLWeb_QLDL]
GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_top4Nation]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[FUNC_top4Nation]()
returns @4top table
(
idNation char(10),
nameNation nvarchar(10),
countTour int
)
as
begin
	insert into @4top 
	SELECT TOP(4) maQG,tenQG,countTour 
	FROM Nation  
	ORDER BY countTour DESC
	return
end;
GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_topNDestination]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[FUNC_topNDestination](@sl int)
returns @Ntop table
(
maDD char(10),
tenDD nvarchar(100),
tenTinh nvarchar(100),
near nvarchar(100),
countHomeStay int,
countTaxi int,
countWL int,
countTour int
)
as
begin
	insert into @Ntop 
	SELECT TOP(@sl) maDD,tenDD,tenTinh,near,countHomeStay,countTaxi,countWL,countTour
	FROM TourDestination,Province
	where TourDestination.maTinh= Province.maTinh
	ORDER BY countWL DESC
	return
end;
GO
/****** Object:  Table [dbo].[Nation]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nation](
	[maQG] [char](10) NOT NULL,
	[tenQG] [nvarchar](100) NULL,
	[pic] [nvarchar](100) NULL,
	[note] [nvarchar](100) NULL,
	[moTa] [nvarchar](500) NULL,
	[countTour] [int] NULL,
 CONSTRAINT [pk_nation] PRIMARY KEY CLUSTERED 
(
	[maQG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[maTinh] [char](10) NOT NULL,
	[maQG] [char](10) NOT NULL,
	[tenTinh] [nvarchar](100) NULL,
	[pic] [nvarchar](100) NULL,
	[note] [nvarchar](100) NULL,
	[moTa] [nvarchar](500) NULL,
 CONSTRAINT [pk_province] PRIMARY KEY CLUSTERED 
(
	[maTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourDestination]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourDestination](
	[maDD] [char](10) NOT NULL,
	[maTinh] [char](10) NOT NULL,
	[tenDD] [nvarchar](100) NULL,
	[pic] [nvarchar](100) NULL,
	[note] [nvarchar](100) NULL,
	[moTa] [nvarchar](500) NULL,
	[near] [nvarchar](100) NULL,
	[countHomeStay] [int] NULL,
	[countTaxi] [int] NULL,
	[countWL] [int] NULL,
	[countTour] [int] NULL,
	[Cost] [float] NULL,
 CONSTRAINT [pk_tourDestination] PRIMARY KEY CLUSTERED 
(
	[maDD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DestinationTour]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DestinationTour]
AS
SELECT dbo.TourDestination.maDD, dbo.TourDestination.tenDD, dbo.Nation.tenQG, dbo.TourDestination.pic, dbo.TourDestination.note, dbo.TourDestination.moTa, dbo.TourDestination.near, dbo.TourDestination.countHomeStay, 
dbo.TourDestination.countTaxi, dbo.Province.tenTinh, TourDestination.countTour, TourDestination.Cost
FROM dbo.TourDestination INNER JOIN
dbo.Province ON dbo.TourDestination.maTinh = dbo.Province.maTinh INNER JOIN
dbo.Nation ON dbo.Province.maQG = dbo.Nation.maQG
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[maBlog] [char](10) NOT NULL,
	[maDD] [char](10) NOT NULL,
	[username] [varchar](25) NULL,
	[content] [nvarchar](1000) NULL,
	[pic] [char](500) NULL,
	[note] [nvarchar](100) NULL,
	[header] [nvarchar](100) NULL,
 CONSTRAINT [pk_blog] PRIMARY KEY CLUSTERED 
(
	[maBlog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[detailBlog]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[detailBlog]
as
select a.*,b.tenDD  from Blog as a,TourDestination as b
where a.maDD=b.maDD
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[cartID] [char](10) NOT NULL,
	[username] [varchar](25) NULL,
	[slSP] [int] NULL,
	[price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[cartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailCart]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailCart](
	[cartID] [char](10) NOT NULL,
	[desTourID] [char](10) NOT NULL,
	[dayADD] [datetime] NULL,
	[sl] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cartID] ASC,
	[desTourID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VIEW_detailCart]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[VIEW_detailCart]
as
select a.cartID,a.username,b.dayADD,c.tenDD,b.sl,c.pic,c.Cost,c.maDD from Cart as a,DetailCart as b,TourDestination as c
where a.cartID=b.cartID and b.desTourID = c.maDD
GO
/****** Object:  Table [dbo].[HomeStay]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeStay](
	[maKS] [char](10) NOT NULL,
	[maDD] [char](10) NOT NULL,
	[tenKS] [nvarchar](50) NULL,
	[phoneNum] [char](10) NULL,
	[pic] [nvarchar](100) NULL,
	[note] [nvarchar](100) NULL,
	[moTa] [nvarchar](500) NULL,
	[numReview] [int] NULL,
	[costPerNight] [int] NULL,
 CONSTRAINT [pk_homeStay] PRIMARY KEY CLUSTERED 
(
	[maKS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[detailService]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[detailService]
as
select HomeStay.*,b.tenDD,b.tenQG,b.tenTinh from HomeStay,(select a.*,maDD,tenDD from (select Nation.tenQG,Province.tenTinh,Province.maTinh from Nation,Province
where Nation.maQG=Province.maQG) as a, TourDestination where a.maTinh=TourDestination.maTinh ) as b where b.maDD=HomeStay.maDD
GO
/****** Object:  View [dbo].[VIEW_top6DestianationTour]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VIEW_top6DestianationTour]
as
SELECT TOP(6) maDD,tenDD,tenTinh,near,countHomeStay,countTaxi,countWL,countTour
FROM TourDestination,Province
where TourDestination.maTinh= Province.maTinh
ORDER BY countWL DESC
GO
/****** Object:  View [dbo].[DestinationReview]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[DestinationReview] as 
select TourDestination.maDD,tenDD,tenTinh,tenQG,TourDestination.pic  from TourDestination,Province,Nation
where TourDestination.maTinh=Province.maTinh and Province.maQG=Nation.maQG
GO
/****** Object:  Table [dbo].[Taxi]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taxi](
	[bienSo] [varchar](15) NOT NULL,
	[maDD] [char](10) NOT NULL,
	[soGhe] [int] NULL,
	[phoneNum] [char](10) NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk_taxi] PRIMARY KEY CLUSTERED 
(
	[bienSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DestinationInfor]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[DestinationInfor] as
select a.*,b.SoLuongTaxi,c.SoluongKS from 
(select TourDestination.maDD,tenDD,tenTinh,tenQG,TourDestination.pic  from TourDestination,Province,Nation
where TourDestination.maTinh=Province.maTinh and Province.maQG=Nation.maQG ) as a
FULL OUTER JOIN (select count(bienSo) as SoLuongTaxi ,TourDestination.maDD from Taxi,TourDestination
where TourDestination.maDD=Taxi.maDD group by (TourDestination.maDD) ) as b
on a.maDD=b.maDD 
FULL OUTER JOIN (select count(maKS) as SoluongKS ,TourDestination.maDD from HomeStay,TourDestination
where TourDestination.maDD=HomeStay.maDD group by (TourDestination.maDD) ) as c
on a.maDD=c.maDD 
GO
/****** Object:  View [dbo].[VIEW_top4Nation]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VIEW_top4Nation]
as
SELECT TOP(4) maQG,tenQG,countTour,pic
FROM Nation  
ORDER BY countTour DESC
GO
/****** Object:  View [dbo].[colName]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[colName]
as

SELECT COLUMN_NAME,TABLE_NAME,ORDINAL_POSITION

FROM INFORMATION_SCHEMA.COLUMNS
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[tenDanhMuc] [nvarchar](100) NOT NULL,
	[num] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[tenDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[username] [varchar](25) NOT NULL,
	[pass] [varchar](25) NULL,
	[tenKH] [nvarchar](25) NULL,
	[hoKH] [nvarchar](25) NULL,
	[phoneNum] [char](10) NULL,
	[email] [varchar](25) NULL,
	[note] [nvarchar](100) NULL,
	[Feedback] [nvarchar](500) NULL,
	[Job] [nvarchar](100) NULL,
	[nameQ] [nvarchar](100) NULL,
	[pic] [nvarchar](100) NULL,
 CONSTRAINT [pk_customer] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSDatXe]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSDatXe](
	[maHD] [char](10) NOT NULL,
	[bienSo] [varchar](15) NOT NULL,
	[cost] [float] NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk2_dSDatXe] PRIMARY KEY CLUSTERED 
(
	[bienSo] ASC,
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSKSCanTT]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSKSCanTT](
	[maKS] [char](10) NOT NULL,
	[maHD] [char](10) NOT NULL,
	[cost] [float] NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk2_dSKSCanTT] PRIMARY KEY CLUSTERED 
(
	[maKS] ASC,
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSKSTheoTrip]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSKSTheoTrip](
	[maCD] [char](10) NOT NULL,
	[maKS] [char](10) NOT NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk2_dSKSTheoTrip] PRIMARY KEY CLUSTERED 
(
	[maKS] ASC,
	[maCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSKSTrongWL]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSKSTrongWL](
	[maKS] [char](10) NOT NULL,
	[maWL] [char](10) NOT NULL,
	[ngayAdd] [date] NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk2_dSKSTrongWL] PRIMARY KEY CLUSTERED 
(
	[maKS] ASC,
	[maWL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSTourCanTT]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSTourCanTT](
	[maTour] [char](10) NOT NULL,
	[maHD] [char](10) NOT NULL,
	[cost] [float] NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk2_dSTourCanTT] PRIMARY KEY CLUSTERED 
(
	[maTour] ASC,
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSTourTrongWL]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSTourTrongWL](
	[maTour] [char](10) NOT NULL,
	[maWL] [char](10) NOT NULL,
	[ngayAdd] [date] NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk2_dSTourTrongWL] PRIMARY KEY CLUSTERED 
(
	[maTour] ASC,
	[maWL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSTripTheoTour]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSTripTheoTour](
	[maCD] [char](10) NOT NULL,
	[maTour] [char](10) NOT NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk2_dSTripTheoTour] PRIMARY KEY CLUSTERED 
(
	[maTour] ASC,
	[maCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElecBill]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElecBill](
	[maHD] [char](10) NOT NULL,
	[username] [varchar](25) NOT NULL,
	[tongTien] [float] NULL,
	[paymentMethod] [nvarchar](25) NULL,
	[dayCreate] [date] NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk_elecBill] PRIMARY KEY CLUSTERED 
(
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IndexPage]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndexPage](
	[img] [nvarchar](100) NULL,
	[titleImg] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyWebSite]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyWebSite](
	[nameWeb] [nvarchar](100) NOT NULL,
	[logo] [nvarchar](200) NULL,
	[phoneNum1] [char](10) NULL,
	[phoneNum2] [char](10) NULL,
	[addressCompany] [nvarchar](300) NULL,
	[mail] [nvarchar](100) NULL,
	[fb] [nvarchar](100) NULL,
	[tw] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[nameWeb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[nameQ] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nameQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenCacBang]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenCacBang](
	[tenCacBang] [nvarchar](100) NOT NULL,
	[chuThich] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[tenCacBang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tour]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour](
	[maTour] [char](10) NOT NULL,
	[tenTour] [nvarchar](50) NULL,
	[dayStart] [date] NULL,
	[soLuongMax] [int] NULL,
	[soDem] [int] NULL,
	[pic] [nvarchar](100) NULL,
	[note] [nvarchar](100) NULL,
	[moTa] [nvarchar](500) NULL,
	[Cost] [float] NULL,
 CONSTRAINT [pk_tour] PRIMARY KEY CLUSTERED 
(
	[maTour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[maCD] [char](10) NOT NULL,
	[maDDStart] [char](10) NOT NULL,
	[maDDEnd] [char](10) NOT NULL,
	[dayStrat] [date] NULL,
	[pic] [nvarchar](100) NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk_trip] PRIMARY KEY CLUSTERED 
(
	[maCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 6/20/2020 12:10:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishList](
	[maWL] [char](10) NOT NULL,
	[username] [varchar](25) NOT NULL,
	[note] [nvarchar](100) NULL,
 CONSTRAINT [pk_wishList] PRIMARY KEY CLUSTERED 
(
	[maWL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT ((0)) FOR [slSP]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((0)) FOR [num]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('Good Severvice') FOR [Feedback]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('User') FOR [nameQ]
GO
ALTER TABLE [dbo].[HomeStay] ADD  DEFAULT ((0)) FOR [numReview]
GO
ALTER TABLE [dbo].[HomeStay] ADD  DEFAULT ((0)) FOR [costPerNight]
GO
ALTER TABLE [dbo].[MyWebSite] ADD  DEFAULT ('0000000000') FOR [phoneNum2]
GO
ALTER TABLE [dbo].[MyWebSite] ADD  DEFAULT ('https://facebook.com/') FOR [fb]
GO
ALTER TABLE [dbo].[MyWebSite] ADD  DEFAULT ('https://twitter.com/') FOR [tw]
GO
ALTER TABLE [dbo].[Nation] ADD  DEFAULT ((0)) FOR [countTour]
GO
ALTER TABLE [dbo].[TourDestination] ADD  DEFAULT ((0)) FOR [countHomeStay]
GO
ALTER TABLE [dbo].[TourDestination] ADD  DEFAULT ((0)) FOR [countTaxi]
GO
ALTER TABLE [dbo].[TourDestination] ADD  DEFAULT ((0)) FOR [countWL]
GO
ALTER TABLE [dbo].[TourDestination] ADD  DEFAULT ((0)) FOR [countTour]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [fk_blog] FOREIGN KEY([maDD])
REFERENCES [dbo].[TourDestination] ([maDD])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [fk_blog]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[Customer] ([username])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([nameQ])
REFERENCES [dbo].[PhanQuyen] ([nameQ])
GO
ALTER TABLE [dbo].[DetailCart]  WITH CHECK ADD FOREIGN KEY([cartID])
REFERENCES [dbo].[Cart] ([cartID])
GO
ALTER TABLE [dbo].[DetailCart]  WITH CHECK ADD FOREIGN KEY([desTourID])
REFERENCES [dbo].[TourDestination] ([maDD])
GO
ALTER TABLE [dbo].[DSDatXe]  WITH CHECK ADD  CONSTRAINT [fk_dSDatXe_HD] FOREIGN KEY([maHD])
REFERENCES [dbo].[ElecBill] ([maHD])
GO
ALTER TABLE [dbo].[DSDatXe] CHECK CONSTRAINT [fk_dSDatXe_HD]
GO
ALTER TABLE [dbo].[DSDatXe]  WITH CHECK ADD  CONSTRAINT [fk_dSDatXe_Taxi] FOREIGN KEY([bienSo])
REFERENCES [dbo].[Taxi] ([bienSo])
GO
ALTER TABLE [dbo].[DSDatXe] CHECK CONSTRAINT [fk_dSDatXe_Taxi]
GO
ALTER TABLE [dbo].[DSKSCanTT]  WITH CHECK ADD  CONSTRAINT [fk_dSKSCanTT_HD] FOREIGN KEY([maHD])
REFERENCES [dbo].[ElecBill] ([maHD])
GO
ALTER TABLE [dbo].[DSKSCanTT] CHECK CONSTRAINT [fk_dSKSCanTT_HD]
GO
ALTER TABLE [dbo].[DSKSCanTT]  WITH CHECK ADD  CONSTRAINT [fk_dSKSCanTT_KS] FOREIGN KEY([maKS])
REFERENCES [dbo].[HomeStay] ([maKS])
GO
ALTER TABLE [dbo].[DSKSCanTT] CHECK CONSTRAINT [fk_dSKSCanTT_KS]
GO
ALTER TABLE [dbo].[DSKSTheoTrip]  WITH CHECK ADD  CONSTRAINT [fk_dSKSTheoTrip_KS] FOREIGN KEY([maKS])
REFERENCES [dbo].[HomeStay] ([maKS])
GO
ALTER TABLE [dbo].[DSKSTheoTrip] CHECK CONSTRAINT [fk_dSKSTheoTrip_KS]
GO
ALTER TABLE [dbo].[DSKSTheoTrip]  WITH CHECK ADD  CONSTRAINT [fk_dSKSTheoTrip_Trip] FOREIGN KEY([maCD])
REFERENCES [dbo].[Trip] ([maCD])
GO
ALTER TABLE [dbo].[DSKSTheoTrip] CHECK CONSTRAINT [fk_dSKSTheoTrip_Trip]
GO
ALTER TABLE [dbo].[DSKSTrongWL]  WITH CHECK ADD  CONSTRAINT [fk_dSKSTrongWL_KS] FOREIGN KEY([maKS])
REFERENCES [dbo].[HomeStay] ([maKS])
GO
ALTER TABLE [dbo].[DSKSTrongWL] CHECK CONSTRAINT [fk_dSKSTrongWL_KS]
GO
ALTER TABLE [dbo].[DSKSTrongWL]  WITH CHECK ADD  CONSTRAINT [fk_dSKSTrongWL_WL] FOREIGN KEY([maWL])
REFERENCES [dbo].[WishList] ([maWL])
GO
ALTER TABLE [dbo].[DSKSTrongWL] CHECK CONSTRAINT [fk_dSKSTrongWL_WL]
GO
ALTER TABLE [dbo].[DSTourCanTT]  WITH CHECK ADD  CONSTRAINT [fk_dSTourCanTT_HD] FOREIGN KEY([maHD])
REFERENCES [dbo].[ElecBill] ([maHD])
GO
ALTER TABLE [dbo].[DSTourCanTT] CHECK CONSTRAINT [fk_dSTourCanTT_HD]
GO
ALTER TABLE [dbo].[DSTourCanTT]  WITH CHECK ADD  CONSTRAINT [fk_dSTourCanTT_Tour] FOREIGN KEY([maTour])
REFERENCES [dbo].[Tour] ([maTour])
GO
ALTER TABLE [dbo].[DSTourCanTT] CHECK CONSTRAINT [fk_dSTourCanTT_Tour]
GO
ALTER TABLE [dbo].[DSTourTrongWL]  WITH CHECK ADD  CONSTRAINT [fk_dSTourTrongWL_Tour] FOREIGN KEY([maTour])
REFERENCES [dbo].[Tour] ([maTour])
GO
ALTER TABLE [dbo].[DSTourTrongWL] CHECK CONSTRAINT [fk_dSTourTrongWL_Tour]
GO
ALTER TABLE [dbo].[DSTourTrongWL]  WITH CHECK ADD  CONSTRAINT [fk_dSTourTrongWL_WL] FOREIGN KEY([maWL])
REFERENCES [dbo].[WishList] ([maWL])
GO
ALTER TABLE [dbo].[DSTourTrongWL] CHECK CONSTRAINT [fk_dSTourTrongWL_WL]
GO
ALTER TABLE [dbo].[DSTripTheoTour]  WITH CHECK ADD  CONSTRAINT [fk_dSTripTheoTour_Tour] FOREIGN KEY([maTour])
REFERENCES [dbo].[Tour] ([maTour])
GO
ALTER TABLE [dbo].[DSTripTheoTour] CHECK CONSTRAINT [fk_dSTripTheoTour_Tour]
GO
ALTER TABLE [dbo].[DSTripTheoTour]  WITH CHECK ADD  CONSTRAINT [fk_dSTripTheoTour_Trip] FOREIGN KEY([maCD])
REFERENCES [dbo].[Trip] ([maCD])
GO
ALTER TABLE [dbo].[DSTripTheoTour] CHECK CONSTRAINT [fk_dSTripTheoTour_Trip]
GO
ALTER TABLE [dbo].[ElecBill]  WITH CHECK ADD  CONSTRAINT [fk_elecBill] FOREIGN KEY([username])
REFERENCES [dbo].[Customer] ([username])
GO
ALTER TABLE [dbo].[ElecBill] CHECK CONSTRAINT [fk_elecBill]
GO
ALTER TABLE [dbo].[HomeStay]  WITH CHECK ADD  CONSTRAINT [fk_homeStay] FOREIGN KEY([maDD])
REFERENCES [dbo].[TourDestination] ([maDD])
GO
ALTER TABLE [dbo].[HomeStay] CHECK CONSTRAINT [fk_homeStay]
GO
ALTER TABLE [dbo].[Province]  WITH CHECK ADD  CONSTRAINT [fk_province] FOREIGN KEY([maQG])
REFERENCES [dbo].[Nation] ([maQG])
GO
ALTER TABLE [dbo].[Province] CHECK CONSTRAINT [fk_province]
GO
ALTER TABLE [dbo].[Taxi]  WITH CHECK ADD  CONSTRAINT [fk_taxi_DD] FOREIGN KEY([maDD])
REFERENCES [dbo].[TourDestination] ([maDD])
GO
ALTER TABLE [dbo].[Taxi] CHECK CONSTRAINT [fk_taxi_DD]
GO
ALTER TABLE [dbo].[TourDestination]  WITH CHECK ADD  CONSTRAINT [fk_tourDestiantion] FOREIGN KEY([maTinh])
REFERENCES [dbo].[Province] ([maTinh])
GO
ALTER TABLE [dbo].[TourDestination] CHECK CONSTRAINT [fk_tourDestiantion]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [fk_trip_DDE] FOREIGN KEY([maDDEnd])
REFERENCES [dbo].[TourDestination] ([maDD])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [fk_trip_DDE]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [fk_trip_DDS] FOREIGN KEY([maDDStart])
REFERENCES [dbo].[TourDestination] ([maDD])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [fk_trip_DDS]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [fk_wishList] FOREIGN KEY([username])
REFERENCES [dbo].[Customer] ([username])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [fk_wishList]
GO
USE [master]
GO
ALTER DATABASE [BTLWeb_QLDL] SET  READ_WRITE 
GO
