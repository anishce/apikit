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
    public class Link
    {
        public string Rel { get; set; } = null!;
        public string Href { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
