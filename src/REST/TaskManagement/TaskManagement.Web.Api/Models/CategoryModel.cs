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
    public class CategoryModel
    {
        public long CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null;
        public List<LinkModel> Links { get; set; } = null!;
    }
}
