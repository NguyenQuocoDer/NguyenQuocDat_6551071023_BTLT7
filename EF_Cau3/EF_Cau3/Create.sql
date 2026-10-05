CREATE DATABASE SunriseHomestay;
GO
USE SunriseHomestay;
GO

CREATE TABLE LoaiPhong (
    MaLoai    INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai   NVARCHAR(100) NOT NULL,
    GiaMoiDem DECIMAL(18,2) NOT NULL,
    MoTa      NVARCHAR(255) NULL
);
GO

CREATE TABLE Phong (
    MaPhong   INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong   VARCHAR(10) NOT NULL,
    TangSo    INT NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL,      -- Trống / Đang ở / Đang dọn
    HinhAnh   NVARCHAR(255) NULL,         -- chỉ lưu TÊN FILE ảnh
    MaLoai    INT NOT NULL,
    CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai)
);
GO

INSERT INTO LoaiPhong (TenLoai, GiaMoiDem, MoTa) VALUES
(N'Phòng đơn', 300000, N'1 giường đơn, phù hợp 1 người'),
(N'Phòng đôi', 500000, N'1 giường đôi, phù hợp 2 người'),
(N'Phòng VIP', 900000, N'Phòng rộng, ban công, view đẹp');
GO

INSERT INTO Phong (SoPhong, TangSo, TinhTrang, MaLoai) VALUES
('101', 1, N'Trống',   1),
('102', 1, N'Đang ở',  1),
('201', 2, N'Trống',   2),
('202', 2, N'Đang dọn',2),
('301', 3, N'Trống',   3);
GO

SELECT * FROM LoaiPhong;
SELECT * FROM Phong;