using InternetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetApp.ViewModel
{
    public class ProductCart
    {
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}