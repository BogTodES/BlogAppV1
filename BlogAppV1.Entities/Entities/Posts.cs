using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Posts : IEntity
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
            UserPostReacts = new HashSet<UserPostReacts>();
        }

        public long Id { get; set; }
        public long SectionId { get; set; }
        public long? PhotoId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public virtual Media Photo { get; set; }
        public virtual Sections Section { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<UserPostReacts> UserPostReacts { get; set; }
    }
}
