﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="string"/>.
    /// Returns true if it is not null or empty.
    /// </summary>
    [ValueConversion(typeof(string), typeof(bool))]
    public class StringNullOrEmptyToInverseBoolConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new StringNullOrEmptyToInverseBoolConverter());

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !(value is string))
                return Binding.DoNothing;

            var stringValue = (string)value;
            return !String.IsNullOrEmpty(stringValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}