using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    //* * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    //Maybe just implement MedicalNote from Patient.cs instead?
    //* * * * * * * * * * * * * * * * * * * * * * * * * * * * *

    public class Treatment
    {
        public int Id { get; set; } //potentially unnecessary?
        public string Name { get; set; }
        public double Cost { get; set; }


        public Treatment() 
        {
            Name = string.Empty;
            Cost = 0.0;
        }
    }
}
