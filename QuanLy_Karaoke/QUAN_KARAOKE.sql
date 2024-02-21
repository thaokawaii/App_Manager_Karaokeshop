create database NMCNPM
go
use NMCNPM
go

create table CHITIETHD (
   MAHD                 char(10)             not null,
   MAMH                 char(10)             not null,
   SL                   int                  null,
   DONGIA               float                null,
   constraint PK_CHITIETHD primary key (MAHD, MAMH)
)
go


create table CHITIETPN (
   MAHANG               char(10)             not null,
   MAPN                 char(10)             not null,
   SL                   int                  null,
   DONGIA               float            default 0,
   constraint PK_CHITIETPN primary key (MAHANG, MAPN)
)
go



create table CTPHIEUTHUE (
   MAPHIEU              char(10)             not null,
   MAHD                 char(10)             not null,
   GIODEN               datetime             null,
   GIODI                datetime             null,
   constraint PK_CTPHIEUTHUE primary key (MAPHIEU, MAHD)
)
go

create table HANGHOA (
   MAHANG               char(10)             not null,
   MANCC                char(10)             null,
   TENHH                nvarchar(30)             null,
   DVT                  nvarchar(10)             null,
   DONGIA               float                null,
   constraint PK_HANGHOA primary key nonclustered (MAHANG)
)
go


create table HOADON (
   MAHD                 char(10)             not null,
   MAKH                 char(10)             not null,
   MANV                 char(10)             not null,
   NGAYTT               datetime             null,
   TONGTG               float               null,
   TIENPHONG            float                default 0,
   TIENDV               float               default 0,
   TONGTIEN             float               default 0,
   TINHTRANG            nvarchar(20)           null,
   constraint PK_HOADON primary key nonclustered (MAHD)
)
go



create table KHACHHANG (
   MAKH                 char(10)             not null,
   TEN                  nvarchar(30)             null,
   SDT                  char(10)             null,
   DIACHI               nvarchar(50)             null,
   TONGTIEN             float               default 0,
   constraint PK_KHACHHANG primary key nonclustered (MAKH)
)
go

create table LOAIHANG (
   MALOAI               char(10)             not null,
   TENLOAI              nvarchar(30)             null,
   constraint PK_LOAIHANG primary key nonclustered (MALOAI)
)
go

create table LOAIPHONG (
   MALOAI               char(10)             not null,
   TENLOAIPH            nvarchar(30)             null,
   GIATHUE              float               default 0,
   constraint PK_LOAIPHONG primary key nonclustered (MALOAI)
)
go


create table MATHANG (
   MAMH                 char(10)             not null,
   MALOAI               char(10)             null,
   TENMH                nvarchar(30)             null,
   DVT                  nvarchar(10)             null,
   SLTON                int                  null,
   GIABAN               float                null,
   constraint PK_MATHANG primary key nonclustered (MAMH)
)
go


create table NHACC (
   MANCC                char(10)             not null,
   TENNCC               nvarchar(50)             null,
   DIACHI               nvarchar(50)             null,
   SDT                  char(10)             null,
   constraint PK_NHACC primary key nonclustered (MANCC)
)
go

create table NHANVIEN (
   MANV                 char(10)             not null,
   TENNV                nvarchar(30)             null,
   DIACHI               nvarchar(50)             null,
   SDT                  char(10)             null,
   CMT                  char(10)             null,
   GIOITINH             nvarchar(10)             null,
   NGAYSINH             datetime             null,
   NGAYVL               datetime             null,
   CHUCVU               nvarchar(20)             null,
   TENDN                char(20)            unique,
   MATKHAU              char(20)             null,
   constraint PK_NHANVIEN primary key nonclustered (MANV)
)
go


create table PHIEUNHAP (
   MAPN                 char(10)             not null,
   MANV                 char(10)             null,
   NGAYNHAP             datetime             null,
   TONGTIEN             float                default 0,
   constraint PK_PHIEUNHAP primary key nonclustered (MAPN)
)
go


