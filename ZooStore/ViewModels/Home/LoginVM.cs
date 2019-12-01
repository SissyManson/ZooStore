using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooStore.ViewModels.Home
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
    }
}