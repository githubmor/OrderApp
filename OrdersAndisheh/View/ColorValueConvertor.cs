﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace OrdersAndisheh.View
{
    public class ColorValueConvertor : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (value == null || !(value is decimal))
            //    return new SolidColorBrush(Colors.Black);

            var dValue = System.Convert.ToDecimal(value);
            if (dValue >  8)
                return new SolidColorBrush(Colors.Red);
            else
                return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
