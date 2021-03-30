using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Memory
{
    /// <summary>
    /// Output data from comparing the range data before and after a change.
    /// </summary>
    public interface IMemoryComparison
    {
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
        /// True if the address of the changed range matches the address of the range saved to memory.
        /// </summary>
        bool LocationMatches { get; }

        /// <summary>
        /// 'LocationMatches' and 'DataMatches'
        /// </summary>
        bool LocationMatchesAndDataMatches { get; }

        /// <summary>
        /// Data saved to memory before the change occurred. Will be null if no data was stored in memory.
        /// Will only include data stored in memory before the change was triggered.
        /// </summary>
        IChangeProperties? PropertiesBeforeChange { get; }

        /// <summary>
        /// Change properties read from the modified range. The formulas for the changed cell will only be read into memory if necessary, so may be null.
        /// Range formulas will be null if:
        /// <list type="">
        /// <item>- Saved range address is different from changed range address</item>
        /// <item>- Saved range has a different dimension to the changed range</item>
        /// <item>- No saved data from before change</item>
        /// <item>- Size of changed range exceeds the cut-off threshold</item>
        /// </list>
        /// </summary>
        IChangeProperties PropertiesAfterChange { get; }

    }
}
