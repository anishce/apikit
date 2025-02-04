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
    public class PriorityModel
    {
        public long? PriorityId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Ordinal { get; set; }
        public List<LinkModel> Links { get; set; } = null!;
    }
}
