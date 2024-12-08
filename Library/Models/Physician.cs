﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Physician
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime GraduationDate { get; set; }
        public int Id { get; set; }
        public List<string> Specializations { get; set; } = new List<string>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Physician() 
        {
            Name = string.Empty;
            LicenseNumber = string.Empty;
            GraduationDate = DateTime.MinValue;
            Specializations = new List<string>();
            Appointments = new List<Appointment>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
