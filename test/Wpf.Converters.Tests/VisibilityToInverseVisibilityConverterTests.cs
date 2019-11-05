using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class VisibilityToInverseVisibilityConverterTests
    {
        [Theory]
        [InlineData(Visibility.Visible, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(Visibility.Collapsed, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(Visibility.Hidden, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(Visibility.Visible, typeof(Visibility), "hidden", "en-US", Visibility.Hidden)]
        [InlineData(Visibility.Collapsed, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        [InlineData(Visibility.Hidden, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new VisibilityToInverseVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(Visibility.Visible, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(Visibility.Collapsed, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(Visibility.Hidden, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(Visibility.Visible, typeof(Visibility), "hidden", "en-US", Visibility.Hidden)]
        [InlineData(Visibility.Collapsed, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        [InlineData(Visibility.Hidden, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        public void ConvertBack(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new VisibilityToInverseVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.ConvertBack(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new VisibilityToInverseVisibilityConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<VisibilityToInverseVisibilityConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = VisibilityToInverseVisibilityConverter.Instance;
            Assert.IsType<VisibilityToInverseVisibilityConverter>(instance);
        }
    }
}
