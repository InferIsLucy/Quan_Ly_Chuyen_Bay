CREATE database QLYBANVECHUYENBAY
GO

---use master
---go


Use QLYBANVECHUYENBAY
GO

---DROP database QLYBANVECHUYENBAY
---GO


--Bang Taikhoan
CREATE TABLE ACCOUNT
(
	MaTK INT IDENTITY PRIMARY KEY NOT NULL, 
	DisplayName NVARCHAR(100) NOT NULL,
	UserName NVARCHAR(100) NOT NULL,
	Password NVARCHAR(1000) NOT NULL,
	Type INT NOT NULL -----1 là admin, 0 là nhân viên
)
GO

--Bang CHUYENBAY
CREATE TABLE CHUYENBAY 
(
   MaChuyenBay INT IDENTITY PRIMARY KEY NOT NULL,
   GiaVe money NOT NULL,
   SanBayDi INT NOT NULL, --khoangoai
   SanBayDen INT NOT NULL, --khoangoai
   NgayKhoiHanh smalldatetime NOT NULL, 
   GioKhoiHanh datetime NOT NULL,
   ThoiGianBay int NOT NULL,
)
 
--Bang DOANHTHUCHUYENBAY
CREATE TABLE DOANHTHUCHUYENBAY
(
   MaChuyenBay INT NOT NULL, --ngoai
   NgayKhoiHanh smalldatetime NOT NULL, --ngoai
   SoVe INT DEFAULT 0 NOT NULL, --- MẶC ĐỊNH LÀ KHÔNG CÓ VÉ NÀO
   DoanhThu FLOAT DEFAULT 0 NOT NULL,
   TyLe FLOAT DEFAULT 0 NOT NULL,
   CONSTRAINT PK_DOANHTHUCHUYENBAY PRIMARY KEY(MaChuyenBay, NgayKhoiHanh)
)

---DROP TABLE DBO.DOANHTHUCHUYENBAY
 
--Bang CHITIETCHUYENBAY
CREATE TABLE CT_CHUYENBAY 
(
   MaCTChuyenBay INT IDENTITY PRIMARY KEY NOT NULL,
   MaChuyenBay INT NOT NULL, --khoangoai
   SanBayTrungGian INT NOT NULL, --khoangoai
   ThoiGianDung FLOAT DEFAULT 0 NOT NULL, ----TÍNH BẰNG PHÚT
   GhiChu NVARCHAR(200),
)
 
--Bang SANBAY
CREATE TABLE SANBAY 
(
   MaSanBay INT IDENTITY PRIMARY KEY NOT NULL,
   TenSanBay varchar(100) NOT NULL,
)
 
--Bang VECHUYENBAY
CREATE TABLE VECHUYENBAY 
(
   MaChuyenBay INT IDENTITY NOT NULL, --chinh, NGOAI
   CMND varchar(10) NOT NULL, -- chinh, NGOAI
   HanhKhach varchar(100) NOT NULL,
   DienThoai varchar(10) NOT NULL,
   MaHangVe varchar(50) NOT NULL, --khoangoai
   GiaTien money NOT NULL,
   MaGhe INT NOT NULL, --ngoai
   NgayThanhToan SMALLDATETIME NOT NULL,
   CONSTRAINT PK_VECHUYENBAY PRIMARY KEY(MaChuyenBay, CMND)
)

---DROP TABLE dbo.VECHUYENBAY

