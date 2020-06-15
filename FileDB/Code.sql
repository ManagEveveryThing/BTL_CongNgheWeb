--Create database BTLWeb_QLDL
--use a
--drop database BTLWeb_QLDL

Use BTLWeb_QLDL

go
Create table Nation( -- 1 quoc gia
	maQG char(10) not null,
	tenQG nvarchar(100),
	pic nvarchar(100),
	note nvarchar(100)
)
Alter table Nation add moTa nvarchar(500)

Create table Province( -- 2 tinh
	maTinh char(10) not null,
	maQG char(10) not null,
	tenTinh nvarchar(100),
	pic nvarchar(100),
	note nvarchar(100)
)
Alter table Province add moTa nvarchar(500)

Create table TourDestination( --3 dia diem
	maDD char(10) not null,
	maTinh char(10) not null,
	tenDD nvarchar(100),
	pic nvarchar(100),
	note nvarchar(100)
)
Alter table TourDestination add moTa nvarchar(500)

Create table Trip( --4 chuyen di
	maCD char(10) not null,
	maDDStart char(10) not null,
	maDDEnd char(10) not null,
	dayStrat date,
	pic nvarchar(100),
	note nvarchar(100)
)
Create table Tour( --5 tour 
	maTour char(10) not null,
	tenTour nvarchar(50),
	dayStart date,
	soLuongMax int,
	soDem int,
	pic nvarchar(100),
	note nvarchar(100)
)
Alter table Tour add moTa nvarchar(500)

Create table HomeStay( --6 Khach San
	maKS char(10) not null,
	maDD char(10) not null,
	tenKS nvarchar(50),
	phoneNum char(10),
	pic nvarchar(100),
	note nvarchar(100)
)
Alter table HomeStay add moTa nvarchar(500)

Create table Blog( --7 blog
	maBlog char(10) not null,
	maDD char(10) not null,
	username varchar(25),
	content nvarchar(1000),
	pic char(500),
	note nvarchar(100)
)
Create table Taxi( --8 taxi
	bienSo varchar(15) not null,
	maDD char(10) not null,
	soGhe int,
	phoneNum char(10),
	note nvarchar(100)
)
Create table Customer( --9 khach hang
	username varchar(25) not null,
	pass varchar(25),
	tenKH nvarchar(25),
	hoKH nvarchar(25),
	phoneNum char(10),
	email varchar(25),
	note nvarchar(100)
)
Create table WishList( --10 gio hang 
	maWL char(10) not null,
	username varchar(25) not null,
	note nvarchar(100)
)
Create table ElecBill( --11 hoa don dien tu
	maHD char(10) not null,
	username varchar(25) not null,
	tongTien float,
	paymentMethod nvarchar(25),
	dayCreate date,
	note nvarchar(100)
)

