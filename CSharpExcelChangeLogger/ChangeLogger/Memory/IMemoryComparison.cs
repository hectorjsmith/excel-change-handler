using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    /// <summary>
    /// Output data from comparing the range data before and after a change.
    /// </summary>
    public interface IMemoryComparison
    {
        /// <summary>
        /// True if the address of the changed range matches the address of the range saved to memory.
        /// </summary>
        bool LocationMatches { get; }

        /// <summary>
        /// True if the data in the changed range is an exact match to the range data saved to memory.
        /// Will always be false if the 'LocationMatches' field is false since there is no point calculating it.
        /// </summary>
        bool DataMatches { get; }

        bool IsNewRow { get; }

        bool IsRowDelete { get; }

        bool IsNewColumn { get; }

        bool IsColumnDelete { get; }

        /// <summary>
        /// 'LocationMatches' and 'DataMatches'
        /// </summary>
        bool LocationMatchesAndDataMatches { get; }

        /// <summary>
        /// Data saved to memory before the change occurred. Will be null if no data was stored in memory.
        /// </summary>
        string[,]? DataBeforeChange { get; }

        /// <summary>
        /// Data read from the changed range. Data is loaded only when absolutely necessary, so may be null.
        /// Data will be null if:
        /// <list type="">
        /// <item>- Saved range address is different from changed range address</item>
        /// <item>- Saved range has a different dimension to the changed range</item>
        /// <item>- No saved data from before change</item>
        /// <item>- Size of changed range exceeds the cut-off threshold</item>
        /// </list>
        /// </summary>
        string[,]? DataAfterChange { get; }
    }
}
