using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Excel.Exception
{
    public class ExcelDataAccessException : InvalidOperationException
    {
        internal ExcelDataAccessException(string paramName, System.Exception innerException)
            : base($"Error accessing '{paramName}' field through provided wrapper implementation", innerException)
        {
        }
    }
}
