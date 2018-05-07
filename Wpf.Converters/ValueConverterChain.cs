using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Represents a chain of <see cref="IValueConverter"/>s to be executed in succession.
    /// Please note, that only converters with a <see cref="ValueConversionAttribute"/> can use the targetType parameter.
    /// The idea for this converter comes from reading https://www.codeproject.com/Articles/15061/Piping-Value-Converters-in-WPF
    /// </summary>
    [ContentProperty("Converters")]
    [ContentWrapper(typeof(ObservableCollection<IValueConverter>))]
    public class ValueConverterChain : IValueConverter
    {
        public ObservableCollection<IValueConverter> Converters { get; } = new ObservableCollection<IValueConverter>();

        private readonly Dictionary<IValueConverter, ValueConversionAttribute> _valueConversionAttributes = new Dictionary<IValueConverter, ValueConversionAttribute>();

        public ValueConverterChain()
        {
            Converters.CollectionChanged += (sender, args) =>
            {
                if (args.OldItems != null)
                    foreach (IValueConverter oldConverter in args.OldItems)
                        _valueConversionAttributes.Remove(oldConverter);

                if (args.NewItems != null)
                    foreach (IValueConverter newConverter in args.NewItems)
                        _valueConversionAttributes[newConverter] = newConverter.GetType().GetCustomAttributes<ValueConversionAttribute>().SingleOrDefault();
            };
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ExecuteConverters(Converters, value, targetType, parameter, culture, false);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ExecuteConverters(Converters, value, targetType, parameter, culture, true);
        }

        private object ExecuteConverters(IEnumerable<IValueConverter> converters, object value, Type finalTargetType, object parameter, CultureInfo culture, bool reversed)
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
                    output = reversed ? converter.ConvertBack(output, finalTargetType, parameter, culture) : converter.Convert(output, finalTargetType, parameter, culture);
                }
                else
                {
                    var valueConversionAttribute = _valueConversionAttributes.ContainsKey(converter) ? _valueConversionAttributes[converter] : null;
                    var currentTargetType = reversed ? valueConversionAttribute?.SourceType : valueConversionAttribute?.TargetType;
                    output = reversed ? converter.ConvertBack(output, currentTargetType, parameter, culture) : converter.Convert(output, currentTargetType, parameter, culture);
                }

                if (output == Binding.DoNothing)
                    break;
            }

            return output;
        }
    }
}
