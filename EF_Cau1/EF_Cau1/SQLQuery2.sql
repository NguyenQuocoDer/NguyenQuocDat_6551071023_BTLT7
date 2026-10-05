CREATE DATABASE FitZone;
GO
USE FitZone;
GO

CREATE TABLE HoiVien (
    MaHV          INT IDENTITY(1,1) PRIMARY KEY,
    HoTen         NVARCHAR(100) NOT NULL,
    GioiTinh      BIT NOT NULL,            -- 1 = Nam, 0 = Nữ
    NgaySinh      DATE NOT NULL,
    SDT           VARCHAR(15) NULL,
    Email         VARCHAR(100) NULL,
    HangThanhVien NVARCHAR(20) NULL,       -- Basic / VIP / Premium
    NgayDangKy    DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThai     BIT NOT NULL             -- 1 = Đang hoạt động, 0 = Tạm ngưng
);
GO

INSERT INTO HoiVien (HoTen, GioiTinh, NgaySinh, SDT, Email, HangThanhVien, TrangThai) VALUES
(N'Nguyễn Văn An',  1, '2000-05-12', '0901234567', 'an@gmail.com',    N'Basic',   1),
(N'Trần Thị Bình',  0, '1998-11-03', '0912345678', 'binh@gmail.com',  N'VIP',     1),
(N'Lê Hoàng Cường', 1, '1995-02-20', '0987654321', 'cuong@gmail.com', N'Premium', 0),
(N'Phạm Thị Dung',  0, '2002-08-30', '0933445566', 'dung@gmail.com',  N'Basic',   1),
(N'Võ Minh Khang',  1, '1990-01-15', '0977112233', 'khang@gmail.com', N'VIP',     1);
GO

SELECT * FROM HoiVien;