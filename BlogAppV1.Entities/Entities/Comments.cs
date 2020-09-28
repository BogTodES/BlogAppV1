using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Comments : IEntity
    {
        public Comments()
        {
            UserCommentReacts = new HashSet<UserCommentReacts>();
        }

        public long Id { get; set; }
        public int UserId { get; set; }
        public long PostId { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public virtual Posts Post { get; set; }
        public virtual ICollection<UserCommentReacts> UserCommentReacts { get; set; }
    }
}
