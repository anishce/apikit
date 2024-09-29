// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Api

#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.Web.Api.Models
#pragma warning restore VSSpell001 // Spell Check
{
    public class UserContactModel
    {
        public IEnumerable<EmailBookModel> Emails { get; set; } = null!;
        public IEnumerable<PhoneBookModel> Phones { get; set; } = null!;
        public string? FaxNumber {  get; set; }
        public string? Remarks { get; set; }
    }
}
