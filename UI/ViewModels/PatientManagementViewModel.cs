using Library.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UI.ViewModels
{
    public class PatientManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PatientViewModel? SelectedPatient { get; set; }

        public ObservableCollection<PatientViewModel> PatientsObservableCollection
        {
            get => new ObservableCollection<PatientViewModel>(PatientServiceProxy.Current.Patients.Where( p => p != null).Select( p => new PatientViewModel(p)));
        }
        public void DeletePatient()
        {
            if (SelectedPatient == null) return;

            PatientServiceProxy.Current.RemovePatient(SelectedPatient.Id);
            Refresh();
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(PatientsObservableCollection));
        }
    }
}
