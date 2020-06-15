
-------------------bổ sung sql
----------------------- create View
---------------------- thêm các bảng và trường cho trang web
Alter table Customer add Feedback nvarchar(500) default 'Good Severvice'
Alter table Customer add Job nvarchar(100)

Alter Table TourDestination Add near nvarchar(100)
Alter table TourDestination Add countHomeStay int default 0
Alter table TourDestination Add countTaxi int default 0
Alter table TourDestination Add countWL int default 0
Alter table TourDestination Add countTour int default 0

Alter table Nation Add countTour int default 0

Alter table Homestay Add numReview int default 0
Alter table Homestay add costPerNight int default 0

Alter table Blog add header nvarchar(100)
go
-- use for footer
Create table MyWebSite (
	nameWeb nvarchar(100) primary key,
	logo nvarchar(200),
	phoneNum1 char(10),
	phoneNum2 char(10) default '0000000000',
	addressCompany nvarchar(300),
	mail nvarchar(100),
	fb nvarchar(100) default 'https://facebook.com/',
	tw nvarchar(100) default 'https://twitter.com/',
)
Create table Categories(
	tenDanhMuc nvarchar(100) primary key,
	num int default 0
)
drop table MyWebSite
drop table Categories


select * from TenCacBang

--------------------30-5-2020

Create table PhanQuyen(
	nameQ nvarchar(100) primary key
)

Insert into PhanQuyen values (N'Admin')
Insert into PhanQuyen values (N'User')
Insert into PhanQuyen values (N'User Vip')

go
CREATE VIEW [dbo].[DestinationTour]
AS
SELECT dbo.TourDestination.maDD, dbo.TourDestination.tenDD, dbo.Nation.tenQG, dbo.TourDestination.pic, dbo.TourDestination.note, dbo.TourDestination.moTa, dbo.TourDestination.near, dbo.TourDestination.countHomeStay, 
dbo.TourDestination.countTaxi, dbo.Province.tenTinh, TourDestination.countTour
FROM dbo.TourDestination INNER JOIN
dbo.Province ON dbo.TourDestination.maTinh = dbo.Province.maTinh INNER JOIN
dbo.Nation ON dbo.Province.maQG = dbo.Nation.maQG
GO
USE [BTLWeb_QLDL]
GO


/****** Object:  Table [dbo].[HotelSevice]    Script Date: 6/8/2020 5:00:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HotelSevice](
	[IDHotel] [nchar](10) NOT NULL,
	[NameHotel] [nvarchar](50) NULL,
	[PriceHotel] [int] NULL,
	[AddressHotel] [nvarchar](50) NULL,
	[Reviews] [int] NULL,
	[ContentHotel] [nvarchar](50) NULL,
	[Urlimage] [nvarchar](50) NULL,
 CONSTRAINT [PK_HotelSevice] PRIMARY KEY CLUSTERED 
(
	[IDHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

