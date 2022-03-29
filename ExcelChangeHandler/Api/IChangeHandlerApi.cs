using ExcelChangeHandler.Excel;

namespace ExcelChangeHandler.Api
{
    /// <summary>
    /// Implementation of the <see cref="GenericChangeHandlerApi{IWorksheet,IRange}"/> generic class with non-generic types.
    /// </summary>
    public interface IChangeHandlerApi : IGenericChangeHandlerApi<IWorksheet, IRange>
    {
    }
}
