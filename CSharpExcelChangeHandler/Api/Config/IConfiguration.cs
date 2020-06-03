using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Api.Config
{
    public interface IConfiguration
    {
        /// <summary>
        /// Global flag to enable/disable change detection.
        /// If this field is set to false, no data is saved to memory in the BeforeChange method and no handlers are called in the AfterChange method.
        /// </summary>
        bool ChangeHandlingEnabled { get; set; }
    }
}
