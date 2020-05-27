using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Excel.Cached
{
    internal interface ICachedWorksheet : IWorksheet
    {
        IWorksheet RawWorksheet { get; }
    }
}
