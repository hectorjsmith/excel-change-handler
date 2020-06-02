using CSharpExcelChangeHandler.Base;
using CSharpExcelChangeHandler.Excel;
using System;

namespace CSharpExcelChangeHandler.ChangeHandling.Memory
{
    class ChangeHandlerMemory : BaseClass, IChangeHandlerMemory
    {
        private const int ExcelMaxColumnCount = 16384;
        private const int ExcelMaxRowCount = 1048576;
        private const int DefaultMaxRangeSizeForStoringData = 15000;

        public int MaxRangeSizeForStoringData { get; set; } = DefaultMaxRangeSizeForStoringData;
        public string? SheetName { get; private set; }
        public int? SheetRows { get; private set; }
        public int? SheetColumns { get; private set; }
        public string? RangeAddress { get; private set; }
        public string[,]? RangeData { get; private set; }

        public ChangeHandlerMemory(ILoggingManager loggingManager) : base(loggingManager)
        {
        }

        public void UnsetMemory()
        {
            SheetName = null;
            SheetRows = null;
            SheetColumns = null;
            RangeAddress = null;
            RangeData = null;
        }

        public void SetMemory(IWorksheet sheet, IRange range)
        {
            SheetName = sheet.Name;
            SheetRows = sheet.RowCount;
            SheetColumns = sheet.ColumnCount;
            RangeAddress = range.Address;

            int cellCount = range.RowCount * range.ColumnCount;
            if (cellCount <= MaxRangeSizeForStoringData)
            {
                RangeData = TryReadRangeData(sheet, range);
            }
            else
            {
                RangeData = null;
            }
        }

        public IMemoryComparison Compare(IWorksheet sheet, IRange range)
        {
            bool dataMatches = false;
            string[,]? newRangeData = null;

            bool locationMatches = CheckLocationMatches(sheet, range);
            if (locationMatches && RangeData != null && CheckRangeSizeMatchesData(RangeData, range))
            {
                newRangeData = TryReadRangeData(sheet, range);
                dataMatches = newRangeData != null && CompareDataArrays(RangeData, newRangeData);
            }

            return new MemoryComparison(locationMatches: locationMatches,
                                        dataMatches: dataMatches,
                                        isNewRow: CheckForNewRow(sheet, range),
                                        isRowDelete: CheckForRowDelete(sheet, range),
                                        isNewColumn: CheckForNewColumn(sheet, range),
                                        isColumnDelete: CheckForColumnDelete(sheet, range),
                                        rangeAddressBeforeChange: RangeAddress,
                                        rangeAddressAfterChange: range.Address,
                                        sheetNameBeforeChange: SheetName,
                                        sheetNameAfterChange: sheet.Name,
                                        dataBeforeChange: RangeData,
                                        dataAfterChange: newRangeData);
        }

        private string[,]? TryReadRangeData(IWorksheet sheet, IRange range)
        {
            try
            {
                return range.RangeData;
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("Error reading range data into memory. Sheet: {0} ; Range: {1}", sheet.Name, RangeAddress), ex);
                return null;
            }
        }

        private bool CheckLocationMatches(IWorksheet sheet, IRange range)
        {
            return string.Equals(SheetName, sheet.Name, StringComparison.Ordinal)
                && string.Equals(RangeAddress, range.Address, StringComparison.Ordinal);
        }

        private bool CheckRangeSizeMatchesData(string[,] data, IRange range)
        {
            return data.GetLength(0) == range.RowCount && data.GetLength(1) == range.ColumnCount;
        }

        private bool CompareDataArrays(string[,] data1, string[,] data2)
        {
            if (data1.GetLength(0) != data2.GetLength(0) || data1.GetLength(1) != data2.GetLength(1))
            {
                return false;
            }

            for (int row = 0; row < data1.GetLength(0); row++)
            {
                for (int col = 0; col < data1.GetLength(1); col++)
                {
                    if (!string.Equals(data1[row, col], data2[row, col], StringComparison.Ordinal))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckForNewRow(IWorksheet sheet, IRange range)
        {
            if (SheetRows == null || sheet.RowCount <= SheetRows)
            {
                return false;
            }
            return range.ColumnCount == ExcelMaxColumnCount;
        }

        private bool CheckForRowDelete(IWorksheet sheet, IRange range)
        {
            if (SheetRows == null || sheet.RowCount >= SheetRows)
            {
                return false;
            }
            return range.ColumnCount == ExcelMaxColumnCount;
        }

        private bool CheckForNewColumn(IWorksheet sheet, IRange range)
        {
            if (SheetColumns == null || sheet.ColumnCount <= SheetColumns)
            {
                return false;
            }
            return range.RowCount == ExcelMaxRowCount;
        }

        private bool CheckForColumnDelete(IWorksheet sheet, IRange range)
        {
            if (SheetColumns == null || sheet.ColumnCount >= SheetColumns)
            {
                return false;
            }
            return range.RowCount == ExcelMaxRowCount;
        }

    }
}
