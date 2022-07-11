using UnityTools.Runtime.UI;

namespace ImportantPrototype.Tools.UI
{
    public abstract class ListItemView : Element { }
    
    public abstract class ListItemView<T> : ListItemView
    {
        public abstract void Bind(T data);
    }
}