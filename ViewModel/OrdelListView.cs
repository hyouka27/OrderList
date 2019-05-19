using OrderList.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderList.ViewModel
{
    class OrdelListView : INotifyPropertyChanged
    {
        private ObservableCollection<OrdelView> product = new ObservableCollection<OrdelView>();

        public ObservableCollection<OrdelView> Product
        {
            get { return product; }
            set {
                if (product != value)
                {
                    product = value;
                    NotifyPropertyChanged(nameof(Product));
                }
            }
        }
        public string ProductName { get; set; }
        public ICommand CreateItem { get { return new CreateItem(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
