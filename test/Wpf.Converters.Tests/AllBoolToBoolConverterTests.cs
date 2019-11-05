using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class AllBoolToBoolConverterTests
    {
        [Theory]
        [InlineData(new object[] { false, false }, typeof(bool), null, "en-US", false)]
        [InlineData(new object[] { true, false }, typeof(bool), null, "en-US", false)]
        [InlineData(new object[] { true, true }, typeof(bool), null, "en-US", true)]
        public void Convert(object[] input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new AllBoolToBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Convert_returns_DependencyPropertyUnsetValue_when_values_null()
        {
            var converter = new AllBoolToBoolConverter();
            var culture = new CultureInfo("en-US");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var output = converter.Convert(null, typeof(bool), null, culture);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Equal(DependencyProperty.UnsetValue, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new AllBoolToBoolConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(true, new[] { typeof(bool) }, null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new AllBoolToBoolConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<AllBoolToBoolConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = AllBoolToBoolConverter.Instance;
            Assert.IsType<AllBoolToBoolConverter>(instance);
        }
    }
}
