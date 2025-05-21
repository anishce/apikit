SET NOCOUNT ON;
GO


-------------------------------------------
-- 1. Insert Lookup Data for Priority and Status
-------------------------------------------
-- Priority: (Low, Medium, High)
INSERT INTO Priority (Name, Ordinal)
VALUES 
    ('Low', 1), 
    ('Medium', 2), 
    ('High', 3);


-- Status: (Not Started, In Progress, Completed)
INSERT INTO Status (Name, Ordinal)
VALUES 
    ('Not Started', 1), 
    ('In Progress', 2), 
    ('Completed', 3);


-------------------------------------------
-- 2. Insert 100 Sample Rows into Category
-------------------------------------------
DECLARE @i AS INT;
SET @i = 1;
WHILE (@i <= 100)
BEGIN
    INSERT INTO Category (Name, Description)
    VALUES (
        'Category ' + CAST(@i AS NVARCHAR(10)),
        'Description for Category ' + CAST(@i AS NVARCHAR(10))
    );
    SET @i = @i + 1;
END


-------------------------------------------
-- 3. Insert 100 Sample Rows into Users
-------------------------------------------
SET @i = 1;
WHILE (@i <= 100)
BEGIN
    INSERT INTO Users (Username, Firstname, Lastname, Email)
    VALUES (
        'user' + CAST(@i AS NVARCHAR(10)),
        'First' + CAST(@i AS NVARCHAR(10)),
        'Last' + CAST(@i AS NVARCHAR(10)),
        'user' + CAST(@i AS NVARCHAR(10)) + '@example.com'
    );
    SET @i = @i + 1;
END


-------------------------------------------
-- 4. Insert 100 Sample Rows into Task
-------------------------------------------
SET @i = 1;
WHILE (@i <= 100)
BEGIN
    INSERT INTO Task (Subject, StartDate, DueDate, DateCompleted, PriorityId, StatusId)
    VALUES (
        'Task Subject ' + CAST(@i AS NVARCHAR(10)),
        DATEADD(day, @i, GETDATE()),
        DATEADD(day, @i + 3, GETDATE()),
        CASE WHEN (@i % 3) = 0 THEN DATEADD(day, @i + 5, GETDATE()) ELSE NULL END,
        CASE 
            WHEN (@i % 3) = 0 THEN 3  -- High
            WHEN (@i % 3) = 1 THEN 1  -- Low
            ELSE 2                   -- Medium
        END,
        CASE 
            WHEN (@i % 2) = 0 THEN 2  -- In Progress
            ELSE 1                   -- Not Started
        END
    );
    SET @i = @i + 1;
END


-------------------------------------------
-- 5. Insert Sample Data into Join Table: TaskCategory
-------------------------------------------
DECLARE @taskid INT = 1;
WHILE (@taskid <= 100)
BEGIN
    -- Each Task is assigned at least 1 Category (CategoryId equals TaskId)
    INSERT INTO TaskCategory (TaskId, CategoryId)
    VALUES (@taskid, @taskid);
    
    -- If possible, assign a second Category (using TaskId+1)
    IF (@taskid < 100)
    BEGIN
         INSERT INTO TaskCategory (TaskId, CategoryId)
         VALUES (@taskid, @taskid + 1);
    END
    SET @taskid = @taskid + 1;
END


-------------------------------------------
-- 6. Insert Sample Data into Join Table: TaskAssignee
-------------------------------------------
SET @taskid = 1;
WHILE (@taskid <= 100)
BEGIN
    -- Each Task gets assigned to two Users:
    INSERT INTO TaskAssignee (TaskId, UserId)
    VALUES (@taskid, @taskid),                            -- Assignee 1
           (@taskid, ((@taskid % 100) + 1));               -- Assignee 2 (wraps to 1 if TaskId=100)
    SET @taskid = @taskid + 1;
END


-------------------------------------------
-- 7. Insert Sample Data into TaskLink (Links for Task)
-------------------------------------------
SET @i = 1;
WHILE (@i <= 100)
BEGIN
    INSERT INTO TaskLink (TaskId, Rel, Href, Title, Type)
    VALUES (
        @i,
        'self',
        'http://example.com/tasks/' + CAST(@i AS NVARCHAR(10)),
        'Task Link ' + CAST(@i AS NVARCHAR(10)),
        'application/json'
    );
    SET @i = @i + 1;
END


-------------------------------------------
-- 8. Insert Sample Data into CategoryLink (Links for Category)
-------------------------------------------
SET @i = 1;
WHILE (@i <= 100)
BEGIN
    INSERT INTO CategoryLink (CategoryId, Rel, Href, Title, Type)
    VALUES (
        @i,
        'self',
        'http://example.com/categories/' + CAST(@i AS NVARCHAR(10)),
        'Category Link ' + CAST(@i AS NVARCHAR(10)),
        'application/json'
    );
    SET @i = @i + 1;
END


-------------------------------------------
-- 9. Insert Sample Data into PriorityLink (Links for Priority)
-------------------------------------------
INSERT INTO PriorityLink (PriorityId, Rel, Href, Title, Type)
VALUES 
  (1, 'self', 'http://example.com/priority/1', 'Low Priority Link', 'application/json'),
  (2, 'self', 'http://example.com/priority/2', 'Medium Priority Link', 'application/json'),
  (3, 'self', 'http://example.com/priority/3', 'High Priority Link', 'application/json');


-------------------------------------------
-- 10. Insert Sample Data into StatusLink (Links for Status)
-------------------------------------------
INSERT INTO StatusLink (StatusId, Rel, Href, Title, Type)
VALUES 
  (1, 'self', 'http://example.com/status/1', 'Not Started Link', 'application/json'),
  (2, 'self', 'http://example.com/status/2', 'In Progress Link', 'application/json'),
  (3, 'self', 'http://example.com/status/3', 'Completed Link', 'application/json');


-------------------------------------------
-- 11. Insert Sample Data into UserLink (Links for Users)
-------------------------------------------
SET @i = 1;
WHILE (@i <= 100)
BEGIN
    INSERT INTO UserLink (UserId, Rel, Href, Title, Type)
    VALUES (
        @i,
        'self',
        'http://example.com/users/' + CAST(@i AS NVARCHAR(10)),
        'User Link ' + CAST(@i AS NVARCHAR(10)),
        'application/json'
    );
    SET @i = @i + 1;
END
GO

SET NOCOUNT OFF;