-- create DS
go
Create table DSKSTheoTrip( -- 12 . 
	maCD char(10) not null,
	maKS char(10) not null,
	note nvarchar(100)
)
Create table DSTripTheoTour( -- 13 
	maCD char(10) not null,
	maTour char(10) not null,
	note nvarchar(100)
)
Create table DSKSCanTT( -- 14.
	maKS char(10) not null,
	maHD char(10) not null,
	cost float,
	note nvarchar(100)
)
Create table DSTourCanTT(  -- 15
	maTour char(10) not null,
	maHD char(10) not null,
	cost float,
	note nvarchar(100)
)
Create table DSTourTrongWL( --16
	maTour char(10) not null,
	maWL char(10) not null,
	ngayAdd date,
	note nvarchar(100)
)
Create table DSKSTrongWL(  --17.
	maKS char(10) not null,
	maWL char(10) not null,
	ngayAdd date,
	note nvarchar(100)
)
Create table DSDatXe( --18
	maHD char(10) not null,
	bienSo varchar(15) not null,
	cost float,
	note nvarchar(100)
)
go
-- tao du lieu
--1. 
insert into Nation (maQG,tenQG,pic,note)
values ('QG00000001',N'Vietnam',N' ',N' ')
insert into Nation (maQG,tenQG,pic,note)
values ('QG00000002',N'USA',N' ',N' ')
insert into Nation (maQG,tenQG,pic,note)
values ('QG00000003',N'UK',N' ',N' ')
--2.
insert into Province (maTinh,maQG,tenTinh,pic,note)
values ('TINH000001','QG00000001',N'Hanoi',N' ',N' ')
insert into Province (maTinh,maQG,tenTinh,pic,note)
values ('TINH000002','QG00000001',N'Ninhbinh',N' ',N' ')
insert into Province (maTinh,maQG,tenTinh,pic,note)
values ('TINH000003','QG00000001',N'HCM',N' ',N' ')
--3.
insert into TourDestination (maDD,maTinh,tenDD,pic,note)
values ('DD00000001','TINH000001',N'Hàng Bài',N' ',N' ')
insert into TourDestination (maDD,maTinh,tenDD,pic,note)
values ('DD00000002','TINH000001',N'Lăng Bác',N' ',N' ')
insert into TourDestination (maDD,maTinh,tenDD,pic,note)
values ('DD00000003','TINH000001',N'Công viên nước hồ Tây',N' ',N' ')
--4
insert into Trip(maCD,maDDStart,maDDEnd,dayStrat,pic,note)
values ('CD00000001','DD00000002','DD00000001','1/1/2000',N' ',N' ')
insert into Trip(maCD,maDDStart,maDDEnd,dayStrat,pic,note)
values ('CD00000002','DD00000002','DD00000003','1/1/2000',N' ',N' ')
insert into Trip(maCD,maDDStart,maDDEnd,dayStrat,pic,note)
values ('CD00000003','DD00000001','DD00000003','1/1/2000',N' ',N' ')
--5
insert into Tour(maTour,tenTour,soLuongMax,soDem,dayStart,pic,note)
values ('TOUR000001',N'Explore Hanoi',100,2,'1/1/2000',N' ',N' ')
insert into Tour(maTour,tenTour,soLuongMax,soDem,dayStart,pic,note)
values ('TOUR000002',N'On Holiday',100,2,'1/1/2000',N' ',N' ')
insert into Tour(maTour,tenTour,soLuongMax,soDem,dayStart,pic,note)
values ('TOUR000003',N'Around the world',100,2,'1/1/2000',N' ',N' ')
--6.
insert into HomeStay(maKS,maDD,tenKS,phoneNum,pic,note)
values ('KS00000001','DD00000001',N'Fortuna','0900000000',N' ',N' ')
insert into HomeStay(maKS,maDD,tenKS,phoneNum,pic,note)
values ('KS00000002','DD00000001',N'Ngoc Trai','0900000000',N' ',N' ')
insert into HomeStay(maKS,maDD,tenKS,phoneNum,pic,note)
values ('KS00000003','DD00000001',N'Ngọc Trai','0900000000',N' ',N' ')
--7 
insert into Blog(maBlog,maDD,username,content,pic,note)
values ('BLOG000001','DD00000001','username1',N' ',N' ',N' ')
insert into Blog(maBlog,maDD,username,content,pic,note)
values ('BLOG000002','DD00000001','username1',N' ',N' ',N' ')
insert into Blog(maBlog,maDD,username,content,pic,note)
values ('BLOG000003','DD00000001','username1',N' ',N' ',N' ')
--8
insert into Taxi(bienSo,maDD,phoneNum,soGhe,note)
values ('GH00-XT002','DD00000001','0900000000',4,N' ')
insert into Taxi(bienSo,maDD,phoneNum,soGhe,note)
values ('GH00-XT003','DD00000001','0900000000',4,N' ')
insert into Taxi(bienSo,maDD,phoneNum,soGhe,note)
values ('GH00-XT004','DD00000001','0900000000',4,N' ')
--9
insert into Customer(username,pass,tenKH,hoKH,phoneNum,email,note)
values ('username1',N'000000',N'Anh',N'Pham Duc','0900000000','a@email.com',N' ')
insert into Customer(username,pass,tenKH,hoKH,phoneNum,email,note)
values ('username2',N'000000',N'Linh',N'Trinh Ngoc','0900000000','l@email.com',N' ')
insert into Customer(username,pass,tenKH,hoKH,phoneNum,email,note)
values ('username3',N'000000',N'Huyen',N'Nguyen Thi','0900000000','h@email.com',N' ')
--10
insert into WishList(maWL,username,note)
values ('WL00000001','username1',N' ')
insert into WishList(maWL,username,note)
values ('WL00000002','username2',N' ')
insert into WishList(maWL,username,note)
values ('WL00000003','username3',N' ')
--11
insert into ElecBill(maHD,username,tongTien,paymentMethod,dayCreate,note)
values ('HD00000001','username1',100,N'Cash','1/1/2000',N' ')
insert into ElecBill(maHD,username,tongTien,paymentMethod,dayCreate,note)
values ('HD00000002','username1',200,N'Cash','1/1/2000',N' ')
insert into ElecBill(maHD,username,tongTien,paymentMethod,dayCreate,note)
values ('HD00000003','username2',400,N'Cash','1/1/2000',N' ')
--12
insert into DSKSTheoTrip(maCD,maKS,note)
values ('CD00000001','KS00000001',N' ')
insert into DSKSTheoTrip(maCD,maKS,note)
values ('CD00000002','KS00000002',N' ')
insert into DSKSTheoTrip(maCD,maKS,note)
values ('CD00000003','KS00000003',N' ')
--13. 
insert into DSTripTheoTour(maCD,maTour,note)
values ('CD00000001','TOUR000001',N' ')
insert into DSTripTheoTour(maCD,maTour,note)
values ('CD00000002','TOUR000001',N' ')
insert into DSTripTheoTour(maCD,maTour,note)
values ('CD00000003','TOUR000002',N' ')
--14
insert into DSKSCanTT(maHD,maKS,cost,note)
values ('HD00000001','KS00000001',100,N' ')
insert into DSKSCanTT(maHD,maKS,cost,note)
values ('HD00000002','KS00000001',150,N' ')
insert into DSKSCanTT(maHD,maKS,cost,note)
values ('HD00000003','KS00000002',120,N' ')
--15
insert into DSTourCanTT(maHD,maTour,cost,note)
values ('HD00000001','TOUR000001',100,N' ')
insert into DSTourCanTT(maHD,maTour,cost,note)
values ('HD00000002','TOUR000001',120,N' ')
insert into DSTourCanTT(maHD,maTour,cost,note)
values ('HD00000003','TOUR000002',120,N' ')
--16
insert into DSTourTrongWL(maWL,maTour,ngayAdd,note)
values ('WL00000001','TOUR000001','1/1/2000',N' ')
insert into DSTourTrongWL(maWL,maTour,ngayAdd,note)
values ('WL00000001','TOUR000002','1/1/2000',N' ')
insert into DSTourTrongWL(maWL,maTour,ngayAdd,note)
values ('WL00000001','TOUR000003','1/1/2000',N' ')
--17
insert into DSKSTrongWL(maWL,maKS,ngayAdd,note)
values ('WL00000001','KS00000001','1/1/2000',N' ')
insert into DSKSTrongWL(maWL,maKS,ngayAdd,note)
values ('WL00000001','KS00000002','1/1/2000',N' ')
insert into DSKSTrongWL(maWL,maKS,ngayAdd,note)
values ('WL00000001','KS00000003','1/1/2000',N' ')
--18
insert into DSDatXe(maHD,bienSo,cost,note)
values ('HD00000001','GH00-XT002',40,N' ')
insert into DSDatXe(maHD,bienSo,cost,note)
values ('HD00000002','GH00-XT003',30,N' ')
insert into DSDatXe(maHD,bienSo,cost,note)
values ('HD00000003','GH00-XT004',50,N' ')
go
-- 1 khoa chinh
Alter table Nation
Add CONSTRAINT pk_nation Primary key (maQG)
Alter table Province
Add CONSTRAINT pk_province Primary key (maTinh)
Alter table TourDestination
Add CONSTRAINT pk_tourDestination Primary key (maDD)
Alter table Trip
Add CONSTRAINT pk_trip Primary key (maCD)
Alter table Tour
Add CONSTRAINT pk_tour Primary key (maTour)
Alter table HomeStay
Add CONSTRAINT pk_homeStay Primary key (maKS)
Alter table Blog
Add CONSTRAINT pk_blog Primary key (maBlog)
Alter table Taxi
Add CONSTRAINT pk_taxi Primary key (bienSo)
Alter table Customer
Add CONSTRAINT pk_customer Primary key (username)
Alter table WishList
Add CONSTRAINT pk_wishList Primary key (maWL)
Alter table ElecBill
Add CONSTRAINT pk_elecBill Primary key (maHD)
-- khoa ngoai
Alter table Province
Add CONSTRAINT fk_province foreign key (maQG) references Nation(maQG)
Alter table TourDestination
Add CONSTRAINT fk_tourDestiantion foreign key (maTinh) references Province(maTinh)
Alter table Trip
Add CONSTRAINT fk_trip_DDS foreign key (maDDStart) references TourDestination(maDD)
Alter table Trip
Add CONSTRAINT fk_trip_DDE foreign key (maDDEnd) references TourDestination(maDD)
Alter table HomeStay
Add CONSTRAINT fk_homeStay foreign key (maDD) references TourDestination(maDD)
Alter table Blog
Add CONSTRAINT fk_blog foreign key (maDD) references TourDestination(maDD)
Alter table WishList
Add CONSTRAINT fk_wishList foreign key (username) references Customer(username)
Alter table ElecBill
Add CONSTRAINT fk_elecBill foreign key (username) references Customer(username)
Alter table DSTripTheoTour 
Add CONSTRAINT fk_dSTripTheoTour_Trip foreign key (maCD) references Trip(maCD)
Alter table DSTripTheoTour 
Add CONSTRAINT fk_dSTripTheoTour_Tour foreign key (maTour) references Tour(maTour)
Alter table DSTourCanTT
Add CONSTRAINT fk_dSTourCanTT_Tour foreign key (maTour) references Tour(maTour)
Alter table DSTourCanTT
Add CONSTRAINT fk_dSTourCanTT_HD foreign key (maHD) references ElecBill(maHD)
Alter table DSKSCanTT
Add CONSTRAINT fk_dSKSCanTT_KS foreign key (maKS) references HomeStay(maKS)
Alter table DSKSCanTT
Add CONSTRAINT fk_dSKSCanTT_HD foreign key (maHD) references ElecBill(maHD)
Alter table DSKSTheoTrip 
Add CONSTRAINT fk_dSKSTheoTrip_Trip foreign key (maCD) references Trip(maCD)
Alter table DSKSTheoTrip 
Add CONSTRAINT fk_dSKSTheoTrip_KS foreign key (maKS) references HomeStay(maKS)
Alter table DSTourTrongWL
Add CONSTRAINT fk_dSTourTrongWL_Tour foreign key (maTour) references Tour(maTour)
Alter table DSTourTrongWL
Add CONSTRAINT fk_dSTourTrongWL_WL foreign key (maWL) references WishList(maWL)
Alter table DSKSTrongWL
Add CONSTRAINT fk_dSKSTrongWL_KS foreign key (maKS) references HomeStay(maKS)
Alter table DSKSTrongWL
Add CONSTRAINT fk_dSKSTrongWL_WL foreign key (maWL) references WishList(maWL)
Alter table Taxi
Add CONSTRAINT fk_taxi_DD foreign key (maDD) references TourDestination(maDD)
Alter table DSDatXe
Add CONSTRAINT fk_dSDatXe_HD foreign key (maHD) references ElecBill(maHD)
Alter table DSDatXe
Add CONSTRAINT fk_dSDatXe_Taxi foreign key (bienSo) references Taxi(bienSo)
--2 khoa chinh
Alter table DSKSTheoTrip
Add CONSTRAINT pk2_dSKSTheoTrip Primary key (maKS,maCD)
Alter table DSTripTheoTour
Add CONSTRAINT pk2_dSTripTheoTour Primary key (maTour,maCD)
Alter table DSKSCanTT
Add CONSTRAINT pk2_dSKSCanTT Primary key (maKS,maHD)
Alter table DSTourCanTT
Add CONSTRAINT pk2_dSTourCanTT Primary key (maTour,maHD)
Alter table DSTourTrongWL
Add CONSTRAINT pk2_dSTourTrongWL Primary key (maTour,maWL)
Alter table DSKSTrongWL
Add CONSTRAINT pk2_dSKSTrongWL Primary key (maKS,maWL)
Alter table DSDatXe
Add CONSTRAINT pk2_dSDatXe Primary key (bienSo,maHD)
go

