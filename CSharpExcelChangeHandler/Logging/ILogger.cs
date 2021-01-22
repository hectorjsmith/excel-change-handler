﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Logging
{
    public interface ILogger
    {
        void Debug(string message);

        void Info(string message);

        void Error(string message, Exception ex);
    }
}