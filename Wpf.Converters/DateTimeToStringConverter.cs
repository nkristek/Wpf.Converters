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
    public class DateTimeToStringConverter
        : MarkupExtension, IValueConverter
    {
        public static readonly IValueConverter Instance = new DateTimeToStringConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var dateTime = (DateTime)value;
            if (dateTime == DateTime.MinValue)
                return null;

            if (parameter is string s && !String.IsNullOrEmpty(s))
                return dateTime.ToString(s);

            return dateTime.ToString(culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
