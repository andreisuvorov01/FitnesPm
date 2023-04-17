using FitnesPmSuvorov.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnesPmSuvorov.ViewModel
{

    public class AccountVM : BaseVm
    {
        public Account _SelectedAccount;
        public ObservableCollection<Account> _Accounts;

        public Account SelectedAccount
        {
            get => _SelectedAccount;
            set
            {
                _SelectedAccount = value;
                OnpropertyChanged(nameof(SelectedAccount));
            }
        }

        public ObservableCollection<Account> Accounts
        {
            get => _Accounts;
            set
            {
                _Accounts = value;
                OnpropertyChanged(nameof(Accounts));
            }
        }
        public AccountVM()
        {
            Accounts = new ObservableCollection<Account>();

            LoadData();
        }

        public void LoadData()
        {
            if(_Accounts.Count > 0)
            {
                _Accounts.Clear();
            }

            var result = DbSingleTone.Db_s.Account.ToList();
            result.ForEach(account => Accounts.Add(account));
        }

        public void DeleteTrainig()
        {
            if (!(SelectedAccount is null))
            {
                using (var db = new FitnessPmEntities1())
                {
                    var result = MessageBox.Show("вы действительно хотите удалить этот элемент?", "предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            var AccountForDelete = db.Account.Find(SelectedAccount.id);
                            if (AccountForDelete != null)
                            {
                                db.Account.Remove(AccountForDelete);
                                db.SaveChanges();
                                SelectedAccount = null;
                                LoadData();
                                MessageBox.Show("аккаунт успешно удалена", "успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите объект для удаения", "предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
