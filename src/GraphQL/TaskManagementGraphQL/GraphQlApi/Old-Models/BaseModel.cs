// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Api

#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.GraphQL.Api.Models
#pragma warning restore VSSpell001 // Spell Check
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public int version { get; set; }
    }
}
