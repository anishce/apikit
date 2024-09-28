// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

namespace AnishCeDev.TaskManagement.Web.Api.Models
{
    public class TaskModel
    {
        public long TaskId { get; set; }
        public string Subject { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateCompleted { get; set; }
        public List<CategoryModel> Categories { get; set; } = null!;
        public PriorityModel Priority { get; set; } = null!;
        public StatusModel Status { get; set; } = null!;
        public List<LinkModel> Links { get; set; } = null!;
        public List<User> Assignees { get; set; } = null!;
    }
}
