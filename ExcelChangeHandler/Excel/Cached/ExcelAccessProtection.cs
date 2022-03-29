using ExcelChangeHandler.Excel.Exception;
using System;

namespace ExcelChangeHandler.Excel.Cached
{
    internal class ExcelAccessProtection
    {
        public static T ReadDataAndWrapException<T>(string paramName, Func<T> getter)
        {
            try
            {
                return getter();
            }
            catch (System.Exception ex)
            {
                throw new ExcelDataAccessException(paramName, ex);
            }
        }

        public static void RunActionAndWrapException(string actionName, Action action)
        {
            try
            {
                action();
            }
            catch (System.Exception ex)
            {
                throw new ExcelDataAccessException(actionName, ex);
            }
        }
    }
}
