// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Api

#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.Web.Api.Models
#pragma warning restore VSSpell001 // Spell Check
{
    public class EmailBookModel
    {
        public EmailBookType Type { get; set; }
        public string? Email { get; set; }
    }

    public enum EmailBookType
    {
        Official=1,
        Personal=2
    }
}
