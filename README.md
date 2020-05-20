# C# Excel ChangeLogger

C# library to enable logging and highlighting changes made on an Excel worksheet.

The goal of this project is to provide a standard way to detect and handle data changes in an excel workbook.

[![pipeline status](https://gitlab.com/hectorjsmith/csharp-excel-changelogger/badges/master/pipeline.svg)](https://gitlab.com/hectorjsmith/csharp-excel-changelogger/-/commits/master)

## How to Use

*See the included example project to see it in action*

### API

The library is driven through a singleton API class. The class has methods that should get triggered before and after a change.

The API instance can be accessed as so:

```csharp
IChangeLoggerApi api = ChangeLoggerApi.Instance;
```

### Detect Changes

The API class needs to be informed of changes that happen in the Excel workbook. The library intentionally does not hook directly into Excel events for a few reasons:
- This approach makes the code more modular and easier to test
- No dependency on Excel interop

There are two methods that should get called to handle a change. One is to be called before the change, and one after.

```csharp
ChangeLoggerApi.Instance.BeforeChange(wrappedSheet, wrappedRange);
ChangeLoggerApi.Instance.AfterChange(wrappedSheet, wrappedRange);
```

To avoid having any dependencies on Excel interop libraries, the sheet and range the API class takes are wrappers.
The client code must create instances of the `IWorksheet` and `IRange` interfaces that expose the information the library needs (sheet name, range address, etc).
These instances can then be passed into the before/after methods on the API.

The provided example application shows an implementation of these wrapper interfaces based on excel ranges and worksheets.
The example application also shows how before and after methods can be hooked into the `SheetSelectionChange` and `SheetChange` events respectively.

### Handle Changes

The library can be setup with a number of change handlers. Each change handler must implement the `IChangeHandler` interface.

To add a new change handler:

```csharp
ChangeLoggerApi.Instance.AddCustomHandler(...);
```

The library contains a couple of default implementations to get started. A standard change highlighter and a standard change logger.
These can be created by using the change handler factory on the API.

```csharp
ChangeLoggerApi.Instance.ChangeHandlerFactory.NewSimpleChangeHighlighter(...);
ChangeLoggerApi.Instance.ChangeHandlerFactory.NewSimpleChangeLogger();
```

Custom handlers can be crated by extending the `IChangeHandler` interface and implementing the `HandleChange` method.

One of the parameters to the `HandleChange` method is the memory comparison object - `IMemoryComparison`.
This object contains is the result of comparing the data provided to the library in the `BeforeChange` and `AfterChange` methods and holds a lot of useful data about the comparison.

### Configuration

The library configuration object can be accessed through the API class:

```csharp
ChangeLoggerApi.Instance.Configuration
```

---

## Design

The Excel event for `SheetChange` is triggered after the change has occured and does not contain information about what the state was **before** the change.
That is why the library has a `BeforeChange` and a `AfterChange` method. It allows the library to keep track of what the data was before the change happened.

With access to the data before and after the change, the library can detect false-changes - the `SheetChange` event can get triggered when the cell didn't actually change (e.g. paste formatting).
It also allows for logging changes made to a worksheet with the before and after values (e.g. for peer review).

### How Changes are Detected

The library detects changes by comparing the data provided in the `BeforeChange` and the `AfterChange` methods.

Once the `BeforeChange` method is called, the library will store the following information in memory:
- Sheet name
- Sheet row number
- Sheet column number
- Range address
- Range data (up to 15,000 cells)

When the `AfterChange` method is called, the data in memory is compared to the data provided:

- If memory is blank, consider a valid change
- Check range locations (sheet name + range address)
  - If location does not match, valid change
- Check range dimensions
  - If range dimensions do not match, valid change
- Compare data
  - If data in memory is blank, valid change
  - Read data from input range and compare to data in memory
    - If data is different, valid change
- If everything matches, no change - handles do not get called

**NOTE:** The code in `BeforeChange` and `AfterChange` does not fire if no handlers have been set, or if `ChangeLoggerApi.Instance.Configuration.ChangeHandlingEnabled` is set to `false`.

The `IMemoryComparison` object provided to the change handlers will include the results of this comparison:

```csharp
public bool LocationMatches { get; }
public bool DataMatches { get; }
public bool IsNewRow { get; }
public bool IsRowDelete { get; }
public bool IsNewColumn { get; }
public bool IsColumnDelete { get; }
public bool LocationMatchesAndDataMatches { get; }
public string[,]? DataBeforeChange { get; }
public string[,]? DataAfterChange { get; }
```

**NOTE:** The data before and after change may be null. To help improve performance data will only be loaded into memory if necessary.
