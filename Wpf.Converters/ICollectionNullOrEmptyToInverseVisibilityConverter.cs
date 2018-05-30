using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="ICollection"/>.
    /// Returns <see cref="Visibility.Visible"/> if it is not null or empty.
    /// Returns <see cref="Visibility.Hidden"/> if it is null or empty "Hidden" was set as a parameter.
    /// Returns <see cref="Visibility.Collapsed"/> otherwise.
    /// </summary>
    [ValueConversion(typeof(ICollection), typeof(Visibility))]
    public class ICollectionNullOrEmptyToInverseVisibilityConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new ICollectionNullOrEmptyToInverseVisibilityConverter());

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !(value is ICollection))
                return Binding.DoNothing;

            var collectionValue = (ICollection)value;
            if (collectionValue != null && collectionValue.Count > 0)
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
