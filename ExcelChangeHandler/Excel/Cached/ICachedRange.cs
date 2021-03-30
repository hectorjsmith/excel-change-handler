using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Excel.Cached
{
    internal interface ICachedRange : IRange
    {
        IRange RawRange { get; }
    }
}
