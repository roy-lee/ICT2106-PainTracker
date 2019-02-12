using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    interface IWellness 
    {
         PainDiary[] GetPainDiary(DateTime startDate, DateTime endDate);
        Dictionary<DateTime, double> getPainMedicineIntake(int PainRating);
        Interference[] getInterference(DateTime startDate, DateTime endDate);
        Mood[] getMood(DateTime startDate, DateTime endDate);
        Medicine[] getMedicineIntake(DateTime startDate, DateTime endDate);
    }
}
