using Library.Models;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class AppointmentViewModel
    {
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
                if(Model != null && Model.Id != value)
                    Model.Id = value;
            }
        }

        /*
        public string PatientName
        {
            get => Model?.Patient.Name ?? string.Empty;
        }
        public string PhysicianName
        {
            get => Model?.Physician.Name ?? string.Empty;
        }
        */

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
            if(Model!= null)
            {
                AppointmentServiceProxy.Current.AddOrUpdate(Model);
            }
        }
    }
}
