using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects <see cref="ICollection" />.
    ///     Returns true if it is null or empty.
    /// </summary>
    [ValueConversion(typeof(ICollection), typeof(bool))]
    public class ICollectionNullOrEmptyToBoolConverter
#if NET35
        : IValueConverter
#else
        : MarkupExtension, IValueConverter
#endif
    {
        private static IValueConverter _instance;

        /// <summary>
        /// Static instance of this converter.
        /// </summary>
        public static IValueConverter Instance => _instance ?? (_instance = new ICollectionNullOrEmptyToBoolConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !(value is ICollection))
                return Binding.DoNothing;

            var collectionValue = (ICollection) value;
            return collectionValue == null || collectionValue.Count == 0;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

#if !NET35
        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
#endif
    }
}