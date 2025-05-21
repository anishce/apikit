-- 1) Create the database
CREATE DATABASE TaskManagement2;
GO

USE TaskManagement2;
GO

-- 2) Tables for lookup entities

CREATE TABLE Priority (
    PriorityId   BIGINT       IDENTITY(1,1) PRIMARY KEY,
    Name         NVARCHAR(200) NOT NULL,
    Ordinal      INT           NOT NULL
);

CREATE TABLE Status (
    StatusId     BIGINT       IDENTITY(1,1) PRIMARY KEY,
    Name         NVARCHAR(200) NOT NULL,
    Ordinal      INT           NOT NULL
);

CREATE TABLE Category (
    CategoryId   BIGINT       IDENTITY(1,1) PRIMARY KEY,
    Name         NVARCHAR(200) NOT NULL,
    Description  NVARCHAR(MAX) NULL
);

CREATE TABLE [User] (
    UserId       BIGINT       IDENTITY(1,1) PRIMARY KEY,
    Username     NVARCHAR(100) NOT NULL,
    Firstname    NVARCHAR(100) NOT NULL,
    Lastname     NVARCHAR(100) NOT NULL,
    Email        NVARCHAR(256) NOT NULL
);

-- 3) Core Task table

CREATE TABLE [Task] (
    TaskId         BIGINT       IDENTITY(1,1) PRIMARY KEY,
    Subject        NVARCHAR(500) NOT NULL,
    StartDate      DATETIME2    NULL,
    DueDate        DATETIME2    NULL,
    DateCompleted  DATETIME2    NULL,
    
    PriorityId     BIGINT       NOT NULL
                     CONSTRAINT FK_Task_Priority FOREIGN KEY REFERENCES Priority(PriorityId),
    StatusId       BIGINT       NOT NULL
                     CONSTRAINT FK_Task_Status   FOREIGN KEY REFERENCES Status(StatusId)
);

-- 4) Many-to-Many bridge tables

CREATE TABLE TaskCategory (
    TaskId      BIGINT NOT NULL
                  CONSTRAINT FK_TaskCategory_Task     FOREIGN KEY REFERENCES [Task](TaskId),
    CategoryId  BIGINT NOT NULL
                  CONSTRAINT FK_TaskCategory_Category FOREIGN KEY REFERENCES Category(CategoryId),
    PRIMARY KEY (TaskId, CategoryId)
);

CREATE TABLE TaskAssignee (
    TaskId   BIGINT NOT NULL
               CONSTRAINT FK_TaskAssignee_Task FOREIGN KEY REFERENCES [Task](TaskId),
    UserId   BIGINT NOT NULL
               CONSTRAINT FK_TaskAssignee_User FOREIGN KEY REFERENCES [User](UserId),
    PRIMARY KEY (TaskId, UserId)
);

-- 5) Generic Link table (holds LinkModel for any parent)

CREATE TABLE Link (
    LinkId      BIGINT        IDENTITY(1,1) PRIMARY KEY,
    ParentType  NVARCHAR(50)  NOT NULL,  -- e.g. 'Task', 'Category', 'Priority', 'Status', 'User'
    ParentId    BIGINT        NOT NULL,  -- matches the PK value of the parent table
    Rel         NVARCHAR(100) NOT NULL,
    Href        NVARCHAR(2000) NOT NULL,
    Title       NVARCHAR(200) NOT NULL,
    [Type]      NVARCHAR(100) NOT NULL
);

-- 6) (Optional) Index to speed up lookups by parent
CREATE INDEX IX_Link_Parent ON Link(ParentType, ParentId);
