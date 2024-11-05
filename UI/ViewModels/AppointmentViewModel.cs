using Library.Models;
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
    public class AppointmentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Appointment? Model { get; set; }

        public ObservableCollection<Patient> Patients
        {
            get => new ObservableCollection<Patient>(PatientServiceProxy.Current.Patients);
        }

        public Patient? SelectedPatient
        {
            get => Model?.Patient;
            set
            {
                if (Model != null && Model.Patient != value)
                    Model.Patient = value;
            }
        }


        public ObservableCollection<Physician> Physicians
        {
            get => new ObservableCollection<Physician>(PhysicianServiceProxy.Current.Physicians);
        }

        public Physician? SelectedPhysician
        {
            get => Model?.Physician;
            set
            {
                if (Model != null && Model.Physician != value)
                    Model.Physician = value;
            }
        }

        /*
         * deep copy on appointment (using new keyword) 
         */

        public DateTime MinDate
        {
            get => DateTime.Now;
        }

        public DateTime Date
        {
            get => Model?.Date ?? DateTime.Now;
            set
            {
                if (Model != null && Model.Date != value)
                    Model.Date = value;
            }
        }

        public TimeSpan ScheduledTime { get; set; }

        public int Id
        {
            get
            {
                if (Model == null)
                    return -1;
                return Model.Id;
            }
            set
            {
                if (Model != null && Model.Id != value)
                    Model.Id = value;
            }
        }

        public AppointmentViewModel()
        {
            Model = new Appointment();
        }
        public AppointmentViewModel(Appointment? _model)
        {
            Model = _model;
        }


        public void AddOrUpdate()
        {
            if (Model != null)
            {
                AppointmentServiceProxy.Current.AddOrUpdate(Model);
            }
        }

        public void Refresh()
        {
            //refresh the Patients & Physician list in thingy
            NotifyPropertyChanged(nameof(Patients));
            NotifyPropertyChanged(nameof(Physicians));
        }

        public void RefreshTime()
        {
            if (Model != null)
            {
                if (Model.Date != null)
                {
                    Model.Date = Date.Date; //the .Date throws away the time info so it can properly set the time in the following line.
                    Model.Date = Model.Date.Add(ScheduledTime);
                }
            }
        }
    }
}
