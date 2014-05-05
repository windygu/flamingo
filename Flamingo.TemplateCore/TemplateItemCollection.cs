using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Flamingo.TemplateCore
{
    public class TemplateFaceItemCollection:IEnumerator
    {
        IList<TemplateFaceItem> list = new List<TemplateFaceItem>();

        internal void AddNormalItem(TemplateFaceItem item) 
        {
            if (item.TemplateItemId != -1) 
            {
                list.Add(item);
                item.Status = TemplateItemStatus.Normal;
            }
        }

        public void AddItem(TemplateFaceItem item)
        {
            list.Add(item);
            item.Status = TemplateItemStatus.New;
        }

        public void DeleteItem(TemplateFaceItem item) 
        {
            item.Status = TemplateItemStatus.Delete;
            if (item.TemplateItemId==-1) 
            {
                list.Remove(item);
            }
        }

        public TemplateFaceItem EditItem(TemplateFaceItem item) 
        {
            int i = list.IndexOf(item);
            TemplateFaceItem newItem = list[i];
            newItem.Status = TemplateItemStatus.Edit;
            if (item.TemplateItemId == -1) 
            {
                newItem.Status = TemplateItemStatus.New;
            }
            return newItem;
        }

        public int Count
        {
            get { return list.Count; }
        }

        public TemplateFaceItem this[int index]
        {
            get
            {
                return (TemplateFaceItem)list[index];
            }
        }

        int i = -1;

        #region IEnumerator 成员

        public object Current
        {
            get
            {
                return list[i];
            }
        }

        public bool MoveNext()
        {
            i++;
            if (i < list.Count) 
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            i = -1;
        }

        #endregion
    }
}
