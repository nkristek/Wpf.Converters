using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class DateTimeToStringConverterTests
    {
        public static IEnumerable<object?[]> SampleConvertData()
        {
            var date = new DateTime(2019, 10, 29, 10, 35, 24, DateTimeKind.Utc);
            var cultureString = "en-US";
            var culture = new CultureInfo(cultureString);
            yield return new object?[] { date, typeof(string), null, cultureString, date.ToString(culture) };
            yield return new object[] { date, typeof(string), String.Empty, cultureString, date.ToString(culture) };
            yield return new object[] { date, typeof(string), "G", cultureString, date.ToString("G", culture) };
            yield return new object?[] { null, typeof(string), null, cultureString, DependencyProperty.UnsetValue };
            yield return new object?[] { null, typeof(string), "G", cultureString, DependencyProperty.UnsetValue };
            yield return new object?[] { "?", typeof(string), null, cultureString, DependencyProperty.UnsetValue };
            yield return new object?[] { "?", typeof(string), "G", cultureString, DependencyProperty.UnsetValue };
        }

        [Theory]
        [MemberData(nameof(SampleConvertData))]
        public void Convert(object input, Type targetType, object? parameter, string cultureString, object expectedOutput)
        {
            var converter = new DateTimeToStringConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.Convert(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        public static IEnumerable<object?[]> SampleConvertBackData()
        {
            var date = new DateTime(2019, 10, 29, 10, 35, 24, DateTimeKind.Utc);
            var cultureString = "en-US";
            var culture = new CultureInfo(cultureString);
            yield return new object?[] { date.ToString(culture), typeof(DateTime), null, cultureString, date };
            yield return new object[] { date.ToString(culture), typeof(DateTime), String.Empty, cultureString, date };
            yield return new object[] { date.ToString("G", culture), typeof(DateTime), "G", cultureString, date };
            yield return new object?[] { null, typeof(DateTime), null, cultureString, DependencyProperty.UnsetValue };
            yield return new object?[] { null, typeof(DateTime), "G", cultureString, DependencyProperty.UnsetValue };
            yield return new object?[] { "?", typeof(DateTime), null, cultureString, DependencyProperty.UnsetValue };
            yield return new object?[] { "?", typeof(DateTime), "G", cultureString, DependencyProperty.UnsetValue };
        }

        [Theory]
        [MemberData(nameof(SampleConvertBackData))]
        public void ConvertBack(object input, Type targetType, object? parameter, string cultureString, object expectedOutput)
        {
            var converter = new DateTimeToStringConverter();
            var culture = new CultureInfo(cultureString);
            var output = converter.ConvertBack(input, targetType, parameter, culture);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void ProvideValue_returns_instance()
        {
            var converter = new DateTimeToStringConverter();
            var providedValue = converter.ProvideValue(null);
            Assert.IsType<DateTimeToStringConverter>(providedValue);
        }

        [Fact]
        public void Instance_returns_instance()
        {
            var instance = DateTimeToStringConverter.Instance;
            Assert.IsType<DateTimeToStringConverter>(instance);
        }
    }
}