create table PHIEUTHUE (
   MAPHIEU              char(10)             not null,
   MAPHONG              char(10)             not null,
   NGAYTHUE             datetime             null,
   constraint PK_PHIEUTHUE primary key nonclustered (MAPHIEU)
)
go

create table PHONG (
   MAPHONG              char(10)             not null,
   MALOAI               char(10)             not null,
   TINHTRANG            nvarchar(10)              null,
   TENPH                nvarchar(20)             null,
   constraint PK_PHONG primary key nonclustered (MAPHONG)
)
go



alter table CHITIETHD
   add constraint FK_CHITIETH_CHITIETHD_HOADON foreign key (MAHD)
      references HOADON (MAHD)
go

alter table CHITIETHD
   add constraint FK_CHITIETH_CHITIETHD_MATHANG foreign key (MAMH)
      references MATHANG (MAMH)
go

alter table CHITIETPN
   add constraint FK_CHITIETP_CHITIETPN_HANGHOA foreign key (MAHANG)
      references HANGHOA (MAHANG)
go

alter table CHITIETPN
   add constraint FK_CHITIETP_CHITIETPN_PHIEUNHA foreign key (MAPN)
      references PHIEUNHAP (MAPN)
go

alter table CTPHIEUTHUE
   add constraint FK_CTPHIEUT_CTPHIEUTH_PHIEUTHU foreign key (MAPHIEU)
      references PHIEUTHUE (MAPHIEU)
go

alter table CTPHIEUTHUE
   add constraint FK_CTPHIEUT_CTPHIEUTH_HOADON foreign key (MAHD)
      references HOADON (MAHD)
go

alter table HANGHOA
   add constraint FK_HANGHOA_REFERENCE_NHACC foreign key (MANCC)
      references NHACC (MANCC)
go

alter table HOADON
   add constraint FK_HOADON_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go

alter table HOADON
   add constraint FK_HOADON_RELATIONS_KHACHHAN foreign key (MAKH)
      references KHACHHANG (MAKH)
go

alter table MATHANG
   add constraint FK_MATHANG_RELATIONS_LOAIHANG foreign key (MALOAI)
      references LOAIHANG (MALOAI)
go

alter table PHIEUNHAP
   add constraint FK_PHIEUNHA_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go

alter table PHIEUTHUE
   add constraint FK_PHIEUTHU_RELATIONS_PHONG foreign key (MAPHONG)
      references PHONG (MAPHONG)
go

alter table PHONG
   add constraint FK_PHONG_RELATIONS_LOAIPHON foreign key (MALOAI)
      references LOAIPHONG (MALOAI)
go

