using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ICollectionNullOrEmptyToInverseVisibilityConverterTests
    {
        [Theory]
        [InlineData(null, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(new object[] { }, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        [InlineData(new object[] { 1 }, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(null, typeof(Visibility), "hidden", "en-US", Visibility.Hidden)]
        [InlineData(new object[] { }, typeof(Visibility), "hidden", "en-US", Visibility.Hidden)]
        [InlineData(new object[] { 1 }, typeof(Visibility), "hidden", "en-US", Visibility.Visible)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new ICollectionNullOrEmptyToInverseVisibilityConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Convert_returns_DependencyPropertyUnsetValue_when_value_is_not_ICollection()
        {
            var converter = new ICollectionNullOrEmptyToInverseVisibilityConverter();
            var culture = new CultureInfo("en-US");
            var output = converter.Convert(true, typeof(Visibility), null, culture);
            Assert.Equal(DependencyProperty.UnsetValue, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new ICollectionNullOrEmptyToInverseVisibilityConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(Visibility.Visible, typeof(ICollection), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new ICollectionNullOrEmptyToInverseVisibilityConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<ICollectionNullOrEmptyToInverseVisibilityConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = ICollectionNullOrEmptyToInverseVisibilityConverter.Instance;
            Assert.IsType<ICollectionNullOrEmptyToInverseVisibilityConverter>(instance);
        }
    }
}
