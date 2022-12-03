using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    internal class IdNotExistException:Exception
    {

    }
}


//כאן אני צריכה להגדיר חריגות כלליות

//1.חריגה עבור יישות שלא נמצאה או מזהה חסר (עבור עידכון מחיקה או בקשה
//2.חריגה של כפילות מזהה עבור הוספה של אובייקט עם מזהה שכבר קיים