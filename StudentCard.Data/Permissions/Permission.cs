using StudentCard.Data.Common.Interfaces;
using System.Collections.Generic;

namespace StudentCard.Data.Permissions
{
    public class Permission : IEntity
    {
        public int Id { get; set; }

        public List<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
    }
}
