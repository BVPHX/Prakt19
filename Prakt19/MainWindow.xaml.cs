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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prakt19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public TennisRatingDB db = new TennisRatingDB();
        AddProd add;
        EditRecord editRecord = new EditRecord();
        public MainWindow()
        {
            InitializeComponent();
            db.Rating.Load();
            mainGrid.ItemsSource = db.Rating.Local.ToBindingList();
            if (mainGrid.SelectedIndex == -1)
            {
                bDelete.IsEnabled = false;
                bChange.IsEnabled = false;
            }
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            add = new AddProd();
            Rating entry = new Rating();
            if (add.ShowDialog() == false) return;
            else
            {
                entry.FirstName = add.FirstName;
                entry.MiddleName = add.MiddleName;
                entry.LastName = add.LastName;
                entry.Gender = add.Gender;
                entry.BrithDate = add.BirthDate.Date;
                entry.TrainerFirstName = add.TrainerFirstName;
                entry.TrainerLastName = add.TrainerLastName;
                entry.TrainerMiddleName = add.TrainerMiddleName;
                entry.CountryName = add.CountryName;
                entry.Rating1 = add.Rating1;
                entry.Rating2 = add.Rating2;
                entry.Rating3 = add.Rating3;
                entry.Rating4 = add.Rating4;
                entry.Rating5 = add.Rating5;

                db.Rating.Add(entry);
                db.SaveChanges();



                mainGrid.Items.Refresh();
            }
        }

        private void ChangeRecord_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = mainGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Rating row = (Rating)mainGrid.Items[indexRow];
                editRecord = new EditRecord();
                if (editRecord.ShowDialog() == false) return;

                else
                {
                    row = db.Rating.Find(indexRow);

                    row.FirstName = add.FirstName;
                    row.MiddleName = add.MiddleName;
                    row.LastName = add.LastName;
                    row.Gender = add.Gender;
                    row.BrithDate = add.BirthDate.Date;
                    row.TrainerFirstName = add.TrainerFirstName;
                    row.TrainerLastName = add.TrainerLastName;
                    row.TrainerMiddleName = add.TrainerMiddleName;
                    row.CountryName = add.CountryName;
                    row.Rating1 = add.Rating1;
                    row.Rating2 = add.Rating2;
                    row.Rating3 = add.Rating3;
                    row.Rating4 = add.Rating4;
                    row.Rating5 = add.Rating5;

                    db.SaveChanges();
                    mainGrid.Items.Refresh();
                }
            }
            else MessageBox.Show("Не выбрана запись");
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {

            //if (mainGrid.SelectedIndex != -1)
            //{
            //    Rating row = (Rating)mainGrid.Items[mainGrid.SelectedIndex];
            //    var res = MessageBox.Show("Вы уверены что хотите удалить запись?", "Удаление записи", MessageBoxButton.YesNo);
            //    if (res == MessageBoxResult.Yes)
            //    {
            //        db.Rating.Remove(row);
            //        db.SaveChanges();
            //        mainGrid.Items.Refresh();
            //    }
            //    else return;
            //}

            Rating row = (Rating)mainGrid.Items[mainGrid.SelectedIndex];
            int del = db.Database.ExecuteSqlCommand($"DELETE FROM Rating WHERE PlayerID={row.PlayerID}");
            mainGrid.ItemsSource = db.Rating.ToList();
        }

        private void GridSelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (mainGrid.SelectedIndex != -1)
            {
                bDelete.IsEnabled = true;
                bChange.IsEnabled = true;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SortRating1_click(object sender, RoutedEventArgs e)
        {
            var list = from temp in db.Rating orderby temp.Rating1 select temp;
            mainGrid.ItemsSource = list.ToList();
        }
        private void SortRating2_click(object sender, RoutedEventArgs e)
        {
            var list = from temp in db.Rating orderby temp.Rating2 select temp;
            mainGrid.ItemsSource = list.ToList();
        }
        private void SortRating3_click(object sender, RoutedEventArgs e)
        {
            var list = from temp in db.Rating orderby temp.Rating3 select temp;
            mainGrid.ItemsSource = list.ToList();
        }
        private void SortRating4_click(object sender, RoutedEventArgs e)
        {
            var list = from temp in db.Rating orderby temp.Rating4 select temp;
            mainGrid.ItemsSource = list.ToList();
        }
        private void SortRating5_click(object sender, RoutedEventArgs e)
        {
            var list = from temp in db.Rating orderby temp.Rating5 select temp;
            mainGrid.ItemsSource = list.ToList();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
 
            var query = db.Database.ExecuteSqlCommand("UPDATE Rating");
            mainGrid.Items.Refresh();
        }
    }
}
