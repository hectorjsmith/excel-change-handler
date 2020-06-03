using CSharpExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Api.Factory
{
    public static class ChangeHandlerApiFactory
    {
        public static IGenericChangeHandlerApi<TWorksheetType, TRangeType> NewGenericApiInstance<TWorksheetType, TRangeType>() where TWorksheetType : IWorksheet where TRangeType : IRange
        {
            return new GenericChangeHandlerApi<TWorksheetType, TRangeType>();
        }

        public static IChangeHandlerApi NewApiInstance()
        {
            return new ChangeHandlerApi();
        }
    }
}
