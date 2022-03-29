﻿using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Memory
{
    /// <summary>
    /// Set of properties related to the sheet and range affected by a change.
    /// </summary>
    public interface IChangeProperties
    {
        /// <summary>
        /// Name of the sheet where the change took place.
        /// </summary>
        string? SheetName { get; }

        /// <summary>
        /// Number of used columns on the sheet.
        /// </summary>
        int? SheetColumns { get; }

        /// <summary>
        /// Number of used rows on the sheet.
        /// </summary>
        int? SheetRows { get; }

        /// <summary>
        /// String representation of the address where the change took place. This address may be a single-cell refenence, an area, or multiple areas.
        /// </summary>
        string? RangeAddress { get; }

        /// <summary>
        /// Count the number of cells in the changed range.
        /// </summary>
        long? RangeCellCount { get; }

        /// <summary>
        /// Formula data for the range on this sheet.
        /// </summary>
        string[,]? RangeFormulas { get; }
    }
}
