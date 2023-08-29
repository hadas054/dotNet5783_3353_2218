using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PL.converter
{

    public class ConfirmCart:IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return values is null ? false : values[0] != "" &&
                    new EmailAddressAttribute().IsValid(values[1]) &&
                    values[2] != ""! ?
                    true : false;
            }
            catch { return false; }

        }
        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
