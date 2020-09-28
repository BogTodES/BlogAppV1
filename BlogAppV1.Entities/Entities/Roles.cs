using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Roles : IEntity
    {
        public Roles()
        {
            RolesPermissions = new HashSet<RolesPermissions>();
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RolesPermissions> RolesPermissions { get; set; }
        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
