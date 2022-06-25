using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Hemoglobin.Converters
{
    public class Bool2VisibilityConverter : IValueConverter
    {
        private static readonly Lazy<Bool2VisibilityConverter>
               Lazy = new Lazy<Bool2VisibilityConverter>(() => new Bool2VisibilityConverter());

        public static Bool2VisibilityConverter Instance => Lazy.Value;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (parameter == null)
                    {
                        return bool.Parse(value.ToString()) ? Visibility.Visible : Visibility.Collapsed;
                    }
                    else if (parameter.ToString() == "-")
                    {
                        return bool.Parse(value.ToString()) ? Visibility.Collapsed : Visibility.Visible;
                    }
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
