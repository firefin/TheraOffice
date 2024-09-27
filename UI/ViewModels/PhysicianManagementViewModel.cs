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
    public class PhysicianManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PhysicianViewModel? SelectedPhysician { get; set; }

        public ObservableCollection<PhysicianViewModel> PhysiciansObservableCollection
        {
            get => new ObservableCollection<PhysicianViewModel>(PhysicianServiceProxy.Current.Physicians.Where(p => p != null).Select(p => new PhysicianViewModel(p)));
        }

        public void Delete()
        {
            if(SelectedPhysician == null) return;

            PhysicianServiceProxy.Current.RemovePhysician(SelectedPhysician.Id);
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(PhysiciansObservableCollection));
        }
    }
}
