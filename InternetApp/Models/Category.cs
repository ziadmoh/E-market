using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternetApp.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Category Name Can Not Be Empty")]
        [MaxLength(50, ErrorMessage = "You Have Passed The Amount Of Required Number Of Characters.")]
        [MinLength(5, ErrorMessage = "Category Name At Least Must Consist Of 5 Characters.")]
        public String name { get; set; }
        public int number_of_products { get; set; }

    }
}