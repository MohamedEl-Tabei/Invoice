﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.DTOs
{
    public class CategoryDTOCreate
    {
        [Description("Name is required. Please use letters and spaces only.")]
        public string Name { get; set; }
    }
}
