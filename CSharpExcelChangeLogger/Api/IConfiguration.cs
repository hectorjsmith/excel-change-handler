using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Api
{
    public interface IConfiguration
    {
        bool ChangeHandlingEnabled { get; set; }
    }
}
