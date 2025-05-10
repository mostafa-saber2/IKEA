﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departments
{
   public class CreatedDepartmentDTO
    {
        [Required(ErrorMessage = "Name is required!!")]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Required(ErrorMessage ="Code is required!!")]
        public string Code { get; set; } = null!;
        [Display(Name="Date of Creation")]
        public DateOnly CreationDate { get; set; }
    }
}
