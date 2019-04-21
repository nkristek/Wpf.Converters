﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects <see cref="object" />.
    ///     Returns <see cref="Visibility.Visible" /> if <see cref="object.ToString" /> equals the given parameter.
    ///     Returns <see cref="Visibility.Collapsed" /> otherwise.
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class ObjectToStringEqualsParameterToVisibilityConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new ObjectToStringEqualsParameterToVisibilityConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() == parameter as string ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
    }
}