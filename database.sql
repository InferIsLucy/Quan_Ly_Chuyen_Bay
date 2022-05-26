CREATE database QLYBANVECHUYENBAY
GO

Use QLYBANVECHUYENBAY
GO

--Bang Taikhoan
CREATE TABLE ACCOUNT
(
	MaTK INT IDENTITY PRIMARY KEY NOT NULL, 
	DisplayName NVARCHAR(100) NOT NULL,
	UserName NVARCHAR(100) NOT NULL,
	Password NVARCHAR(1000) NOT NULL,
	Type INT NOT NULL --1 là admin, 0 là nhân viên
)
GO

--Bang CHUYENBAY
CREATE TABLE CHUYENBAY 
(
   MaChuyenBay varchar(50) NOT NULL,
   GiaVe money NOT NULL,
   SanBayDi varchar(50) NOT NULL, --khoangoai
   SanBayDen varchar(50) NOT NULL, --khoangoai
   NgayKhoiHanh smalldatetime NOT NULL, 
   GioKhoiHanh datetime NOT NULL,
   ThoiGianBay int NOT NULL,
   SoLuongGheHang1 int NOT NULL,
   SoLuongGheHang2 int NOT NULL,
   CONSTRAINT PK_CHUYENBAY PRIMARY KEY(MaChuyenBay),
)
 
--Bang DOANHTHUCHUYENBAY
CREATE TABLE DOANHTHUCHUYENBAY
(
   MaChuyenBay varchar(50) NOT NULL, --ngoai
   NgayKhoiHanh smalldatetime NOT NULL, --ngoai
   SoVe int NULL,
   DoanhThu int NULL,
   TyLe float NULL,
   CONSTRAINT PK_DOANHTHUCHUYENBAY PRIMARY KEY(MaChuyenBay, NgayKhoiHanh)
)
 
--Bang CHITIETCHUYENBAY
CREATE TABLE CT_CHUYENBAY 
(
   MaCTChuyenBay varchar(50) NOT NULL,
   MaChuyenBay varchar(50) NOT NULL, --khoangoai
   SanBayTrungGian varchar(50) NOT NULL, --khoangoai
   ThoiGianDung int NOT NULL,
   GhiChu NVARCHAR(200),
   CONSTRAINT PK_CTCHUYENBAY PRIMARY KEY(MaCTChuyenBay),
)
 
--Bang SANBAY
CREATE TABLE SANBAY 
(
   MaSanBay varchar(50) NOT NULL,
   TenSanBay varchar(100) NOT NULL,
   CONSTRAINT PK_SANBAY PRIMARY KEY(MaSanBay),
)
 
--Bang VECHUYENBAY
CREATE TABLE VECHUYENBAY 
(
   MaChuyenBay varchar(50) NOT NULL, --chinh, NGOAI
   CMND varchar(10) NOT NULL, -- chinh, NGOAI
   HanhKhach varchar(100) NOT NULL,
   DienThoai varchar(10) NOT NULL,
   MaHangVe varchar(50) NOT NULL, --khoangoai
   GiaTien money NOT NULL,
   MaGhe varchar(50) NOT NULL, --ngoai
   CONSTRAINT PK_VECHUYENBAY PRIMARY KEY(MaChuyenBay, CMND)
)
 
--Bang HANGVE
CREATE TABLE HANGVE
(
   MaHangVe varchar(50) NOT NULL,
   MaChuyenBay varchar(50) NOT NULL, --NGOAI
   TenHangVe varchar(100) NOT NULL,
   PhanTramDonGia float NOT NULL,
   SoLuongGhe int NOT NULL,
   SLGheDat int NOT NULL,
   SLGheTrong int NOT NULL,
   CONSTRAINT PK_HANGVE PRIMARY KEY(MaHangVe, MaChuyenBay)
)
 
--Bang KHACHHANG
CREATE TABLE KHACHHANG
(
   CMND varchar(10) NOT NULL,
   DienThoai varchar(10) NOT NULL,
   TenKH varchar(100) NOT NULL,
   CONSTRAINT PK_KHACHHANG PRIMARY KEY(CMND),
)
GO
 
--Bang VITRIGHE
--CREATE TABLE VITRIGHE
--(
--   MaGhe varchar(50) NOT NULL,
--   TinhTrang BIT NOT NULL, --1: trống, 0: hết
--    CONSTRAINT PK_VITRIGHE PRIMARY KEY(MaGhe),
--)
 
