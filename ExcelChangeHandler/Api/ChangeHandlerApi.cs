using ExcelChangeHandler.Excel;

namespace ExcelChangeHandler.Api
{
    internal class ChangeHandlerApi : GenericChangeHandlerApi<IWorksheet, IRange>, IChangeHandlerApi
    {
    }
}