INSERT INTO LOAIPHONG VALUES('LP01',N'Phòng Vip',50000),('LP02',N'Phòng thường',250000);
--Phòng
INSERT INTO PHONG VALUES('PH01','LP02',N'Trống',N'Thường 1.1'),
('PH02','LP02',N'Trống',N'Thường 1.2'),
('PH03','LP02',N'Trống',N'Thường 1.3'),
('PH04','LP02',N'Trống',N'Thường 1.4'),
('PH05','LP02',N'Trống',N'Thường 2.1'),
('PH06','LP02',N'Trống',N'Thường 2.2'),
('PH07','LP02',N'Trống',N'Thường 2.3'),
('PH08','LP02',N'Trống',N'Thường 2.4'),
('PH09','LP02',N'Trống',N'Thường 3.1'),
('PH10','LP02',N'Trống',N'Thường 3.2'),
('PH11','LP02',N'Trống',N'Thường 3.3'),
('PH12','LP02',N'Trống',N'Thường 3.4'),
('PH13','LP01',N'Trống',N'Vip 1'),
('PH14','LP01',N'Trống',N'Vip 2'),
('PH15','LP01',N'Trống',N'Vip 3')
--select * from MATHANG
--select MAMH as N'Mã',TENMH as N'Tên mặt hàng',DVT,GIABAN as N'Giá' from MATHANG
--Nhà cung cấp
INSERT INTO NHACC VALUES ('NCC01',N'Công ty Cocacola',N'Quận 7,TP.HCM','0398745214'),
('NCC02',N'Công ty bia Sài Gòn',N' Quận 1, TP.HCM','0363945214'),
('NCC03',N'Bách hóa xanh',N'  Quận 1, TP.HCM','0897412548')
--Nhân viên
SET DATEFORMAT DMY
INSERT INTO NHANVIEN VALUES('NV01',N'Nguyễn Tấn Thạo',N'Bình Định','0935841254','2514521452','Nam','17-09-2002','20-07-2020',N'Nhân viên','thao','123')
INSERT INTO NHANVIEN VALUES('NV02',N'Đặng Văn Hảo',N'Phú Yên','0775841254','2587413698','Nam','20-03-2002','20-08-2020',N'Nhân viên','son','123')
INSERT INTO NHANVIEN VALUES('NV03',N'Nguyễn Thị Hoa',N'TP.HCM','0897451258','2334521452',N'Nữ','20-08-2001','20-07-2020',N'Nhân viên','hoa','123')
INSERT INTO NHANVIEN VALUES('NV04',N'Trần Văn Khôi',N'Hà Nội','0225841254','2514578522','Nam','17-09-1998','20-06-2002',N'Admin','khoi','123')
--Khách hàng
INSERT INTO KHACHHANG VALUES('KH00',N'Vãng lai',null,null,null),('KH01',N'Nguyễn Văn Lân','0398415284','Tân Phú-TP.HCM',500000),('KH02',N'Nguyễn Thị Vân','0935145284','Tân Bình-TP.HCM',600000),
('KH03',N'Trần Văn Quy','0868415284',N'Quận 9-TP.HCM',500000)
--Loại hàng
INSERT INTO LOAIHANG VALUES('LH01',N'Bia'),('LH02',N'Nước ngọt'),('LH03',N'Đồ ăn nhanh'),('LH04',N'Món ăn');
--Mặt hàng
INSERT INTO MATHANG VALUES('MH01','LH01',N'Bia Sài Gòn','Chai',600,15000),
('MH02','LH01',N'Bia Tiger','Chai',500,20000),
('MH03','LH01',N'Bia Henieken','Chai',600,25000),
('MH04','LH02',N'Coca','Chai',500,15000),
('MH05','LH02',N'Pepsi','Chai',400,15000),
('MH06','LH02',N'Fanta','Chai',300,10000),
('MH07','LH02',N'Redbull','lon',100,20000),
('MH08','LH03',N'Aquafina','Chai',600,10000),
('MH09','LH04',N'Mực nướng','Con',300,50000),
('MH10','LH04',N'Mì xào',N'Đĩa',200,100000),
('MH11','LH03',N'Xoài','Đĩa',300,50000),
('MH12','LH03',N'Bim Bim','Bịch',600,20000),
('MH13','LH03',N'ổi','Đĩa',300,50000),
('MH14','LH03',N'Khô gà','Bịch',600,50000),
('MH15','LH03',N'Cóc','Đĩa',300,50000),
('MH16','LH03',N'Mít sấy','Bịch',600,20000)
--Hàng hóa
INSERT INTO HANGHOA VALUES('HH01','NCC03',N'Xoài','Kg',20000),
('HH02','NCC03',N'ổi','Kg',15000),
('HH03','NCC03',N'Xoài','Kg',30000),
('HH04','NCC03',N'Cóc','Kg',25000),
('HH05','NCC03',N'Mực khô','Kg',500000),
('HH06','NCC03',N'Nước lọc','thùng',120000),
('HH07','NCC01',N'CocaCola','thùng',140000),
('HH08','NCC03',N'Pepsi','thùng',140000),
('HH09','NCC02',N'Tiger','thùng',410000),
('HH10','NCC02',N'Sài Gòn Lager','thùng',255000),
('HH11','NCC02',N'Heineken','thùng',445000)
--Phiếu thuê
INSERT INTO PHIEUTHUE VALUES('PT01','PH01','20/12/2022')
--HÓA ĐƠN
INSERT INTO HOADON VALUES('HD01','KH01','NV01','20/12/2022',0,0,0,0,N'Đã thanh toán')
--Chi tiết phiếu thuê
INSERT INTO CTPHIEUTHUE VALUES('PT01','HD01','10:30:00','12:00:00')
--Chi tiết hóa đơn
INSERT INTO CHITIETHD VALUES('HD01','MH01',1,15000)
--Phiếu nhập
INSERT INTO PHIEUNHAP VALUES('PN01','NV01','20/12/2022',0)
--chi tiết phiếu nhập
INSERT INTO CHITIETPN VALUES('HH01','PN01',2,0)

