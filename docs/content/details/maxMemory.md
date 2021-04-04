---
title: Max Memory Limit
weight: 30
---

To avoid memory issues when tracking changes on very large sheets/ranges, this library has a configured memory limit.
If the number of cells provided in the `BeforeChange` method is over the max memory value, the range data will not be stored.
In this case the library will not be able to accurately detect exactly which cells were changed in the changed range.

This limit can be changed through the `api.Configuration` property. By default, it is set to 250,000.
