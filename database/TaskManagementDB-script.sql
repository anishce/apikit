-- Create the database
CREATE DATABASE TaskManagementDB;
GO

USE TaskManagementDB;
GO

-------------------------------------------
-- Lookup/Reference Tables
-------------------------------------------

-- Table for Priority (from PriorityModel)
CREATE TABLE Priority (
    PriorityId BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Ordinal INT NOT NULL
);
GO

-- Table for Status (from StatusModel)
CREATE TABLE Status (
    StatusId BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Ordinal INT NOT NULL
);
GO

-- Table for Category (from CategoryModel)
CREATE TABLE Category (
    CategoryId BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL
);
GO

-- Table for Users (from UserModel; "User" is reserved, so we use "Users")
CREATE TABLE Users (
    UserId BIGINT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Firstname NVARCHAR(100) NOT NULL,
    Lastname NVARCHAR(100) NOT NULL,
    Email NVARCHAR(200) NOT NULL
);
GO

-------------------------------------------
-- Main Task Table
-------------------------------------------

CREATE TABLE Task (
    TaskId BIGINT PRIMARY KEY IDENTITY(1,1),
    Subject NVARCHAR(255) NOT NULL,
    StartDate DATETIME NULL,
    DueDate DATETIME NULL,
    DateCompleted DATETIME NULL,
    PriorityId BIGINT NOT NULL,
    StatusId BIGINT NOT NULL,
    CONSTRAINT FK_Task_Priority FOREIGN KEY (PriorityId) 
         REFERENCES Priority(PriorityId),
    CONSTRAINT FK_Task_Status FOREIGN KEY (StatusId) 
         REFERENCES Status(StatusId)
);
GO

-------------------------------------------
-- Many-to-Many Join Tables
-------------------------------------------

-- Join table for Task and Category relationship
CREATE TABLE TaskCategory (
    TaskId BIGINT NOT NULL,
    CategoryId BIGINT NOT NULL,
    PRIMARY KEY (TaskId, CategoryId),
    CONSTRAINT FK_TaskCategory_Task FOREIGN KEY (TaskId) 
         REFERENCES Task(TaskId),
    CONSTRAINT FK_TaskCategory_Category FOREIGN KEY (CategoryId) 
         REFERENCES Category(CategoryId)
);
GO

-- Join table for Task and Users (Assignees)
CREATE TABLE TaskAssignee (
    TaskId BIGINT NOT NULL,
    UserId BIGINT NOT NULL,
    PRIMARY KEY (TaskId, UserId),
    CONSTRAINT FK_TaskAssignee_Task FOREIGN KEY (TaskId) 
         REFERENCES Task(TaskId),
    CONSTRAINT FK_TaskAssignee_User FOREIGN KEY (UserId) 
         REFERENCES Users(UserId)
);
GO

-------------------------------------------
-- Link Tables for Each Model
-------------------------------------------

-- Links associated with a Task (from TaskModel.Links)
CREATE TABLE TaskLink (
    LinkId INT PRIMARY KEY IDENTITY(1,1),
    TaskId BIGINT NOT NULL,
    Rel NVARCHAR(50) NOT NULL,
    Href NVARCHAR(500) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_TaskLink_Task FOREIGN KEY (TaskId)
         REFERENCES Task(TaskId)
);
GO

-- Links associated with a Category (from CategoryModel.Links)
CREATE TABLE CategoryLink (
    LinkId INT PRIMARY KEY IDENTITY(1,1),
    CategoryId BIGINT NOT NULL,
    Rel NVARCHAR(50) NOT NULL,
    Href NVARCHAR(500) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_CategoryLink_Category FOREIGN KEY (CategoryId)
         REFERENCES Category(CategoryId)
);
GO

-- Links associated with Priority (from PriorityModel.Links)
CREATE TABLE PriorityLink (
    LinkId INT PRIMARY KEY IDENTITY(1,1),
    PriorityId BIGINT NOT NULL,
    Rel NVARCHAR(50) NOT NULL,
    Href NVARCHAR(500) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_PriorityLink_Priority FOREIGN KEY (PriorityId)
         REFERENCES Priority(PriorityId)
);
GO

-- Links associated with Status (from StatusModel.Links)
CREATE TABLE StatusLink (
    LinkId INT PRIMARY KEY IDENTITY(1,1),
    StatusId BIGINT NOT NULL,
    Rel NVARCHAR(50) NOT NULL,
    Href NVARCHAR(500) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_StatusLink_Status FOREIGN KEY (StatusId)
         REFERENCES Status(StatusId)
);
GO

-- Links associated with a User (from UserModel.Links)
CREATE TABLE UserLink (
    LinkId INT PRIMARY KEY IDENTITY(1,1),
    UserId BIGINT NOT NULL,
    Rel NVARCHAR(50) NOT NULL,
    Href NVARCHAR(500) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_UserLink_User FOREIGN KEY (UserId)
         REFERENCES Users(UserId)
);
GO