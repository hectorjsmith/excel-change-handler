using CSharpExcelChangeHandler.Api.Config;
using CSharpExcelChangeHandler.ChangeHandling.Factory;
using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandler.Logging;

namespace CSharpExcelChangeHandler.Api
{
    public interface IGenericChangeHandlerApi<TWorksheetType, TRangeType> 
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        /// <summary>
        /// API configuration object.
        /// </summary>
        IConfiguration Configuration { get; }

        /// <summary>
        /// Factory to build common change handlers.
        /// </summary>
        IChangeHandlerFactory<TWorksheetType, TRangeType> ChangeHandlerFactory { get; }

        /// <summary>
        /// Set the logger used to log system messages and errors in the API code.
        /// </summary>
        void SetApplicationLogger(ILogger? logger);

        /// <summary>
        /// Hook to prepare the API code for an upcoming change. This method will set the internal memory of the library to the sheet and range provided.
        /// </summary>
        void BeforeChange(TWorksheetType sheet, TRangeType range);

        /// <summary>
        /// Hook to process a cell change. This method will compare the internal memory against the sheet and range provided to detect changes.
        /// If a change is detected, all registered change handlers will be invoked.
        /// </summary>
        void AfterChange(TWorksheetType sheet, TRangeType range);

        /// <summary>
        /// Clear all registered change handlers. When no handlers are defined the library will not do anything.
        /// </summary>
        void ClearAllHandlers();

        /// <summary>
        /// Add the set of default change handlers defined in the library. By default the library adds a simple change highlighter handler that changes the background colour of changed ranges.
        /// </summary>
        void AddDefaultHandlers();

        /// <summary>
        /// Add a custom change handler. This handler will be called when a change is detected (using the BeforeChange and AfterChange methods).
        /// No ordering of change handlers is guaranteed, handlers are called in an arbitrary order.
        /// </summary>
        void AddCustomHandler(IChangeHandler<TWorksheetType, TRangeType> handler);
    }
}
