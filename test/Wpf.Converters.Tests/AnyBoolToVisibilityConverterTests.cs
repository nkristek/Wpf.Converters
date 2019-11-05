using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class AnyBoolToVisibilityConverterTests
    {
        [Theory]
        [InlineData(new object[] { false, false }, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(new object[] { true, false }, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(new object[] { true, true }, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(new object[] { false, false }, typeof(Visibility), "hidden", "en-US", Visibility.Hidden)]
        [InlineData(new object[] { true, false }, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        [InlineData(new object[] { true, true }, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        public void Convert(object[] input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new AnyBoolToVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Convert_returns_DependencyPropertyUnsetValue_when_values_null()
        {
            var converter = new AnyBoolToVisibilityConverter();
            var culture = new CultureInfo("en-US");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var output = converter.Convert(null, typeof(Visibility), null, culture);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Equal(DependencyProperty.UnsetValue, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new AnyBoolToVisibilityConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(Visibility.Visible, new[] { typeof(bool) }, null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new AnyBoolToVisibilityConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<AnyBoolToVisibilityConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = AnyBoolToVisibilityConverter.Instance;
            Assert.IsType<AnyBoolToVisibilityConverter>(instance);
        }
    }
}
