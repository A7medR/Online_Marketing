using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebApplication2.Models
    {
        public class Cart
        {
            [Key]
            [ForeignKey("Product")]
            public int product_id { get; set; }
            public DateTime added_at { get; set; }
            public virtual Product Product { get; set; }

            public string PassedDate
            {
                get
                {
                    return AppManager.calculateDateDiff(added_at, DateTime.Now);
                }
            }
        }

        class AppManager
        {
            public static string calculateDateDiff(DateTime d1, DateTime d2)
            {
                var dateDif = d2.Subtract(d1);
                if (dateDif.TotalHours < 1)
                {
                    return Convert.ToInt32(dateDif.TotalMinutes) + " Minutes ago";

                }

                else if (dateDif.TotalDays < 1)
                {
                    return Convert.ToInt32(dateDif.TotalHours) + " Hours ago";
                }
                else if (dateDif.TotalDays > 1 && dateDif.TotalDays < 7)
                {
                    return Convert.ToInt32(dateDif.TotalDays) + " Days  ago";

                }
                else if (dateDif.TotalDays >= 7)
                {
                    return Convert.ToInt32((dateDif.TotalDays / 7.0)) + " Weeks ago";

                }
                return "";
            }
        }
    }

