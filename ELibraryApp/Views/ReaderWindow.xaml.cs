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
using System.Windows.Shapes;

namespace ELibraryApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ReaderWindow.xaml
    /// </summary>
    public partial class ReaderWin : Window
    {
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();
        int _readerId;

        public ReaderWin(int readerId)
        {
            InitializeComponent();
            BooksDataGrid.ItemsSource = eLibraryDBEntities.Books.ToList();
            HistoryDataGrid.ItemsSource = eLibraryDBEntities.BookReservationJournals.ToList();
            _readerId = readerId;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
