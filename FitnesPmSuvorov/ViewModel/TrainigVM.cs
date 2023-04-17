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
    public class TrainigVM : BaseVm
    {
        #region привязка полей
        public trainig _SelectedTraining;
        private ObservableCollection<trainig> _Trainig;

        public trainig SelectedTraining
        {
            get => _SelectedTraining;
            set
            {
                _SelectedTraining = value;
                OnpropertyChanged(nameof(SelectedTraining));
            }
        }

        public ObservableCollection<trainig> Trainig
        {
            get => _Trainig;
            set
            {
                _Trainig = value;
                OnpropertyChanged(nameof(Trainig));
            }
        }
        #endregion

        public TrainigVM()
        {
            Trainig = new ObservableCollection<trainig>();

            LoadData();
        }

        public void LoadData()
        {
            if (_Trainig.Count > 0)
            {
                _Trainig.Clear();
            }

            var result = DbSingleTone.Db_s.trainig.ToList();

            result.ForEach(a => Trainig.Add(a));
        }

        public void DeleteTrainig()
        {
            if (!(SelectedTraining is null))
            {
                using (var db = new FitnessPmEntities1())
                {
                    var result = MessageBox.Show("вы действительно хотите удалить этот элемент?", "предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            var TrainigForDelete = db.trainig.Find(SelectedTraining.id);
                            if (TrainigForDelete != null)
                            {
                                db.trainig.Remove(TrainigForDelete);
                                db.SaveChanges();
                                SelectedTraining = null;
                                LoadData();
                                MessageBox.Show("тренировка успешно удалена", "успешно", MessageBoxButton.OK, MessageBoxImage.Information);
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
