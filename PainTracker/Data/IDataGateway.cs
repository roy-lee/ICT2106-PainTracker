using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainTracker.Models;

namespace PainTracker.Data
{
    interface IDataGateway<T>
    {

        IEnumerable<T> SelectAll();

        T SelectById(int? id);

        void Insert(T obj);

        T FindObjectID(T obj);

        void Update(T obj);

        T Delete(int? id);

        void Save();

        Boolean Exists(int? id);

    }
}
