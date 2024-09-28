// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Api

namespace AnishCeDev.TaskManagement.Web.Api.Models
{
    public class PhoneBookModel
    {
        public PhoneBookType Type { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public enum PhoneBookType
    {
        Office=1,
        Home=2
    }
}
