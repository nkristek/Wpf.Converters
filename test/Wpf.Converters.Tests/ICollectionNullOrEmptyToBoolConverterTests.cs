using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ICollectionNullOrEmptyToBoolConverterTests
    {
        [Theory]
        [InlineData(null, typeof(bool), null, "en-US", true)]
        [InlineData(new object[] { }, typeof(bool), null, "en-US", true)]
        [InlineData(new object[] { 1 }, typeof(bool), null, "en-US", false)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converter = new ICollectionNullOrEmptyToBoolConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Convert_returns_DependencyPropertyUnsetValue_when_value_is_not_ICollection()
        {
            var converter = new ICollectionNullOrEmptyToBoolConverter();
            var culture = new CultureInfo("en-US");
            var output = converter.Convert(true, typeof(bool), null, culture);
            Assert.Equal(DependencyProperty.UnsetValue, output);
        }

        [Fact]
        public void ConvertBack_throws_NotSupportedException()
        {
            var converter = new ICollectionNullOrEmptyToBoolConverter();
            var culture = new CultureInfo("en-US");
            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(true, typeof(ICollection), null, culture));
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new ICollectionNullOrEmptyToBoolConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<ICollectionNullOrEmptyToBoolConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = ICollectionNullOrEmptyToBoolConverter.Instance;
            Assert.IsType<ICollectionNullOrEmptyToBoolConverter>(instance);
        }
    }
}
