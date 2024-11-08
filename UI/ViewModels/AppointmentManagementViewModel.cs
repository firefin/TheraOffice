using Library.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UI.ViewModels
{
    public class AppointmentManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AppointmentViewModel? SelectedAppointment { get; set; }

        public ObservableCollection<AppointmentViewModel> AppointmentsObservableCollection
        {
            get => new ObservableCollection<AppointmentViewModel>(AppointmentServiceProxy.Current.Appointments.Where(a => a != null).Select(a => new AppointmentViewModel(a)));
        }
        public void DeleteAppointment()
        {
            if (SelectedAppointment == null) return;

            AppointmentServiceProxy.Current.RemoveAppointment(SelectedAppointment.Id);
            Refresh();
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(AppointmentsObservableCollection));
        }
    }
}