--Bang PHIEUDATCHO
CREATE TABLE PHIEUDATCHO
(
   MaPhieuDat varchar(50) NOT NULL,
   MaHangVe varchar(50) NOT NULL, --NGOAI
   CMND varchar(10) NOT NULL, --NGOAI
   MaChuyenBay varchar(50) NOT NULL, --NGOAI
   GiaTien money NOT NULL,
   NgayDat date NOT NULL,
   CONSTRAINT PK_PHIEUDATCHO PRIMARY KEY(MaPhieuDat),
)
 
--Bang THAMSO
CREATE TABLE THAMSO
(
   ThoiGianBayToiThieu int NOT NULL,
   SoSanBayTrungGianToiDa int NOT NULL,
   ThoiGianDungToiThieu int NOT NULL,
   ThoiGianDungToiDa int NOT NULL,
   SLHangVeToiDa int NOT NULL,
   TGChamNhatDatVe int NOT NULL,
   TGChamNhatHuyDatVe int NOT NULL,
)
 
---------------------- TẠO PROCEDURE ---------------------
CREATE PROC USP_Login
@UserName NVARCHAR(100), @PassWord NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.ACCOUNT WHERE UserName = @UserName AND Password= @PassWord
END
GO
 
-----------ràng buộc bảng CHUYENBAY
--khoá ngoại
ALTER TABLE CHUYENBAY ADD CONSTRAINT fk01_CB FOREIGN KEY(SanBayDi) REFERENCES SANBAY(MaSanBay)
ALTER TABLE CHUYENBAY ADD CONSTRAINT fk02_CB FOREIGN KEY(SanBayDen) REFERENCES SANBAY(MaSanBay)
--GiaVe
 
-----------ràng buộc bảng DOANHTHUCHUYENBAY
--khoá ngoại
ALTER TABLE DOANHTHUCHUYENBAY ADD CONSTRAINT fk01_DTCB FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE DOANHTHUCHUYENBAY ADD CONSTRAINT fk02_DTCB FOREIGN KEY(NgayKhoiHanh) REFERENCES CHUYENBAY(NgayKhoiHanh)
 
-----------ràng buộc bảng CT_CHUYENBAY
--khoá ngoại
ALTER TABLE CT_CHUYENBAY ADD CONSTRAINT fk01_CTCB FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE CT_CHUYENBAY ADD CONSTRAINT fk02_CTCB FOREIGN KEY(SanBayTrungGian) REFERENCES SANBAY(MaSanBay)
 
-----------ràng buộc bảng SANBAY
--khoá ngoại
 
-----------ràng buộc bảng VECHUYENBAY
--khoá ngoại
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk01_VCB FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk02_VCB FOREIGN KEY(CMND) REFERENCES KHACHHANG(CMND)
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk03_VCB FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe)
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk04_VCB FOREIGN KEY(MaGhe) REFERENCES VITRIGHE(MaGhe)
 
-----------ràng buộc bảng HANGVE
--khoá ngoại
ALTER TABLE HANGVE ADD CONSTRAINT fk01_HV FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
 
-----------ràng buộc bảng KHACHHANG
 
 
-----------ràng buộc bảng PHIEUDATCHO
--khoá ngoại
ALTER TABLE PHIEUDATCHO ADD CONSTRAINT fk01_PDC FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE PHIEUDATCHO ADD CONSTRAINT fk02_PDC FOREIGN KEY(CMND) REFERENCES KHACHHANG(CMND)
ALTER TABLE PHIEUDATCHO ADD CONSTRAINT fk03_PDC FOREIGN KEY(MaHangVe) REFERENCES HANGVE(MaHangVe)
 
-----------ràng buộc bảng THAMSO
 
 
set dateformat dmy
 
 
--DU LIEU
INSERT INTO dbo.ACCOUNT
			(	UserName,
				DisplayName,
				Password,
				Type
			)
VALUES		(	N'admin',
				N'Quản trị viên',
				N'1',
				1 
			)

INSERT INTO dbo.ACCOUNT
			(	UserName,
				DisplayName,
				Password,
				Type
			)
VALUES		(	N'Dang',
				N'Nhân viên Đăng',
				N'1',
				0
			)

