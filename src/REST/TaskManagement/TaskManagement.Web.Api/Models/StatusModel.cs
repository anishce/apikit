// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

namespace AnishCeDev.TaskManagement.Web.Api.Models
{
    public class StatusModel
    {
        public long StatusId { get; set; }
        public string Name { get; set; } = null!;
        public int Ordinal { get; set; }
        public List<LinkModel> Links { get; set; } = null!;
    }
}
