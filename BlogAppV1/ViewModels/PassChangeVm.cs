using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels
{
    public class PassChangeVm
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Must have at least 5 characters")]
        public string NewPassword { get; set; }
    }
}
