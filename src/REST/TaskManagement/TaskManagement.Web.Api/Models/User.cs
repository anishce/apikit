// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Api

using System;

namespace AnishCeDev.TaskManagement.Web.Api.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; };
        public string LastName { get; set; } = null!;
        public string UserName = null!;
        public string Password = null!;
        public UserContactModel Contact =null!;
        repeated UserAddressMessage addresses=8;
    public bool isActive = 9;
        public string remarks = 10;
        public string createdBy = 11;
        public DateTime CreatedDate = 12;
        public string modifiedBy = 13;
        public google.protobuf.Timestamp modifiedDate = 14;
        public int32 roleId = 16;
    }
}