--trigger
----khi khách gọi mọn cập nhật số lượng hàng tồn
create trigger SLMH on CHITIETHD FOR INSERT
AS
begin
UPDATE MATHANG
SET SLTON=SLTON-(select SL FROM inserted where MAMH=MATHANG.MAMH)
from MATHANG 
join inserted on MATHANG.MAMH=inserted.MAMH
end
---Khi nhập phiếu thuê cập nhật lại tình trạng phòng
create  trigger TingtrangPhong on PHIEUTHUE FOR INSERT
as
UPDATE PHONG
SET TINHTRANG=N'Đã thuê'
where MAPHONG=(select MAPHONG FROM inserted)
---Update tiền dịch vụ khi thêm mặt hàng vào chi tiết hóa đơn
create trigger TienDV ON CHITIETHD FOR INSERT
as
UPDATE HOADON
set TIENDV=TIENDV +(select SUM(SL*GIABAN) from MATHANG m,inserted k where m.MAMH=k.MAMH AND k.MAHD= HOADON.MAHD)
where MAHD=(select MAHD FROM inserted)
----Kiểm tra tài khoản đăng nhập

create proc SP_AuthoLogin
@Username char(15),
@Password char(15)
as
begin
    if exists (select * from NHANVIEN where TENDN = @Username and MATKHAU = @Password and CHUCVU=N'Admin')
	 select 0 as code
	else if exists(select * from NHANVIEN where TENDN = @Username and MATKHAU = @Password and CHUCVU=N'Nhân viên')
        select 1 as code
    else if exists(select * from NhanVien where TENDN = @Username and MATKHAU != @Password) 
        select 2 as code
    else select 3 as code
end
exec SP_AuthoLogin 'thao','123'
--Tính giờ thuê
create function tinhtg(@maphieu char(10))
returns float
as
	begin
		declare @gio int, @phut float
		set @gio = (select DATEPART(hour,GIODI) - DATEPART(hour,GIODEN) from CTPHIEUTHUE where MAPHIEU = @maphieu)
		set @phut = (select((DATEPART(mi,GIODI) - DATEPART(mi,GIODEN))) from CTPHIEUTHUE where MAPHIEU = @maphieu)
		if @phut < 0
			set @gio = @gio - 1 
		set @phut = abs(@phut)*1.0/60
		return @gio + @phut
	end
print DBO.tinhtg('PT01')
---Tính tiền phòng
create function tinhtienphong(@maphieu char(10))
returns float
as
	begin
	declare @tienphong float
	declare @gio float
	set @gio=(select DBO.tinhtg(@maphieu))
		select @tienphong = @gio *LOAIPHONG.GIATHUE from LOAIPHONG,PHONG,PHIEUTHUE where LOAIPHONG.MALOAI=PHONG.MALOAI and PHIEUTHUE.MAPHONG=PHONG.MAPHONG and MAPHIEU=@maphieu
        return convert(int,@tienphong)
	end
	print convert(int,DBO.tinhtienphong('PT02'))
--update tiền dịch vụ khi thêm vào chi tiết hóa đơn
create trigger ThemCTHD ON CHITIETHD FOR INSERT
as
UPDATE
CHITIETHD
set DONGIA=(select (CHITIETHD.SL*MATHANG.GIABAN) from CHITIETHD,MATHANG where CHITIETHD.MAMH=MATHANG.MAMH and CHITIETHD.MAMH=(SELECT MAMH FROM inserted) and CHITIETHD.MAHD=(select MAHD from inserted) )
where MAMH=(SELECT MAMH FROM inserted) AND MAHD=(SELECT MAHD FROM inserted)

