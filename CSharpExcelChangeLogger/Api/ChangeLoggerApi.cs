using CSharpExcelChangeLogger.ChangeLogger;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Api
{
    public interface IChangeLoggerApi
    {
        IConfiguration Configuration { get; }

        void SetLogger(ILogger? logger);

        void BeforeChange(IWorksheet sheet, IRange range);

        void AfterChange(IWorksheet sheet, IRange range);
    }

    public class ChangeLoggerApi : IChangeLoggerApi
    {
        private static IChangeLoggerApi? _instance;
        public static IChangeLoggerApi Instance = _instance ?? (_instance = new ChangeLoggerApi());

        public IConfiguration Configuration => StaticChangeLoggerManager.Configuration;

        private ChangeLoggerApi()
        {
        }

        public void SetLogger(ILogger? logger)
        {
            StaticChangeLoggerManager.SetInjectedLogger(logger);
        }

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            throw new NotImplementedException();
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            StaticChangeLoggerManager.AfterChange(sheet, range);
        }
    }
}
