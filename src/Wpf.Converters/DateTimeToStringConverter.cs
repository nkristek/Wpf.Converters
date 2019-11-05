using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// <para>Expects a <see cref="DateTime" />.</para>
    /// <para>Returns the <see cref="string" /> representation.</para>
    /// <para>Optionally a parameter can be set which will be used as a parameter of the <see cref="DateTime.ToString(string)" /> method.</para>
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateTimeToStringConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new DateTimeToStringConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (!(value is DateTime dateTimeValue))
                return DependencyProperty.UnsetValue;

            if (parameter is string s && !String.IsNullOrEmpty(s))
                return dateTimeValue.ToString(s, culture);

            return dateTimeValue.ToString(culture);
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (!(value is string stringValue))
                return DependencyProperty.UnsetValue;

            if (parameter is string parameterAsString && !String.IsNullOrEmpty(parameterAsString))
            {
                if (DateTime.TryParseExact(stringValue, parameterAsString, culture, DateTimeStyles.None, out var parsedDateTime))
                    return parsedDateTime;

                return DependencyProperty.UnsetValue;
            }

            if (DateTime.TryParse(stringValue, culture, DateTimeStyles.None, out var dateTime))
                return dateTime;

            return DependencyProperty.UnsetValue;
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