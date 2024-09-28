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
        public string? MiddleName { get; set; } = null;
        public string LastName { get; set; } = null!;
        public string UserName = null!;
        public string Password = null!;
        public UserContactModel Contact =null!;
        //repeated UserAddressMessage addresses=8;
        public bool IsActive { get; set; }
        public string? Remarks { get; set; } = null;
        public string CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public string? ModifiedBy { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;

        public int? RoleId { get; set; } = null!;
    }
}
