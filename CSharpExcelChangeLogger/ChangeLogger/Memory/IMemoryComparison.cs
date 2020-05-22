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

        /// <summary>
        /// Returns true if the change logger detected that the latest change was a new row. False otherwise.
        /// </summary>
        bool IsNewRow { get; }

        /// <summary>
        /// Returns true if the change logger detected that the latest change was a row deletion. False otherwise.
        /// </summary>
        bool IsRowDelete { get; }

        /// <summary>
        /// Returns true if the change logger detected that the latest change was a new column. False otherwise.
        /// </summary>
        bool IsNewColumn { get; }

        /// <summary>
        /// Returns true if the change logger detected that the latest change was a column deletion. False otherwise.
        /// </summary>
        bool IsColumnDelete { get; }

        /// <summary>
        /// 'LocationMatches' and 'DataMatches'
        /// </summary>
        bool LocationMatchesAndDataMatches { get; }

        /// <summary>
        /// Address of the range stored in memory before the change occurred.
        /// </summary>
        string? RangeAddressBeforeChange { get; }

        /// <summary>
        /// Address of the range where the change occurred.
        /// </summary>
        string? RangeAddressAfterChange { get; }

        /// <summary>
        /// Name of the sheet data stored in memory before the change occurred.
        /// </summary>
        string? SheetNameBeforeChange { get; }

        /// <summary>
        /// Name of the sheet where the change occurred.
        /// </summary>
        string? SheetNameAfterChange { get; }

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
