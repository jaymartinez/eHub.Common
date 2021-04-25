using System;
using System.Collections.Generic;
using System.Text;

namespace eHub.Common.Services
{
    public abstract class ServiceBase
    {
        public abstract void HandleMessages(List<string> messages);
    }
}