--Bang HANGVE
CREATE TABLE HANGVE
(
   MaHangVe INT IDENTITY NOT NULL,
   MaChuyenBay INT NOT NULL, --NGOAI
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
 
----Bang VITRIGHE
CREATE TABLE VITRIGHE
(
   MaGhe INT IDENTITY PRIMARY KEY NOT NULL,
   TinhTrang INT DEFAULT 0 NOT NULL, ---A 0: GHẾ TRỐNG, 1: GHẾ CÓ NGƯỜI (ĐÃ THANH TOÁN)
)
GO
 
--Bang PHIEUDATCHO
CREATE TABLE PHIEUDATCHO
(
   MaPhieuDat INT IDENTITY PRIMARY KEY NOT NULL,
   MaHangVe INT NOT NULL, --NGOAI
   CMND varchar(10) NOT NULL, --NGOAI
   MaChuyenBay INT NOT NULL, --NGOAI
   TrangThai INT DEFAULT 0 NOT NULL, --- 0: CHƯA THANH TOÁN, 1: ĐÃ THANH TOÁN
   GiaTien money NOT NULL,
   NgayDat date NOT NULL,
)

---DROP TABLE PHIEUDATCHO
 
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
GO
 








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
CREATE PROC USP_GetListCustomInForByName
@name varchar(100)
AS
BEGIN
	SELECT * 
	FROM dbo.KHACHHANG 
	WHERE TenKH like @name
END
GO

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











-----------ràng buộc bảng CHUYENBAY--------------------------
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
 
 









-----------------------DU LIEU----------------------------
--THÊM TÀI KHOẢN
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
---SELECT * FROM dbo.ACCOUNT
---THÊM DOANH THU CHUYẾN BAY
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

---SELECT * FROM dbo.DOANHTHUCHUYENBAY
---- INSERT KHACHHANG
INSERT INTO dbo.KHACHHANG			(	CMND,
										DienThoai, --ngoai
										TenKH
									)
VALUES								(
										'0123456789',
										'0123456789',
										'Bui Hai Dang'
									)

INSERT INTO dbo.KHACHHANG			(	CMND,
										DienThoai, --ngoai
										TenKH
									)
VALUES								(
										'1010101010',
										'1010101010',
										'Bui Hai Dang'
									)

INSERT INTO dbo.KHACHHANG			(	CMND,
										DienThoai, --ngoai
										TenKH
									)
VALUES								(
										'1111111111',
										'1111111111',
										'Nguyen Ngoc Han'
									)

INSERT INTO dbo.KHACHHANG			(	CMND,
										DienThoai, --ngoai
										TenKH
									)
VALUES								(
										'9876543210',
										'9876543210',
										'Nguyen Hoang Long'
									)

INSERT INTO dbo.KHACHHANG			(	CMND,
										DienThoai, --ngoai
										TenKH
									)
VALUES								(
										'2222222222',
										'2222222222',
										'Nguyen Thi Tra Giang'
									)
---SELECT * FROM dbo.KHACHHANG

---- INSERT PHIEUDATCHO
INSERT INTO dbo.PHIEUDATCHO			(
										MaHangVe,
										CMND, 
										MaChuyenBay, 
										TrangThai,
										GiaTien,
										NgayDat
									)
VALUES								(
										1,
										'9876543210',
										1,
										0,
										3000,
										'20220530'
									)

INSERT INTO dbo.PHIEUDATCHO			(
										MaHangVe,
										CMND, 
										MaChuyenBay, 
										TrangThai,
										GiaTien,
										NgayDat
									)
VALUES								(
										2,
										'2222222222',
										2,
										0,
										4000,
										'20220531'
									)

---DELETE FROM dbo.PHIEUDATCHO WHERE condition


INSERT INTO dbo.PHIEUDATCHO			(
										MaHangVe,
										CMND, 
										MaChuyenBay, 
										TrangThai,
										GiaTien,
										NgayDat
									)
VALUES								(
										1,
										'0123456789',
										1,
										1,
										3000,
										'20220530'
									)

INSERT INTO dbo.PHIEUDATCHO			(
										MaHangVe,
										CMND, 
										MaChuyenBay, 
										TrangThai,
										GiaTien,
										NgayDat
									)
VALUES								(
										2,
										'1111111111',
										2,
										1,
										4000,
										'20220530'
									)

INSERT INTO dbo.PHIEUDATCHO			(
										MaHangVe,
										CMND, 
										MaChuyenBay, 
										TrangThai,
										GiaTien,
										NgayDat
									)
VALUES								(
										1,
										'1010101010',
										1,
										1,
										3000,
										'20220529'
									)

GO
----select * from dbo.PHIEUDATCHO


select * from dbo.ACCOUNT