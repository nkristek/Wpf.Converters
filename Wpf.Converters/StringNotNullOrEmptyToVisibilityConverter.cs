﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="string"/>.
    /// Returns <see cref="Visibility.Visible"/> if it is not null or empty.
    /// Returns <see cref="Visibility.Hidden"/> if it is null or empty "Hidden" was set as a parameter.
    /// Returns <see cref="Visibility.Collapsed"/> otherwise.
    /// </summary>
    public class StringNotNullOrEmptyToVisibilityConverter
        : MarkupExtension, IValueConverter
    {
        public static readonly IValueConverter Instance = new StringNotNullOrEmptyToVisibilityConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!String.IsNullOrEmpty(value as string))
                return Visibility.Visible;

            if (parameter is string parameterAsString && parameterAsString.ToLower().Equals("hidden"))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}