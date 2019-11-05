using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ObjectToStringEqualsParameterToInverseVisibilityConverterTests
    {
        [Theory]
        [InlineData(null, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(0, typeof(Visibility), "1", "en-US", Visibility.Visible)]
        [InlineData(1, typeof(Visibility), "1", "en-US", Visibility.Collapsed)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new ObjectToStringEqualsParameterToInverseVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new ObjectToStringEqualsParameterToInverseVisibilityConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(Visibility.Visible, typeof(object), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new ObjectToStringEqualsParameterToInverseVisibilityConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<ObjectToStringEqualsParameterToInverseVisibilityConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance;
            Assert.IsType<ObjectToStringEqualsParameterToInverseVisibilityConverter>(instance);
        }
    }
}
