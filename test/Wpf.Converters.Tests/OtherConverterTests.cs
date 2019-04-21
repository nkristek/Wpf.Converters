using System;
using System.Globalization;
using System.Windows.Data;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class OtherConverterTests
    {
        [Fact]
        public void TestDateTimeToStringConverter()
        {
            var sampleDateTime = DateTime.Now;
            Assert.Equal(sampleDateTime.ToString(),
                DateTimeToStringConverter.Instance.Convert(sampleDateTime, typeof(string), null, CultureInfo.CurrentCulture));
            Assert.Equal(sampleDateTime.ToString("g"),
                DateTimeToStringConverter.Instance.Convert(sampleDateTime, typeof(string), "g", CultureInfo.CurrentCulture));
            Assert.Equal(Binding.DoNothing, DateTimeToStringConverter.Instance.Convert(null, typeof(string), null, CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestValueConverterChain()
        {
            var valueNullToInverseBoolConverterChain = new ValueConverterChain
            {
                Converters = {ValueNullToBoolConverter.Instance, BoolToInverseBoolConverter.Instance}
            };

            CompareConverterResult(ValueNullToInverseBoolConverter.Instance, valueNullToInverseBoolConverterChain, null, typeof(object), null,
                CultureInfo.CurrentCulture);
            CompareConverterResult(ValueNullToInverseBoolConverter.Instance, valueNullToInverseBoolConverterChain, new object(), typeof(object), null,
                CultureInfo.CurrentCulture);
        }

        private static void CompareConverterResult(IValueConverter referenceConverter, IValueConverter converterToTest, object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var expectedResult = referenceConverter.Convert(value, targetType, parameter, culture);
            var actualResult = converterToTest.Convert(value, targetType, parameter, culture);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}