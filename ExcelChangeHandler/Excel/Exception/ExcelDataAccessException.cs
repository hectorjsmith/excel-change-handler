using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Excel.Exception
{
    /// <summary>
    /// Wrapper exception that wraps around any exceptions thrown when accessing Excel data through provided implementations of <see cref="IWorksheet"/> and <see cref="IRange"/>.
    /// </summary>
    public class ExcelDataAccessException : InvalidOperationException
    {
        internal ExcelDataAccessException(string paramName, System.Exception innerException)
            : base($"Error accessing '{paramName}' field through provided wrapper implementation", innerException)
        {
        }
    }
}
