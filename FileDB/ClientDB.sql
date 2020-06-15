/*
		2020-06-11 Bổ sung và hoàn thiện csdl cho phía người dùng
*/
----------------------------------------------- Index ---------------------------------
-- 1. bảng tổng quan
create table IndexPage(
	img nvarchar(100), -- bức ảnh đầu tiên vào 
	titleImg nvarchar(100)
)
--2. create function lấy ra 4 thằng nổi tiếng nhất or view tùy ý
go
create function FUNC_top4Nation()
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
go
create view VIEW_top4Nation
as
SELECT TOP(4) maQG,tenQG,countTour,pic
FROM Nation  
ORDER BY countTour DESC
go


--3. Tour destination lấy tra 6 địa điểm top và funtion lấy ra n dịa diểm
go
create function FUNC_topNDestination(@sl int)
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
go
create view VIEW_top6DestianationTour
as
SELECT TOP(6) maDD,tenDD,tenTinh,near,countHomeStay,countTaxi,countWL,countTour
FROM TourDestination,Province
where TourDestination.maTinh= Province.maTinh
ORDER BY countWL DESC
go
-- 3. pading destiantion
--create function FUC_9DesTourpage (@pageN int)
--returns @pageNth table
--(	maDD char(8),
--	tenDD nvarchar(100),
--	tenTinh nvarchar(100),
--	tenQG nvarchar(100),
--	pic nvarchar(100),
--	moTa nvarchar(100),
--	near nvarchar(100),
--	countTour int)
--as
--begin
--	Declare cur Cursor for
--	select maDD,tenDD,tenTinh,tenQG,a.pic,a.moTa,near,a.countTour from
--	TourDestination as a,Province as b,Nation as c
--	where a.maTinh=b.maTinh and b.maQG=c.maQG

--	open cur
--	FETCH NEXT FROM cur 

--	WHILE @@FETCH_STATUS = 0
--	begin
--		Insert into @pageNth
--		select 
--	end

--	return
--end


-------------------------------------- About------------------------------------

-------------------------------------- Service------------------------------------
Create table servicepage(
	Paragrap nvarchar(100) primary key
)



--------------------------------------- Data------------------------------------
-- 1.index:
--1.1 IndexPage
go
Insert into IndexPage values ('bg_2.jpg','Make Your Tour Amazing With Us')
go
--1.2 top4 tour

Insert into Nation values('QG00000004','Autralia','place-4.jpg','','',5)

select * from Nation
select * from Province
select * from TourDestination

---------------------- Phana quyen
--create table DSQuyen(
--	username varchar(25)  not null,
--	nameQ nvarchar(100) not null
--)
--Alter table DSQuyen
--Add CONSTRAINT fk_DSQuyen_1 foreign key (username) references Customer(username)
--Alter table DSQuyen
--Add CONSTRAINT fk_DSQuyen_2 foreign key (nameQ) references PhanQuyen(nameQ)
--Alter table DSQuyen
--Add CONSTRAINT pk2_DSQuyen2 Primary key (username,nameQ)

--drop table DSQuyen

--select * from PhanQuyen
--select * from Customer
--select * from DSQuyen

--insert into DSQuyen values ('admin','Admin')
--insert into DSQuyen values ('username1','User')
go
alter table Customer add nameQ nvarchar(100) references PhanQuyen(nameQ) default 'User'

--- create Cart

create table Cart(
	cartID char(10) primary key,
	username varchar(25) references Customer(username),
	slSP int default 0,
	price float default 0
)

Create table DetailCart(
	cartID char(10) references Cart(cartID) not null,
	desTourID char(10) references TourDestination(maDD) not null,
	dayADD datetime,
	sl int
)

alter table DetailCart add primary key (cartID,desTourID)
go
--select * from DetailCart
go
alter view VIEW_detailCart
as
select a.cartID,a.username,b.dayADD,c.tenDD,b.sl,c.pic,c.Cost from Cart as a,DetailCart as b,TourDestination as c
where a.cartID=b.cartID and b.desTourID = c.maDD

go
alter table TourDestination add Cost float
go
select * from VIEW_detailCart where username= 'Jonh2099'
select * from DetailCart