using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Brovushka.ClassHelper
{
    class MoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            char rub = (char)8381;
            if (value is null)
            {
                return "0.00" + rub;
            }
            else
            {
                decimal val = (decimal)value;
                string res = val.ToString("0.00", CultureInfo.InvariantCulture);
                return res + rub;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
