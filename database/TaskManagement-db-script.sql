-- Create Database
CREATE DATABASE TaskManagement;
GO

USE TaskManagement;
GO

-- Link Table
CREATE TABLE Link (
    LinkId BIGINT IDENTITY(1,1) PRIMARY KEY,
    Rel NVARCHAR(100) NOT NULL,
    Href NVARCHAR(500) NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Type NVARCHAR(100) NOT NULL
);

-- Category Table
CREATE TABLE Category (
    CategoryId BIGINT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000) NULL
);

-- Priority Table
CREATE TABLE Priority (
    PriorityId BIGINT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Ordinal INT NOT NULL
);

-- Status Table
CREATE TABLE Status (
    StatusId BIGINT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Ordinal INT NOT NULL
);

-- User Table
CREATE TABLE [User] (
    UserId BIGINT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    Firstname NVARCHAR(100) NOT NULL,
    Lastname NVARCHAR(100) NOT NULL,
    Email NVARCHAR(200) NOT NULL
);

-- Task Table
CREATE TABLE Task (
    TaskId BIGINT IDENTITY(1,1) PRIMARY KEY,
    Subject NVARCHAR(500) NOT NULL,
    StartDate DATETIME NULL,
    DueDate DATETIME NULL,
    DateCompleted DATETIME NULL,
    PriorityId BIGINT NOT NULL FOREIGN KEY REFERENCES Priority(PriorityId),
    StatusId BIGINT NOT NULL FOREIGN KEY REFERENCES Status(StatusId)
);

-- Task-Category Many-to-Many
CREATE TABLE TaskCategory (
    TaskId BIGINT NOT NULL FOREIGN KEY REFERENCES Task(TaskId),
    CategoryId BIGINT NOT NULL FOREIGN KEY REFERENCES Category(CategoryId),
    PRIMARY KEY (TaskId, CategoryId)
);

-- Task-User (Assignees) Many-to-Many
CREATE TABLE TaskAssignee (
    TaskId BIGINT NOT NULL FOREIGN KEY REFERENCES Task(TaskId),
    UserId BIGINT NOT NULL FOREIGN KEY REFERENCES [User](UserId),
    PRIMARY KEY (TaskId, UserId)
);

-- Link Associations
CREATE TABLE TaskLink (
    TaskId BIGINT NOT NULL FOREIGN KEY REFERENCES Task(TaskId),
    LinkId BIGINT NOT NULL FOREIGN KEY REFERENCES Link(LinkId),
    PRIMARY KEY (TaskId, LinkId)
);

CREATE TABLE CategoryLink (
    CategoryId BIGINT NOT NULL FOREIGN KEY REFERENCES Category(CategoryId),
    LinkId BIGINT NOT NULL FOREIGN KEY REFERENCES Link(LinkId),
    PRIMARY KEY (CategoryId, LinkId)
);

CREATE TABLE PriorityLink (
    PriorityId BIGINT NOT NULL FOREIGN KEY REFERENCES Priority(PriorityId),
    LinkId BIGINT NOT NULL FOREIGN KEY REFERENCES Link(LinkId),
    PRIMARY KEY (PriorityId, LinkId)
);

CREATE TABLE StatusLink (
    StatusId BIGINT NOT NULL FOREIGN KEY REFERENCES Status(StatusId),
    LinkId BIGINT NOT NULL FOREIGN KEY REFERENCES Link(LinkId),
    PRIMARY KEY (StatusId, LinkId)
);

CREATE TABLE UserLink (
    UserId BIGINT NOT NULL FOREIGN KEY REFERENCES [User](UserId),
    LinkId BIGINT NOT NULL FOREIGN KEY REFERENCES Link(LinkId),
    PRIMARY KEY (UserId, LinkId)
);
