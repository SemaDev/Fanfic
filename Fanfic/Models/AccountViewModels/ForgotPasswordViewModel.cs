using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Remote (action: "CheckForgetPasswordEmail", controller:"Account", ErrorMessage = "E-mail address doesn't exist")]
        public string Email { get; set; }
    }
}
