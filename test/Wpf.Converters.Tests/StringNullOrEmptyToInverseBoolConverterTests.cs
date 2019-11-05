using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class StringNullOrEmptyToInverseBoolConverterTests
    {
        [Theory]
        [InlineData("not empty", typeof(bool), null, "en-US", true)]
        [InlineData(null, typeof(bool), null, "en-US", false)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new StringNullOrEmptyToInverseBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Convert_returns_DependencyPropertyUnsetValue_when_value_is_not_string()
        {
            var converter = new StringNullOrEmptyToInverseBoolConverter();
            var culture = new CultureInfo("en-US");
            var output = converter.Convert(true, typeof(bool), null, culture);
            Assert.Equal(DependencyProperty.UnsetValue, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new StringNullOrEmptyToInverseBoolConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(true, typeof(string), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new StringNullOrEmptyToInverseBoolConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<StringNullOrEmptyToInverseBoolConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = StringNullOrEmptyToInverseBoolConverter.Instance;
            Assert.IsType<StringNullOrEmptyToInverseBoolConverter>(instance);
        }
    }
}
