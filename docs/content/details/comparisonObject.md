---
title: Comparison Object
weight: 20
---

The `IMemoryComparison` object provided to the change handlers will include the results of this comparison as well as information about what data was in memory before the change:

{{< highlight csharp "linenos=table" >}}
public bool HasSheetSizeChanged { get; }
public bool IsNewRow { get; }
public bool IsRowDelete { get; }
public bool IsNewColumn { get; }
public bool IsColumnDelete { get; }
public bool LocationMatches { get; }
public bool LocationMatchesAndDataMatches { get; }
IChangeProperties? PropertiesBeforeChange { get; }
IChangeProperties PropertiesAfterChange { get; }
{{< /highlight >}}

The `PropertiesBeforeChange` property will be null if no memory was set before the change was recorded (i.e. the `BeforeChange` method was not called). The `PropertiesAfterChange` will never be null and include data known about the new state of the range.

All properties on the `IChangeProperties` interface are nullable and will only be populated if known.

{{< highlight csharp "linenos=table" >}}
string? SheetName { get; }
int? SheetColumns { get; }
int? SheetRows { get; }
string? RangeAddress { get; }
long? RangeCellCount { get; }
string[,]? RangeFormulas { get; }
{{< /highlight >}}

{{< hint info >}}
**NOTE**: The range formula data before and after change may be null, this data is only read when necessary to improve performance.
{{< /hint >}}
