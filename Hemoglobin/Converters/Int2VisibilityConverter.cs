﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Hemoglobin.Converters
{
    public class Int2VisibilityConverter : IValueConverter
    {
        private static Lazy<Int2VisibilityConverter> lazyInstance = new Lazy<Int2VisibilityConverter>(() => new Int2VisibilityConverter());
        public static Int2VisibilityConverter Instance => lazyInstance.Value;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (parameter == null)
                    {
                        return int.Parse(value.ToString()) > 0 ? Visibility.Visible : Visibility.Collapsed;
                    }
                    else if (parameter.ToString() == "-")
                    {
                        return int.Parse(value.ToString()) > 0 ? Visibility.Collapsed : Visibility.Visible;
                    }
                    else
                    {
                        int iParam = 0;
                        int.TryParse(parameter.ToString(), out iParam);
                        if (iParam != 0)
                        {
                            return int.Parse(value.ToString()) <= iParam ? Visibility.Visible : Visibility.Collapsed;
                        }
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
