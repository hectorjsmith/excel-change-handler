﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLogger.Excel;
using ExampleVstoProject.Wrapper;
using System.Windows.Forms;

namespace ExampleVstoProject
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Excel.Application application = Globals.ThisAddIn.Application;
            // Use the Application level events instead of the workbook events - workbook events often get disabled for no apparent reason
            application.SheetSelectionChange += Application_SheetSelectionChange;
            application.SheetChange += Application_SheetChange;

            IChangeLoggerApi api = ChangeLoggerApi.Instance;
            api.SetCustomHighlighter(api.NewSimpleChangeHighlighter(16776960));
        }

        private void Application_SheetChange(object sheet, Excel.Range range)
        {
            try
            {
                Excel.Worksheet worksheet = (Excel.Worksheet)sheet;
                IWorksheet wrappedSheet = new ExcelWorksheetWrapper(worksheet);
                IRange wrappedRange = new ExcelRangeWrapper(range);
                ChangeLoggerApi.Instance.AfterChange(wrappedSheet, wrappedRange);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Application_SheetSelectionChange(object sheet, Excel.Range range)
        {
            try
            {
                Excel.Worksheet worksheet = (Excel.Worksheet)sheet;
                IWorksheet wrappedSheet = new ExcelWorksheetWrapper(worksheet);
                IRange wrappedRange = new ExcelRangeWrapper(range);
                ChangeLoggerApi.Instance.BeforeChange(wrappedSheet, wrappedRange);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
