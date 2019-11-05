using System;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class ValueConverterChainTests
    {
        [Theory]
        [InlineData(false, typeof(Visibility), null, "en-US", Visibility.Visible)]
        [InlineData(true, typeof(Visibility), null, "en-US", Visibility.Collapsed)]
        public void Convert(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converterChain = new ValueConverterChain
            {
                Converters = 
                { 
                    new BoolToInverseBoolConverter(),
                    new BoolToVisibilityConverter()
                }
            };

            var culture = new CultureInfo(cultureString);
            var output = converterChain.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(Visibility.Visible, typeof(bool), null, "en-US", false)]
        [InlineData(Visibility.Collapsed, typeof(bool), null, "en-US", true)]
        public void ConvertBack(object input, Type targetType, object parameter, string cultureString, object expectedOutput)
        {
            var converterChain = new ValueConverterChain
            {
                Converters =
                {
                    new BoolToInverseBoolConverter(),
                    new BoolToVisibilityConverter()
                }
            };

            var culture = new CultureInfo(cultureString);
            var output = converterChain.ConvertBack(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }
    }
}
