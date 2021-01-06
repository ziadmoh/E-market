using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InternetApp.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Product Name Can Not Be Empty")]
        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "You Have Exceed The Maximum Amount Of Characters")]
        [MinLength(5, ErrorMessage = "The Product Name At Least Must Consist Of 5 Characters")]
        [Display(Name = "Product Name")]
        [Index(IsUnique = true)]
        public String name { get; set; }
        [Required(ErrorMessage = "You Have To Enter Your Price Of Product")]
        [Display(Name = "Price")]
        public float price { get; set; }
       
        [Display(Name = "Image")]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        public String image { get; set; }


        [Required(ErrorMessage = "Description Can Not Be Empty")]
        [MinLength(10, ErrorMessage = "Description At Least Must Consist Of 10 Characters")]
        [Display(Name = "Description")]

        public String description { get; set; }



        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "You Have To Enter Your Category Of Product")]
        [Display(Name = "Category")]
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

    }
}