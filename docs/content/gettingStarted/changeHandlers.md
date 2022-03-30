---
title: Change Handlers
weight: 30
---

The library can be setup with a number of change handlers.
Change handlers are where all the logic to process a change is located and will generally be specific to the application using this library.

Change handlers can be defined as `System.Action` instances or as classes. If using a class, it must implement the `IChangeHandler` interface.

To add a new change handler:

{{< highlight csharp "linenos=table" >}}
api.AddCustomHandler(...);
{{< /highlight >}}

The library contains a couple of default implementations to get started.
A standard change highlighter and a standard change logger.
These can be created by using the `ChangeHandlerFactory` on the API.

{{< highlight csharp "linenos=table" >}}
api.ChangeHandlerFactory.NewSimpleChangeHighlighter(...);
api.ChangeHandlerFactory.NewSimpleChangeLogger();
{{< /highlight >}}

Handlers are executed in the same order they were added to the API.

Each handler has access to the [memory comparison object]({{< ref "details/comparisonObject" >}}), and the worksheet and range where the change was detected.

---

Here is a simple handler that just logs the location where changes were detected:

{{< highlight csharp "linenos=table" >}}
api.AddCustomHandler((memory, sheet, range) => {
    Console.Log($"Change detected on {sheet.Name} at {range.Address}");
});
{{< /highlight >}}
