using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.Entities.DTOs
{
    public class UserNoPass
    {
        public int Id { get; set; }
        public long? PhotoId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public byte? Gender { get; set; }


        public UserNoPass(Users user)
        {
            Id = user.Id;
            PhotoId = user.Id;
            Username = user.Username;
            Email = user.Email;
            Birthdate = user.Birthdate;
            Gender = user.Gender;
        }

    }
}
