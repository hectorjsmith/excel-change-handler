using CSharpExcelChangeHandler.Excel;

namespace CSharpExcelChangeHandler.Api
{
    public interface IChangeHandlerApi : IGenericChangeHandlerApi<IWorksheet, IRange>
    {
    }
}
