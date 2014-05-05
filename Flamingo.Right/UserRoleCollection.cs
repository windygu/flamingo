using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class UserRoleCollection
    {
        IList<Role> roles = new List<Role>();

        public bool HaveRole(Role role)
        {
            foreach (Role ro in roles)
            {
                if (role.Equals(ro))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddRole(Role role)
        {
            if (!HaveRole(role))
            {
                roles.Add(role);
            }
        }

        public void DeleteRole(Role role)
        {
            for (int i = 0; i < roles.Count; i++)
            {
                if (role.Equals(roles[i]))
                {
                    roles.RemoveAt(i);
                }
            }
        }

        public int Count
        {
            get { return roles.Count; }
        }

        public Role this[int i]
        {
            get { return roles[i]; }
        }
    }
}