----------------------------------- wweb
Create View DestinationReview as 
select TourDestination.maDD,tenDD,tenTinh,tenQG,TourDestination.pic  from TourDestination,Province,Nation
where TourDestination.maTinh=Province.maTinh and Province.maQG=Nation.maQG
go

Create View DestinationInfor as
select a.*,b.SoLuongTaxi,c.SoluongKS from 
(select TourDestination.maDD,tenDD,tenTinh,tenQG,TourDestination.pic  from TourDestination,Province,Nation
where TourDestination.maTinh=Province.maTinh and Province.maQG=Nation.maQG ) as a
FULL OUTER JOIN (select count(bienSo) as SoLuongTaxi ,TourDestination.maDD from Taxi,TourDestination
where TourDestination.maDD=Taxi.maDD group by (TourDestination.maDD) ) as b
on a.maDD=b.maDD 
FULL OUTER JOIN (select count(maKS) as SoluongKS ,TourDestination.maDD from HomeStay,TourDestination
where TourDestination.maDD=HomeStay.maDD group by (TourDestination.maDD) ) as c
on a.maDD=c.maDD 
go



-- create table 
create table TenCacBang(
	tenCacBang nvarchar(100) primary key,
	chuThich nvarchar(100)
)
drop table TenCacBang

insert into TenCacBang(tenCacBang)
values ('Blog')
insert into TenCacBang(tenCacBang)
values ('Category')
insert into TenCacBang(tenCacBang)
values ('Customer')
insert into TenCacBang(tenCacBang)
values ('DSDatXe')
insert into TenCacBang(tenCacBang)
values ('DSKSCanTT')
insert into TenCacBang(tenCacBang)
values ('DSKSTheoTrip')
insert into TenCacBang(tenCacBang)
values ('DSKSTrongWL')
insert into TenCacBang(tenCacBang)
values ('DSTourCanTT')
insert into TenCacBang(tenCacBang)
values ('DSTourTrongWL')
insert into TenCacBang(tenCacBang)
values ('DSTripTheoTour')
insert into TenCacBang(tenCacBang)
values ('ElecBill')
insert into TenCacBang(tenCacBang)
values ('HomeStay')
insert into TenCacBang(tenCacBang)
values ('MyWebSite')
insert into TenCacBang(tenCacBang)
values ('Nation')
insert into TenCacBang(tenCacBang)
values ('Province')
insert into TenCacBang(tenCacBang)
values ('Taxi')
insert into TenCacBang(tenCacBang)
values ('TenCacBang')
insert into TenCacBang(tenCacBang)
values ('Tour')
insert into TenCacBang(tenCacBang)
values ('TourDestination')
insert into TenCacBang(tenCacBang)
values ('Trip')
insert into TenCacBang(tenCacBang)
values ('WishList')

select * from tenCacBang

go
Create View colName
as

SELECT COLUMN_NAME,TABLE_NAME,ORDINAL_POSITION

FROM INFORMATION_SCHEMA.COLUMNS

--------------
WHERE TABLE_NAME = 'Tour'

ORDER BY ORDINAL_POSITION
go
select * from colName
where TABLE_NAME = 'Tour'


