using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Logging
{
    /// <summary>
    /// Simple logger interface. An implementation of this interface can be provided to the change handler API to enable logging in the library.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log a debug-level message.
        /// </summary>
        void Debug(string message);

        /// <summary>
        /// Log a info-level message.
        /// </summary>
        void Info(string message);

        /// <summary>
        /// Log an error-level message with an exception.
        /// </summary>
        void Error(string message, Exception ex);
    }
}
