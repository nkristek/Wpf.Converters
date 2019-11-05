using System;
using System.Globalization;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ObjectToStringEqualsParameterToBoolConverterTests
    {
        [Theory]
        [InlineData(null, typeof(bool), null, "en-US", true)]
        [InlineData(0, typeof(bool), "1", "en-US", false)]
        [InlineData(1, typeof(bool), "1", "en-US", true)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new ObjectToStringEqualsParameterToBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new ObjectToStringEqualsParameterToBoolConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(true, typeof(object), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new ObjectToStringEqualsParameterToBoolConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<ObjectToStringEqualsParameterToBoolConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = ObjectToStringEqualsParameterToBoolConverter.Instance;
            Assert.IsType<ObjectToStringEqualsParameterToBoolConverter>(instance);
        }
    }
}
