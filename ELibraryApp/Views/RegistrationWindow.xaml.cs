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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWin : Window
    {
        ELibraryDBEntities eLibrary = new ELibraryDBEntities();
        User _user = new User();
        Reader _reader = new Reader();

        public RegistrationWin()
        {
            InitializeComponent();
            BirthDatePicker.DisplayDate = DateTime.Now;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                try
                {
                    _user.Login = LoginTextBox.Text;
                    _user.Password = PassTextBox.Text;
                    _user.IsBlocked = false;
                    _user.RoleId = 1;
                    eLibrary.Users.Add(_user);
                    eLibrary.SaveChanges();
                    _reader.FIO = FIOTextBox.Text;
                    _reader.BirthDate = BirthDatePicker.SelectedDate;
                    _reader.Phone = PhoneTextBox.Text;
                    _reader.IsCollegeEmployee = IsEmpCheckBox.IsChecked;
                    _reader.Rating = 0;
                    _reader.UserId = eLibrary.Users.FirstOrDefault(u => u.Login == _user.Login).UserId;
                    eLibrary.Readers.Add(_reader);
                    eLibrary.SaveChanges();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private bool ModelCheck()
        {
            string errors = "Ошибки:";
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if (string.IsNullOrEmpty(PassTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if (string.IsNullOrEmpty(FIOTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if (string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                errors += "\nЗаполните поле Логин";
            }
            if(errors == "Ошибки:")
            {
                return true;
            }
            else
            {
                MessageBox.Show(errors);
                return false;
            }
        }
    }
}
