using System.Windows;
using System.Data.SQLite;
using System.Data;
using Microsoft.Win32;
using System.IO;

namespace OrderMasters

{
    public partial class MainWindow : Window
    {
        //Zmienne do zpaisu danych w bazie
        private SQLiteDataAdapter DataA = null;
        private DataSet DataS = null;
        private DataTable Datat = null;

        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
            //Połączenie z bazą i odczyt danych
            SQLiteConnection SQLC = new SQLiteConnection("Data Source=OList.s3db");
            SQLiteCommand Command = SQLC.CreateCommand();
            Command.CommandText = "SELECT * FROM ListOrder";
            DataA = new SQLiteDataAdapter(Command.CommandText,SQLC);
            SQLiteCommandBuilder oCommandBuilder = new SQLiteCommandBuilder(DataA);
            DataS = new DataSet();
            DataA.Fill(DataS);
            Datat = DataS.Tables[0];
            lstItems.DataContext =Datat.DefaultView;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Dodanie danych z pól do bazy danych
            DataRow DataR =Datat.NewRow();
            DataR[0] = 1;
            DataR[1] = NameProduct.Text;
            DataR[2] = int.Parse(QTY.Text);
            DataR[3] = int.Parse(PrieceP.Text);
            DataR[4] = ((int.Parse(QTY.Text))*(int.Parse(PrieceP.Text)));
            Datat.Rows.Add(DataR);
            DataA.Update(DataS);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Usunięcie danych z bazy, pozycji poprzez zliczanie która to pozycja jest zaznaczona. 
            if (0 == lstItems.SelectedItems.Count)
            {
                return;
            }
            DataRow DataR = ((DataRowView)lstItems.SelectedItem).Row;
            DataR.Delete();
            DataA.Update(DataS);
        }

        private void Window_Closing(object sender,
            System.ComponentModel.CancelEventArgs e)
        {

            //Zamknięcie okna
            if (null != DataA)
            {
                DataA.Dispose();
                DataA = null;
            }
        }
        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            //Zapis danych do pliku
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, NameProduct.Text);
        }
        private void LstItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //potrzebne do zanznaczania elelmtów do usunięcia. 
        }
    }
}
