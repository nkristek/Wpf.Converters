using System;
using System.Globalization;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nkristek.Wpf.Converters.Tests
{
    /// <summary>
    /// Test other <see cref="IValueConverter"/> and <see cref="IMultiValueConverter"/>
    /// </summary>
    [TestClass]
    public class OtherConverterTests
    {
        [TestMethod]
        public void TestDateTimeToStringConverter()
        {
            var sampleDateTime = DateTime.Now;
            Assert.AreEqual(sampleDateTime.ToString(), DateTimeToStringConverter.Instance.Convert(sampleDateTime, typeof(string), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(sampleDateTime.ToString("g"), DateTimeToStringConverter.Instance.Convert(sampleDateTime, typeof(string), "g", CultureInfo.CurrentCulture));
            Assert.AreEqual(null, DateTimeToStringConverter.Instance.Convert(null, typeof(string), null, CultureInfo.CurrentCulture));
        }
    }
}
