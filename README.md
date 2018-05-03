# Wpf.Converters
A collection of often used converters to write a WPF based application

## Prerequisites

The nuget package and [DLL](https://github.com/nkristek/Wpf.Converters/releases) are built using .NET 4.7, but you can compile the library yourself to fit your needs.

## Installation

The recommended way to use this library is via [Nuget](https://www.nuget.org/packages/nkristek.Wpf.Converters/), but you also can either download the DLL from the latest [release](https://github.com/nkristek/Wpf.Converters/releases) or compile it yourself.

## How to use

Import it via:
```xaml
xmlns:c="clr-namespace:nkristek.Wpf.Converters;assembly=nkristek.Wpf.Converters"
```

You can use a converter from this library either by using the MarkupExtension:
```xaml
<Label Content="{Binding Value}"
       Visibility="{Binding Value, Converter={c:ValueNotNullToVisibilityConverter}}" />
```
or static instance:
```xaml
<Label Content="{Binding Value}"
       Visibility="{Binding Value, Converter={x:Static c:ValueNotNullToVisibilityConverter.Instance}}" />
```
or of course create instances in the views:
```xaml
<Window.Resources>
    <c:ValueNotNullToVisibilityConverter x:Key="ValueNotNullToVisibilityConverter" />
</Window.Resources>

<Label Content="{Binding Value}"
       Visibility="{Binding Value, Converter={StaticResource ValueNotNullToVisibilityConverter}}" />
```

## Overview

- AnyBoolToBoolConverter
- AnyBoolToInverseBoolConverter
- AnyBoolToVisibilityConverter
- BoolToInverseBoolConverter
- BoolToNotVisibilityConverter
- BoolToVisibilityConverter
- DateTimeToStringConverter
- IEnumerableNotNullOrEmptyToBoolConverter
- IEnumerableNullOrEmptyToBoolConverter
- ObjectToStringEqualsParameterToVisibilityConverter
- StringNotNullOrEmptyToBoolConverter
- StringNotNullOrEmptyToVisibilityConverter
- ValueNotNullToBoolConverter
- ValueNotNullToVisibilityConverter
- ValueNullToBoolConverter
- VisibilityToInverseVisibilityConverter

## Contribution

If you find a bug feel free to open an issue. Contributions are also appreciated.
