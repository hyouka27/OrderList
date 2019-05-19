using OrderList.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderList.Command
{
    class CreateItem : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is OrdelListView itemList)
            {
                itemList.Product.Add(new OrdelView() { Name = itemList.ProductName, Ended= false });
            }
        }
    }
}