create trigger UDCTHD ON CHITIETHD FOR UPDATE
as
UPDATE
CHITIETHD
set DONGIA=(select (CHITIETHD.SL*MATHANG.GIABAN) from CHITIETHD,MATHANG where CHITIETHD.MAMH=MATHANG.MAMH and CHITIETHD.MAMH=(SELECT MAMH FROM inserted) and CHITIETHD.MAHD=(select MAHD from inserted) )
where MAMH=(SELECT MAMH FROM inserted) AND MAHD=(SELECT MAHD FROM inserted)
--cập nhật hóa đơn khi thanh toán
create proc CapNhatHD @maPhieu char(10),@maHD char(10)
as
declare @tien float=(select dbo.tinhtienphong(@maPhieu))
begin
update HOADON 
SET TIENPHONG=@tien,TONGTIEN=(select TIENDV+TIENPHONG from HOADON WHERE MAHD=@maHD),TINHTRANG=N'Đã thanh toán',TONGTG=(select  DBO.tinhtg(@maPhieu))
where MAHD=@maHD
end
exec CapNhatHD'PT02','HD02'

--Kiểm tra tình trạng phòng
create proc KTPhong @ma char(10)
as
begin
if exists(select * from PHONG where TINHTRANG like N'Đã thuê' and MAPHONG=@ma)
select 0 as code
else
select 1 as code
end
exec KTPhong 'PH03'
--update tổng tiền khách đã thanh toán ở quán
create trigger UpdateTienKH ON HOADON FOR UPDATE
as
update KHACHHANG set TONGTIEN=(select (KHACHHANG.TONGTIEN+inserted.TONGTIEN) from inserted,KHACHHANG where inserted.MAKH=KHACHHANG.MAKH)
where MAKH=(select MAKH from inserted)







