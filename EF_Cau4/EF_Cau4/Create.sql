CREATE DATABASE AnKhangClinic;
GO
USE AnKhangClinic;
GO

CREATE TABLE BacSi (
    MaBS       INT IDENTITY(1,1) PRIMARY KEY,
    HoTen      NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100) NULL,
    SDT        VARCHAR(15) NULL
);
GO

CREATE TABLE LichKham (
    MaLich      INT IDENTITY(1,1) PRIMARY KEY,
    TenBenhNhan NVARCHAR(100) NOT NULL,
    SDT         VARCHAR(15) NULL,
    NgayKham    DATE NOT NULL,
    GioKham     TIME(0) NOT NULL,
    MaBS        INT NOT NULL,
    TrangThai   NVARCHAR(20) NOT NULL,     -- Chờ khám / Đã khám / Đã hủy
    CONSTRAINT FK_LichKham_BacSi FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS)
);
GO

INSERT INTO BacSi (HoTen, ChuyenKhoa, SDT) VALUES
(N'Nguyễn Văn A', N'Nội tổng quát', '0901111111'),
(N'Trần Thị B',   N'Nhi khoa',      '0902222222'),
(N'Lê Minh C',    N'Da liễu',       '0903333333');
GO

-- Dữ liệu mẫu tính theo ngày hôm nay để bạn dễ thử tìm kiếm theo khoảng ngày
INSERT INTO LichKham (TenBenhNhan, SDT, NgayKham, GioKham, MaBS, TrangThai) VALUES
(N'Phạm Văn Hùng',  '0911000001', DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), '08:30', 1, N'Đã khám'),
(N'Hoàng Thị Lan',  '0911000002', DATEADD(DAY, -3,  CAST(GETDATE() AS DATE)), '09:00', 2, N'Đã khám'),
(N'Đỗ Quang Huy',   '0911000003', CAST(GETDATE() AS DATE),                    '14:00', 1, N'Chờ khám'),
(N'Vũ Thu Hà',      '0911000004', DATEADD(DAY, 2,   CAST(GETDATE() AS DATE)), '10:15', 3, N'Chờ khám'),
(N'Bùi Anh Tuấn',   '0911000005', DATEADD(DAY, 5,   CAST(GETDATE() AS DATE)), '15:30', 2, N'Đã hủy');
GO

SELECT * FROM BacSi;
SELECT * FROM LichKham;