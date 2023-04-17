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
        public event EventHandler<bool> AuthSuccess;
        public event EventHandler<int> RoleReceived;
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
                OnpropertyChanged(nameof(password));
            }
        }
        public string BtnVhod
        {
            get => _BtnVhod;
            set
            {
                _BtnVhod=value;
                OnpropertyChanged(nameof(BtnVhod));
            }
        }
        public async void GetRoleAndPassToAnotherClass()
        {
            try
            {
                var role = await DbSingleTone.Db_s.Account.Where(User => User.login == Login).Select(User => User.role).FirstOrDefaultAsync();

                // Отправляем айди роли в другой класс
                RoleReceived?.Invoke(this, role);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Не удалось получить роль пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    var role = await DbSingleTone.Db_s.Account.Where(User => User.login == Login).Select(User => User.role).FirstOrDefaultAsync();
                    AuthSuccess?.Invoke(this, true);
                    RoleReceived?.Invoke(this, role); // Отправка айди роли в другой класс
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
            BtnVhod = "Подождите...";
            if (await Authotize(Login, password))
            {
                var authWindow = new AuthWindow();
                authWindow.Close();
                AuthSuccess?.Invoke(this, true);
               
                var vhod = true;
                BtnVhod = "Войти";
                

            }
            BtnVhod = "Войти";
        }
      
    }
}
