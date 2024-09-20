using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;

namespace UI.ViewModels
{
    public class PatientManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Patient? SelectedPatient { get; set; }

        public ObservableCollection<Patient> PatientsObservableCollection
        {
            get
            {
                return new ObservableCollection<Patient>(PatientServiceProxy.Current.Patients);
            }
        }
        public void DeletePatient()
        {
            if (SelectedPatient == null) return;
            PatientServiceProxy.Current.RemovePatient(SelectedPatient.Id);
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(PatientsObservableCollection));
        }
    }
}
