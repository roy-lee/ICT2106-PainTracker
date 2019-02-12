using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;

namespace ExploreCalifornia.Data
{
    public class PainDiaryGateway : IPainDiaryGateway
    {
        internal ExploreCaliforniaContext db = new ExploreCaliforniaContext();

        public IEnumerable<PainDiary> SelectAll()
        {
            return db.PainDiary;
        }

     

        public PainDiary SelectById(int? id)
        {
            PainDiary pain = db.PainDiary.Find(id);
            return pain;
        }

        public List<PainEntry> retrieveEntries(int? id)
        {
            List<PainEntry> list = new List<PainEntry>();
           
            foreach (var entry in db.PainEntry)
            {                
                if(entry.patientId == id)
                {
                    list.Add(entry);
                }             
            }
           
            return list;
        }

        public List<PainEntry> retrieveMood(List<PainEntry> l)
        {

            foreach (PainEntry id in l)
            {
                foreach (var entry in db.Mood)
                {
                    if (entry.painEntryId == id.painEntryId)
                    {
                        id.Mood.Id = entry.Id;
                        id.Mood.moodType = entry.moodType;
                        id.Mood.duration = entry.duration;
                    }
                }
            }
            return l;
        }

        public List<PainEntry> retrieveInterference(List<PainEntry> l)
        {
            foreach (PainEntry id in l)
                foreach (var entry in db.Interference)
                {
                    if (entry.painEntryId == id.painEntryId)
                    {
                        //Interference i = new Interference(entry.Id, entry.description, entry.severity, entry.duration);
                        id.Interference.Id = entry.Id;
                        id.Interference.severity = entry.severity;
                        id.Interference.duration = entry.duration;
                        id.Interference.description = entry.description;
                        
                    }
                }
            return l;
        }
    }
}
