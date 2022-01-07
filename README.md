# C# Excel ChangeHandler

C# library to enable detecting and processing changes made on an Excel worksheet.

The goal of this project is to provide a standard way to detect and handle data changes in an excel workbook. This can be used to log or highlight any data changes.

[![documentation](https://img.shields.io/badge/docs-latest-orange)](https://hectorjsmith.gitlab.io/excel-change-handler/)
[![pipeline status](https://gitlab.com/hectorjsmith/excel-change-handler/badges/main/pipeline.svg)](https://gitlab.com/hectorjsmith/excel-change-handler/-/commits/main)
[![project version on nuget](https://badgen.net/nuget/v/ExcelChangeHandler/latest)](https://www.nuget.org/packages/ExcelChangeHandler/)

## How to Use

### API

The library is driven by a main API class. The class has methods that should get triggered before and after a change.

A new instance of the API can be created using the static factory method:

```csharp
IChangeHandlerApi api = ChangeHandlerApiFactory.NewApiInstance();
```

### Detect Changes

The API class needs to be informed of changes that happen in the Excel workbook. The library intentionally does not hook directly into Excel to keep it simple and avoid dependencies on Excel itself.

There are two methods that should get called to handle a change. One is to be called before the change, and one after.

```csharp
api.BeforeChange(wrappedSheet, wrappedRange);
api.AfterChange(wrappedSheet, wrappedRange);
```

To avoid having any dependencies on Excel interop libraries, the sheet and range the API class takes are wrappers.
The client code must create instances of the `IWorksheet` and `IRange` interfaces that expose the information the library needs (sheet name, range address, etc).
These instances can then be passed into the before/after methods on the API.

The provided example application shows an implementation of these wrapper interfaces based on excel ranges and worksheets.
The example application also shows how before and after methods can be hooked into the `SheetSelectionChange` and `SheetChange` events respectively.

**NOTE**: in order to correctly detect changes, the same API instance must be used for both `BeforeChange` and `AfterChange`.
This is because the state memory from before the change is tied to that particular API instance. If a different instance is used, there will be no memory of the data provided in the `BeforeChange` method.

### Handle Changes

The library can be setup with a number of change handlers. Each change handler must implement the `IChangeHandler` interface.

To add a new change handler:

```csharp
api.AddCustomHandler(...);
```

The library contains a couple of default implementations to get started. A standard change highlighter and a standard change logger.
These can be created by using the change handler factory on the API.

```csharp
api.ChangeHandlerFactory.NewSimpleChangeHighlighter(...);
api.ChangeHandlerFactory.NewSimpleChangeLogger();
```

Custom handlers can be crated by extending the `IChangeHandler` interface and implementing the `HandleChange` method.

One of the parameters to the `HandleChange` method is the memory comparison object - `IMemoryComparison`.
This object contains is the result of comparing the data provided to the library in the `BeforeChange` and `AfterChange` methods and holds a lot of useful data about the comparison.

## Design

The Excel event for `SheetChange` is triggered after the change has occured and does not contain information about what the state was **before** the change.
That is why the library has a `BeforeChange` and a `AfterChange` method. It allows the library to keep track of what the data was before the change happened.

With access to the data before and after the change, the library can detect false-changes - the `SheetChange` event can get triggered when the cell didn't actually change (e.g. paste formatting).
It also allows for logging the value before and after a change was made (for example, to generate change logs for peer review).
