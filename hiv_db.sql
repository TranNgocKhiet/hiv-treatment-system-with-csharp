-- CREATE DATABASE
USE [master];
GO

BEGIN
    DROP DATABASE IF EXISTS hiv_db;
END;
GO

CREATE DATABASE hiv_db;
GO

-- CREATE TABLES
USE hiv_db;
GO	

CREATE TABLE Roles (
    Id BIGINT PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);

CREATE TABLE Users (
    Id BIGINT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100) UNIQUE,
    Username VARCHAR(50) UNIQUE,
    Password NVARCHAR(255),
    Gender NVARCHAR(50),
    AccountStatus NVARCHAR(20),
    DateOfBirth DATE,
    RoleId BIGINT,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

CREATE TABLE Regimen (
    Id BIGINT IDENTITY PRIMARY KEY,
    Components NVARCHAR(255),
    RegimenName NVARCHAR(100),
    Description NVARCHAR(1000),
    Indications NVARCHAR(500),
    Contraindications NVARCHAR(500),
    DoctorId BIGINT NULL,
    FOREIGN KEY (DoctorId) REFERENCES Users(Id)
);

CREATE TABLE DoctorProfile (
    Id BIGINT IDENTITY PRIMARY KEY,
    LicenseNumber NVARCHAR(50) UNIQUE NOT NULL,
    StartYear VARCHAR(4),
    Qualifications NVARCHAR(500),
    Biography NVARCHAR(MAX),
    Background NVARCHAR(MAX),
    DoctorId BIGINT NOT NULL,
    FOREIGN KEY (DoctorId) REFERENCES Users(Id)
);

CREATE TABLE Schedule (
    Id BIGINT IDENTITY PRIMARY KEY,
    Type NVARCHAR(50),
    ActiveStatus NVARCHAR(50),
    RequestStatus NVARCHAR(50),
    Date DATE,
    Slot TIME,
    RoomCode NVARCHAR(50),
    DoctorId BIGINT,
    PatientId BIGINT,
    FOREIGN KEY (DoctorId) REFERENCES Users(Id),
    FOREIGN KEY (PatientId) REFERENCES Users(Id)
);

CREATE TABLE HealthRecord (
    Id BIGINT IDENTITY PRIMARY KEY,
    HivStatus NVARCHAR(50),
    BloodType NVARCHAR(10),
    TreatmentStatus NVARCHAR(50),
    Weight FLOAT,
    Height FLOAT,
    ScheduleId BIGINT,
    RegimenId BIGINT,
    FOREIGN KEY (ScheduleId) REFERENCES Schedule(Id),
    FOREIGN KEY (RegimenId) REFERENCES Regimen(Id)
);

CREATE TABLE TestResult (
    Id BIGINT IDENTITY PRIMARY KEY,
    Unit NVARCHAR(50),
    Type NVARCHAR(100),
    Result NVARCHAR(100),
    Note NVARCHAR(255),
    ExpectedResultTime DATETIME,
    ActualResultTime DATETIME,
    HealthRecordId BIGINT,
    FOREIGN KEY (HealthRecordId) REFERENCES HealthRecord(Id)
);

INSERT INTO Roles (Id, RoleName) VALUES 
(1, N'Quản lí'), (2, N'Bác sĩ'), (3, N'Kỹ thuật viên phòng thí nghiệm'), (4, N'Bệnh nhân');

INSERT INTO Users (FullName, Address, PhoneNumber, Email, Username, Password, Gender, AccountStatus, DateOfBirth, RoleId) VALUES
-- Managers
(N'Trần Thị B', N'45 Nguyễn Huệ, Đà Nẵng', '0900000002', 'manager1@example.com', 'man1', '123', N'Nữ', N'Đang hoạt động', '1990-12-20', 1),
(N'Lê Văn C', N'12 Trường Sa, TP.HCM', '0900000003', 'manager2@example.com', 'man2', '123', N'Nam', N'Đang hoạt động', '1990-12-20', 1),
-- Doctors
(N'Ngô Văn G', N'35 Hai Bà Trưng, Hà Nội', '0900000007', 'doctor1@example.com', 'doc1', '123', N'Nam', N'Đang hoạt động', '1990-12-20', 2),
(N'Huỳnh Thị H', N'90 Pasteur, TP.HCM', '0900000008', 'doctor2@example.com', 'doc2', '123', N'Nữ', N'Đang hoạt động', '1990-12-20', 2),
(N'Tô Văn I', N'55 Lạc BIGINT Quân, Đà Nẵng', '0900000009', 'doctor3@example.com', 'doc3', '123', N'Nam', N'Đang hoạt động', '1990-12-20', 2),
-- Lab technician
(N'Phạm Thị D', N'88 Lý Thường Kiệt, Huế', '0900000004', 'labtechnician1@example.com', 'labtech1', '123', N'Nữ', N'Đang hoạt động', '1990-12-20', 3),
(N'Hoàng Văn E', N'76 Nguyễn Văn Linh, Cần Thơ', '0900000005', 'labtechnician2@example.com', 'labtech2', '123', N'Nam', N'Đang hoạt động', '1992-03-25', 3),
-- Patients
(N'Đỗ Thị J', N'14 Nguyễn Thái Học, Quảng Ninh', '0900000010', 'patient1@example.com', 'pat1', '123', N'Nữ', N'Đang hoạt động', '1990-12-20', 4),
(N'Nguyễn Văn K', N'200 Lê Văn Sỹ, TP.HCM', '0900000011', 'patient2@example.com', 'pat2', '123', N'Nam', N'Đang hoạt động', '1990-12-20', 4),
(N'Trương Thị L', N'10 Nguyễn Trãi, Hải Phòng', '0900000012', 'patient3@example.com', 'pat3', '123', N'Nữ', N'Đang hoạt động', '1990-12-20', 4),
(N'Lý Văn M', N'88 Phan Bội Châu, Quảng Nam', '0900000013', 'patient4@example.com', 'pat4', '123', N'Nam', N'Đang hoạt động', '1990-12-20', 4),
(N'Bùi Thị N', N'30 Cách Mạng Tháng Tám, Hà Nội', '0900000014', 'patient5@example.com', 'pat5', '123', N'Nữ', N'Đang hoạt động', '1990-12-20', 4);

