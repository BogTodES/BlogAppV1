using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.Entities.DTOs
{
    public class CommentInfoDto
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public int CommenterId { get; set; }
        public string CommenterUsername { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public string Body { get; set; }
        public IEnumerable<UserCommentReacts> Reacts { get; set; }
    }
}
