// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Api

#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.Web.Api.Models
#pragma warning restore VSSpell001 // Spell Check
{
    public class PhoneBookModel
    {
        public PhoneBookType Type { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public enum PhoneBookType
    {
        Office = 1,
        Home = 2
    }
}
