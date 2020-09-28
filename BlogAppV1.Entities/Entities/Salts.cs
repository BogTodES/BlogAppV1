using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Salts : IEntity
    {
        public int UserId { get; set; }
        public string Salt { get; set; }

        public virtual Users User { get; set; }
    }
}
