using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Excel.Cached
{
    internal interface ICachedRange : IRange
    {
        IRange RawRange { get; }
    }
}
