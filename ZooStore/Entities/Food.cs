using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooStore.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
    }
}