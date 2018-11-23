namespace My_Calc.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using My_Calc.Resources;

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