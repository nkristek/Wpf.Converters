using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// <para>Expects an <see cref="object" />.</para>
    /// <para>Returns <see langword="true"/> if the value is not <see langword="null"/>.</para>
    /// <para>Returns <see langword="false"/> otherwise.</para>
    /// </summary>
    [ValueConversion(typeof(object), typeof(bool))]
    public class ValueNullToInverseBoolConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new ValueNullToInverseBoolConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            return value != null;
        }

        /// <inheritdoc />
        /// <exception cref="NotSupportedException">This operation is not supported.</exception>
        public object ConvertBack(object value, Type targetType, object? parameter, CultureInfo? culture)
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