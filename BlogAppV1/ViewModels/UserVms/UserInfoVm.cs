using BlogAppV1.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels
{
    public class UserInfoVm
    {
        public int Id { get; set; }

        [Required]
        [Remote("IsTaken", "Account",
            ErrorMessage = "Username is already in use (forgot account?).")] // nu merge
        [MinLength(4, ErrorMessage = "Must have at least 4 characters.")]
        [MaxLength(30, ErrorMessage = "Must have less than 30 characters.")]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        [Remote("IsTaken", "Account",
            ErrorMessage = "Email is already in use (forgot account?).")] // nu merge
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? Birthdate { get; set; }
        public byte? Gender { get; set; }

        public Media Photo { get; set; }

        public int FriendState { get; set; }
    }
}
