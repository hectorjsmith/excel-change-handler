---
title: API
weight: 20
---

The library is driven by a main API class.

A new instance of the API can be created using the static factory method.

{{< highlight csharp "linenos=table" >}}
IChangeHandlerApi api = ChangeHandlerApiFactory.NewApiInstance();
{{< /highlight >}}

{{< hint warning >}}
**NOTE**: Each instance of the API class is separate and no memory is shared between them.
The same instance should always be used to track changes.
{{< /hint >}}
