using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Prakt19
{
    /// <summary>
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        TennisRatingDB db = new TennisRatingDB();

        public AuthWin()
        {
            InitializeComponent();
            db.Auth.Load();
        }

        private void AuthAttempt(object sender, RoutedEventArgs e)
        {
            var user = db.Auth.Where(l => l.UserLogin == tbLoginInput.Text).FirstOrDefault();


            if (user != null)
            {
                if (user.UserPassword == pbPassInput.Password)
                {
                    DialogResult = true;
                    Close();
                }
            }
            else
            {

                MessageBox.Show("Неверный логин или пароль");
            }
        }



        private void Exit(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
