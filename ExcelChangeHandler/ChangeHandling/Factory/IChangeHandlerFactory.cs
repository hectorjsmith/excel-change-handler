using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Factory
{
    /// <summary>
    /// Factory class for the simple change handlers bundled with this library.
    /// These handlers will likely only be used for very simple uses-cases or when trying out the library.
    /// In general, custom <see cref="IChangeHandler{TWorksheetType, TRangeType}"/> instances should be created and used.
    /// </summary>
    public interface IChangeHandlerFactory<TWorksheetType, TRangeType> where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        /// <summary>
        /// Build and return a new simple change highlighter.
        /// </summary>
        /// <param name="highlightColour">Colour to use when highlighting cells. This is the colour that will be provided to the <see cref="IRange.FillRange(int)"/> method.</param>
        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeHighlighter(int highlightColour);

        /// <summary>
        /// Build a new change handler which logs any change to the provided logger interface.
        /// </summary>
        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger(ILogger logger);

        /// <summary>
        /// Build a new change handler which logs any change to the logger provided to the overall change handler API instance.
        /// </summary>
        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger();
    }
}
