using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// <para>Expects an instance implementing <see cref="ICollection" />.</para>
    /// <para>Returns <see langword="true"/> if the value is not <see langword="null"/> or empty.</para>
    /// <para>Returns <see langword="false"/> otherwise.</para>
    /// </summary>
    [ValueConversion(typeof(ICollection), typeof(bool))]
    public class ICollectionNullOrEmptyToInverseBoolConverter
#if NET35
        : IValueConverter
#else
        : MarkupExtension, IValueConverter
#endif
    {
        private static IValueConverter? _instance;

        /// <summary>
        /// Static instance of this converter.
        /// </summary>
        public static IValueConverter Instance => _instance ?? (_instance = new ICollectionNullOrEmptyToInverseBoolConverter());

        /// <inheritdoc />
        public virtual object Convert(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (value != null && !(value is ICollection))
                return DependencyProperty.UnsetValue;

            return value is ICollection collectionValue && collectionValue.Count > 0;
        }

        /// <inheritdoc />
        /// <exception cref="NotSupportedException">This operation is not supported.</exception>
        public virtual object ConvertBack(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            throw new NotSupportedException();
        }

#if !NET35
        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider? serviceProvider)
        {
            return Instance;
        }
#endif
    }
}