// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Api

namespace AnishCeDev.TaskManagement.Web.Api.Models
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
