using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;

namespace Besenica
{
    public class ObservableListSource<T> : ObservableCollection<T>, IListSource
           where T : class
    {
        private IBindingList mBindingList;

        bool IListSource.ContainsListCollection { get { return false; } }

        IList IListSource.GetList()
        {
            return mBindingList ?? (mBindingList = this.ToBindingList());
        }
    }
}
