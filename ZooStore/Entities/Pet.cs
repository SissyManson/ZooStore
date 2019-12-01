using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooStore.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string FurType { get; set; }
        public int Age { get; set; }
        public int LifeSpan { get; set; }
        public DateTime HereFrom { get; set; }
    }
}