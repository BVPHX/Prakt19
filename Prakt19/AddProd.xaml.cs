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

namespace Prakt19
{
    /// <summary>
    /// Логика взаимодействия для AddProd.xaml
    /// </summary>
    public partial class AddProd : Window
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }
        public string TrainerMiddleName { get; set; }
        public string CountryName { get; set; }
        public int Rating1 { get; set; }
        public int Rating2 { get; set; }
        public int Rating3 { get; set; }
        public int Rating4 { get; set; }
        public int Rating5 { get; set; }

        public AddProd()
        {

            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int _)) return;
            e.Handled = true;
        }

        private void FilledAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FirstName = tbName.Text;
                MiddleName = tbMiddleName.Text;
                LastName = tbLastName.Text;
                Gender = tbGender.Text;
                BirthDate = (DateTime)dpDateBirth.SelectedDate;
                TrainerFirstName = tbTrainerName.Text;
                TrainerLastName = tbTrainerLastName.Text;
                TrainerMiddleName = tbTrainerMiddleName.Text;
                CountryName = tbCountryName.Text;
                Rating1 = Convert.ToInt32(tbRating1.Text);
                Rating2 = Convert.ToInt32(tbRating2.Text);
                Rating3 = Convert.ToInt32(tbRating3.Text);
                Rating4 = Convert.ToInt32(tbRating4.Text);
                Rating5 = Convert.ToInt32(tbRating5.Text);
DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
                Close();
            }
            
            Close();
        }
    }
}
