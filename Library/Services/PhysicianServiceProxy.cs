using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class PhysicianServiceProxy
    {
        private static object _lock = new object();
        public static PhysicianServiceProxy Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new PhysicianServiceProxy();
                }
                return instance;
            }
        }

        private static PhysicianServiceProxy? instance;

        private PhysicianServiceProxy()
        {
            instance = null;

            Physicians = new List<Physician>
            {
                new Physician { Name = "Dr. Test", Id = 1 },
                new Physician { Name = "Dr. Doctor", Id = 2 }
            };
        }

        public int LastKey
        {
            get
            {
                if (Physicians.Any())
                    return Physicians.Select(x => x.Id).Max();
                return 0;
            }
        }
        private List<Physician> physicians;

        public List<Physician> Physicians
        {
            get => physicians;
            private set
            {
                if (physicians != value) physicians = value;
            }
        }

        public void AddOrUpdatePhysician(Physician p)
        {
            if (p.Id <= 0)
            {
                p.Id = LastKey + 1;
                Physicians.Add(p);
            }
        }

        public void RemovePhysician(int id)
        {
            var remove = Physicians.FirstOrDefault(x => x.Id == id);
            if(remove != null) 
                Physicians.Remove(remove);
        }
            
    }
}
