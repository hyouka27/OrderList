using OrderList.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace OrderList
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var itemlist = new OrdelListView();
            itemlist.Product.Add(new OrdelView() { Name = "Taks 1", Ended = false });
            itemlist.Product.Add(new OrdelView() { Name = "Taks 2", Ended = true});
            this.DataContext = itemlist;
        }
    }
}
