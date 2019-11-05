using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class BoolToInverseVisibilityConverterTests
    {
        [Theory]
        [InlineData(false, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(true, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(false, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        [InlineData(true, typeof(Visibility), "hidden", "en-US", Visibility.Hidden)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new BoolToInverseVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Convert_returns_DependencyPropertyUnsetValue_when_value_null()
        {
            var converter = new BoolToInverseVisibilityConverter();
            var culture = new CultureInfo("en-US");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var output = converter.Convert(null, typeof(Visibility), null, culture);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Equal(DependencyProperty.UnsetValue, output);
        }

        [Theory]
        [InlineData(Visibility.Visible, typeof(Visibility), null, "en-US", false)]
        [InlineData(Visibility.Collapsed, typeof(Visibility), null, "en-US", true)]
        [InlineData(Visibility.Visible, typeof(Visibility), "hidden", "en-US", false)]
        [InlineData(Visibility.Hidden, typeof(Visibility), "hidden", "en-US", true)]
        public void ConvertBack(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new BoolToInverseVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.ConvertBack(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new BoolToInverseVisibilityConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<BoolToInverseVisibilityConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = BoolToInverseVisibilityConverter.Instance;
            Assert.IsType<BoolToInverseVisibilityConverter>(instance);
        }
    }
}
