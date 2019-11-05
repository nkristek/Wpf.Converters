using System;
using System.Globalization;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ValueNullToBoolConverterTests
    {
        [Theory]
        [InlineData(true, typeof(bool), null, "en-US", false)]
        [InlineData(null, typeof(bool), null, "en-US", true)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new ValueNullToBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new ValueNullToBoolConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(true, typeof(object), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new ValueNullToBoolConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<ValueNullToBoolConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = ValueNullToBoolConverter.Instance;
            Assert.IsType<ValueNullToBoolConverter>(instance);
        }
    }
}
