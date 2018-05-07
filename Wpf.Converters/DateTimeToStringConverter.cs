using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects a <see cref="DateTime"/>.
    /// Returns <see cref="string"/> representation. 
    /// Optionally a parameter can be set which will be used as a parameter of the <see cref="DateTime.ToString(string)"/> method.
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateTimeToStringConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new DateTimeToStringConverter());

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
                return Binding.DoNothing;

            var dateTimeValue = (DateTime)value;

            if (parameter is string s && !String.IsNullOrEmpty(s))
                return dateTimeValue.ToString(s);

            return dateTimeValue.ToString(culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return Binding.DoNothing;

            var stringValue = (string)value;

            if (parameter is string parameterAsString && !String.IsNullOrEmpty(parameterAsString))
            {
                if (DateTime.TryParseExact(stringValue, parameterAsString, null, DateTimeStyles.None, out var parsedDateTime))
                    return parsedDateTime;
                return Binding.DoNothing;
            }

            if (DateTime.TryParse(stringValue, out var dateTime))
                return dateTime;
            return Binding.DoNothing;
        }
    }
}
