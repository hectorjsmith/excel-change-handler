---
title: Overview
weight: 10
---

![Diagram showing an overview of how the library works](img/overview.png)

- (1): Each time a cell is selected in Excel, the `SheetSelectionChange` Excel event is fired. This gets forwarded to the library through the `BeforeChange` method.
- (2): When a cell is changed, the `SheetChange` Excel event is fired. This gets forwarded to the library through the `AfterChange` method.
- (3): The library checks if the data provided between `(1)` and `(2)` is a valid change, if so, the library calls all provided change handlers.

The Excel event for `SheetChange` is triggered after the change has occured and does not contain information about what the state was **before** the change.
That is why the library has a `BeforeChange` and a `AfterChange` method. It allows the library to keep track of what the data was before the change happened.

With access to the data before and after the change, the library can detect false-changes - the `SheetChange` event can get triggered when the cell didn't actually change (e.g. paste formatting).
It also allows for logging changes made to a worksheet with the before and after values (e.g. for peer review).
