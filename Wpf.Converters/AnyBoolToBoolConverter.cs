﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects a list of <see cref="bool"/>.
    /// Returns true if any of them are true.
    /// </summary>
    public class AnyBoolToBoolConverter
        : MarkupExtension, IMultiValueConverter
    {
        public static readonly IMultiValueConverter Instance = new AnyBoolToBoolConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Any(v => v is bool b && b);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}