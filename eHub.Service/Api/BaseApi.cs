using System;
using System.Collections.Generic;
using System.Text;

namespace eHub.Common.Api
{
    public class BaseApi
    {
        public void HandleMessages(List<string> messages)
        {
            #region Temporary
            foreach (var m in messages)
            {
                Console.WriteLine(m);
            }
            #endregion

        }
    }
}
