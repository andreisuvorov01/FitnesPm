using FitnesPmSuvorov.View;
using FitnesPmSuvorov.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using FitnesPmSuvorov.DB;
using System.Collections.ObjectModel;
using System.Web.UI.MobileControls;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.Windows.Threading;
using System.Web.Security;
using System.Xml.Serialization;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FitnesPmSuvorov
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Point windowCoordinates;
        private Point mouseCoordinates;
        private trainig _Trainig;
        private AuthVM _authVM;
        private bool isLogged = false;
        private AccountAddOrEdit _accountAddOrEdit;
        private TranigAddOrEdit _TranigAddOrEdit;

        private readonly TrainigVM _TrainigVM;
        private readonly AccountVM _AccountVM;
        public MainWindow()
        {
            InitializeComponent();
            Table.SelectedIndex = 0;
            
            _TrainigVM = new TrainigVM();
            _AccountVM = new AccountVM();

            _authVM = new AuthVM();
            _authVM.AuthSuccess += AuthVM_AuthSuccess;
            _authVM.RoleReceived += AuthVM_RoleRecevied;
            lstBoxMain.BorderThickness = new Thickness(0);
            list();

            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            MainFrame.Navigate(new TrainingPage { DataContext = _TrainigVM });
        }

        public void AuthVM_AuthSuccess(object sender, bool e)
        {
           
        }

        public void AuthVM_RoleRecevied(object sender, int roleId)
        {
          if (roleId == 1)
            {
                Voidite.Visibility = Visibility.Hidden;
                lstBoxMain.Visibility = Visibility.Visible;
                AllTraning.Visibility = Visibility.Visible;
                izbrannorTraning.Visibility = Visibility.Visible;

                AddButton.Visibility = Visibility.Hidden;
                EditButton.Visibility = Visibility.Hidden;
                DeleteButton.Visibility = Visibility.Hidden;
                Table.Visibility = Visibility.Hidden;
                MainFrame.Visibility = Visibility.Hidden;
            }
            else
            {
                Voidite.Visibility = Visibility.Hidden;
                lstBoxMain.Visibility = Visibility.Hidden;
                AllTraning.Visibility = Visibility.Hidden;
                izbrannorTraning.Visibility = Visibility.Hidden;

                AddButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
                Table.Visibility = Visibility.Visible;
                MainFrame.Visibility = Visibility.Visible;
            }
            isLogged = true;
        }
        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
           if(isLogged == true)
            {
                var result = System.Windows.MessageBox.Show("Вы уже вошли, сменить апккаунт?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if(_accountAddOrEdit != null)
                    {
                        _accountAddOrEdit.Close();
                    }

                    if(_TranigAddOrEdit != null)
                    {
                        _TranigAddOrEdit.Close();
                    }
                    var AuthYes = new AuthWindow();
                    AuthYes.DataContext = _authVM;
                    AuthYes.ShowDialog();
                }
            }
            else
            {
                var Auth = new AuthWindow();
                Auth.DataContext = _authVM;

                Auth.ShowDialog();
            }
           
        }
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
       
        
      

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private List<trainig> GetTrainingList()
        {
            List<trainig> trainings = new List<trainig>();

            using (var db = new FitnessPmEntities1())
            {
                var query = from t in db.trainig
                            select t;

                trainings = query.ToList();
            }

            return trainings;
        }
        private void list()
        {
            List<trainig> trainingList = GetTrainingList();
            lstBoxMain.ItemsSource = trainingList;
        }
       
        

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowNotification()
        {
            NotificationPopup.IsOpen = true;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3); // устанавливаем таймер на 3 секунды
            timer.Tick += (sender, e) =>
            {
                NotificationPopup.IsOpen = false;
                timer.Stop();
            };
            timer.Start();
        }
        private void izbrannoe_Click(object sender, RoutedEventArgs e)
              {
          
           
            trainig selectedTraining = lstBoxMain.SelectedItem as trainig;

            if (selectedTraining != null)
            {
                using (var context = new FitnessPmEntities1())
                {
                    string currentLogin = _authVM.Login;
                    string currentPassword = _authVM.password;
                    // Get the current account (assuming there's only one logged in)
                    Account currentAccount = context.Account.FirstOrDefault(a => a.login == currentLogin && a.password == currentPassword);

                    if (currentAccount != null)
                    {
                        // Check if the subscription already exists
                        subscription existingSubscription = currentAccount.subscription.FirstOrDefault(s => s.id_training == selectedTraining.id);

                        if (existingSubscription == null)
                        {
                            // Create a new subscription entity
                            subscription newSubscription = new subscription
                            {
                                id_account = currentAccount.id,
                                id_training = selectedTraining.id,
                                date_start = DateTime.Now,
                                date_end = DateTime.Now.AddDays(30)

                            };

                            // Add the subscription to the context and save changes
                            context.subscription.Add(newSubscription);
                            context.SaveChanges();
                            System.Windows.MessageBox.Show("тренировка успешно добавлена в избранное", "избранное", MessageBoxButton.OK, MessageBoxImage.Information);
                           
                        }
                        else
                        {
                            // Remove the existing subscription
                            context.subscription.Remove(existingSubscription);
                            context.SaveChanges();
                            var subscriptions = context.subscription.Where(s => s.id_account == currentAccount.id).ToList();
                            var trainingIds = subscriptions.Select(s => s.id_training).ToList();
                            var trainings = context.trainig.Where(t => trainingIds.Contains(t.id)).ToList();
                            System.Windows.MessageBox.Show("Тренировка успешно удалена","успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            lstBoxMain.ItemsSource = trainings;
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("ошибка на этапе чтения аккаунта", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("не выбран элемент", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void AllTraning_Click(object sender, RoutedEventArgs e)
        {
            list();
        }

        private void izbrannorTraning_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FitnessPmEntities1())
            {
                string currentLogin = _authVM.Login;
                string currentPassword = _authVM.password;
                // Get the current account (assuming there's only one logged in)
                Account currentAccount = context.Account.FirstOrDefault(a => a.login == currentLogin && a.password == currentPassword);
                {
                    var subscriptions = context.subscription.Where(s => s.id_account == currentAccount.id).ToList();
                    var trainingIds = subscriptions.Select(s => s.id_training).ToList();
                    var trainings = context.trainig.Where(t => trainingIds.Contains(t.id)).ToList();

                    lstBoxMain.ItemsSource = trainings;
                }

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch(Table.SelectedIndex)
            {
                case 0:
                    {
                        var TranigWindows = new TranigAddOrEdit(null);
                        TranigWindows.Show();
                    break;
                }
                case 1:
                    {
                        break;
                    }
            }
            
        }

            private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Table.SelectedIndex)
            {
                case 0:
                    {
                        var TranigWindows = new TranigAddOrEdit(_TrainigVM.SelectedTraining);
                         _TranigAddOrEdit = TranigWindows;
                        TranigWindows.Show();
                        break;
                    }
                case 1:
                    {
                        var AccountWindow = new AccountAddOrEdit(_AccountVM.SelectedAccount);
                        _accountAddOrEdit = AccountWindow;
                        AccountWindow.Show();
                        break;
                    }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Table.SelectedIndex)
            {
                case 0:
                    {
                        _TrainigVM.DeleteTrainig();                        
                        break;
                    }
                case 1:
                    {
                        _AccountVM.DeleteTrainig();
                        break;
                    }
            }
        }

        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(Table.SelectedIndex)
            {
                case 0:
                    {
                        MainFrame.Navigate(new TrainingPage { DataContext = _TrainigVM });
                        break;
                    }
            case 1:
                    {
                        MainFrame.Navigate(new AccountPage { DataContext = _AccountVM });
                        break;
                    }
            }
        }
    }
}
