using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Media : IEntity
    {
        public Media()
        {
            Blogs = new HashSet<Blogs>();
            Posts = new HashSet<Posts>();
            Sections = new HashSet<Sections>();
            Users = new HashSet<Users>();
        }

        public long Id { get; set; }
        public byte[] Content { get; set; }

        public virtual ICollection<Blogs> Blogs { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Sections> Sections { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
