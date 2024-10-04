using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class AppointmentViewModel
    {
        private Appointment? model {  get; set; }
        public int Id
        {
            get
            {
                if (model == null)
                    return -1;
                return model.Id;
            }
            set
            {
                if(model != null && model.Id != value)
                    model.Id = value;
            }
        }
        public string PatientName
        {
            get => model?.Patient.Name ?? string.Empty;
        }
        public string PhysicianName
        {
            get => model?.Physician.Name ?? string.Empty;
        }

        public AppointmentViewModel() 
        {
            model = new Appointment();
        }
        public AppointmentViewModel(Appointment? _model)
        {
            model = _model;
        }
    }
}
