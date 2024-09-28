// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

namespace AnishCeDev.TaskManagement.Web.Api.Models
{
    public class TaskModel
    {
        public long TaskId { get; set; }
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateCompleted { get; set; }
        public List<Category> Categories { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public List<Link> Links { get; set; }
        public List<User> Assignees { get; set; }
    }
}
