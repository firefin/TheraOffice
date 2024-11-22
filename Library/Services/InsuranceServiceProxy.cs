using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class InsuranceServiceProxy
    {
        private static object _lock = new object();
        public static InsuranceServiceProxy Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new InsuranceServiceProxy();
                }
                return instance;
            }
        }

        private static InsuranceServiceProxy? instance;

        private InsuranceServiceProxy()
        {
            instance = null;

            Insurances = new List<Insurance>
            {
                new Insurance{Name = "Test Insurance LLC.", Id = 1},
                new Insurance{Name = "Other Test Insurance Co.", Id = 2}
            };
        }

        public int LastKey
        {
            get
            {
                if (Insurances.Any())
                    return Insurances.Select(x => x.Id).Max();
                return 0;
            }
        }
        private List<Insurance> insurances;
        public List<Insurance> Insurances
        {
            get
            {
                return insurances;
            }
            private set
            {
                if (insurances != value) insurances = value;
            }
        }
        public void AddOrUpdateInsurance(Insurance i)
        {
            if(i.Id <= 0)
            {
                i.Id = LastKey + 1;
                Insurances.Add(i);
            }
        }
        public void RemoveInsurance(int id)
        {
            if (Insurances.Any(x => x.Id == id))
            {
                Insurances.RemoveAt(Insurances.FindIndex(x => x.Id == id));
            }
        }
        //might not be necessary? will leave for future.
        public void AddCoverage(int insuranceID, string name, decimal coverage)
        {             
            if (Insurances.Any(x => x.Id == insuranceID))
            {
                Insurances.First(x => x.Id == insuranceID).Coverages.Add(name.ToLower(), coverage);
            }
        }
    }
}
