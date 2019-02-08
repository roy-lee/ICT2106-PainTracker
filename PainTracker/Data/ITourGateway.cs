using PainTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Data
{
    interface ITourGateway
    {
        IEnumerable<Tour> SelectAll();
        Tour SelectById(int? id);
        void Insert(Tour tour);
        void Update(Tour tour);
        Tour Delete(int? id);
        void Save();
    }
}
