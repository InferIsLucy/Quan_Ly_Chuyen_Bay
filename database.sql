CREATE database QLYBANVECHUYENBAY
GO
--use master
--go
Use QLYBANVECHUYENBAY
GO

DROP database QLYBANVECHUYENBAY
GO

--Restore database QLBANVECHUYENBAY from disk = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLYBANVECHUYENBAY.mdf'

--Bang Taikhoan
CREATE TABLE ACCOUNT
(
 MaTK INT IDENTITY PRIMARY KEY NOT NULL,
 DisplayName NVARCHAR(100) NOT NULL,
 UserName NVARCHAR(100) UNIQUE NOT NULL,
 Password NVARCHAR(1000) DEFAULT 0 NOT NULL,
 Type INT DEFAULT 0 NOT NULL -----1 là admin, 0 là nhân viên (chỉ có có nhân viênn quản lý thôi)
)
GO
--Bang CHUYENBAY
CREATE TABLE CHUYENBAY
(
 MaChuyenBay INT IDENTITY(1,1),
 GiaVe money NOT NULL,
 MaSanBayDi varchar(5) NOT NULL, --khoangoai
 MaSanBayDen varchar(5) NOT NULL, --khoangoai
 NgayGioKhoiHanh smalldatetime,
 ThoiGianBay int NOT NULL,
 CONSTRAINT PK_CB PRIMARY KEY (MaChuyenBay)
)
--DROP TABLE CHUYENBAY
 
--Bang DOANHTHUCHUYENBAY
CREATE TABLE DOANHTHUCHUYENBAY
(
 MaDoanhThuCB INT IDENTITY(1,1),
 MaChuyenBay INT NOT NULL, --ngoai
 NgayKhoiHanh smalldatetime NOT NULL, -- NgayKhoiHanh = NgayGioKhoiHanh FROM CHUYENBAY
 SoVe INT DEFAULT 0 NOT NULL, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
 DoanhThu INT DEFAULT 0 NOT NULL,
 TyLe FLOAT DEFAULT 0 NOT NULL,
 CONSTRAINT PK_DOANHTHUCHUYENBAY PRIMARY KEY(MaDoanhThuCB)
)
--DROP TABLE DOANHTHUCHUYENBAY
 
--Bang SANBAY
CREATE TABLE SANBAY
(
 MaSanBay varchar(5) PRIMARY KEY NOT NULL,
 TenSanBay varchar(100) UNIQUE NOT NULL,
)
--DROP TABLE SANBAY
 
                                     --MỚI SỬA BẢNG CT_CHUYENBAY THÀNH BẢNG SANBAYTRUNGGIAN NHA--
--Bang SANBAYTRUNGGIAN
CREATE TABLE SANBAYTRUNGGIAN
(
 MaChuyenBay INT NOT NULL, --khoangoai
 MaSanBay varchar(5) NOT NULL, --khoangoai
 TenSanBay nvarchar(100) NOT NULL,
 MaSanBayTruoc varchar(5) NOT NULL, --khoangoai
 MaSanBaySau varchar(5) NOT NULL, --khoangoai
 ThoiGianDung INT DEFAULT 0 NOT NULL,
 GhiChu NVARCHAR(200),
 CONSTRAINT PK_SANBAYTRUNGGIAN PRIMARY KEY(MaChuyenBay, MaSanBay)
)
 
 
--DROP TABLE SANBAYTRUNGGIAN
 
--INSERT INTO SANBAYTRUNGGIAN VALUES ('1', 'HAN', 'San bay quoc te Noi Bai', 'HPH', 'LOL', '30', '')
 
--SELECT * FROM SANBAYTRUNGGIAN
 
 
--Bang VECHUYENBAY
CREATE TABLE VECHUYENBAY
(
 MaVeChuyenBay INT IDENTITY NOT NULL,
 MaChuyenBay INT NOT NULL, --NGOAI
 MaSanBayTrungGian varchar(5),
 CMND varchar(10) NOT NULL, --NGOAI
 HanhKhach nvarchar(100) NOT NULL,
 DienThoai varchar(10) NOT NULL,
 MaHangVe INT NOT NULL, --khoangoai
 GiaTien money NOT NULL,
 MaGhe INT NOT NULL, --ngoai
 NgayThanhToan SMALLDATETIME NOT NULL,
 CONSTRAINT PK_VECHUYENBAY PRIMARY KEY(MaVeChuyenBay)
)
--DROP TABLE VECHUYENBAY

