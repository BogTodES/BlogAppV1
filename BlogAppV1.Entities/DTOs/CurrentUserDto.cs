using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.Entities.DTOs
{
    public class CurrentUserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
