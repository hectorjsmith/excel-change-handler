---
title: Detecting Changes
weight: 10
---

The API class needs to be informed of changes that happen in the Excel workbook. The library intentionally does not hook directly into Excel events for a few reasons:
- This approach makes the code more modular and easier to test
- No dependency on Excel interop

There are two methods that should get called to handle a change. One is to be called before the change, and one after.

{{< highlight csharp "linenos=table" >}}
api.BeforeChange(wrappedSheet, wrappedRange);
api.AfterChange(wrappedSheet, wrappedRange);
{{< /highlight >}}

To avoid having any dependencies on Excel interop libraries, the sheet and range the API class takes are wrappers.
The client code must create instances of the `IWorksheet` and `IRange` interfaces that expose the information the library needs (sheet name, range address, etc).
These instances can then be passed into the before/after methods on the API.

{{< hint info >}}
**NOTE**: The provided sheet and range data objects are internally wrapped in a caching class to improve performance. That means properties on these objects are only read once.
{{< /hint >}}

## Algorithm

The library detects changes by comparing the data provided in the `BeforeChange` and the `AfterChange` methods.

Once the `BeforeChange` method is called, the library will store the following information in memory:
- Sheet name
- Sheet row number
- Sheet column number
- Range address
- Range data (if range size is below memory limit)

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

{{< hint info >}}
**NOTE**: The code in `BeforeChange` and `AfterChange` does not fire if no handlers have been set, or if `api.Configuration.ChangeHandlingEnabled` is set to `false`.
{{< /hint >}}