INSERT INTO DoctorProfile (LicenseNumber, StartYear, Qualifications, Biography, Background, DoctorId) VALUES
('HIV-BIGINT-001', '2012', N'Thạc sĩ Y học...', N'Bác sĩ có hơn 10 năm...', N'Hơn 10 năm làm việc tại...', 3),
('HIV-ARV-002', '2015', N'Bác sĩ đa khoa...', N'Chuyên trách tư vấn ARV...', N'Từng làm việc tại Trung tâm Y tế...', 4),
('HIV-COM-003', '2020', N'Cử nhân Y đa khoa...', N'Bác sĩ trẻ năng động...', N'Tình nguyện viên NGO...', 5);

INSERT INTO Regimen (Components, RegimenName, Description, Indications, Contraindications, DoctorId) VALUES 
(N'TDF + 3TC + DTG', N'Phác đồ bậc một TLD', N'Dành cho người nhiễm HIV...', N'HIV lâm sàng giai đoạn 1...', N'Suy gan nặng...', NULL),
(N'TDF + 3TC + EFV', N'Phác đồ thay thế bậc một', N'Sử dụng khi không thể dùng DTG...', N'HIV lâm sàng giai đoạn 2...', N'Rối loạn tâm thần...', NULL),
(N'AZT + 3TC + LPV/r', N'Phác đồ bậc hai có PI', N'Sử dụng khi thất bại...', N'HIV giai đoạn 3...', N'Không dung nạp AZT...', 3),
(N'TDF + FTC + DRV/r', N'Phác đồ thay thế tăng cường DRV', N'Phác đồ cá nhân hoá...', N'HIV giai đoạn 3...', N'Suy thận nặng...', 4),
(N'ABC + 3TC + DTG', N'Phác đồ tăng cường DTG...', N'Dành cho bệnh nhân HIV...', N'HIV giai đoạn 3...', N'HLA-B*5701 dương tính...', 5);

INSERT INTO Schedule (Type, ActiveStatus, RequestStatus, Date, Slot, RoomCode, DoctorId, PatientId) VALUES
(N'Khám', N'Đang hoạt động', N'Chờ duyệt', '2025-06-20', '08:00:00', N'301', 3, 8),
(N'Khám', N'Đã hủy', N'Chờ duyệt', '2025-06-18', '09:00:00', N'100', 4, 8),
(N'Tái khám', N'Đang hoạt động', N'Đã duyệt', '2025-07-01', '10:00:00', N'230', 5, 9),
(N'Tái khám', N'Đã hủy', N'Từ chối', '2025-06-25', '11:00:00', N'320', 3, 9),
(N'Tư vấn', N'Đang hoạt động', N'Đã duyệt', '2025-06-22', '14:00:00', N'205', 4, 10);

INSERT INTO HealthRecord (HivStatus, BloodType, TreatmentStatus, Weight, Height, ScheduleId, RegimenId) VALUES
(N'Dương tính', N'O+', N'Chờ khám', 55.2, 168.5, 1, 1), 
(N'Dương tính', N'B+', N'Đã khám', 63.4, 172.0, 2, 2),
(N'Dương tính', N'A-', N'Chờ khám', 59.1, 166.2, 3, 1),
(N'Dương tính', N'O-', N'Chờ khám', 61.0, 174.3, 4, 3),
(N'Dương tính', N'AB+', N'Đã khám', 50.8, 163.7, 5, 4);

INSERT INTO TestResult (Unit, Type, Result, Note, ExpectedResultTime, ActualResultTime, HealthRecordId) VALUES
(N'mg/dL', N'Xét nghiệm máu', N'105', N'Bình thường', '2025-06-01T09:00:00', '2025-06-01T08:45:00', 1),
(N'BPM', N'Điện tâm đồ', N'72', N'Nhip tim ổn định', '2025-06-02T10:30:00', '2025-06-02T10:20:00', 1),
(N'mmol/L', N'Đường huyết', N'6.1', N'Ranh giới tiền tiểu đường', '2025-06-05T15:00:00', '2025-06-05T15:10:00', 2),
(N'mg/L', N'CRP', N'3.5', N'Tăng nhẹ', '2025-06-07T08:00:00', '2025-06-07T08:30:00', 3),
(N'x10^9/L', N'Huyết cầu trắng', N'4.8', N'Bình thường', '2025-06-08T11:00:00', '2025-06-08T10:50:00', 2);

SELECT * FROM Users;
SELECT * FROM Roles;
SELECT * FROM Schedule;
SELECT * FROM DoctorProfile;
SELECT * FROM Regimen;
SELECT * FROM HealthRecord;
SELECT * FROM TestResult;

