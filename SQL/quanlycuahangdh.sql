CREATE DATABASE QUANLYCUAHANGDH
GO 

USE QUANLYCUAHANGDH
GO 

CREATE TABLE KHACHHANG(
	MAKH INT IDENTITY NOT NULL,
	TENKH NVARCHAR(200) NOT NULL,
	NGSINH DATE NOT NULL,
	DIACHI NVARCHAR(200) NOT NULL,
	SDT VARCHAR(10) NOT NULL
)
GO 

CREATE TABLE NHANVIEN(
	MANV VARCHAR(10) NOT NULL,
	TENNV NVARCHAR(200) NOT NULL,
	NGAYSINH DATE NOT NULL,
	SDT VARCHAR(11) NOT NULL,
	NGAYVAOLAM DATE NOT NULL,
	LUONG DECIMAL  NOT NULL,
	CHUCVU NVARCHAR(30) NOT NULL,
	DIACHI NVARCHAR(200) NOT NULL,
	PASSWORDS VARCHAR(500)
)
GO 

CREATE TABLE NHACUNGCAP(
	MANCC VARCHAR(10) NOT NULL,
	TENNCC NVARCHAR(200) NOT NULL
)
GO 

CREATE TABLE LOAISANPHAM(
	MALSP VARCHAR(10) NOT NULL,
	TENLSP NVARCHAR(200) NOT NULL
)
GO 

CREATE TABLE SANPHAM(	
	MASP VARCHAR(15) NOT NULL,
	TENSP NVARCHAR(200) NOT NULL,
	SOLUONG INT NOT NULL,
	GIAMUA DECIMAL NOT NULL,
	GIABAN DECIMAL NOT NULL,	
	MALSP VARCHAR(10) NOT NULL,
	MANCC VARCHAR(10) NOT NULL,
	HinhAnh IMAGE NULL
)
GO 

CREATE TABLE HOADON(
	SOHD INT IDENTITY, 
	MANV VARCHAR(10) NOT NULL,
	MAKH INT NOT NULL,
	NGAYLAPHOADON DATETIME NOT NULL,
	THANHTIENHD DECIMAL NULL,
	TRANGTHAI NVARCHAR(50) NULL
)
GO 

CREATE TABLE CTHD(
	SOHD INT NOT NULL,
	MASP VARCHAR(15) NOT NULL,
	SOLUONG INT NOT NULL,
	DONGIASP DECIMAL NULL,
	THANHTIENSP DECIMAL NULL
)
GO
CREATE TABLE [MESSAGE](
	SOTN INT IDENTITY,
	NGGUI VARCHAR(10),
	NGNHAN VARCHAR(10),
	NOIDUNG NVARCHAR(1000),
	THOIGIAN DATETIME
)
--CREATE TABLE [USER]
--(
--	IDUSER INT IDENTITY,
--	UserName VARCHAR(20) NOT NULL,
--	[Password] VARCHAR(20) NOT NULL,
--	HOTEN NVARCHAR(100) NOT NULL,
--	QUYEN NVARCHAR(20) NOT NULL
--)
GO 

