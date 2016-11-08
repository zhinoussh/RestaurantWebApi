using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_for_Anugular_Restaurant.Models
{
    // Model used as parameters to MealCategoryController actions.

    public class tbl_Meals_Category
    {
        [Key]
        public int pkey { get; set; }

        [Required]
        public string meal_name { get; set; }

       
    }
}