select MAMH as N'Mã hàng',MALOAI as N'Mã loại',TENMH as N'Tên MH',GIABAN as N'Giá' from MATHANG
select *from HOADON
set DATEFORMAT DMY
Insert into HOADON VALUES('HD02','KH01','NV01',GETDATE(),0,0,0,0,N'Chưa thanh toán')
select * from HOADON where TINHTRANG like 'Chua%'
select *from PHIEUTHUE
SELECT CONCAT('MH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAMH),3,2),0) + 1),2)) from MATHANG where MAMH like 'MH%'
select *from CHITIETHD
Insert INTO CHITIETHD VALUES('HD02','MH02',2,0)
SELECT NHANVIEN.TENNV,KHACHHANG.TEN,CTPHIEUTHUE.GIODEN,CTPHIEUTHUE.GIODI,PHONG.TENPH,HOADON.MAHD,HOADON.TONGTG,MATHANG.TENMH,CHITIETHD.SL,CHITIETHD.DONGIA,HOADON.TIENDV,HOADON.TIENPHONG,HOADON.TONGTIEN 
FROM NHANVIEN,KHACHHANG,PHONG,PHIEUTHUE,CTPHIEUTHUE,HOADON,CHITIETHD,MATHANG where CHITIETHD.MAHD=HOADON.MAHD and CTPHIEUTHUE.MAHD=HOADON.MAHD and CTPHIEUTHUE.MAPHIEU=PHIEUTHUE.MAPHIEU
and PHIEUTHUE.MAPHONG=PHONG.MAPHONG and HOADON.MANV=NHANVIEN.MANV and HOADON.MAKH=KHACHHANG.MAKH and CHITIETHD.MAMH=MATHANG.MAMH and HOADON.MAHD='HD02'
select HOADON.MAHD,MAMH,SL,DONGIA from CHITIETHD,HOADON where HOADON.MAHD=CHITIETHD.MAHD and HOADON.TINHTRANG like'chua%'

---hiển thị hóa đơm phòng chưa thanh toán
select CHITIETHD.MAHD as N'Mã đơn',TENMH as N'Tên mặt hàng',SL as N'Số lượng',CHITIETHD.DONGIA as N'Giá' from CHITIETHD,HOADON,CTPHIEUTHUE,PHIEUTHUE,PHONG,MATHANG
where HOADON.MAHD=CHITIETHD.MAHD  and HOADON.MAHD=CTPHIEUTHUE.MAHD 
and CTPHIEUTHUE.MAPHIEU=PHIEUTHUE.MAPHIEU and PHIEUTHUE.MAPHONG=PHONG.MAPHONG and CHITIETHD.MAMH=MATHANG.MAMH and PHONG.MAPHONG='PH01'
select * from PHONG
select * from CTPHIEUTHUE
select * FROM HOADON
update CTPHIEUTHUE
set GIODI=GETDATE()
where MAPHIEU=(SELECT CTPHIEUTHUE.MAPHIEU from PHIEUTHUE,CTPHIEUTHUE where PHIEUTHUE.MAPHIEU=CTPHIEUTHUE.MAPHIEU and MAPHONG='PH01')

--update HOADON
--set TONGTIEN=(TIENDV+TIENPHONG)
--where MAHD='HD01'
update PHONG
set TINHTRANG=N'Trống'
where MAPHONG=(select PHONG.MAPHONG from PHONG,PHIEUTHUE,CTPHIEUTHUE,HOADON where PHONG.MAPHONG=PHIEUTHUE.MAPHONG and PHIEUTHUE.MAPHIEU=CTPHIEUTHUE.MAPHIEU and CTPHIEUTHUE.MAHD=HOADON.MAHD and HOADON.MAHD='HD01')
update HOADON
SET TONGTIEN=(TIENPHONG+TIENDV)
WHERE MAHD='HD01'
select TIENPHONG FROM HOADON WHERE MAHD='HD02'
select TIENDV FROM HOADON where MAHD='HD02'
declare @kq float

UPDATE CHITIETHD 
set SL=1
where MAHD='HD06' and MAMH='MH11'
select TENNV FROM NHANVIEN where TENDN='thao'
select MAMH as N'Mã hàng',MALOAI as N'Mã loại',TENMH as N'Tên MH',DVT,GIABAN as N'Giá' from MATHANG WHERE  TENMH like N'Bia%'

select HOADON.MAHD from HOADON,PHIEUTHUE,CTPHIEUTHUE,PHONG where HOADON.MAHD = CTPHIEUTHUE.MAHD and CTPHIEUTHUE.MAPHIEU = PHIEUTHUE.MAPHIEU and PHIEUTHUE.MAPHONG = PHONG.MAPHONG AND PHONG.MAPHONG = '' and HOADON.TINHTRANG=N'Chưa thanh toán'

select MAKH as N'Mã KH',TEN as N'Họ tên',SDT ,DIACHI as N'Địa chỉ',TONGTIEN as N'Tổng tiền' from KHACHHANG
select MAHD as N'MÃ HD',TENMH as N'Tên hàng',SL as N'Số lượng',CHITIETHD.DONGIA   from CHITIETHD,MATHANG WHERE CHITIETHD.MAMH=MATHANG.MAMH and MAHD='HD01'

SELECT CONCAT('KH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAKH),3,2),0) + 1),2)) from KHACHHANG where MAKH like 'KH%'
set dateformat DMY
select GIODEN from CTPHIEUTHUE WHERE MAPHIEU='PT01' and MAHD='HD01'
select PHIEUTHUE.MAPHIEU from HOADON,PHIEUTHUE,CTPHIEUTHUE,PHONG where HOADON.MAHD = CTPHIEUTHUE.MAHD and CTPHIEUTHUE.MAPHIEU = PHIEUTHUE.MAPHIEU and PHIEUTHUE.MAPHONG = PHONG.MAPHONG AND PHONG.MAPHONG = 'PH07' and HOADON.TINHTRANG=N'Chưa thanh toán'

select MANV as N'Mã',TENNV as N'Tên',DIACHI as N'Địa chỉ',SDT,CMT,GIOITINH as 'Giới tính',NGAYSINH as N'Ngày sinh',NGAYVL as N'Ngày vào làm',TENDN as N'Tên DN',MATKHAU as N'Mật khẩu' FROM NHANVIEN