CREATE TABLE SOLUONGGHE
(
 MaHangVe INT IDENTITY NOT NULL,
 TenHangVe NVARCHAR(100) NOT NULL,
 PhanTramDonGia FLOAT NOT NULL,
 SoLuongGhe INT NOT NULL
 CONSTRAINT PK_SOLUONGGHE PRIMARY KEY(MaHangVe)
)

--Bang HANGVE
CREATE TABLE HANGVE
(
 MaHangVe INT NOT NULL,
 MaChuyenBay INT NOT NULL, --NGOAI
 TenHangVe  nvarchar(100) NOT NULL,
 PhanTramDonGia float NOT NULL,
 SoLuongGhe int NOT NULL,
 SLGheDat int NOT NULL,
 SLGheTrong int NOT NULL,
 CONSTRAINT PK_HANGVE PRIMARY KEY(MaHangVe, MaChuyenBay)
)
--DROP TABLE HANGVE

--Bang KHACHHANG
CREATE TABLE KHACHHANG
(
 CMND varchar(10) NOT NULL,
 DienThoai varchar(10) NOT NULL,
 TenKH nvarchar(100) NOT NULL,
 CONSTRAINT PK_KHACHHANG PRIMARY KEY(CMND),
)
GO
 
----Bang VITRIGHE
CREATE TABLE VITRIGHE
(
 MaGhe INT IDENTITY PRIMARY KEY NOT NULL,
 MaHangVe INT NOT NULL, --NGOAI-------------------------
 MaChuyenBay INT NOT NULL,
 TinhTrang INT DEFAULT 0 NOT NULL,
)
GO
 
--DROP TABLE VITRIGHE

--Bang PHIEUDATCHO
CREATE TABLE PHIEUDATCHO
(
 MaPhieuDat INT IDENTITY PRIMARY KEY NOT NULL,
 MaHangVe INT NOT NULL, --NGOAI
 MaGhe INT, --NGOAI
 CMND varchar(10) NOT NULL, --NGOAI
 MaChuyenBay INT NOT NULL, --NGOAI
 GiaTien money NOT NULL,
 NgayDat smalldatetime NOT NULL,
 NgayHetHanTT smalldatetime NULL,
 TrangThai int DEFAULT 0 NOT NULL,
)
 
--DROP TABLE PHIEUDATCHO
 
--insert INTO PHIEUDATCHO VALUES ('2', '2', '245411311', '1', 700000, '20/05/2022 05:00:00', '0')
 --DROP TABLE SOLUONGGHE
 
--Bang THAMSO
CREATE TABLE THAMSO
(
 SLSanBay int DEFAULT 0 NOT NULL,
 ThoiGianBayToiThieu int DEFAULT 0 NOT NULL,
 SoSanBayTrungGianToiDa int DEFAULT 0 NOT NULL,
 ThoiGianDungToiThieu int DEFAULT 0 NOT NULL,
 ThoiGianDungToiDa int DEFAULT 0 NOT NULL,
 SLHangVeToiDa int DEFAULT 0 NOT NULL,
 TGChamNhatDatVe int DEFAULT 0 NOT NULL,
 ThoiHanThanhToan int DEFAULT 0,
 TGChamNhatHuyDatVe int DEFAULT 0 NOT NULL,
)
GO
UPDATE dbo.THAMSO SET ThoiGianBayToiThieu = 100

--DROP TABLE THAMSO


















 
-----------ràng buộc bảng CHUYENBAY
--khoá ngoại
ALTER TABLE CHUYENBAY ADD CONSTRAINT fk01_CB FOREIGN KEY(MaSanBayDi) REFERENCES SANBAY(MaSanBay)
--ALTER TABLE CHUYENBAY DROP CONSTRAINT fk01_CB;

ALTER TABLE CHUYENBAY ADD CONSTRAINT fk02_CB FOREIGN KEY(MaSanBayDen) REFERENCES SANBAY(MaSanBay)
--ALTER TABLE CHUYENBAY DROP CONSTRAINT fk02_CB;
--GiaVe
 
-----------ràng buộc bảng DOANHTHUCHUYENBAY
--khoá ngoại
ALTER TABLE DOANHTHUCHUYENBAY ADD CONSTRAINT fk01_DTCB FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
--ALTER TABLE DOANHTHUCHUYENBAY ADD CONSTRAINT fk02_DTCB FOREIGN KEY(NgayKhoiHanh) REFERENCES CHUYENBAY(NgayKhoiHanh)
 
