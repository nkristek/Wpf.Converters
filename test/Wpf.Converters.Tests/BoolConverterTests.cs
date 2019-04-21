using System.Globalization;
using System.Linq;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class BoolConverterTests
    {
        [Fact]
        public void TestBoolToInverseBoolConverter()
        {
            var result1 = BoolToInverseBoolConverter.Instance.Convert(false, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = BoolToInverseBoolConverter.Instance.Convert(true, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);
        }

        [Fact]
        public void TestValueNullToBoolConverter()
        {
            var result1 = ValueNullToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = ValueNullToBoolConverter.Instance.Convert(new object(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);
        }

        [Fact]
        public void TestValueNullToInverseBoolConverter()
        {
            var result1 = ValueNullToInverseBoolConverter.Instance.Convert(new object(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = ValueNullToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);
        }

        [Fact]
        public void TestStringNullOrEmptyToBoolConverter()
        {
            var result1 = StringNullOrEmptyToBoolConverter.Instance.Convert("not empty", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.False((bool) result1);

            var result2 = StringNullOrEmptyToBoolConverter.Instance.Convert("", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.True((bool) result2);

            var result3 = StringNullOrEmptyToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result3);
            Assert.True((bool) result3);
        }

        [Fact]
        public void TestStringNullOrEmptyToInverseBoolConverter()
        {
            var result1 = StringNullOrEmptyToInverseBoolConverter.Instance.Convert("not empty", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = StringNullOrEmptyToInverseBoolConverter.Instance.Convert("", typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);

            var result3 = StringNullOrEmptyToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result3);
            Assert.False((bool) result3);
        }

        [Fact]
        public void TestICollectionNullOrEmptyToBoolConverter()
        {
            var result1 = ICollectionNullOrEmptyToBoolConverter.Instance.Convert(new[] {new object()}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.False((bool) result1);

            var result2 = ICollectionNullOrEmptyToBoolConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.True((bool) result2);

            var result3 = ICollectionNullOrEmptyToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result3);
            Assert.True((bool) result3);
        }

        [Fact]
        public void TestICollectionNullOrEmptyToInverseBoolConverter()
        {
            var result1 = ICollectionNullOrEmptyToInverseBoolConverter.Instance.Convert(new[] {new object()}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = ICollectionNullOrEmptyToInverseBoolConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(bool), null,
                CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);

            var result3 = ICollectionNullOrEmptyToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result3);
            Assert.False((bool) result3);
        }

        [Fact]
        public void TestAllBoolToBoolConverter()
        {
            var result1 = AllBoolToBoolConverter.Instance.Convert(new object[] {false, true}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.False((bool) result1);

            var result2 = AllBoolToBoolConverter.Instance.Convert(new object[] {true, true}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.True((bool) result2);
        }

        [Fact]
        public void TestAllBoolToInverseBoolConverter()
        {
            var result1 = AllBoolToInverseBoolConverter.Instance.Convert(new object[] {false, true}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = AllBoolToInverseBoolConverter.Instance.Convert(new object[] {true, true}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);
        }

        [Fact]
        public void TestAnyBoolToBoolConverter()
        {
            var result1 = AnyBoolToBoolConverter.Instance.Convert(new object[] {false, true}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = AnyBoolToBoolConverter.Instance.Convert(new object[] {false, false}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);
        }

        [Fact]
        public void TestAnyBoolToInverseBoolConverter()
        {
            var result1 = AnyBoolToInverseBoolConverter.Instance.Convert(new object[] {false, false}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result1);
            Assert.True((bool) result1);

            var result2 = AnyBoolToInverseBoolConverter.Instance.Convert(new object[] {false, true}, typeof(bool), null, CultureInfo.CurrentCulture);
            Assert.IsType<bool>(result2);
            Assert.False((bool) result2);
        }

        [Fact]
        public void TestObjectToStringEqualsParameterToBoolConverter()
        {
            Assert.Equal(true, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert("equal", typeof(bool), "equal", CultureInfo.CurrentCulture));
            Assert.Equal(true, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture));
            Assert.Equal(false,
                ObjectToStringEqualsParameterToBoolConverter.Instance.Convert("not equal1", typeof(bool), "not equal2", CultureInfo.CurrentCulture));
            Assert.Equal(false, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert(null, typeof(bool), "not equal", CultureInfo.CurrentCulture));
            Assert.Equal(false, ObjectToStringEqualsParameterToBoolConverter.Instance.Convert("not equal", typeof(bool), null, CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestObjectToStringEqualsParameterToInverseBoolConverter()
        {
            Assert.Equal(false,
                ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert("equal", typeof(bool), "equal", CultureInfo.CurrentCulture));
            Assert.Equal(false, ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture));
            Assert.Equal(true,
                ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert("not equal1", typeof(bool), "not equal2", CultureInfo.CurrentCulture));
            Assert.Equal(true,
                ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert(null, typeof(bool), "not equal", CultureInfo.CurrentCulture));
            Assert.Equal(true,
                ObjectToStringEqualsParameterToInverseBoolConverter.Instance.Convert("not equal", typeof(bool), null, CultureInfo.CurrentCulture));
        }
    }
}