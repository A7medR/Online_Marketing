using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "you have to enter this name")]
        public string name { get; set; }
        [Required(ErrorMessage = "you have to enter this price")]
        public float price { get; set; }
        [Required(ErrorMessage = "you have to enter this image")]
        public string image { get; set; }
        [Required(ErrorMessage = "you have to enter this description")]
        public string description { get; set; }


        [Required(ErrorMessage = "you have to enter this Category")]
        [Display(Name = "Category")]
        [ForeignKey("category")]
        public int Category_id { get; set; }
        public virtual Category category { get; set; }
        public virtual Cart cart { get; set; }

    }
}