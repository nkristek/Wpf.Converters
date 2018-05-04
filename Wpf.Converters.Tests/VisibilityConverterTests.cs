using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nkristek.Wpf.Converters.Tests
{
    /// <summary>
    /// Test <see cref="IValueConverter"/> and <see cref="IMultiValueConverter"/> which return a <see cref="bool"/>
    /// </summary>
    [TestClass]
    public class VisibilityConverterTests
    {
        [TestMethod]
        public void TestVisibilityToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Collapsed, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Collapsed, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Visible, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Hidden, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Hidden, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Visible, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Visible, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestBoolToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, BoolToVisibilityConverter.Instance.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, BoolToVisibilityConverter.Instance.Convert(true, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, BoolToVisibilityConverter.Instance.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, BoolToVisibilityConverter.Instance.Convert(false, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestBoolToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, BoolToInverseVisibilityConverter.Instance.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, BoolToInverseVisibilityConverter.Instance.Convert(false, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, BoolToInverseVisibilityConverter.Instance.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, BoolToInverseVisibilityConverter.Instance.Convert(true, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestValueNullToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, ValueNullToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ValueNullToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, ValueNullToVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, ValueNullToVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestValueNullToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, ValueNullToInverseVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ValueNullToInverseVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, ValueNullToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, ValueNullToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestStringNullOrEmptyToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Collapsed, StringNullOrEmptyToVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, StringNullOrEmptyToVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Visible, StringNullOrEmptyToVisibilityConverter.Instance.Convert("", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, StringNullOrEmptyToVisibilityConverter.Instance.Convert("", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Visible, StringNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, StringNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestStringNullOrEmptyToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestICollectionNullOrEmptyToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Visible, ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(new[] { new object() }, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(new[] { new object() }, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestICollectionNullOrEmptyToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Collapsed, ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Visible, ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(new[] { new object() }, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(new[] { new object() }, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestAnyBoolToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, AnyBoolToVisibilityConverter.Instance.Convert(new object[] { false, true }, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, AnyBoolToVisibilityConverter.Instance.Convert(new object[] { false, true }, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, AnyBoolToVisibilityConverter.Instance.Convert(new object[] { false, false }, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, AnyBoolToVisibilityConverter.Instance.Convert(new object[] { false, false }, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestAnyBoolToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] { false, false }, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] { false, false }, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] { false, true }, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] { false, true }, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestObjectToStringEqualsParameterToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert("equal", typeof(Visibility), "equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Collapsed, ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert("not equal1", typeof(Visibility), "not equal2", CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Collapsed, ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "not equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Collapsed, ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert("not equal", typeof(Visibility), null, CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestObjectToStringEqualsParameterToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Collapsed, ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert("equal", typeof(Visibility), "equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Collapsed, ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert("not equal1", typeof(Visibility), "not equal2", CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "not equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Visible, ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert("not equal", typeof(Visibility), null, CultureInfo.CurrentCulture));
        }
    }
}
