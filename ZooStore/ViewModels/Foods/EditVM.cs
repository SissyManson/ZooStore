using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooStore.ViewModels.Foods
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Type: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Type { get; set; }

        [DisplayName("Quantity: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public double Quantity { get; set; }

        [DisplayName("Price: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public decimal Price { get; set; }
    }
}