-----------ràng buộc bảng SANBAYTRUNGGIAN
--khoá ngoại
ALTER TABLE SANBAYTRUNGGIAN ADD CONSTRAINT fk01_CTTG FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE SANBAYTRUNGGIAN ADD CONSTRAINT fk02_CTTG FOREIGN KEY(MaSanBay) REFERENCES SANBAY(MaSanBay)
ALTER TABLE SANBAYTRUNGGIAN ADD CONSTRAINT fk03_CTTG FOREIGN KEY(MaSanBayTruoc) REFERENCES SANBAY(MaSanBay)
ALTER TABLE SANBAYTRUNGGIAN ADD CONSTRAINT fk04_CTTG FOREIGN KEY(MaSanBaySau) REFERENCES SANBAY(MaSanBay)
-----------ràng buộc bảng SANBAY
--khoá ngoại
 
-----------ràng buộc bảng VECHUYENBAY
--khoá ngoại
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk01_VCB FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk02_VCB FOREIGN KEY(CMND) REFERENCES KHACHHANG(CMND)
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk03_VCB FOREIGN KEY(MaHangVe) REFERENCES SOLUONGGHE(MaHangVe)
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk04_VCB FOREIGN KEY(MaGhe) REFERENCES VITRIGHE(MaGhe)
ALTER TABLE VECHUYENBAY ADD CONSTRAINT fk05_VCB FOREIGN KEY(MaSanBayTrungGian) REFERENCES SANBAY(MaSanBay)

--ALTER TABLE VECHUYENBAY DROP CONSTRAINT fk01_VCB
--ALTER TABLE VECHUYENBAY DROP CONSTRAINT fk02_VCB
--ALTER TABLE VECHUYENBAY DROP CONSTRAINT fk03_VCB
--ALTER TABLE VECHUYENBAY DROP CONSTRAINT fk04_VCB

 
-----------ràng buộc bảng HANGVE
--khoá ngoại
ALTER TABLE HANGVE ADD CONSTRAINT fk01_HV FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE HANGVE ADD CONSTRAINT fk02_HV FOREIGN KEY(MaHangve) REFERENCES SOLUONGGHE(MaHangVe)
--ALTER TABLE HANGVE DROP CONSTRAINT fk01_HV

 
-----------ràng buộc bảng KHACHHANG
 
 
-----------ràng buộc bảng PHIEUDATCHO
--khoá ngoại
ALTER TABLE PHIEUDATCHO ADD CONSTRAINT fk01_PDC FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
ALTER TABLE PHIEUDATCHO ADD CONSTRAINT fk02_PDC FOREIGN KEY(CMND) REFERENCES KHACHHANG(CMND)
ALTER TABLE PHIEUDATCHO ADD CONSTRAINT fk03_PDC FOREIGN KEY(MaHangVe) REFERENCES SOLUONGGHE(MaHangVe)
ALTER TABLE PHIEUDATCHO ADD CONSTRAINT fk04_PDC FOREIGN KEY(MaGhe) REFERENCES VITRIGHE(MaGhe)

--ALTER TABLE PHIEUDATCHO DROP CONSTRAINT fk01_PDC
--
--ALTER TABLE PHIEUDATCHO DROP CONSTRAINT fk03_PDC
--ALTER TABLE PHIEUDATCHO DROP CONSTRAINT fk04_PDC
 
-----------ràng buộc bảng VITRIGHE
ALTER TABLE VITRIGHE ADD CONSTRAINT fk01_VTG FOREIGN KEY(MaHangve) REFERENCES SOLUONGGHE(MaHangVe)
ALTER TABLE VITRIGHE ADD CONSTRAINT fk02_VTG FOREIGN KEY(MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
--ALTER TABLE VITRIGHE DROP CONSTRAINT fk01_VTG

-----------ràng buộc bảng THAMSO
-----------ràng buộc bảng SOLUONGGHE

 
set dateformat dmy
 
 














-------------------DU LIEU
--Du lieu ACCOUNT
INSERT INTO dbo.ACCOUNT
     ( UserName,
       DisplayName,
       Password,
       Type
     )
VALUES    ( N'admin',
       N'Quản trị viên',
       N'1',
       1
     )
 
INSERT INTO dbo.ACCOUNT
     ( UserName,
       DisplayName,
       Password,
       Type
     )
VALUES    ( N'Dang',
       N'Nhân viên Đăng',
       N'1',
       0
     )
 
 
 
--SELECT * FROM dbo.ACCOUNT
--GO
 
 INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	1,
										'20150701',
										100,
										46000
									)

INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	2,
										'20150101',
										100,
										12000
									)

INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	3,
										'20220901',
										100,
										23000
									)

INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	4,
										'20220401',
										100,
										23000
									)

INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	5,
										'20220401',
										100,
										12000
									)

INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	6,
										'20220401',
										100,
										30000
									)

INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	7,
										'20160801',
										100,
										23000
									)

INSERT INTO dbo.DOANHTHUCHUYENBAY	(	MaChuyenBay,
										NgayKhoiHanh, --ngoai
										SoVe, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
										DoanhThu
									)
VALUES								(	8,
										'20160301',
										100,
										23000
									)

  
--Du lieu CHUYENBAY
select * from THAMSO
 
INSERT INTO CHUYENBAY (GiaVe, MaSanBayDi, MaSanBayDen, NgayGioKhoiHanh, ThoiGianBay) VALUES ('1000000', 'VCS', 'LOL', '25/09/2022 09:00:00', 45)
--delete from CHUYENBAY WHERE GIAVE = '1000000'
 
--select * from CHUYENBAY
 
--Du lieu DOANHTHUCHUYENBAY
--INSERT INTO DOANHTHUCHUYENBAY (MaChuyenBay, NgayKhoiHanh, SoVe, DoanhThu, TyLe) VALUES ()
 
--Du lieu SANBAY
 
INSERT INTO SANBAY VALUES ('VCS', 'San bay Con Dao')
INSERT INTO SANBAY VALUES ('VCA', 'San bay quoc te Can Tho')
INSERT INTO SANBAY VALUES ('DAD', 'San bay quoc te Da Nang')
INSERT INTO SANBAY VALUES ('HPH', 'San bay quoc te Cat Bi')
INSERT INTO SANBAY VALUES ('HAN', 'San bay quoc te Noi Bai')
INSERT INTO SANBAY VALUES ('SGN', 'San bay quoc te Tan Son Nhat')
INSERT INTO SANBAY VALUES ('CXR', 'San bay quoc te Cam Ranh')
INSERT INTO SANBAY VALUES ('LOL', 'San bay quoc te Dak Nong')
INSERT INTO SANBAY VALUES ('PQC', 'San bay quoc te Phu Quoc')
INSERT INTO SANBAY VALUES ('VII', 'San bay quoc te Vinh')
 
select * from SANBAY
delete from SANBAY
 
--Du lieu SANBAYTRUNGGIAN
--INSERT INTO SANBAYTRUNGGIAN (MaChuyenBay, MaSanBay, TenSanBay, MaSanBayTruoc, MaSanBaySau, ThoiGianDung, GhiChu) VALUES ()
 
INSERT INTO SANBAYTRUNGGIAN VALUES ('1', 'VCS', 'San bay Con Dao', 'HAN', 'HPH', '10', '')
INSERT INTO SANBAYTRUNGGIAN VALUES ('1', 'DAD', 'San bay quoc te Da Nang', 'HAN', 'HPH', '10', '')
INSERT INTO SANBAYTRUNGGIAN VALUES ('1', 'LOL', 'San bay quoc te Dak Nong', 'HAN', 'HPH', '30', '')
 
--SELECT * FROM SANBAYTRUNGGIAN
--DELETE FROM SANBAYTRUNGGIAN
 
--Du lieu VECHUYENBAY
--INSERT INTO VECHUYENBAY (MaVeChuyenBay, MaChuyenBay, CMND, HanhKhach, DienThoai, MaHangVe, GiaTien, MaGhe, NgayThanhToan) VALUES ()
 
