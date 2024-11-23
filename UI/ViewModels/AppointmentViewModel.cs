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

        public TimeSpan ScheduledTime
        {
            get => Model?.Date.TimeOfDay ?? TimeSpan.Zero;
            set
            {
                if(Model != null && Model.Date.TimeOfDay != value)
                    Model.Date = Model.Date.Add(value);
            }
        }

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

        private TimeSpan EarliestTime = new TimeSpan(8, 0, 0);
        private TimeSpan LatestTime = new TimeSpan(17, 0, 0);

        public string SchedulingErrorMessage = string.Empty;
        public bool AddOrUpdate()
        {
            if (Model != null) // if there's a model
            {
                if(Model.Date.DayOfWeek != DayOfWeek.Saturday && Model.Date.DayOfWeek != DayOfWeek.Sunday) // if it's not the weekend
                {
                    if (Model.Date.TimeOfDay > EarliestTime && Model.Date.TimeOfDay < LatestTime) // if it's between 8a & 5p
                    {
                        AppointmentServiceProxy.Current.AddOrUpdate(Model);
                        return true;
                    }
                    else
                    {
                        //inform user invalid time
                        SchedulingErrorMessage = $"Error: The time must be between {EarliestTime} and {LatestTime}.";
                    }
                }
                else
                {
                    //inform user invalid day
                    SchedulingErrorMessage = "Error: The date must not be the weekend.";
                }   
            }
            else
            {
                SchedulingErrorMessage = "Error: No model.";
            }
            return false;
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
                var temp = Date.Date;
                temp = temp.Date.Add(ScheduledTime);
                Model.Date = temp;
            }
        }
    }
}
