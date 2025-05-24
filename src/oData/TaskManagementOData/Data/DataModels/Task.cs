// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnishCeDev.TaskManagement.Data.DataModels
{
    public class Task
    {
        public long TaskId { get; set; }
        public string Subject { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateCompleted { get; set; }

        // Many-to-many relationships
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public List<UserModel> Assignees { get; set; } = new List<UserModel>();

        // One-to-many (or many-to-one) reference relationships
        public PriorityModel Priority { get; set; } = null!;
        public StatusModel Status { get; set; } = null!;

        // Owned collection for Task links
        public List<LinkModel> Links { get; set; } = new List<LinkModel>();
    }
}
