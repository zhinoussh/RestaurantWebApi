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
        public tbl_Meals_Category()
        {
            SubCategory = new HashSet<tbl_Sub_Category>();
        }
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<tbl_Sub_Category> SubCategory { get; set; }
       
    }
}