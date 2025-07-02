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
    public class UserModel
    {
        public long UserId { get; set; }
#pragma warning disable VSSpell001 // Spell Check
        public string Username { get; set; } = null!;
#pragma warning restore VSSpell001 // Spell Check
#pragma warning disable VSSpell001 // Spell Check
        public string Firstname { get; set; } = null!;
#pragma warning restore VSSpell001 // Spell Check
#pragma warning disable VSSpell001 // Spell Check
        public string Lastname { get; set; } = null!;
#pragma warning restore VSSpell001 // Spell Check
        public string Email { get; set; } = null!;
        public List<LinkModel> Links { get; set; } = null!;
    }
}
