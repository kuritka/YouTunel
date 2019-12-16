using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace YouTunelPutty20._Client.ViewModel
{
    internal class MvvmBase : INotifyPropertyChanged
    {

        public void NotifyOnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        internal void NotifyOnPropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = ((MemberExpression) property.Body).Member.Name;
            NotifyOnPropertyChanged(name);            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
