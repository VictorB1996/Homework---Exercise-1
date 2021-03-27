using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    class DummyDatabaseConnectionException: Exception
    {
        public DummyDatabaseConnectionException(string exceptionMessage): base(exceptionMessage)
        {

        }
    }
}
