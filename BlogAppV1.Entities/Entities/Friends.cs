using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Friends : IEntity
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Users Receiver { get; set; }
        public virtual Users Sender { get; set; }
    }
}
