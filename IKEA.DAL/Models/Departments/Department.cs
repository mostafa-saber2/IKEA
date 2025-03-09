﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departments
{
    public class Department:ModelBase
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Code { get; set; }=null!;
        [Display(Name="Creation Date ")]
        public DateOnly CreationDate {  get; set; }


    }
}
