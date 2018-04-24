using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nkristek.Wpf.Converters.Tests
{
    [TestClass]
    public class ConvertersTests
    {
        [TestMethod]
        public void TestAnyBoolToBoolConverter()
        {
            var result1 = AnyBoolToBoolConverter.Instance.Convert(new object[] { false, true }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = AnyBoolToBoolConverter.Instance.Convert(new object[] { false, false }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void TestAnyBoolToInverseBoolConverter()
        {
            var result1 = AnyBoolToInverseBoolConverter.Instance.Convert(new object[] { false, false }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = AnyBoolToInverseBoolConverter.Instance.Convert(new object[] { false, true }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void TestAnyBoolToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, AnyBoolToVisibilityConverter.Instance.Convert(new object[] { false, true }, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, AnyBoolToVisibilityConverter.Instance.Convert(new object[] { false, false }, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Hidden, AnyBoolToVisibilityConverter.Instance.Convert(new object[] { false, false }, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestBoolToInverseBoolConverter()
        {
            var result1 = BoolToInverseBoolConverter.Instance.Convert(false, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = BoolToInverseBoolConverter.Instance.Convert(true, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void TestBoolToNotVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, BoolToNotVisibilityConverter.Instance.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, BoolToNotVisibilityConverter.Instance.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Hidden, BoolToNotVisibilityConverter.Instance.Convert(true, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestBoolToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, BoolToVisibilityConverter.Instance.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, BoolToVisibilityConverter.Instance.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Hidden, BoolToVisibilityConverter.Instance.Convert(false, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestDateTimeToStringConverter()
        {
            var sampleDateTime = DateTime.Now;
            Assert.AreEqual(sampleDateTime.ToString(), DateTimeToStringConverter.Instance.Convert(sampleDateTime, typeof(string), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(sampleDateTime.ToString("g"), DateTimeToStringConverter.Instance.Convert(sampleDateTime, typeof(string), "g", CultureInfo.CurrentCulture));
            Assert.AreEqual(null, DateTimeToStringConverter.Instance.Convert(null, typeof(string), null, CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestIEnumerableNotNullOrEmptyToBoolConverter()
        {
            var result1 = IEnumerableNotNullOrEmptyToBoolConverter.Instance.Convert(new[] { new object() }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = IEnumerableNotNullOrEmptyToBoolConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void TestIEnumerableNullOrEmptyToBoolConverter()
        {
            var result1 = IEnumerableNullOrEmptyToBoolConverter.Instance.Convert(new[] { new object() }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsFalse((bool)result1);

            var result2 = IEnumerableNullOrEmptyToBoolConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsTrue((bool)result2);
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
        public void TestStringNotNullOrEmptyToBoolConverter()
        {
            var result1 = StringNotNullOrEmptyToBoolConverter.Instance.Convert("not empty", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = StringNotNullOrEmptyToBoolConverter.Instance.Convert("", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);

            var result3 = StringNotNullOrEmptyToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result3, typeof(bool));
            Assert.IsFalse((bool)result3);
        }

        [TestMethod]
        public void TestStringNotNullOrEmptyToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, StringNotNullOrEmptyToVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, StringNotNullOrEmptyToVisibilityConverter.Instance.Convert("", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, StringNotNullOrEmptyToVisibilityConverter.Instance.Convert("", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, StringNotNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(Visibility.Hidden, StringNotNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestValueNotNullToBoolConverter()
        {
            var result1 = ValueNotNullToBoolConverter.Instance.Convert(new object(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = ValueNotNullToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void TestValueNotNullToVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, ValueNotNullToVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, ValueNotNullToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Hidden, ValueNotNullToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestValueNullToBoolConverter()
        {
            var result1 = ValueNullToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = ValueNullToBoolConverter.Instance.Convert(new object(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void TestVisibilityToInverseVisibilityConverter()
        {
            Assert.AreEqual(Visibility.Visible, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Collapsed, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Visible, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Hidden, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Collapsed, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Visible, typeof(Visibility), null, CultureInfo.CurrentCulture));

            Assert.AreEqual(Visibility.Hidden, VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Visible, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }
    }
}
