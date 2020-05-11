using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLogger.Excel;
using ExampleVstoProject.Wrapper;

namespace ExampleVstoProject
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Globals.ThisAddIn.Application.WorkbookOpen += Application_WorkbookOpen;
            ((Excel.AppEvents_Event)Globals.ThisAddIn.Application).NewWorkbook += Application_WorkbookOpen;
            ChangeLoggerApi.Instance.Configuration.CellHighlightRgbColour = 16776960;
        }

        private void Application_WorkbookOpen(Excel.Workbook workbook)
        {
            workbook.SheetSelectionChange += Workbook_SheetSelectionChange;
            workbook.SheetChange += Workbook_SheetChange;
        }

        private void Workbook_SheetChange(object sheet, Excel.Range range)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet) sheet;
            IWorksheet wrappedSheet = new ExcelWorksheetWrapper(worksheet);
            IRange wrappedRange = new ExcelRangeWrapper(range);
            ChangeLoggerApi.Instance.AfterChange(wrappedSheet, wrappedRange);
        }

        private void Workbook_SheetSelectionChange(object sheet, Excel.Range range)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)sheet;
            IWorksheet wrappedSheet = new ExcelWorksheetWrapper(worksheet);
            IRange wrappedRange = new ExcelRangeWrapper(range);
            ChangeLoggerApi.Instance.BeforeChange(wrappedSheet, wrappedRange);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
