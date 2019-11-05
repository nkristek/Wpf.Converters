using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
#if !NET35
    /// <inheritdoc />
    /// <summary>
    /// Represents a chain of multiple <see cref="IValueConverter" /> to be executed in succession.
    /// </summary>
    /// <remarks>
    /// Only converters with a <see cref="ValueConversionAttribute" /> can use the targetType parameter.
    /// </remarks>
    [ContentProperty("Converters")]
    public class ValueConverterChain
        : IValueConverter
    {
        /// <summary>
        /// Collection of converters which should be executed in succession.
        /// </summary>
        public ObservableCollection<IValueConverter> Converters { get; } = new ObservableCollection<IValueConverter>();

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ExecuteConverters(Converters, value, targetType, parameter, culture, false);
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ExecuteConverters(Converters, value, targetType, parameter, culture, true);
        }

        private object ExecuteConverters(IEnumerable<IValueConverter> converters, object value, Type finalTargetType, object parameter, CultureInfo culture,
            bool reversed)
        {
            var output = value;

            var convertersToProcess = (reversed ? converters.Reverse() : converters).ToList();
            var lastConverter = convertersToProcess.LastOrDefault();
            if (lastConverter == null)
                return value;

            foreach (var converter in convertersToProcess)
            {
                if (converter == lastConverter)
                {
                    output = reversed
                        ? converter.ConvertBack(output, finalTargetType, parameter, culture)
                        : converter.Convert(output, finalTargetType, parameter, culture);
                }
                else
                {
                    var valueConversionAttribute = converter.GetType().GetCustomAttributes(true).OfType<ValueConversionAttribute>().SingleOrDefault();
                    var currentTargetType = reversed ? valueConversionAttribute?.SourceType : valueConversionAttribute?.TargetType;
                    output = reversed
                        ? converter.ConvertBack(output, currentTargetType, parameter, culture)
                        : converter.Convert(output, currentTargetType, parameter, culture);
                }

                if (output == DependencyProperty.UnsetValue || output == Binding.DoNothing)
                    break;
            }

            return output;
        }
    }
#endif
}