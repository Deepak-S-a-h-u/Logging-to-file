﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emp_Dep_Dsg_Assignment.DTO
{
    public class DesignationDto
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Please Enter Designation")]
        [Display(Name = "Designation")]

        public string DsgName { get; set; }
    }
}