--PRIMARY KEY
ALTER TABLE KHACHHANG
ADD CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKH)
ALTER TABLE NHANVIEN
ADD CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANV)
ALTER TABLE NHACUNGCAP
ADD CONSTRAINT PK_NHACUNGCAP PRIMARY KEY(MANCC)
ALTER TABLE LOAISANPHAM
ADD CONSTRAINT PK_LOAISANPHAM PRIMARY KEY(MALSP)
ALTER TABLE SANPHAM
ADD CONSTRAINT PK_SANPHAM PRIMARY KEY(MASP)
ALTER TABLE HOADON
ADD CONSTRAINT PK_HOADON PRIMARY KEY(SOHD)
ALTER TABLE CTHD
ADD CONSTRAINT PK_CTHD PRIMARY KEY(SOHD, MASP)
ALTER TABLE [MESSAGE]
ADD CONSTRAINT PK_USER PRIMARY KEY(SOTN)
GO
--FOREIGN KEY
ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SANPHAM1 FOREIGN KEY(MALSP) REFERENCES LOAISANPHAM(MALSP)
ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SANPHAM2 FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC)
ALTER TABLE HOADON
ADD CONSTRAINT FK_HOADON1 FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
ALTER TABLE HOADON
ADD CONSTRAINT FK_HOADON2 FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
ALTER TABLE CTHD
ADD CONSTRAINT FK_CTHD1 FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)
ALTER TABLE CTHD
ADD CONSTRAINT FK_CTHD2 FOREIGN KEY(SOHD) REFERENCES HOADON(SOHD)  
--RBTV
Alter table NHANVIEN
add constraint C_NV1 check(LEN(sdt) = 10 and substring(sdt,1,1) = '0')
Alter table NHANVIEN
add constraint C_NV2 check(luong >= 0)
Alter table KHACHHANG
add constraint C_KH1 check(LEN(sdt) = 10 and substring(sdt,1,1) = '0')
Alter table SANPHAM
add constraint C_SP1 check(soluong >= 0 and giamua >= 0 and giaban >= 0)
Alter table HOADON
add constraint C_HD check(trangthai in (N'Đã thanh toán', N'Chưa thanh toán'))
Alter table CTHD
add constraint C_CTHD check(soluong >= 0)

INSERT INTO dbo.KHACHHANG(TENKH, NGSINH, DIACHI, SDT) VALUES
(N'Trần Văn Long','1995-09-02', N'Q.Đống Đa - Hà Nội', '0868686868'),
(N'Nguyễn Xuân Như','2000-03-29', N'Q.Hai Bà Trưng - Hà Nội', '0969969696'),
(N'Đào Diệp Diệp','2001-04-06', N'Q.Cầu Giấy - Hà Nội', '0585858585'),
(N'Nguyễn Tâm Huỳnh Như','2004-12-27', N'Q.Long Biên - Hà Nội', '0686868686'),
(N'Võ Thị Thảo','1998-06-24', N'Q.Hoàn Kiếm - Hà Nội', '0245454545'),
(N'Trần Tấn Nguyên','1999-03-20', N'Q.Long Biên - Hà Nội', '0679797979')

INSERT INTO NHANVIEN(MANV, TENNV, NGAYSINH, SDT, NGAYVAOLAM, LUONG, CHUCVU, DIACHI, PASSWORDS) VALUES
('NVTNK00','Guess','2000-01-01','0000000000','2020-01-01',0,N'Thu ngân',N'Thành phố Thủ Đức', '$%7eS3@N66'),
('NVTKK00','Guess','2000-01-01','0000000000','2020-01-01',0,N'Thủ kho',N'Thành phố Thủ Đức', 'y%$$(3pV8A'),
('NVTN001',N'Nguyễn Văn Phát','2002-01-01','0971111111','2021-01-01','6000000',N'Thu ngân',N'phường Tăng Nhơn Phú A, Thành phố Thủ Đức', 'Nvv132-@'),
('NVTK001',N'Trần Văn Linh','1997-03-23','0437736603','2021-09-07','7000000',N'Thủ kho',N'phường Tân Phú, Thành phố Thủ Đức', NULL),
('NVTN002',N'Đào Tiến Sơn','1999-05-03','0838751008','2019-05-06','6000000',N'Thu ngân',N'phường Tân Hưng, Quận 7', NULL),
('NVTK002',N'Trần Nhật Nam','1997-11-17','0383651679','2018-11-15','7000000',N'Thủ kho',N'phường 8, Quận 10', 'Tnn381+#'),
('QLCH000',N'Nguyễn Thị Thu Yến','1995-03-23','0573810146','2021-04-02','10000000',N'Quản lý',N'phường Phước Long A, Thành phố Thủ Đức', 'NttYqL)32!')

INSERT INTO LOAISANPHAM(MALSP, TENLSP) VALUES
('DH01', N'Đồng hồ thạch anh'),
('DH02', N'Đồng hồ cơ'),
('DH03', N'Đồng hồ Chronograph'),
('DH04', N'Đồng hồ solar'),
('DH05', N'Đồng hồ đeo tay thông minh')

