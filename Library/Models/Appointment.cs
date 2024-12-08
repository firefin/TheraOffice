﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Appointment
    {
        public DateTime Date { get; set; }
        //public TimeSpan Time { get; set; }
        public Patient Patient { get; set; }
        public Physician Physician { get; set; } //might need to remove/refactor this depending on how implementing appointments needs to be done.
        public int Id { get; set; }   
        public List<Treatment>? Treatments { get; set; }


        public Appointment() { }
        
        /*
        public Appointment(DateTime date, Patient patient, Physician physician)
        {
            Date = date;
            Patient = patient;
            Physician = physician;
        }
        */

        
        public override string ToString() 
        {
            return Date.ToString();
        }

        //Deep copy constructor to fix issue #11
        public Appointment(Appointment app)
        {
            Date = app.Date;
            Patient = app.Patient;
            Physician = app.Physician;
        }
    }
}
