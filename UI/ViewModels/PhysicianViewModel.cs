using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class PhysicianViewModel
    {
        private Physician? model { get; set; }
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
                if (model != null && model.Id != value)
                    model.Id = value;
            }
        }

        public string Name
        {
            get => model?.Name ?? string.Empty;

            set
            {
                if (model != null)
                    model.Name = value;
            }
        }

        public PhysicianViewModel()
        {
            model = new Physician();
        }

        public PhysicianViewModel(Physician? _model)
        {
            model = _model;
        }
    }
}
