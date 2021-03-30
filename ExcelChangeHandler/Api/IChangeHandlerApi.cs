using ExcelChangeHandler.Excel;

namespace ExcelChangeHandler.Api
{
    public interface IChangeHandlerApi : IGenericChangeHandlerApi<IWorksheet, IRange>
    {
    }
}
