using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RoutingSample.Models
{
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        public string Category { get; set; }
        [DisplayName("Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [DisplayName("Available Date")]
        public DateTime AvailableDate { get; set; }
    }
}