using System.Globalization;
using System.Linq;
using System.Windows;
using Xunit;

namespace NKristek.Wpf.Converters.Tests
{
    public class VisibilityConverterTests
    {
        [Fact]
        public void TestVisibilityToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Collapsed, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Collapsed, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Visible,
                VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Hidden, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Hidden, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Visible, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                VisibilityToInverseVisibilityConverter.Instance.Convert(Visibility.Visible, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestBoolToVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible, BoolToVisibilityConverter.Instance.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible, BoolToVisibilityConverter.Instance.Convert(true, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed, BoolToVisibilityConverter.Instance.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden, BoolToVisibilityConverter.Instance.Convert(false, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestBoolToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible, BoolToInverseVisibilityConverter.Instance.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                BoolToInverseVisibilityConverter.Instance.Convert(false, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                BoolToInverseVisibilityConverter.Instance.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                BoolToInverseVisibilityConverter.Instance.Convert(true, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestValueNullToVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible, ValueNullToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ValueNullToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                ValueNullToVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                ValueNullToVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestValueNullToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                ValueNullToInverseVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ValueNullToInverseVisibilityConverter.Instance.Convert(new object(), typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                ValueNullToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                ValueNullToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestStringNullOrEmptyToVisibilityConverter()
        {
            Assert.Equal(Visibility.Collapsed,
                StringNullOrEmptyToVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                StringNullOrEmptyToVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Visible,
                StringNullOrEmptyToVisibilityConverter.Instance.Convert("", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                StringNullOrEmptyToVisibilityConverter.Instance.Convert("", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Visible,
                StringNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                StringNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestStringNullOrEmptyToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("not empty", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("", typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert("", typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                StringNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestICollectionNullOrEmptyToVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Visible,
                ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), "Hidden",
                    CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(new[] {new object()}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                ICollectionNullOrEmptyToVisibilityConverter.Instance.Convert(new[] {new object()}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestICollectionNullOrEmptyToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Collapsed,
                ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), null,
                    CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(Enumerable.Empty<object>(), typeof(Visibility), "Hidden",
                    CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Visible,
                ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(new[] {new object()}, typeof(Visibility), null,
                    CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ICollectionNullOrEmptyToInverseVisibilityConverter.Instance.Convert(new[] {new object()}, typeof(Visibility), "Hidden",
                    CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestAllBoolToVisibilityConverter()
        {
            Assert.Equal(Visibility.Collapsed,
                AllBoolToVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                AllBoolToVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Visible,
                AllBoolToVisibilityConverter.Instance.Convert(new object[] {true, true}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                AllBoolToVisibilityConverter.Instance.Convert(new object[] {true, true}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestAllBoolToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                AllBoolToInverseVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                AllBoolToInverseVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                AllBoolToInverseVisibilityConverter.Instance.Convert(new object[] {true, true}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                AllBoolToInverseVisibilityConverter.Instance.Convert(new object[] {true, true}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestAnyBoolToVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                AnyBoolToVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                AnyBoolToVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                AnyBoolToVisibilityConverter.Instance.Convert(new object[] {false, false}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                AnyBoolToVisibilityConverter.Instance.Convert(new object[] {false, false}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestAnyBoolToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] {false, false}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] {false, false}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));

            Assert.Equal(Visibility.Collapsed,
                AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Hidden,
                AnyBoolToInverseVisibilityConverter.Instance.Convert(new object[] {false, true}, typeof(Visibility), "Hidden", CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestObjectToStringEqualsParameterToVisibilityConverter()
        {
            Assert.Equal(Visibility.Visible,
                ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert("equal", typeof(Visibility), "equal", CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Collapsed,
                ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert("not equal1", typeof(Visibility), "not equal2",
                    CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Collapsed,
                ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert(null, typeof(Visibility), "not equal", CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Collapsed,
                ObjectToStringEqualsParameterToVisibilityConverter.Instance.Convert("not equal", typeof(Visibility), null, CultureInfo.CurrentCulture));
        }

        [Fact]
        public void TestObjectToStringEqualsParameterToInverseVisibilityConverter()
        {
            Assert.Equal(Visibility.Collapsed,
                ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert("equal", typeof(Visibility), "equal", CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Collapsed,
                ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert("not equal1", typeof(Visibility), "not equal2",
                    CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert(null, typeof(Visibility), "not equal", CultureInfo.CurrentCulture));
            Assert.Equal(Visibility.Visible,
                ObjectToStringEqualsParameterToInverseVisibilityConverter.Instance.Convert("not equal", typeof(Visibility), null, CultureInfo.CurrentCulture));
        }
    }
}