using System;
using System.Globalization;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ValueNullToInverseBoolConverterTests
    {
        [Theory]
        [InlineData(true, typeof(bool), null, "en-US", true)]
        [InlineData(null, typeof(bool), null, "en-US", false)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new ValueNullToInverseBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new ValueNullToInverseBoolConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(true, typeof(object), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new ValueNullToInverseBoolConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<ValueNullToInverseBoolConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = ValueNullToInverseBoolConverter.Instance;
            Assert.IsType<ValueNullToInverseBoolConverter>(instance);
        }
    }
}
