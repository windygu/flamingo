using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class Permission
    {
        int permissionId;

        public int PermissionId
        {
            get { return permissionId; }
            internal set { permissionId = value; }
        }

        Module module;

        public Module Module
        {
            get { return module; }
            internal set { module = value; }
        }

        string permissionName;

        public string PermissionName
        {
            get { return permissionName; }
            internal set { permissionName = value; }
        }

        int parentPermissionId = 0;

        public int ParentPermissionId
        {
            get { return parentPermissionId; }
            internal set { parentPermissionId = value; }
        }

        public override bool Equals(object obj)
        {
            Permission per = obj as Permission;
            if (per == null) 
            {
                return false;
            }
            if (permissionName == per.permissionName && permissionId == per.permissionId) 
            {
                return true;
            }
            return false;
        }
    }
}
