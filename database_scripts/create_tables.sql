-- Crear la base de datos
CREATE DATABASE TerapiaApp;
GO

USE TerapiaApp;
GO

-- Tabla de usuarios
CREATE TABLE Users (
    Id NVARCHAR(450) PRIMARY KEY,
    Email NVARCHAR(256) NOT NULL UNIQUE,
    Name NVARCHAR(256) NOT NULL,
    UserType NVARCHAR(20) NOT NULL CHECK (UserType IN ('psychologist', 'patient')),
    PasswordHash VARBINARY(MAX) NOT NULL,
    PasswordSalt VARBINARY(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);
GO

-- Tabla de tareas
CREATE TABLE Tasks (
    Id NVARCHAR(450) PRIMARY KEY,
    Title NVARCHAR(500) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    AssignedDate DATETIME2 NOT NULL,
    DueDate DATETIME2 NOT NULL,
    PatientId NVARCHAR(450) NOT NULL,
    PsychologistId NVARCHAR(450) NOT NULL,
    IsCompleted BIT NOT NULL DEFAULT 0,
    PhotoUrl NVARCHAR(MAX) NULL,
    CompletedAt DATETIME2 NULL,
    FOREIGN KEY (PatientId) REFERENCES Users(Id),
    FOREIGN KEY (PsychologistId) REFERENCES Users(Id)
);
GO

-- Índices para mejorar el rendimiento
CREATE INDEX IX_Tasks_PatientId ON Tasks(PatientId);
CREATE INDEX IX_Tasks_PsychologistId ON Tasks(PsychologistId);
CREATE INDEX IX_Tasks_DueDate ON Tasks(DueDate);
GO

-- Insertar algunos datos de ejemplo
INSERT INTO Users (Id, Email, Name, UserType, PasswordHash, PasswordSalt) 
VALUES 
('psychologist-1', 'dr.garcia@terapia.com', 'Dr. García', 'psychologist', 0x, 0x),
('patient-1', 'maria@ejemplo.com', 'Maria López', 'patient', 0x, 0x);
GO