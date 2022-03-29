using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Api.Factory
{
    /// <summary>
    /// Class responsible for building new instances of the <see cref="IChangeHandlerApi"/> interface.
    /// </summary>
    public static class ChangeHandlerApiFactory
    {
        /// <summary>
        /// Build a new instance of the <see cref="IChangeHandlerApi"/> interface with custom sheet and range types.
        /// </summary>
        /// <typeparam name="TWorksheetType">Type of worksheet to be forwarded down to change handlers.</typeparam>
        /// <typeparam name="TRangeType">Type of range to be forwarded down to change handlers.</typeparam>
        public static IGenericChangeHandlerApi<TWorksheetType, TRangeType> NewGenericApiInstance<TWorksheetType, TRangeType>() where TWorksheetType : IWorksheet where TRangeType : IRange
        {
            return new GenericChangeHandlerApi<TWorksheetType, TRangeType>();
        }

        /// <summary>
        /// Build a new instance of the <see cref="IChangeHandlerApi"/> interface with broad types for worksheet and ranges (<see cref="IWorksheet"/> and <see cref="IRange"/>).
        /// </summary>
        public static IChangeHandlerApi NewApiInstance()
        {
            return new ChangeHandlerApi();
        }
    }
}
