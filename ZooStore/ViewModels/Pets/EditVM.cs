using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooStore.ViewModels.Pets
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Type: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Type { get; set; }

        [DisplayName("Fur Type: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FurType { get; set; }

        [DisplayName("Age: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public int Age { get; set; }

        [DisplayName("Lifespan: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public int LifeSpan { get; set; }

        [DisplayName("Here from: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public DateTime HereFrom { get; set; }
    }
}