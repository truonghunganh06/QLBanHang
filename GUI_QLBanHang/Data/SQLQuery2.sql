
USE [QLBanHang]
GO

CREATE TABLE [NhanVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[VaiTro] [tinyint] NOT NULL,
	[TinhTrang] [tinyint] NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	CONSTRAINT PK_NhanVien PRIMARY KEY ([MaNV]),
	CONSTRAINT [IX_NhanVien_1] UNIQUE ([Email])
)
GO
CREATE TABLE [Hang](
	[MaHang] [int] IDENTITY(1,1) NOT NULL,
	[TenHang] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGiaNhap] [float] NOT NULL,
	[DonGiaBan] [float] NOT NULL,
	[HinhAnh] [nvarchar](300) NULL,
	[GhiChu] [nvarchar](50) NULL,
	[MaNV] [varchar](20) NOT NULL,
	CONSTRAINT [PK_Hang] PRIMARY KEY ([MaHang]),
	CONSTRAINT [FK_Hang_NhanVien] FOREIGN KEY([MaNV]) REFERENCES [NhanVien] ([MaNV]) ON UPDATE CASCADE
)
GO
CREATE TABLE [Khach](
	[DienThoai] [varchar](15) NOT NULL,
	[TenKhach] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[Phai] [nvarchar](5) NULL,
	[ManV] [varchar](20) NOT NULL,
	CONSTRAINT [PK_Khach] PRIMARY KEY ([DienThoai]),
	CONSTRAINT [FK_Khach_NhanVien] FOREIGN KEY([MaNV])REFERENCES [dbo].[NhanVien] ([MaNV]) ON UPDATE CASCADE
)
GO

INSERT INTO [dbo].[NhanVien]([MaNV],[Email],[TenNV],[DiaChi],[VaiTro],[TinhTrang],[MatKhau])
VALUES ('NV001', 'fpoly@fe.edu.vn','FPT POLY',N'Đồng Nai',1,1,'e99a18c428cb38d5f260853678922e03')

GO

CREATE PROCEDURE [dbo].[sp_InsertNhanVien]
	@email nvarchar(50),
	@tenNV varchar(50),
	@diaChi nvarchar(100),
	@vaiTro tinyint,
	@tinhTrang tinyint
AS
BEGIN
	DECLARE @maNV VARCHAR(20);
	DECLARE @id INT;

	SELECT @id = ISNULL(MAX(Id),0) + 1 FROM NhanVien
	SELECT @maNV = 'NV' + FORMAT(@id,'0000')
	INSERT INTO NhanVien(MaNV,Email,TenNV, DiaChi,VaiTro,TinhTrang) 
	OUTPUT INSERTED.Id
	VALUES (@maNV, @email, @tenNV, @diaChi,@vaiTro,@tinhTrang) 
END