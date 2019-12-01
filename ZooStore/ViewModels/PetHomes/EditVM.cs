using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooStore.ViewModels.PetHomes
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Type: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Type { get; set; }

        [DisplayName("Size: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Size { get; set; }

        [DisplayName("Material: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Material { get; set; }

        [DisplayName("Price: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public decimal Price { get; set; }
    }
}