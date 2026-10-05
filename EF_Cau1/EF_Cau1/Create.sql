CREATE DATABASE TriThucBooks;
GO
USE TriThucBooks;
GO

CREATE TABLE TheLoaiSach (
    MaTL        INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai  NVARCHAR(100) NOT NULL UNIQUE,
    MoTa        NVARCHAR(255) NULL,
    SoLuongSach INT NOT NULL DEFAULT 0,
    NgayTao     DATETIME NOT NULL DEFAULT GETDATE()
);
GO

INSERT INTO TheLoaiSach (TenTheLoai, MoTa) VALUES
(N'Tiểu thuyết', N'Các tác phẩm văn học hư cấu'),
(N'Kỹ năng sống', N'Sách phát triển bản thân'),
(N'Thiếu nhi', N'Truyện tranh, truyện cổ tích cho bé'),
(N'Sách giáo khoa', N'Sách học các cấp');
GO

SELECT * FROM TheLoaiSach;