﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class NotExistException : Exception
    {
        public NotExistException(string txt) : base(txt) { }
        override public string ToString()
        { return "The item  that you requested, was not found!\n" + Message; }
    }

    public class alreadyExistException : Exception
    {
        public alreadyExistException(string txt) : base(txt) { }
        override public string ToString()
        { return "The item  that you requested, already exist\n" + Message; }
    }

    [Serializable]
    public class DalConfigException : Exception
    {
        public DalConfigException(string msg) : base(msg) { }
        public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
    }



}


//כאן אני צריכה להגדיר חריגות כלליות

//1.חריגה עבור יישות שלא נמצאה או מזהה חסר (עבור עידכון מחיקה או בקשה
//2.חריגה של כפילות מזהה עבור הוספה של אובייקט עם מזהה שכבר קיים