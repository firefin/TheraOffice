using Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class InsuranceManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public InsuranceViewModel? SelectedInsurance { get; set; }
        public ObservableCollection<InsuranceViewModel> InsurancesObservableCollection
        {
            get => new ObservableCollection<InsuranceViewModel>(InsuranceServiceProxy.Current.Insurances.Where(i => i != null).Select(i => new InsuranceViewModel(i)));
        }
        public void DeleteInsurance()
        {
            if (SelectedInsurance == null) return;

            InsuranceServiceProxy.Current.RemoveInsurance(SelectedInsurance.Id);
            Refresh();
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(InsurancesObservableCollection));
        }

    }
}
