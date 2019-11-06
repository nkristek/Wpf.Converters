using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// <para>Expects a <see cref="string" />.</para>
    /// <para>Returns <see langword="true"/> if the value is not <see langword="null"/> or empty.</para>
    /// <para>Returns <see langword="false"/> otherwise.</para>
    /// </summary>
    [ValueConversion(typeof(string), typeof(bool))]
    public class StringNullOrEmptyToInverseBoolConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new StringNullOrEmptyToInverseBoolConverter());

        /// <inheritdoc />
        public virtual object Convert(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (value != null && !(value is string))
                return DependencyProperty.UnsetValue;

            return !String.IsNullOrEmpty(value as string);
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