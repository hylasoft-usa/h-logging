﻿using Hylasoft.Logging.Configuration.Base;

namespace Hylasoft.Logging.Configuration
{
  public interface IFileLogConfig : IHMessageLogConfig
  {
    string LogName { get; }

    int? MaxLogFiles { get; }
  }
}
