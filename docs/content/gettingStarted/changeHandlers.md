---
title: Change Handlers
weight: 30
---

The library can be setup with a number of change handlers. Each change handler must implement the `IChangeHandler` interface.

To add a new change handler:

{{< highlight csharp "linenos=table" >}}
api.AddCustomHandler(...);
{{< /highlight >}}

The library contains a couple of default implementations to get started. A standard change highlighter and a standard change logger.
These can be created by using the change handler factory on the API.

{{< highlight csharp "linenos=table" >}}
api.ChangeHandlerFactory.NewSimpleChangeHighlighter(...);
api.ChangeHandlerFactory.NewSimpleChangeLogger();
{{< /highlight >}}

Custom handlers can be crated by extending the `IChangeHandler` interface and implementing the `HandleChange` method.
