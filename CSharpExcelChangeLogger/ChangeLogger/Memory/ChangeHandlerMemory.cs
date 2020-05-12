using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.Excel;
using System;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class ChangeHandlerMemory : BaseClass, IChangeHandlerMemory
    {
        private const int DefaultMaxRangeSizeForStoringData = 15000;

        private string SheetName { get; set; } = "";
        private string RangeAddress { get; set; } = "";
        private string[,] RangeData { get; set; } = new string[0, 0];

        public int MaxRangeSizeForStoringData { get; set; } = DefaultMaxRangeSizeForStoringData;

        public void SetMemory(IWorksheet sheet, IRange range)
        {
            SheetName = sheet.Name;
            RangeAddress = range.Address;

            int cellCount = range.RowCount * range.ColumnCount;
            if (cellCount <= MaxRangeSizeForStoringData)
            {
                StoreRangeDataInMemory(sheet, range);
            }
        }

        public IMemoryComparison DoesMemoryMatch(IWorksheet sheet, IRange range)
        {
            bool sheetNameMatches = string.Equals(SheetName, sheet.Name, StringComparison.Ordinal);
            bool rangeAddressMatches = string.Equals(RangeAddress, range.Address, StringComparison.Ordinal);

            bool dataMatches = false;
            bool locationMatches = sheetNameMatches && rangeAddressMatches;
            if (locationMatches)
            {
                dataMatches = CheckDataMatches(range);
            }
            return new MemoryComparison(locationMatches, locationMatches && dataMatches);
        }

        private void StoreRangeDataInMemory(IWorksheet sheet, IRange range)
        {
            try
            {
                RangeData = range.RangeData;
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("Error reading range data into memory. Sheet: {0} ; Range: {1}", sheet.Name, RangeAddress), ex);
            }
        }

        private bool CheckDataMatches(IRange range)
        {
            if (RangeData.GetLength(0) != range.RowCount || RangeData.GetLength(1) != range.ColumnCount)
            {
                return false;
            }

            string[,] newRangeData = range.RangeData;
            for (int row = 0; row < RangeData.GetLength(0); row++)
            {
                for (int col = 0; col < RangeData.GetLength(1); col++)
                {
                    if (!string.Equals(RangeData[row, col], newRangeData[row, col], StringComparison.Ordinal))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