INSERT INTO [MESSAGE] (NGGUI, NGNHAN, NOIDUNG, THOIGIAN) VALUES
('QLCH000', 'NVTN001', N'Khỏe không em :>', '2020-08-27 11:39:41.067'),
('NVTN001', 'QLCH000', N'Dạ không chị', '2020-08-27 11:50:40.067')

INSERT INTO NHACUNGCAP(MANCC, TENNCC) VALUES
('NCC01', N'Xưởng Đồng Hồ Luxury Fashion'),
('NCC02', N'Xưởng Đồng Hồ Giá Sỉ Zwatch'),
('NCC03', N'Đồng hồ Tân Thế Kỷ')

INSERT INTO	SANPHAM(MASP, TENSP, SOLUONG, GIAMUA, GIABAN, MALSP, MANCC, HinhAnh) VALUES
('7632324300011', N'Đồng Hồ nam Thạch Anh', 20, 450000, 467000, 'DH01', 'NCC02', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng Hồ Đeo Tay Nam Thạch Anh.png', SINGLE_BLOB) IMAGE)),
('7632324300028', N'Đồng Hồ nam Quartz', 20, 400000, 450000, 'DH01', 'NCC02', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng Hồ Nam Quartz Thời Trang Nam Ochstin.png', SINGLE_BLOB) IMAGE)),
('7632324300035', N'Đồng Hồ nam Hannah Martin Men Leather', 20, 300000, 312000, 'DH01', 'NCC03', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng Hồ Đeo Tay Nam Hannah Martin Men Leather.png', SINGLE_BLOB) IMAGE)),
('7632324300042', N'Đồng hồ FREDERIQUE CONSTANT 40 mm', 20, 45000000, 48016000, 'DH02', 'NCC01', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\FREDERIQUE CONSTANT 40 mm Automatic kính sapphire Classics.png', SINGLE_BLOB) IMAGE)),
('7632324300059', N'Đồng Hồ nữ Bulova', 20, 8500000, 9035000, 'DH02', 'NCC01', (SELECT * FROM	OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng hồ Nữ Bulova.png', SINGLE_BLOB) IMAGE)),
('7632324300066', N'Đồng Hồ ORIENT 39.3 mm', 20, 9500000, 10829000, 'DH02', 'NCC01', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\ORIENT 39.3 mm Automatic kính sapphire Nam.png', SINGLE_BLOB) IMAGE)),
('7632324300073', N'Đồng Hồ nam Tissot T/Classic', 20, 5800000, 6100000, 'DH03', 'NCC03', (SELECT * FROM	OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng hồ nam Tissot TClassic.png', SINGLE_BLOB) IMAGE)),
('7632324300080', N'Đồng Hồ nam Citizen Eco-Drive', 20, 10000000, 11500500, 'DH03', 'NCC03', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng Hồ Nam Citizen Eco-Drive.png', SINGLE_BLOB) IMAGE)),
('7632324300097', N'Đồng Hồ nam TISSOT SPECIAL COLLECTIONS', 20, 6000000, 6332000, 'DH03', 'NCC01', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng hồ nam TISSOT SPECIAL COLLECTIONS.png', SINGLE_BLOB) IMAGE)),
('7632324300103', N'Đồng Hồ nam Seiko Prospex', 20, 14000000, 14985000, 'DH04', 'NCC02', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng hồ nam Seiko Prospex.png', SINGLE_BLOB) IMAGE)),
('7632324300110', N'Đồng Hồ nam Seiko Solar', 20, 4000000, 4284000, 'DH04', 'NCC02', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng hồ Nam Seiko Solar.png', SINGLE_BLOB) IMAGE)),
('7632324300127', N'Đồng Hồ nam Seiko 5 Sports', 20, 7200000, 7857000, 'DH04', 'NCC02', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Đồng hồ nam Seiko 5 Sports.png', SINGLE_BLOB) IMAGE)),
('7632324300134', N'Samsung Galaxy Watch 4 Classic', 20, 7500000, 7990000, 'DH05', 'NCC01', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Samsung Galaxy Watch 4 Classic.png', SINGLE_BLOB) IMAGE)),
('7632324300141', N'Xiaomi Mi Watch', 20, 2000000, 2390000, 'DH05', 'NCC01', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Xiaomi Mi Watch.png', SINGLE_BLOB) IMAGE)),
('7632324300158', N'Apple Watch SE 40mm', 20, 6500000, 6890000, 'DH05', 'NCC03', (SELECT * FROM OPENROWSET(BULK N'D:\DA-PTTKHT\Hình đồng hồ\Apple Watch SE 40mm.png', SINGLE_BLOB) IMAGE))


-------HẾT NHẬP
SELECT * FROM dbo.KHACHHANG
SELECT * FROM dbo.NHANVIEN
SELECT * FROM dbo.SANPHAM
SELECT * FROM dbo.LOAISANPHAM
SELECT * FROM dbo.NHACUNGCAP
SELECT * FROM dbo.HOADON
delete from HOADON where MAKH = 'KH6'
update SANPHAM set SOLUONG = 20 where MASP = '7632324300028'
SELECT * FROM dbo.CTHD where SOHD = 15
delete from CTHD where SOHD = 10 and MASP = '7632324300011'
select sp.TENSP, CTHD.SOLUONG, CTHD.THANHTIENSP from SANPHAM sp, CTHD where sp.MASP = CTHD.MASP AND CTHD.SOHD = 9
SELECT * FROM dbo.[MESSAGE]
--SELECT * FROM dbo.[USER]
drop table CTHD
drop table HOADON
drop table [MESSAGE]
drop table NHANVIEN
drop table KHACHHANG
drop table SANPHAM
drop table LOAISANPHAM
drop table NHACUNGCAP
---- TRIGGER
-- Nhân viên trên 18 tuổi mới được vào làm
GO
CREATE TRIGGER TR_NgayVL ON dbo.NHANVIEN FOR  INSERT, UPDATE 
AS 
BEGIN 
	DECLARE @NgaySinh DATE
	DECLARE @NgayVL DATE
    SELECT @NgaySinh = INSERTED.NGAYSINH, @NgayVL = Inserted.NGAYVAOLAM FROM INSERTED 

	IF(YEAR(@NgayVL) - YEAR(@NgaySinh) <= 18)
		ROLLBACK TRAN
END 
GO 

-- Khách hàng trên 4 tuổi mới được đăng ký thành viên
--CREATE TRIGGER TR_NgaySinhKH ON dbo.KHACHHANG FOR  INSERT, UPDATE 
--AS 
--BEGIN 
--	DECLARE @NgaySinhKH DATE
--    SELECT @NgaySinhKH = INSERTED.NGSINH FROM INSERTED 

--	IF(YEAR(GETDATE()) - YEAR(@NgaySinhKH) <= 3)
--		ROLLBACK TRAN
--END 
GO 

-- Set lại số hóa đơn khi xóa hóa đơn
CREATE TRIGGER TR_SetIdentitySoHD ON HOADON FOR DELETE
AS
BEGIN
	DECLARE @SOHD INT 
	DECLARE @NewSOHD INT 
	SELECT @SOHD = Deleted.SOHD FROM Deleted
	SET @NewSOHD = @SOHD - 1
	DBCC CHECKIDENT (HOADON, RESEED, @NewSOHD);
END 
GO 

-- Giảm số lượng trong kho khi thêm sản phẩm vào CTHD
CREATE TRIGGER TR_GiamSLKho_UpdateGia_ThanhTiep_SP_Insert ON CTHD FOR INSERT
AS 
BEGIN 
	DECLARE @SoLuongTon INT
	DECLARE @SoLuongBan INT
	DECLARE @MaSP VARCHAR(15)
	
	SELECT @MaSP = Inserted.MASP FROM INSERTED
	SELECT @SoLuongBan = Inserted.SOLUONG FROM Inserted	 		
	SELECT @SoLuongTon = SANPHAM.SOLUONG FROM SANPHAM, Inserted WHERE dbo.SANPHAM.MASP = Inserted.MASP

	IF(@SoLuongTon >= @SoLuongBan)		
	BEGIN
		UPDATE SANPHAM SET SANPHAM.SOLUONG = @SoLuongTon - @SoLuongBan WHERE SANPHAM.MASP = @MaSP		
	END 
	ELSE 
		ROLLBACK TRAN

	DECLARE @SOHD INT
	SELECT @SOHD = Inserted.SOHD FROM Inserted
	-- Update gia san pham
	UPDATE CTHD SET DONGIASP = GIABAN 
				FROM SANPHAM 
				WHERE @MaSP = SANPHAM.MASP AND @SOHD = SOHD AND SANPHAM.MASP = CTHD.MASP
	-- Update thanh tien san pham
	UPDATE CTHD SET THANHTIENSP = @SoLuongBan * DONGIASP 
				WHERE SOHD = @SOHD AND MASP = @MaSP 
END
GO

-- Điều chỉnh số lượng trong kho khi thay đổi số lượng sản phẩm trong CTHD
CREATE TRIGGER TR_GiamSLKho_UpdateGia_ThanhTiep_SP_Update ON CTHD FOR UPDATE
AS 
BEGIN 
	DECLARE @SoLuongTon INT
	DECLARE @SoLuongBanCu INT
	DECLARE @SoLuongBanMoi INT
	DECLARE @MaSP VARCHAR(15)
	       
	SELECT @MaSP = Inserted.MASP FROM INSERTED
	SELECT @SoLuongBanCu = Deleted.SOLUONG FROM Deleted
	SELECT @SoLuongBanMoi = Inserted.SOLUONG FROM Inserted	
	SELECT @SoLuongTon = SANPHAM.SOLUONG FROM SANPHAM, Inserted WHERE SANPHAM.MASP = Inserted.MASP 
		
	BEGIN
		UPDATE SANPHAM SET SANPHAM.SOLUONG = (@SoLuongTon + @SoLuongBanCu - @SoLuongBanMoi) WHERE SANPHAM.MASP = @MaSP		
		IF ((SELECT SANPHAM.SOLUONG FROM sanpham WHERE MASP = @MaSP) < 0)
			ROLLBACK TRAN
	END 

	DECLARE @SOHD INT
	SELECT @SOHD = Inserted.SOHD FROM Inserted
	-- Update gia san pham
	UPDATE CTHD SET DONGIASP = GIABAN 
				FROM SANPHAM 
				WHERE @MaSP = SANPHAM.MASP AND @SOHD = SOHD AND SANPHAM.MASP = CTHD.MASP
	-- Update thanh tien san pham
	UPDATE CTHD SET THANHTIENSP = @SoLuongBanMoi * DONGIASP 
				WHERE SOHD = @SOHD AND MASP = @MaSP 
END
GO

-- Tăng số lượng trong kho khi xóa sản phẩm khỏi CTHD
CREATE TRIGGER TR_GiamSLKho_UpdateGia_ThanhTiep_SP_Delete ON CTHD FOR DELETE
AS 
BEGIN 
	DECLARE @SoLuongTon INT
	DECLARE @SoLuongTraLai INT
	DECLARE @MaSP VARCHAR(15)
	
	SELECT @MaSP = Deleted.MASP FROM Deleted
	SELECT @SoLuongTraLai = Deleted.SOLUONG FROM Deleted	 		
	SELECT @SoLuongTon = SANPHAM.SOLUONG FROM SANPHAM, Deleted WHERE dbo.SANPHAM.MASP = Deleted.MASP

	UPDATE SANPHAM SET SANPHAM.SOLUONG = @SoLuongTon + @SoLuongTraLai  WHERE SANPHAM.MASP = @MaSP		

END
GO

-- Set thành tiền hóa đơn khi thêm chi tiết hóa đơn
CREATE TRIGGER TR_SetThanhTienHD ON dbo.CTHD FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @SoHD INT
    SELECT @SoHD = Inserted.SOHD FROM Inserted
	UPDATE HOADON SET THANHTIENHD = (SELECT SUM(CTHD.THANHTIENSP) FROM dbo.CTHD, Inserted WHERE CTHD.SOHD = @SoHD)
					FROM CTHD 
					WHERE HOADON.SOHD = CTHD.SOHD AND CTHD.SOHD = @SoHD
END
GO 

-- Set lại thành tiền hóa đơn khi xóa chi tiết hóa đơn
CREATE TRIGGER TR_DeleteThanhTienHD ON dbo.CTHD FOR DELETE
AS
BEGIN
	DECLARE @SoHD INT
    SELECT @SoHD = Deleted.SOHD FROM Deleted
	UPDATE HOADON SET THANHTIENHD = (SELECT SUM(CTHD.THANHTIENSP) FROM dbo.CTHD, Deleted WHERE CTHD.SOHD = @SoHD)
					FROM CTHD 
					WHERE HOADON.SOHD = CTHD.SOHD AND CTHD.SOHD = @SoHD
END
GO 

CREATE VIEW View_ShowBill
AS  
	SELECT CTHD.SOHD, TENNV, TENKH, NGAYLAPHOADON, SANPHAM.MASP, TENSP, CTHD.SOLUONG, DONGIASP, THANHTIENSP, THANHTIENHD, TRANGTHAI
	FROM dbo.CTHD, dbo.SANPHAM, dbo.NHANVIEN, dbo.KHACHHANG, dbo.HOADON 
	WHERE CTHD.SOHD = HOADON.SOHD AND HOADON.MANV = NHANVIEN.MANV AND HOADON.MAKH = KHACHHANG.MAKH AND CTHD.MASP = SANPHAM.MASP 
GO 

CREATE PROC SP_ThongKe
AS 
BEGIN 
	SELECT TENSP, SUM(CTHD.SOLUONG) AS 'SL' FROM CTHD, SANPHAM WHERE CTHD.MASP = SANPHAM.MASP
	GROUP BY TENSP
	ORDER BY 'SL' DESC
END
go
SP_ThongKe
GO 

CREATE PROC SP_ThongKeSP_Theo_NamThang
(
	@Thang INT,
	@Nam int
)
AS
BEGIN
	SELECT TENSP AS N'Tên đồng hồ', SUM(CTHD.SOLUONG) AS SL, MONTH(NGAYLAPHOADON) AS N'Tháng', YEAR(NGAYLAPHOADON) AS N'Năm' 
	FROM CTHD, SANPHAM, HOADON 
	WHERE CTHD.MASP = SANPHAM.MASP AND CTHD.SOHD = HOADON.SOHD AND MONTH(NGAYLAPHOADON) = @Thang AND YEAR(NGAYLAPHOADON) = @Nam
	GROUP BY TENSP, NGAYLAPHOADON
	ORDER BY 'SL' DESC
END
go
SP_ThongKeSP_Theo_NamThang 9, 2020
GO

CREATE PROC SP_ThongKeSP_Theo_Nam
(
	@Nam int
)
AS
BEGIN
	SELECT TENSP AS N'Tên đồng hồ', SUM(CTHD.SOLUONG) AS SL, YEAR(NGAYLAPHOADON) AS N'Năm' 
	FROM CTHD, SANPHAM, HOADON 
	WHERE CTHD.MASP = SANPHAM.MASP AND CTHD.SOHD = HOADON.SOHD AND YEAR(NGAYLAPHOADON) = @Nam
	GROUP BY TENSP, NGAYLAPHOADON
	ORDER BY 'SL' DESC
END
go
SP_ThongKeSP_Theo_Nam 2020
GO

-- EXEC dbo.SP_ThongKeSP_Theo_Nam @Nam = 0

CREATE PROC SP_DoanhThu_Nam
(
	@Nam INT 
)
AS
BEGIN
	SELECT YEAR(NGAYLAPHOADON) AS N'Năm' , SUM(THANHTIENHD) AS N'Thành tiền' FROM HOADON WHERE YEAR(NGAYLAPHOADON) = @Nam
	GROUP BY YEAR(NGAYLAPHOADON)
END
go
SP_DoanhThu_Nam 2021
GO

-- EXEC dbo.SP_DoanhThu_Nam  2021


CREATE PROC SP_DoanhThu_ThangNam
(
	@Thang INT,
	@Nam INT 
)
AS
BEGIN
	SELECT MONTH(NGAYLAPHOADON) AS N'Tháng', YEAR(NGAYLAPHOADON) AS N'Năm', SUM(THANHTIENHD) AS N'Thành tiền' FROM HOADON WHERE YEAR(NGAYLAPHOADON) = @Nam AND MONTH(NGAYLAPHOADON) = @Thang
	GROUP BY YEAR(NGAYLAPHOADON), MONTH(NGAYLAPHOADON)
END
SELECT SUM(THANHTIENHD) FROM HOADON WHERE YEAR(NGAYLAPHOADON) = 2020 AND MONTH(NGAYLAPHOADON) = 9 GROUP BY YEAR(NGAYLAPHOADON), MONTH(NGAYLAPHOADON)
GO
SELECT CTHD.MASP as Masp, SUM(CTHD.SOLUONG) as Sl FROM CTHD, SANPHAM, HOADON WHERE CTHD.MASP = SANPHAM.MASP AND CTHD.SOHD = HOADON.SOHD AND MONTH(NGAYLAPHOADON) = 9 AND YEAR(NGAYLAPHOADON) = 2020 GROUP BY CTHD.MASP, CTHD.SOLUONG ORDER BY CTHD.SOLUONG DESC
--EXEC dbo.SP_DoanhThu_ThangNam @Thang = 12, @Nam = 2021


/*CREATE PROC SP_TienLuong
(
	@Nam INT
)
AS
BEGIN	
	SELECT TENNV AS N'Tên nhân viên', SUM(TIENLUONG) AS N'Tiền lương' FROM CHAMCONG, NHANVIEN WHERE YEAR(NGAYLAM) = @Nam AND NHANVIEN.MANV = CHAMCONG.MANV
	GROUP BY TENNV
END
*/
GO

-- EXEC dbo.SP_TienLuong @Nam = 2021 -- int

CREATE PROC SP_TimHDTuNgayDenNgay
(
	@TuNgay datetime,
	@DENNGAY datetime
)
AS
BEGIN 
	select sohd, tennv, tenkh, ngaylaphoadon, thanhtienhd, trangthai from hoadon, khachhang, nhanvien 
	where hoadon.manv = nhanvien.manv and hoadon.makh = khachhang.makh and ngaylaphoadon between @TUNGAY and @DENNGAY
END
go
SP_TimHDTuNgayDenNgay '2020-09-28', '2021-12-22'
GO 

-- thêm tài khoản
Alter proc TK_ADDACCOUNT(
	@Manv varchar(10),
	@code varchar(10)
)
AS
begin
	update NHANVIEN set ACCOUNT = @code where MANV = @Manv
end
--Xóa tài khoản
go
Create proc TK_DELETEACC(
	@Manv varchar(10)
)
AS
begin
	update NHANVIEN set ACCOUNT = NULL where MANV = @Manv
end
/*
CREATE TRIGGER TR_TinhTienNgayLam ON dbo.CHAMCONG FOR INSERT
AS
BEGIN
	DECLARE @MaNV VARCHAR(10)
	DECLARE @NgayLam DATE

	SELECT @MaNV = Inserted.MANV, @NgayLam = Inserted.NGAYLAM FROM Inserted
	UPDATE dbo.CHAMCONG SET TIENLUONG = 300000 WHERE MANV = @MaNV AND NGAYLAM = @NgayLam
END*/
GO 
delete from cthd delete from hoadon
select * from hoadon
/*insert into chamcong(manv,ngaylam) values('nv1', '2020-5-25')
insert into chamcong(manv,ngaylam) values('nv1', '2020-8-27')
insert into chamcong(manv,ngaylam) values('nv2', '2020-9-2')
insert into chamcong(manv,ngaylam) values('nv2', '2020-9-28')
insert into chamcong(manv,ngaylam) values('nv2', '2020-9-29')
insert into chamcong(manv,ngaylam) values('nv2', '2021-10-29')
insert into chamcong(manv,ngaylam) values('nv2', '2021-10-20')
insert into chamcong(manv,ngaylam) values('nv2', '2021-12-20')
insert into chamcong(manv,ngaylam) values('nv2', '2021-12-22')*/
select * from khachhang
select * from cthd
select * from sanpham
--select * from chamcong
update sanpham set soluong = 5
insert into hoadon(manv, makh, ngaylaphoadon) values ('NV01', 'KH04', '2021-12-22 21:25:17.067')
update nhanvien set manv = 'NV2' where manv = 'NV02'
update khachhang set makh = 'KH2' where makh = 'kh02'
update khachhang set makh = 'KH3' where makh = 'kh03'
update khachhang set makh = 'KH4' where makh = 'kh04'
update khachhang set makh = 'KH5' where makh = 'kh05'
update khachhang set makh = 'KH6' where makh = 'kh06'
update khachhang set makh = 'KH' where makh = 'kh01'
select * from sanpham
update sanpham set masp = 'DH1' where masp = 'DH01'
update sanpham set masp = 'DH2' where masp = 'DH02'
update sanpham set masp = 'DH3' where masp = 'DH03'
update sanpham set masp = 'DH4' where masp = 'DH04'
update sanpham set masp = 'DH5' where masp = 'DH05'
update sanpham set masp = 'DH6' where masp = 'DH06'
update sanpham set masp = 'DH7' where masp = 'DH07'
update sanpham set masp = 'DH8' where masp = 'DH08'
update sanpham set masp = 'DH9' where masp = 'DH09'
update sanpham set masp = 'DH1' where masp = 'DH01'
update sanpham set masp = 'DH1' where masp = 'DH01'
update hoadon set trangthai = N'Đã thanh toán'
update hoadon set trangthai = N'Chưa thanh toán' where sohd = 9 and sohd = 4
insert into cthd(sohd, masp, soluong)
Values(1, '7632324300073', 1)
insert into cthd(sohd, masp, soluong)
Values(2, '7632324300035', 1)
insert into cthd(sohd, masp, soluong)
Values(3, '7632324300028', 2)
insert into cthd(sohd, masp, soluong)
Values(3, '7632324300042', 1)
insert into cthd(sohd, masp, soluong)
Values(4, '7632324300073', 4)
insert into cthd(sohd, masp, soluong)
Values(5, '7632324300011', 2)
insert into cthd(sohd, masp, soluong)
Values(6, '7632324300035', 2)
insert into cthd(sohd, masp, soluong)
Values(7, '7632324300035', 2)
insert into cthd(sohd, masp, soluong)
Values(7, '7632324300110', 2)
insert into cthd(sohd, masp, soluong)
Values(8, '7632324300127',1)
insert into cthd(sohd, masp, soluong)
Values(8, '7632324300011', 1)
insert into cthd(sohd, masp, soluong)
Values(8, '7632324300028', 1)
insert into cthd(sohd, masp, soluong)
Values(9, '7632324300066', 1)
insert into cthd(sohd, masp, soluong)
Values(9, '7632324300059', 1)
insert into cthd(sohd, masp, soluong)
Values(9, '7632324300042', 1)
insert into cthd(sohd, masp, soluong)
Values(9, '7632324300011', 1)
insert into cthd(sohd, masp, soluong)
values(1, '7632324300011', 2)
DBCC CHECKIDENT (HOADON, RESEED, 0);

insert into hoadon(manv, makh, ngaylaphoadon) 
values ('NVTN001', 2,'2020-05-25 15:36:41.067'),
('NVTN001',	2,	'2020-08-27 11:39:41.067'),
('NVTN002',	4,	'2020-09-27 11:39:41.067'),
('NVTN002',	1,	'2020-09-28 09:30:41.067'),
('NVTN002',	1,	'2020-09-29 21:57:11.067'),
('NVTN002',	1,	'2021-10-29 21:57:11.067'),
('NVTN002',	1,	'2021-10-20 01:15:18.067'),
('NVTN002',	3,	'2021-12-20 16:25:17.067'),
('NVTN001',	4,	'2021-12-22 21:25:17.067')


--User login id
create login Ocean with password = 'ocean123',
default_database = QUANLYCUAHANGDH
create login Long with password = 'Long123@',
default_database = QUANLYCUAHANGDH
create login An with password = 'An123@',
default_database = QUANLYCUAHANGDH
--User login database
create user Ocean
create user Long
create user An
