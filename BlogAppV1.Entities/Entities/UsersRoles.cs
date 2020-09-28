using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class UsersRoles : IEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
