using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NKristek.Wpf.Converters.Tests
{
    /// <summary>
    /// Test <see cref="IValueConverter"/> and <see cref="IMultiValueConverter"/> which return a <see cref="bool"/>
    /// </summary>
    [TestClass]
    public class BoolConverterTests
    {
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
        public void TestValueNullToInverseBoolConverter()
        {
            var result1 = ValueNullToInverseBoolConverter.Instance.Convert(new object(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = ValueNullToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void TestStringNullOrEmptyToBoolConverter()
        {
            var result1 = StringNullOrEmptyToBoolConverter.Instance.Convert("not empty", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsFalse((bool)result1);

            var result2 = StringNullOrEmptyToBoolConverter.Instance.Convert("", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsTrue((bool)result2);

            var result3 = StringNullOrEmptyToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result3, typeof(bool));
            Assert.IsTrue((bool)result3);
        }

        [TestMethod]
        public void TestStringNullOrEmptyToInverseBoolConverter()
        {
            var result1 = StringNullOrEmptyToInverseBoolConverter.Instance.Convert("not empty", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = StringNullOrEmptyToInverseBoolConverter.Instance.Convert("", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);

            var result3 = StringNullOrEmptyToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result3, typeof(bool));
            Assert.IsFalse((bool)result3);
        }

        [TestMethod]
        public void TestICollectionNullOrEmptyToBoolConverter()
        {
            var result1 = ICollectionNullOrEmptyToBoolConverter.Instance.Convert(new[] { new object() }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsFalse((bool)result1);

            var result2 = ICollectionNullOrEmptyToBoolConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsTrue((bool)result2);

            var result3 = ICollectionNullOrEmptyToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result3, typeof(bool));
            Assert.IsTrue((bool)result3);
        }

        [TestMethod]
        public void TestICollectionNullOrEmptyToInverseBoolConverter()
        {
            var result1 = ICollectionNullOrEmptyToInverseBoolConverter.Instance.Convert(new[] { new object() }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = ICollectionNullOrEmptyToInverseBoolConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);

            var result3 = ICollectionNullOrEmptyToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result3, typeof(bool));
            Assert.IsFalse((bool)result3);
        }

        [TestMethod]
        public void TestAllBoolToBoolConverter()
        {
            var result1 = AllBoolToBoolConverter.Instance.Convert(new object[] { false, true }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsFalse((bool)result1);

            var result2 = AllBoolToBoolConverter.Instance.Convert(new object[] { true, true }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsTrue((bool)result2);
        }

        [TestMethod]
        public void TestAllBoolToInverseBoolConverter()
        {
            var result1 = AllBoolToInverseBoolConverter.Instance.Convert(new object[] { false, true }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result1, typeof(bool));
            Assert.IsTrue((bool)result1);

            var result2 = AllBoolToInverseBoolConverter.Instance.Convert(new object[] { true, true }, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsInstanceOfType(result2, typeof(bool));
            Assert.IsFalse((bool)result2);
        }

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
        public void TestObjectToStringEqualsParameterToBoolConverter()
        {
            Assert.AreEqual(true, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert("equal", typeof(bool), "equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(true, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(false, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert("not equal1", typeof(bool), "not equal2", CultureInfo.CurrentCulture));
            Assert.AreEqual(false, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert(null, typeof(bool), "not equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(false, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert("not equal", typeof(bool), null, CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestObjectToStringEqualsParameterToInverseBoolConverter()
        {
            Assert.AreEqual(false, ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert("equal", typeof(bool), "equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(false, ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture));
            Assert.AreEqual(true, ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert("not equal1", typeof(bool), "not equal2", CultureInfo.CurrentCulture));
            Assert.AreEqual(true, ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert(null, typeof(bool), "not equal", CultureInfo.CurrentCulture));
            Assert.AreEqual(true, ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert("not equal", typeof(bool), null, CultureInfo.CurrentCulture));
        }
    }
}
