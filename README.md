# Wpf.Converters

[![NuGet version](https://img.shields.io/nuget/v/NKristek.Wpf.Converters.svg)](https://www.nuget.org/packages/NKristek.Wpf.Converters/)
[![NuGet downloads](https://img.shields.io/nuget/dt/NKristek.Wpf.Converters.svg)](https://www.nuget.org/packages/NKristek.Wpf.Converters/)
![.NET Framework version: >= 4.0](https://img.shields.io/badge/.NET%20Framework-%3E%3D%204.0-green.svg)
[![GitHub license](https://img.shields.io/github/license/nkristek/Wpf.Converters.svg)](https://github.com/nkristek/Wpf.Converters/blob/master/LICENSE)

A collection of often used converters to write a WPF based application

## Prerequisites

The nuget package and DLL are built using .NET Framework 4.0, but you can compile the library yourself to fit your needs.

## Installation

The recommended way to use this library is via [Nuget](https://www.nuget.org/packages/nkristek.Wpf.Converters/), but you also can either download the DLL from the latest [release](https://github.com/nkristek/Wpf.Converters/releases/latest) or compile it yourself.

## Getting started

Import it via:
```xaml
xmlns:c="clr-namespace:NKristek.Wpf.Converters;assembly=NKristek.Wpf.Converters"
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

You can also use the ```ValueConverterChain``` converter, which executes the given converters in succession. Please note, that the TargetType is only correctly set, when the ```ValueConversionAttribute``` is set on the ```IValueConverter```.

```xaml
<c:ValueConverterChain x:Key="ValueNullToInverseBoolConverter">
    <c:ValueNullToBoolConverter/>
    <c:BoolToInverseBoolConverter/>
</c:ValueConverterChain>
```
The above use of the ```ValueConverterChain``` would be equivalent to the ```ValueNullToInverseBoolConverter```.

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
