using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Hemoglobin.Converters
{
    public class Equal2VisibilityConverter : IValueConverter
    {
        private static readonly Lazy<Equal2VisibilityConverter> lazy
                = new Lazy<Equal2VisibilityConverter>(() => new Equal2VisibilityConverter());
        public static Equal2VisibilityConverter Instance { get { return lazy.Value; } }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null || parameter == null)
                {
                    return Visibility.Collapsed;
                }

                if (value.ToString() == parameter.ToString())
                {
                    return Visibility.Visible;
                }
            }
            catch { }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
