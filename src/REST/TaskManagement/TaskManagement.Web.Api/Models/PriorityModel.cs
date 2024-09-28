// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

namespace AnishCeDev.TaskManagement.Web.Api.Models
{
    public class PriorityModel
    {
        public long? PriorityId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Ordinal { get; set; }
        public List<LinkModel> Links { get; set; } = null!;
    }
}
