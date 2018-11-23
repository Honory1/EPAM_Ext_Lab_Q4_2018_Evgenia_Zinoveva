using My_Calc.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Calc.Models
{
    public enum Operation
    {
        [Display(Name = "Add", ResourceType = typeof(CalcResources))]
        Add,

        [Display(Name = "Deduct", ResourceType = typeof(CalcResources))]
        Deduct,

        [Display(Name = "Share", ResourceType = typeof(CalcResources))]
        Share,

        [Display(Name = "Multiply", ResourceType = typeof(CalcResources))]
        Multiply
    }
}