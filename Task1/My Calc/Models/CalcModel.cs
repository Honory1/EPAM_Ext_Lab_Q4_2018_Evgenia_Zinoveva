namespace My_Calc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using My_Calc.Resources;

    public class CalcModel
    {
        [Display(Name = "x", ResourceType = typeof(CalcResources))]
        [Required]
        public double X { get; set; }

        [Display(Name = "y", ResourceType = typeof(CalcResources))]
        [Required]
        public double Y { get; set; }

        [Display(Name = "Result", ResourceType = typeof(CalcResources))]
        public string Result { get; set; }

        [Display(Name = "OpName", ResourceType = typeof(CalcResources))]
        public Operation Op { get; set; }

        [Display(Name = "Error", ResourceType = typeof(CalcResources))]
        public string Error { get; set; }
    }
}