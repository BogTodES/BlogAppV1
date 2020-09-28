using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class UserCommentReacts : IEntity
    {
        public int UserId { get; set; }
        public long CommentId { get; set; }
        public int ReactId { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual ReactTypes React { get; set; }
        public virtual Users User { get; set; }
    }
}
