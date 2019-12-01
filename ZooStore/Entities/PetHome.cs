using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooStore.Entities
{
    public class PetHome
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
    }
}