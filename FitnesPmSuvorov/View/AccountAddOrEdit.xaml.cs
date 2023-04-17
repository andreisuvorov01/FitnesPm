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
    
    public partial class AccountAddOrEdit : Window
    {
        private Account _account;
        private readonly AccountVM _accountVM;
        public AccountAddOrEdit(Account account)
        {
            InitializeComponent();
            _accountVM = new AccountVM();

            foreach (var item in App.Current.Windows)
            {
                if (item is MainWindow)
                {
                    this.Owner = item as Window;
                }
            }
            if(account is null)
            {
                _account = account = new Account();
            }
            else
            {
                _account = account;
            }
            this.DataContext = _account;
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FitnessPmEntities1())
            {
                try
                {
                    db.Account.AddOrUpdate(_account);
                    db.SaveChanges();
                    MessageBox.Show("данные успешно сохранены", "успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    _accountVM.LoadData();


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
