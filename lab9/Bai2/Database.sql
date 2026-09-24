CREATE DATABASE QLDiem;
GO
USE QLDiem;
GO

CREATE TABLE tblKhoa (
    Makhoa NVARCHAR(50) PRIMARY KEY,
    Tenkhoa NVARCHAR(100)
);

CREATE TABLE tblSinhVien (
    MaSV NVARCHAR(50) PRIMARY KEY,
    Hoten NVARCHAR(100),
    Ngaysinh DATE,
    Noisinh NVARCHAR(100),
    Gioitinh NVARCHAR(10),
    Diachi NVARCHAR(100),
    Makhoa NVARCHAR(50) FOREIGN KEY REFERENCES tblKhoa(Makhoa)
);

CREATE TABLE tblMonHoc (
    Mamon NVARCHAR(50) PRIMARY KEY,
    Tenmon NVARCHAR(100),
    Makhoa NVARCHAR(50) FOREIGN KEY REFERENCES tblKhoa(Makhoa),
    Sohocphan INT,
    Giaovien NVARCHAR(100)
);

CREATE TABLE tblDiem (
    Mamon NVARCHAR(50) FOREIGN KEY REFERENCES tblMonHoc(Mamon),
    MaSV NVARCHAR(50) FOREIGN KEY REFERENCES tblSinhVien(MaSV),
    Diem FLOAT,
    PRIMARY KEY (Mamon, MaSV)
);

-- Insert sample data
INSERT INTO tblKhoa VALUES ('K01', N'Công nghệ thông tin');
INSERT INTO tblKhoa VALUES ('K02', N'Kinh tế');

INSERT INTO tblSinhVien VALUES ('SV01', N'Nguyễn Văn A', '2000-01-01', N'Hà Nội', N'Nam', N'Hà Nội', 'K01');
INSERT INTO tblSinhVien VALUES ('SV02', N'Trần Thị B', '2001-02-02', N'Hải Phòng', N'Nữ', N'Hải Phòng', 'K02');

INSERT INTO tblMonHoc VALUES ('M01', N'Toán', 'K01', 3, N'Nguyễn ThầyToán');
INSERT INTO tblMonHoc VALUES ('M02', N'Lập trình C#', 'K01', 4, N'Nguyễn ThầyC');

INSERT INTO tblDiem VALUES ('M01', 'SV01', 8.5);
INSERT INTO tblDiem VALUES ('M02', 'SV01', 9.0);
