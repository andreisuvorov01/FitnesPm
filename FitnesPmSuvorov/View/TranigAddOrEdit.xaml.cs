using FitnesPmSuvorov.DB;
using FitnesPmSuvorov.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace FitnesPmSuvorov.View
{
    /// <summary>
    /// Логика взаимодействия для TranigAddOrEdit.xaml
    /// </summary>
    public partial class TranigAddOrEdit : Window
    {
        private trainig _trainig;
        private readonly TrainigVM _treningVM;
        public TranigAddOrEdit( trainig trainig)
        {
            InitializeComponent();
            _treningVM = new TrainigVM();
            foreach (var item in App.Current.Windows)
            {
                if (item is MainWindow)
                {
                    this.Owner = item as Window;
                }
            }
            if (trainig is null)
            {
                _trainig = trainig = new trainig();
            }
            else
            {
                _trainig = trainig;
            }
            this.DataContext = _trainig;
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FitnessPmEntities1())
            {
                try
                {
                    db.trainig.AddOrUpdate(_trainig);
                    db.SaveChanges();
                    MessageBox.Show("данные успешно сохранены", "успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    _treningVM.LoadData();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
