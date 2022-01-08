using Common.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class CurrencyType : EntityBase, IDataContext
    {

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Буквенный код", Order = 15)]
        public string LetterCode { get; set; }

        [Required]
        [Display(Name = "Числовой код", Order = 25)]
        public string NumericCode { get; set; }


        /// <summary>
        /// Список книг
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Book> Books { get; set; }
    }
}