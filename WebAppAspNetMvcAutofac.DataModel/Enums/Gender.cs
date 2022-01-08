using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public enum Gender
    {
        [Display(Name = "Женский")]
        Female = 1,

        [Display(Name = "Мужской")]
        Male = 2,
    }
}