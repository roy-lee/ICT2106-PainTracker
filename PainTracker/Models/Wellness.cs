using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class Wellness : IWellness
    {
        PainDiary painDiary;
        Medicine[] medicineIntakeList;

        public Interference[] getInterference(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Medicine[] getMedicineIntake(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Mood[] getMood(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public PainDiary[] GetPainDiary(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, double> getPainMedicineIntake(int PainRating)
        {
            throw new NotImplementedException();
        }
    }
}
