// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.Odata.Api.Models
#pragma warning restore VSSpell001 // Spell Check
#pragma warning restore VSSpell001 // Spell Check
{
    public class StatusModel
    {
        public long StatusId { get; set; }
        public string Name { get; set; } = null!;
        public int Ordinal { get; set; }
        public List<LinkModel> Links { get; set; } = null!;
    }
}
