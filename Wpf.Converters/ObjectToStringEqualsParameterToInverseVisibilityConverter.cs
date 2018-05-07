﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="object"/>.
    /// Returns <see cref="Visibility.Collapsed"/> if <see cref="object.ToString"/> equals the given parameter.
    /// Returns <see cref="Visibility.Visible"/> otherwise.
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class ObjectToStringEqualsParameterToInverseVisibilityConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new ObjectToStringEqualsParameterToInverseVisibilityConverter());

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() != parameter as string ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}