using ExploreCalifornia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Data
{
    interface IPainDiaryGateway 
    {
        IEnumerable<PainDiary> SelectAll();
        PainDiary SelectById(int? id);
    }
}
