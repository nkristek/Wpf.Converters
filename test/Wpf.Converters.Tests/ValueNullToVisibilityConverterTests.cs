using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ValueNullToVisibilityConverterTests
    {
        [Theory]
        [InlineData(true, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(null, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(true, typeof(Visibility), "hidden", "en-US", Visibility.Hidden)]
        [InlineData(null, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new ValueNullToVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new ValueNullToVisibilityConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(Visibility.Visible, typeof(object), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new ValueNullToVisibilityConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<ValueNullToVisibilityConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = ValueNullToVisibilityConverter.Instance;
            Assert.IsType<ValueNullToVisibilityConverter>(instance);
        }
    }
}
