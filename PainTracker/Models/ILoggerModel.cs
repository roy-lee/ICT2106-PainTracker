using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    interface ILoggerModel
    {

        void UpdateLogger();
        void NewEntry(DateTime Date, DateTime Time, int Dosage, int MedID);
        Boolean ViewLog(int id);
        void EditLog(int id);
        void DeleteLog(int id);
    }
}
