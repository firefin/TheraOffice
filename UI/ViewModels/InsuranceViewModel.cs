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
    public class InsuranceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Insurance? model { get; set; }

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
        public Dictionary<string,decimal> Coverages
        {
            get
            {
                if (model == null)
                    return new Dictionary<string, decimal>();
                return model.Coverages.ToDictionary(k => k.Key, v => v.Value);
            }
            set
            {
                Coverages = value;
            }
        }

        public ObservableCollection<KeyValuePair<string, decimal>> CoveragesObservableCollection
        {
            get => new ObservableCollection<KeyValuePair<string, decimal>>(Coverages);
        }
        public KeyValuePair<string, decimal> SelectedCoverage { get; set; }


        public InsuranceViewModel()
        {
            model = new Insurance();
        }

        public InsuranceViewModel(Insurance? _model)
        {
            model = _model;
        }

        public bool AddOrUpdate()
        {
            if(model != null)
            {
                InsuranceServiceProxy.Current.AddOrUpdateInsurance(model);
                return true;
            }
            return false;
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(CoveragesObservableCollection));
        }

        public bool? TryAddCoverage(string name, decimal coverage)
        {
            if (model == null || name == null)
                return false;
            return model.Coverages.TryAdd(name.ToLower(), coverage);
        }

        public bool? TryRemoveCoverage(string name)
        {
            if (model == null || name == null)
                return false;
            return model.Coverages.Remove(name.ToLower());
        }
        public override string ToString()
        {
            return model?.ToString() ?? "Loading Error.";
        }


    }
}
