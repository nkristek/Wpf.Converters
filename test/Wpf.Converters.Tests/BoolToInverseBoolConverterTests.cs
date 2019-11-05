using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class BoolToInverseBoolConverterTests
    {
        [Theory]
        [InlineData(false, typeof(bool), null, "en-US", true)]
        [InlineData(true, typeof(bool), null, "en-US", false)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new BoolToInverseBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Convert_returns_DependencyPropertyUnsetValue_when_value_null()
        {
            var converter = new BoolToInverseBoolConverter();
            var culture = new CultureInfo("en-US");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var output = converter.Convert(null, typeof(bool), null, culture);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Equal(DependencyProperty.UnsetValue, output);
        }

        [Theory]
        [InlineData(false, typeof(bool), null, "en-US", true)]
        [InlineData(true, typeof(bool), null, "en-US", false)]
        public void ConvertBack(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new BoolToInverseBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.ConvertBack(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new BoolToInverseBoolConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<BoolToInverseBoolConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = BoolToInverseBoolConverter.Instance;
            Assert.IsType<BoolToInverseBoolConverter>(instance);
        }
    }
}
