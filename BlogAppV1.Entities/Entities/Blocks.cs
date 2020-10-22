using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Blocks : IEntity
    {
        public int SenderId { get; set; }
        public int BlockedId { get; set; }

        public virtual Users Blocked { get; set; }
        public virtual Users Sender { get; set; }
    }
}
