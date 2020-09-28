using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class ReactTypes : IEntity
    {
        public ReactTypes()
        {
            UserCommentReacts = new HashSet<UserCommentReacts>();
            UserPostReacts = new HashSet<UserPostReacts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserCommentReacts> UserCommentReacts { get; set; }
        public virtual ICollection<UserPostReacts> UserPostReacts { get; set; }
    }
}
