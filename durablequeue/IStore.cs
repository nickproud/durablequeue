using System;
using System.Collections.Generic;
using System.Text;

namespace durablequeue
{
    public interface IStore
    {
        void Flush();
        void Insert(string itemJson);
        List<string> RetrieveAll();
    }
}
