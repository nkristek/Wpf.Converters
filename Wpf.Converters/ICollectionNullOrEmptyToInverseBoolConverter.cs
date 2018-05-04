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
    public class ICollectionNullOrEmptyToInverseBoolConverter
        : MarkupExtension, IValueConverter
    {
        public static readonly IValueConverter Instance = new ICollectionNullOrEmptyToInverseBoolConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is ICollection collection && collection.Count > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
