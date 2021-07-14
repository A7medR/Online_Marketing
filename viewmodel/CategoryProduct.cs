using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.viewmodel
{
    public class CategoryProduct
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }
    }
}