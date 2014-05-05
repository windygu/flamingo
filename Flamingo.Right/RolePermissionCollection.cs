using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class RolePermissionCollection
    {
        IList<Permission> permissions = new List<Permission>();

        public void AddPermission(Permission permission)
        {
            if (HavePermission(permission))
            {
                return;
            }
            permissions.Add(permission);
        }

        public bool HavePermission(Permission permission)
        {
            foreach (Permission per in permissions)
            {
                if (per.Equals(permission))
                {
                    return true;
                }
            }
            return false;
        }

        public void DeletePermission(Permission permission)
        {
            for (int i = 0; i < permissions.Count; i++)
            {
                if (permissions[i].Equals(permission))
                {
                    permissions.RemoveAt(i);
                    return;
                }
            }
        }

        public void Clear() 
        {
            permissions.Clear();
        }

        public Permission this[int i]
        {
            get
            {
                return permissions[i];
            }
        }

        public int Count
        {
            get
            {
                return permissions.Count;
            }
        }
    }
}
