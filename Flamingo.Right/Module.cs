using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class Module
    {
        int id;

        public int Id
        {
            get { return id; }
            internal set { id = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            internal  set { name = value; }
        }

        bool canUse;

        internal bool CanUse
        {
            get { return canUse; }
            set { canUse = value; }
        }

        public override bool Equals(object obj)
        {
            Module m = obj as Module;
            if (m == null) 
            {
                return false;
            }
            if (id == m.id) 
            {
                return true;
            }
            return false;
        }
    }
}
