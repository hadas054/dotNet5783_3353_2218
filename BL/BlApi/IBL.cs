using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBL      //לא סגורה על זה
    {
        IOrder Order { get; }
        IProduct Product { get;}
        ICart cart { get; }
    }
}
