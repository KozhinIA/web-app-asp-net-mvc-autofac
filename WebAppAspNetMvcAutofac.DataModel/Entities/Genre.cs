using Common.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class Genre : EntityBase, IDataContext
    {

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Список книг
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Book> Books { get; set; }
    }
}