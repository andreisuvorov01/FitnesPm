using FitnesPmSuvorov.ViewModel;
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

namespace FitnesPmSuvorov.View
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            
            this.DataContext = new ViewModel.AuthVM();
        }
        
        private void BtnVhod_Click(object sender, RoutedEventArgs e)
        {

            (DataContext as AuthVM).password = Password.Password.ToString();
            AuthVM authVM = new AuthVM();
            authVM.AuthSuccess += AuthVM_AuthSuccess;
            (DataContext as AuthVM).AuthInApp();
            this.Close();
        }
        private void AuthVM_AuthSuccess(object sender, bool e)
        {
            MessageBox.Show("Авторизация прошла успешно!");
            this.Close();
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
