﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class Prescription : ILoggerModel
    {
        [Key]
        public int PrescriptionID { get; set; }

        public int MedicineID { get; set; }
        public int IntakeEventID { get; set; }        

        public int Dosage { get; set; }

        public byte[] Img { get; set; }

        public void DeleteLog(int id)
        {
            throw new NotImplementedException();
        }

        public void EditLog(int id)
        {
            throw new NotImplementedException();
        }

        public void NewEntry(DateTime Date, DateTime Time, int Dosage, int MedID)
        {
            throw new NotImplementedException();
        }

        public void UpdateLogger()
        {
            throw new NotImplementedException();
        }

        public bool ViewLog(int id)
        {
            throw new NotImplementedException();
        }
    }
}