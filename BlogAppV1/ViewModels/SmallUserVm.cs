using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels
{
    public class SmallUserVm
    {
        /*[Required]
        [MinLength(4, ErrorMessage ="Must have at least 4 characters.")]
        [MaxLength(30, ErrorMessage = "Must have less than 30 characters.")]
        public string Username { get; set; }*/

        [Required]
        //[DataType(DataType.EmailAddress)]
        [Remote("IsTaken", "Account", ErrorMessage = "Email is already in use (forgot password?).")] // nu merge
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage="Must have at least 5 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool AreCredentialsInvalid { get; set; }
    }
}
