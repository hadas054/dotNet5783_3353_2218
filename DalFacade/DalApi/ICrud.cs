using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface ICrud<T> where T : struct
    {
        int Add(T Entity);
        void Delete(int Entity);  
        IEnumerable<T?> GetAll();    
        void Update (T Entity);
        T? Get (int Entity); 
    }
}
