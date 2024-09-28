// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

namespace AnishCeDev.TaskManagement.Web.Api.Models
{
    public class CategoryModel
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LinkModel> Links { get; set; }
    }
}
