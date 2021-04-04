---
title: Logging
weight: 60
---

The library supports injecting a custom logger to log system messages and errors. To inject a logger the client code must create a class that implements the `ILogger` interface and inject it into the main API.

{{< highlight csharp "linenos=table" >}}
class MyLogger : ILogger {
    // ...
}
...
api.SetApplicationLogger(new MyLogger());
{{< /highlight >}}

Note that the logger being used is specific to each API instance.
