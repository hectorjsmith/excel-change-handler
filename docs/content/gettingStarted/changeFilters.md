---
title: Change Filters
weight: 25
---

This library supports adding change event filters to dynamically filter out change events that should not be processed.

This can be used to support a variety of use-cases, such as:
- Skipping changes to specific sheets or ranges
- Skipping changes that affect a certain number of cells
- Skipping changes that affect sheet dimensions

Filters can be defined either as `System.Func` instances or as classes. If using a class, it must implement the `IChangeEventFilter` interface.

To add a new filter:

{{< highlight csharp "linenos=table" >}}
api.AddChangeEventFilter(...);
{{< /highlight >}}

If multiple filters are added, they are executed in the order they were provided.
If any filter returns `false`, that change event is skipped and no processors are executed.

If no filters were defined, all changes are processed normally.

Each filter is provided with a [memory comparison object]({{< ref "details/comparisonObject" >}}), and the worksheet and range where the change was detected.

---

Here is a simple filter that ignores all changes on certain sheets:

{{< highlight csharp "linenos=table" >}}
api.AddChangeEventFilter((memory, sheet, range) => {
    if (sheet.Name == "Sheet1" || sheet.Name == "Sheet2") {
        return false;
    }
    return true;
});
{{< /highlight >}}
