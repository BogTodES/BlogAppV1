using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Permissions : IEntity
    {
        public Permissions()
        {
            RolesPermissions = new HashSet<RolesPermissions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RolesPermissions> RolesPermissions { get; set; }
    }
}
