// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnishCeDev.TaskManagement.Data.DataModels
{
    public class Priority
    {
        public long? PriorityId { get; set; }
        public string Name { get; set; } = null!;
        public int Ordinal { get; set; }
        public List<Link> Links { get; set; } = new List<Link>();
    }

}
