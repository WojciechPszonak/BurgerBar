using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Model
{
    public class BurgerIngredient
    {
        public long Id { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "Burger")]
        [Required(ErrorMessageResourceName = "ReferenceRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public Burger Burger { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "Ingredient")]
        [Required(ErrorMessageResourceName = "ReferenceRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public Ingredient Ingredient { get; set; }

        public short Position { get; set; }
    }
}
