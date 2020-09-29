using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class BlogsSections : IEntity
    {
        public long BlogId { get; set; }
        public long SectionId { get; set; }

        public virtual Blogs Blog { get; set; }
        public virtual Sections Section { get; set; }
    }
}
