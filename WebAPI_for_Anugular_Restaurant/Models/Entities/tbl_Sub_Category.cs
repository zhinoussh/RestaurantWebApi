using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI_for_Anugular_Restaurant.Models
{
    public class tbl_Sub_Category
    {
        [Key]
        public int SubCategoryID { get; set; }
        public int? CategoryID { get; set; }
        public String SubCategoryName { get; set; }
        public double price { get; set; }
        public String Description { get; set; }

        [ForeignKey("CategoryID")]
        public tbl_Meals_Category Category { get; set; }


    }
}