using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int number_of_products { get; set; }
    }
}