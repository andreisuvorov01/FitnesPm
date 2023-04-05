using FitnesPmSuvorov.DB;
using FitnesPmSuvorov.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnesPmSuvorov.ViewModel
{
    public class AuthVM : BaseVm
    {
        private Account _user;
        private string _BtnVhod = "войти";

        private string _login;
        private string _password;
        public string Login
        {
            get => _login; 
            set {
                _login = value;
               OnpropertyChanged(nameof(Login));
            }
        }
        public string password
        {
            get => _password;
            set
            {
                _password = value;
                OnpropertyChanged(nameof(Login));
            }
        }
        private async Task<bool> Authotize(string Login, string password)
        {
            try
            {
                var result = await DbSingleTone.Db_s.Account.FirstOrDefaultAsync(User => User.password == password && User.login == Login);
                _user = result;
                if (result != null)
                {
                    MessageBox.Show("авторизация прошла успешно", "авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("неверный логин или пароль", "авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "необработанное исключение", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
        }
        public async void AuthInApp()
        {
            if (await Authotize(Login, password))
            {
                var authWindow = new AuthWindow();
                authWindow.Close();
                var vhod = true;
            }
        }
    }
}
