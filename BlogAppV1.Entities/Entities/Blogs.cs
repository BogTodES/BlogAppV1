using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Blogs : IEntity
    {
        public Blogs()
        {
            BlogsSections = new HashSet<BlogsSections>();
        }

        public long Id { get; set; }
        public int UserId { get; set; }
        public long? PhotoId { get; set; }
        public string Title { get; set; }
        public int? StylePage { get; set; }

        public virtual Media Photo { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<BlogsSections> BlogsSections { get; set; }
    }
}
