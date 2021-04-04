---
title: Object Types
weight: 40
---

It is possible to create two types of API instances. A standard one or a generic one.

The API allows creating instances that are generic on the sub-type of `IWorksheet` or `IRange` that is used.

A generic API instance can be created using the same static factory:

{{< highlight csharp "linenos=table" >}}
IGenericChangeHandlerApi<MySheet, MyRange> api = ChangeHandlerApiFactory.NewGenericApiInstance<MySheet, MyRange>();
{{< /highlight >}}

The `IChangeHandler` interface is also generic on the type of `IWorksheet` and `IRange` used. When adding a new handler to the API instance, the exact same type of worksheet and range must be used.
This is an example from one of the unit tests:

{{< highlight csharp "linenos=table" >}}
IGenericChangeHandlerApi<SimpleMockSheet, SimpleMockRange> api = ChangeHandlerApiFactory.NewGenericApiInstance<SimpleMockSheet, SimpleMockRange>();
GenericMockChangeHandler<SimpleMockSheet, SimpleMockRange> handler = new GenericMockChangeHandler<SimpleMockSheet, SimpleMockRange>();
{{< /highlight >}}

This also means that when the handler is called, it has access to the exact type of object used to call the `BeforeChange` and `AfterChange` methods.
This makes it easy to propagate custom classes down to the change handlers.
