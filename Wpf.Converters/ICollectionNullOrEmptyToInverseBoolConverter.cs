using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="ICollection"/>.
    /// Returns true if it is not null or empty.
    /// </summary>
    [ValueConversion(typeof(ICollection), typeof(bool))]
    public class ICollectionNullOrEmptyToInverseBoolConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new ICollectionNullOrEmptyToInverseBoolConverter());

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !(value is ICollection))
                return Binding.DoNothing;

            var collectionValue = (ICollection)value;
            return collectionValue != null && collectionValue.Count > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
