using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class OrderedProduct : BaseEntity
    {
        [Display(ResourceType = typeof(Labels), Name = "Product")]
        [Required(ErrorMessageResourceName = "ReferenceRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public Product Product { get; set; }

        [Range(1, double.MaxValue, ErrorMessageResourceName = "IncorrectQuantityError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public int Quantity { get; set; }
    }
}