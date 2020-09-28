using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Sections : IEntity
    {
        public Sections()
        {
            BlogsSections = new HashSet<BlogsSections>();
            Posts = new HashSet<Posts>();
        }

        public long Id { get; set; }
        public long? PhotoId { get; set; }
        public string Name { get; set; }
        public bool IsSystemCreated { get; set; }

        public virtual Media Photo { get; set; }
        public virtual ICollection<BlogsSections> BlogsSections { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
