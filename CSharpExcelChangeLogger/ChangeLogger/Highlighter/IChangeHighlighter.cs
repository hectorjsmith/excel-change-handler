﻿using CSharpExcelChangeLogger.ChangeLogger.Processor;
using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Highlighter
{
    public interface IChangeHighlighter
    {
        void HighlightRange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range);
    }
}
