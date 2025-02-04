// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.Web.Api.Models
#pragma warning restore VSSpell001 // Spell Check
#pragma warning restore VSSpell001 // Spell Check
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
        public List<UserModel> Assignees { get; set; } = null!;
    }
}
