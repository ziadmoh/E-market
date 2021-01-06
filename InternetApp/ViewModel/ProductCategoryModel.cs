using InternetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApp.ViewModel
{
    public class ProductCategoryModel
    { 
        public Product Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
}