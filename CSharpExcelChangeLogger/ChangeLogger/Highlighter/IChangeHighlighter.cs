﻿using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Highlighter
{
    public interface IChangeHighlighter
    {
        void HighlightRange(IWorksheet sheet, IRange range);
    }
}
