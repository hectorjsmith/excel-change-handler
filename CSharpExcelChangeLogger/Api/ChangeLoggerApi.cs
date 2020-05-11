using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Api
{
    public interface IChangeLoggerApi
    {
        void BeforeChange(IWorksheet sheet, IRange range);

        void AfterChange(IWorksheet sheet, IRange range);
    }

    public class ChangeLoggerApi : IChangeLoggerApi
    {
        private static IChangeLoggerApi? _instance;
        public static IChangeLoggerApi Instance = _instance ?? (_instance = new ChangeLoggerApi());

        private ChangeLoggerApi()
        {
        }

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            throw new NotImplementedException();
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            throw new NotImplementedException();
        }
    }
}
