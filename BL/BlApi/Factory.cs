using BLImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public class Factory
    {
        static public IBL Get => new BL();
    }
}
