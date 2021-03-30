using ExcelChangeHandler.Excel;

namespace ExcelChangeHandler.Api
{
    public class ChangeHandlerApi : GenericChangeHandlerApi<IWorksheet, IRange>, IChangeHandlerApi
    {
    }
}
