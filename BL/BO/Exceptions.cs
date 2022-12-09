using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

internal class NotExistException : Exception
{
    public NotExistException(string txt) { }
    override public string ToString()
    { return  Message; }
}

internal class alreadyExistException : Exception
{
    public alreadyExistException(string txt) { }
    override public string ToString()
    { return  Message; }
}

internal class ConfirmException : Exception
{
    public ConfirmException(string txt) { }
    override public string ToString()
    { return  Message; }
}