INSERT INTO VECHUYENBAY VALUES ('1', '0000000000', 'HARI HAN', '0000000000', '2', 800000, '1', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('1', '1111111111', 'HARI HAN', '1111111111', '2', 900000, '2', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('1', '2222222222', 'HARI HAN', '2222222222', '2', 1000000, '3', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('2', '3333333333', 'HARI HAN', '3333333333', '1', 1100000, '7', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('2', '4444444444', 'HARI HAN', '4444444444', '1', 700000, '8', '25/09/2021')

 
INSERT INTO VECHUYENBAY VALUES ('2', '123456789', 'HARI NGOC', '0905226387', '1', 800000, '1', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('2', '123456789', 'HARI YANG', '0905226387', '2', 800000, '3', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('2', '123456789', 'HARI NGOC', '0905226387', '1', 800000, '2', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('3', '123456789', 'HARI NGOC', '0905226387', '2', 800000, '10', '25/09/2021')
INSERT INTO VECHUYENBAY VALUES ('2', '123456789', 'HARI NGOC', '0905226387', '1', 800000, '4', '25/09/2021')
SELECT * FROM VECHUYENBAY
 
SELECT * FROM HANGVE
--Du lieu HANGVE
INSERT INTO HANGVE (MaHangVe, MaChuyenBay, TenHangVe, PhanTramDonGia, SoLuongGhe, SLGheDat, SLGheTrong) VALUES ()
 
--INSERT INTO HANGVE  VALUES ('1', 'Ve hang 1', 1.05, 50, 0, 50)
--INSERT INTO HANGVE VALUES ('1', 'Ve hang 2', 1, 50, 0, 50)
 
--INSERT INTO HANGVE VALUES ('2', 'Ve hang 1', 1.05, 30, 0, 30)
--INSERT INTO HANGVE VALUES ('2', 'Ve hang 2', 1, 30, 0, 30)

INSERT INTO SOLUONGGHE (TenHangVe, PhanTramDonGia, SoLuongGhe) VALUES ('Ve hang 1', 1.5, 50)
INSERT INTO SOLUONGGHE (TenHangVe, PhanTramDonGia, SoLuongGhe) VALUES ('Ve hang 2', 1.2, 100)
INSERT INTO SOLUONGGHE (TenHangVe, PhanTramDonGia, SoLuongGhe) VALUES ('Ve hang 3', 1, 50)
SELECT * FROM THAMSO
--Du lieu KHACHHANG
--INSERT INTO KHACHHANG (CMND, DienThoai, TenKH) VALUES ()
 
----Du lieu VITRIGHE
--INSERT INTO VITRIGHE (MaGhe, TinhTrang) VALUES ()
--SELECT * FROM VITRIGHE
--INSERT INTO VITRIGHE VALUES ('1')
--INSERT INTO VITRIGHE VALUES ('1')
--INSERT INTO VITRIGHE VALUES ('0')
--INSERT INTO VITRIGHE VALUES ('0')
 
--Du lieu PHIEUDATCHO
INSERT INTO PHIEUDATCHO (MaPhieuDat, MaHangVe, MaGhe, CMND, MaChuyenBay, GiaTien, NgayDat, TrangThai) 
VALUES ('2', '3' ,'245422311', '1', 500000, '25/09/2022', '')
 
--Du lieu THAMSO
INSERT INTO THAMSO (SLSanBay, ThoiGianBayToiThieu, SoSanBayTrungGianToiDa, ThoiGianDungToiThieu, ThoiGianDungToiDa,
SLHangVeToiDa, TGChamNhatDatVe, TGChamNhatHuyDatVe)
VALUES ('10', '30', '2', '10', '20', '50', '24', '1') --sua TGChanNhatDatVe = 24h/60h
GO
 

 select * from ACCOUNT
 



















 ---------------------- TẠO PROCEDURE ---------------------
---PROC TRUY XUẤT TÀI KHOẢN NGƯỜI DÙNG---
CREATE PROC USP_Login
@UserName NVARCHAR(100), @PassWord NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.ACCOUNT WHERE UserName = @UserName AND Password= @PassWord
END
GO
---drop proc [USP_Login]

---PROC TRUY SUÂT HÓA ĐƠN BỞI NĂM---
CREATE PROC USP_GetListBillByYear
@year INT
AS
BEGIN
SELECT MONTH(NgayKhoiHanh) AS 'THANG', COUNT(MaChuyenBay) AS 'SỐ CHUYẾN BAY', SUM(DoanhThu) AS 'DOANH THU'
FROM dbo.DOANHTHUCHUYENBAY
WHERE YEAR(NgayKhoiHanh) = @year 
GROUP BY MONTH(NgayKhoiHanh)
END
GO
---drop proc [USP_GetListBillByYear]

---DROP PROCEDURE [USP_GetListBillByYear]---XÓA MỘT PROCEDURE

---PROC TÍNH TỔNG TIỀN THEO NĂM
CREATE PROC USP_GetAmountMoneyByYear
@year INT
AS
BEGIN
SELECT SUM(DoanhThu)
FROM dbo.DOANHTHUCHUYENBAY
WHERE YEAR(NgayKhoiHanh) = @year 
END
GO
---drop proc [USP_GetAmountMoneyByYear]

---PROC THỐNG KÊ DOANH THU THEO THÁNG---
CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT MaChuyenBay AS [Mã chuyến bay], SoVe AS [Số vé], DoanhThu AS [Doanh thu]
	FROM dbo.DOANHTHUCHUYENBAY
	WHERE NgayKhoiHanh >= @checkIn AND NgayKhoiHanh <= @checkOut
END
GO
-----drop proc [USP_GetListBillByDate]

---PROC TÍNH TỔNG TIỀN THEO THÁNG---
CREATE PROC USP_GetAmountMoneyByMonth
@checkIn date, @checkOut date
AS
BEGIN
	SELECT SUM(DoanhThu)
	FROM dbo.DOANHTHUCHUYENBAY
	WHERE NgayKhoiHanh >= @checkIn AND NgayKhoiHanh <= @checkOut
END
GO
---drop proc [USP_GetAmountMoneyByMonth]

---PROC HIỆN CHART BẰNG NĂM NHẬP VÀO----
CREATE PROC USP_ChartByYear
@year int
AS
BEGIN
	WITH BIEUDO AS (	SELECT MONTH(NgayKhoiHanh) AS 'THANG', SUM(DoanhThu) AS 'DOANHTHU'
						FROM dbo.DOANHTHUCHUYENBAY
						WHERE YEAR(NgayKhoiHanh) = @year
						GROUP BY MONTH(NgayKhoiHanh)
					)
	SELECT THANG, DOANHTHU
	FROM BIEUDO
END
GO
--DROP PROC [USP_ChartByYear]

---PROC LẤY TÊN KHÁCH HÀNG---
--CREATE PROC USP_GetListCustomInForByName
--@name varchar(100)
--AS
--BEGIN
--	SELECT * 
--	FROM dbo.KHACHHANG 
--	WHERE TenKH like @name
--END
--GO

--DROP PROC USP_GetListCustomInForByName
CREATE PROC USP_GetStatusByCMND
@id varchar(10)
AS
BEGIN
	SELECT TrangThai
	FROM dbo.PHIEUDATCHO
	WHERE CMND = @id
END
GO

--DROP PROC USP_GetStatusByCMND
---PROC CHỈNH SỬA TÀI KHOẢN ----
CREATE PROC USP_UpdateAccount 
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(1000), @newPassword NVARCHAR(1000)
AS
BEGIN
	DECLARE  @isRightPass INT = 0

	SELECT @isRightPass = COUNT(*) FROM dbo.ACCOUNT WHERE UserName = @userName AND Password = @password
	IF(@isRightPass = 1)
	BEGIN
		IF(@newPassword = null OR @newPassword = '')
		BEGIN
			UPDATE dbo.ACCOUNT SET DisplayName = @displayName WHERE UserName = @userName
		END
		ELSE
			UPDATE  dbo.ACCOUNT SET Password = @newPassword, DisplayName = @displayName WHERE UserName = @userName
		END
END
GO

















-------------------QUY DINH
---------Quy định 1: Có 10 sân bay. Thời gian bay tối thiểu là 30 phút. Có tói đa
---2 sân bay trung gian với thời gian dừng từ 10 đến 20 phút
 
-- CÓ 10 SÂN BAY
CREATE TRIGGER SLSANBAY_MAX
ON SANBAY
AFTER INSERT, UPDATE
AS
BEGIN
   DECLARE @SANBAY INT = (SELECT COUNT(MaSanBay) FROM SANBAY)
   DECLARE @MaxSanBay INT = (SELECT SLSanBay FROM THAMSO)
 
   IF (@SANBAY > @MaxSanBay OR @SANBAY <= 0)
   BEGIN
       PRINT 'SO LUONG SAN BAY KHONG HOP LE. YEU CAU NHAP LAI.'
       ROLLBACK TRANSACTION
   END
END
GO 


-- THỜI GIAN BAY TỐI THIỂU LÀ 30 PHÚT
CREATE TRIGGER THOIGIANBAY_MIN
ON CHUYENBAY
FOR INSERT, UPDATE
   AS
       BEGIN
             DECLARE @ThoiGianBay INT = (SELECT ThoiGianBay FROM INSERTED)
             DECLARE @MinThoiGianBay INT = (SELECT ThoiGianBayToiThieu FROM THAMSO)
           IF (@ThoiGianBay < @MinThoiGianBay)
              BEGIN
                   PRINT 'THOI GIAN BAY TOI THIEU LA 30 PHUT'
                   ROLLBACK TRANSACTION
       END
END
GO 


-- CÓ TỐI ĐA 2 SÂN BAY TRUNG GIAN ĐỐI VỚI MỖI CHUYẾN BAY.
CREATE TRIGGER SanBayTrungGian_MAX ON SANBAYTRUNGGIAN                        -----------------------------------------------------SỬA ĐUEEEEEEEEEE
  FOR INSERT, UPDATE
  AS
      BEGIN
	        DECLARE @MaChuyenBay INT
			SELECT @MaChuyenBay = MaChuyenBay
            DECLARE @SoSBTG INT
            SELECT @SoSBTG = COUNT(MaSanBay) FROM SANBAYTRUNGGIAN WHERE MaChuyenBay = @MaChuyenBay
            DECLARE @MaxSanBayTrungGian INT
            SELECT @MaxSanBayTrungGian = SoSanBayTrungGianToiDa FROM THAMSO
          IF (@SoSBTG > @MaxSanBayTrungGian)
             BEGIN
                 ROLLBACK TRANSACTION
              END
      END
GO

-- THỜI GIAN DỪNG TỪ 10 ĐẾN 20 PHÚT
SELECT*FROM SANBAYTRUNGGIAN
GO

CREATE TRIGGER THOIGIANDUNG_KHOANG ON SANBAYTRUNGGIAN
FOR INSERT, UPDATE
AS
BEGIN
  DECLARE @TIME1 INT =(SELECT ThoiGianDungToiThieu FROM THAMSO)
  DECLARE @TIME2 INT = (SELECT ThoiGianDungToiDa FROM THAMSO)
  DECLARE @TIMED INT = (SELECT ThoiGianDung FROM INSERTED)
  IF (@TIMED < @TIME1 OR @TIMED > @TIME2)
     BEGIN
        ROLLBACK TRANSACTION
     END
END
GO

 
---------Quy định 2: Chỉ bán khi còn chỗ. Có hạng vé (1,2). Vé hạng 1 bằng 105% của
--đơn giá, vé hạng 2 bằng giá đơn giá, mỗi chuyến bay có một giá vé riêng.
 
--  CHỈ BÁN VÉ KHI CÒN CHỖ
CREATE TRIGGER QD_BanVe ON VECHUYENBAY
   FOR INSERT, UPDATE
 AS
     BEGIN
         DECLARE @MaChuyenBay INT, @MaHangVe INT, @MaGhe INT, @TinhTrang INT
       SELECT @MaHangVe=MaHangVe, @MaGhe=MaGhe, @MaChuyenBay = MaChuyenBay
       FROM INSERTED
       SELECT @TinhTrang=TinhTrang
       FROM VITRIGHE WHERE MaGhe=@MaGhe
 
       IF (@TinhTrang>0)
       BEGIN
           ROLLBACK TRANSACTION
       END
 
       ELSE --Đặt vé thành công thì TinhTrang ở VITRIGHE = 1
       BEGIN
           UPDATE VITRIGHE
         SET TinhTrang = 1
         FROM VITRIGHE
         JOIN inserted ON VITRIGHE.MaGhe = inserted.MaGhe
       END
     END
GO

DROP TRIGGER QD_BanVe
GO
 
--Cập nhật lại số lượng ghế ĐÃ BÁN ở table HANGVE
--Thêm vé bán
CREATE TRIGGER CapNhat_BanVe ON VECHUYENBAY --hoặc VITRIGHE
AFTER INSERT
AS
BEGIN
   UPDATE HANGVE
 SET SLGheDat = SLGheDat + 1
 FROM HANGVE
 JOIN inserted ON HANGVE.MaChuyenBay = inserted.MaChuyenBay AND
      HANGVE.MaHangVe = inserted.MaHangVe
   UPDATE HANGVE
 SET SLGheTrong = SLGheTrong - 1
 FROM HANGVE
 JOIN inserted ON HANGVE.MaChuyenBay = inserted.MaChuyenBay AND
      HANGVE.MaHangVe = inserted.MaHangVe
END
GO
 
--DROP TRIGGER CapNhat_BanVe
--GO
 
 
 
--Cập nhật đặt vé
CREATE TRIGGER CapNhat_DatVe ON PHIEUDATCHO --hoặc VITRIGHE
AFTER INSERT
AS
BEGIN
   UPDATE HANGVE
 SET SLGheDat = SLGheDat + 1
 FROM HANGVE
 JOIN inserted ON HANGVE.MaChuyenBay = inserted.MaChuyenBay AND
      HANGVE.MaHangVe = inserted.MaHangVe
END
GO
 
DROP TRIGGER CapNhat_DatVe
GO
--Hủy vé
/*
CREATE TRIGGER CapNhat_HuyVe ON VECHUYENBAY --or VITRIGHE
FOR DELETE
AS
BEGIN
   UPDATE HANGVE
   SET SLGheDat = SLGheDat - 1
   FROM HANGVE
   JOIN inserted ON HANGVE.MaChuyenBay = inserted.MaChuyenBay AND
      HANGVE.MaHangVe = inserted.MaHangVe
 
 UPDATE VITRIGHE
 SET TinhTrang = 0
 FROM VITRIGHE
 JOIN inserted ON VITRIGHE.MaGhe = inserted.MaGhe
END
GO
 
DROP TRIGGER CapNhat_HuyVe
GO
*/
 
 
 
-- VÉ HẠNG 1 BẰNG 105% ĐƠN GIÁ, HẠNG 2 BẰNG GIÁ ĐƠN GIÁ
 
 
 
---------Quy định 3: Chỉ cho đặt vé chậm nhất 1 ngày trước khi khởi hành. Vào ngày khởi hành tất cả các phiếu đặt sẽ bị huỷ.
--chỉ cho đặt vé chậm nhất 1 ngày trước khi khởi hành
CREATE TRIGGER QD_DatVe ON PHIEUDATCHO
FOR INSERT, UPDATE
AS
BEGIN
   DECLARE @Time INT
 DECLARE @TGChamNhatDatVe INT
 DECLARE @NgatDat smalldatetime
 DECLARE @NgayGioKhoiHanh SMALLDATETIME
 DECLARE @MaChuyenBay INT
 
 SELECT @MaChuyenBay = MaChuyenBay FROM inserted
 SELECT @NgatDat = NgayDat FROM inserted
 SELECT @NgayGioKhoiHanh = NgayGioKhoiHanh FROM CHUYENBAY
        WHERE MaChuyenBay = @MaChuyenBay
 SELECT @TGChamNhatDatVe = TGChamNhatDatVe FROM THAMSO
 
 SELECT @Time = DATEDIFF(HOUR, @NgatDat, @NgayGioKhoiHanh)
 IF (@Time < @TGChamNhatDatVe)
 BEGIN
     RETURN FALSE;
 END
 ELSE
 BEGIN
     UPDATE VITRIGHE
   SET TinhTrang = 1
   FROM VITRIGHE
   JOIN inserted ON VITRIGHE.MaGhe = inserted.MaGhe
 END
 
END
GO
--Vào ngày khởi hành tất cả các phiếu đặt sẽ bị huỷ.



 
 
 
 
 
---------Quy định 6: người dùng có thể thay đổi các quy định
--QĐ1: Thay đổi số lượng sân bay, thời gian bay tối thiểu, số sân bay trung gian tối đa, thời gian dừng tối thiểu, tối đa tại các sân bay trung gian.
--TRÊN QĐ1
  
 
--QĐ2:thay đổi số lượng các hạng vé
CREATE TRIGGER SoLuongHangVe_MAX ON HANGVE
FOR INSERT, UPDATE
AS
BEGIN
   DECLARE @SLHangVe INT
 SELECT @SLHangVe = COUNT(MaHangVe) FROM HANGVE
 DECLARE @SLHangVeToiDa INT
 SELECT @SLHangVeToiDa = SLHangVeToiDa FROM THAMSO
 IF (@SLHangVe > @SLHangVeToiDa)
    ROLLBACK TRANSACTION
END
GO
 
DROP TRIGGER SoLuongHangVe_MAX
GO
 
--QĐ3: Thay đổi thời gian chậm nhất khi đặt vé, thời gian hủy đặt vé.
--TRÊN QĐ3 - thời gian chậm nhất khi đặt vé
-- Huỷ đặt vé --KHÔNG CHƠI
 
-----------------
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

GO

SELECT TenHangVe FROM SOLUONGGHE
DELETE FROM SOLUONGGHE WHERE TenHangVe = 'Ve hang 2'

