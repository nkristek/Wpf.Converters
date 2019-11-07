# Wpf.Converters

[![CI Status](https://github.com/nkristek/Wpf.Converters/workflows/CI/badge.svg)](https://github.com/nkristek/Wpf.Converters/actions)
[![NuGet version](https://img.shields.io/nuget/v/NKristek.Wpf.Converters.svg)](https://www.nuget.org/packages/NKristek.Wpf.Converters/)
![.NET Framework version: >= 3.5](https://img.shields.io/badge/.NET%20Framework-%3E%3D%203.5-green.svg)
[![GitHub license](https://img.shields.io/github/license/nkristek/Wpf.Converters.svg)](https://github.com/nkristek/Wpf.Converters/blob/master/LICENSE)

This library contains a collection of often used converters to write a WPF based application.

## Installation

The recommended way to use this library is via [Nuget](https://www.nuget.org/packages/nkristek.Wpf.Converters/).

Currently supported frameworks:
- .NET Framework 3.5 or higher
- .NET Core 3.0 or higher

## Getting started

Import it via:
```xaml
xmlns:c="clr-namespace:NKristek.Wpf.Converters;assembly=NKristek.Wpf.Converters"
```

You can use a converter from this library either by using the MarkupExtension*:
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

You can also use the ```ValueConverterChain``` converter*, which executes the given converters in succession. Please note, that the TargetType is only correctly set, when the ```ValueConversionAttribute``` is set on the ```IValueConverter```.

```xaml
<c:ValueConverterChain x:Key="ValueNullToInverseBoolConverter">
    <c:ValueNullToBoolConverter/>
    <c:BoolToInverseBoolConverter/>
</c:ValueConverterChain>
```
The above use of the ```ValueConverterChain``` would be equivalent to the ```ValueNullToInverseBoolConverter```.

*: Only available if target framework is >= .NET 4.0.

## Overview

Bool:
- BoolToInverseBoolConverter
- ValueNullToBoolConverter
- ValueNullToInverseBoolConverter
- StringNullOrEmptyToBoolConverter
- StringNullOrEmptyToInverseBoolConverter
- ICollectionNullOrEmptyToBoolConverter
- ICollectionNullOrEmptyToInverseBoolConverter
- AllBoolToBoolConverter
- AllBoolToInverseBoolConverter
- AnyBoolToBoolConverter
- AnyBoolToInverseBoolConverter
- ObjectToStringEqualsParameterToBoolConverter
- ObjectToStringEqualsParameterToInverseBoolConverter

Visibility:
- VisibilityToInverseVisibilityConverter
- BoolToVisibilityConverter
- BoolToInverseVisibilityConverter
- ValueNullToVisibilityConverter
- ValueNullToInverseVisibilityConverter
- StringNullOrEmptyToVisibilityConverter
- StringNullOrEmptyToInverseVisibilityConverter
- ICollectionNullOrEmptyToVisibilityConverter
- ICollectionNullOrEmptyToInverseVisibilityConverter
- AllBoolToVisibilityConverter
- AllBoolToInverseVisibilityConverter
- AnyBoolToVisibilityConverter
- AnyBoolToInverseVisibilityConverter
- ObjectToStringEqualsParameterToVisibilityConverter
- ObjectToStringEqualsParameterToInverseVisibilityConverter

Other:
- DateTimeToStringConverter
- ValueConverterChain

## Contribution

If you find a bug feel free to open an issue. Contributions are also appreciated.
