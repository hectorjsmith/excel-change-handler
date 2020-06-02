using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Excel.Cached
{
    internal interface ICachedWorksheet : IWorksheet
    {
        IWorksheet RawWorksheet { get; }
    }
}
